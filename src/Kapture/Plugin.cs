using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using ACT_FFXIV.Aetherbridge;
using ACT_FFXIV.Aetherbridge.Updater;
using ACT_FFXIV_Kapture.Config;
using ACT_FFXIV_Kapture.Config.Enum;
using ACT_FFXIV_Kapture.Config.Model;
using ACT_FFXIV_Kapture.Model;
using ACT_FFXIV_Kapture.Resource;
using Advanced_Combat_Tracker;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RainbowMage.OverlayPlugin;
using Configuration = ACT_FFXIV_Kapture.Config.Model.Config;
using EventHandler = ACT_FFXIV.Aetherbridge.EventHandler;
using Timer = System.Timers.Timer;

// ReSharper disable ConvertIfStatementToSwitchStatement
#pragma warning disable 4014

namespace ACT_FFXIV_Kapture.Plugin
{
	// ReSharper disable once UnusedMember.Global
	public class Plugin : IActPluginV1, IOverlayAddonV2
	{
		private static readonly object Lock = new object();
		private static readonly object DiscordLock = new object();
		private static readonly object HTTPLock = new object();
		private BasePresenter _basePresenter;
		private Configuration _configuration;
		private Queue<string> _discordQueue;
		private Timer _discordTimer;
		private HttpClient _httpClient;
		private Queue<string> _httpQueue;
		private Timer _httpTimer;
		private JsonSerializerSettings _jsonSerializerSettings;
		private KaptureConfig _kaptureConfig;
		private KaptureData _kaptureData;
		private KaptureGUILogger _kaptureGuiLogger;
		private string _kaptureVersion;
		private Language _language;
		private Label _pluginStatus;
		private TabPage _tabPage;
		private PluginUpdaterSettings _updaterSettings;

		public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
		{
			try
			{
				InitKaptureBridge();
				SetupLogger();
				SetLanguage();
				LoadSettings();
				CheckForFreshInstall();
				SetupKaptureService();
				CreateLogDirectory();
				SetupDiscord();
				SetupHTTP();
				SetupJsonSerializer();
				SubscribeToLogLineEvents();
				SetupUI(pluginScreenSpace, pluginStatusText);
				LoadLocalizedData();
				CheckForUpdates();
			}
			catch (Exception ex)
			{
				_kaptureGuiLogger?.Error("Failed to initialize plugin.", ex);
				MessageBox.Show(PluginConstants.CriticalFailureMsg + Environment.NewLine +
				                PluginConstants.ErrorPrefix + ex.StackTrace);
				_pluginStatus.Text = PluginConstants.PluginStatusDisabledFailure;
				ActGlobals.oFormActMain.PluginGetSelfData(this).cbEnabled.Checked = false;
			}
		}

		public void DeInitPlugin()
		{
			_discordTimer.Close();
			_discordQueue.Clear();
			_discordTimer.Elapsed -= SendToDiscord;
			_httpTimer.Close();
			_httpQueue.Clear();
			_httpTimer.Elapsed -= SendToHTTP;
			_kaptureConfig.ConfigManager.SaveSettings();
			_kaptureData.LogLineCaptured -= HandleLootEvent;
			_kaptureData.DeInit();
			_kaptureConfig?.DeInit();
			_httpClient.Dispose();
			_pluginStatus.Text = PluginConstants.PluginStatusDisabled;
			_basePresenter.DeInit();
		}

		public void Init()
		{
			SetupEventSource();
		}

		private void SetupUI(TabPage pluginScreenSpace, Label pluginStatusText)
		{
			_tabPage = pluginScreenSpace;
			_pluginStatus = pluginStatusText;
			_tabPage.Text = PluginConstants.TabLabel;
			var baseView = new BaseView {Dock = DockStyle.Fill};
			_tabPage.Controls.Add(baseView);
			_basePresenter = new BasePresenter(baseView, _kaptureData, _kaptureGuiLogger);
			_pluginStatus.Text = PluginConstants.PluginStatusEnabled;
		}

		private void InitKaptureBridge()
		{
			_kaptureData = KaptureData.GetInstance();
		}

		private void SetupLogger()
		{
			_kaptureGuiLogger = KaptureGUILogger.GetInstance(_kaptureData.GetAppDirectory());
		}

		private void SetLanguage()
		{
			_language = _kaptureData.LanguageService.GetCurrentLanguage();
			var cultureInfo = new CultureInfo(_language.Abbreviation);
			Thread.CurrentThread.CurrentUICulture = cultureInfo;
			Thread.CurrentThread.CurrentCulture = cultureInfo;
			LogFormat.LogFormats.Clear();
			typeof(UpdateService).GetConstructor(BindingFlags.Static | BindingFlags.NonPublic, null, new Type[0], null)
				?.Invoke(null, null);
			typeof(ItemPreset).GetConstructor(BindingFlags.Static | BindingFlags.NonPublic, null, new Type[0], null)
				?.Invoke(null, null);
			typeof(LogFormat).GetConstructor(BindingFlags.Static | BindingFlags.NonPublic, null, new Type[0], null)
				?.Invoke(null, null);
			typeof(ZonePreset).GetConstructor(BindingFlags.Static | BindingFlags.NonPublic, null, new Type[0], null)
				?.Invoke(null, null);
		}

		private void LoadSettings()
		{
			KaptureConfig.Initialize(_kaptureData.GetAppDirectory());
			_kaptureConfig = KaptureConfig.GetInstance();
			_configuration = (Configuration) _kaptureConfig.ConfigManager.Config;
			if (_language.Id == _configuration.XIVPlugin.LanguageId)
			{
				_kaptureConfig.ConfigManager.LoadSettings();
				_configuration.XIVPlugin.FreshInstall = false;
				_kaptureConfig.ConfigManager.SaveSettings();
			}
			else
			{
				var newConfig = new Configuration
				{
					General = _configuration.General,
					Filters = _configuration.Filters,
					Items = new Items(),
					Zones = new Zones(),
					Logging = new Logging(),
					Discord = new Discord(),
					HTTP = new HTTP(),
					XIVPlugin = new XIVPlugin()
				};
				newConfig.XIVPlugin.LanguageId = _language.Id;
				KaptureConfig.GetInstance().Config = newConfig;
				_configuration = newConfig;
			}
		}

		private void CheckForFreshInstall()
		{
			if (!_configuration.XIVPlugin.FreshInstall) return;
			_configuration.XIVPlugin.FreshInstall = false;
			_kaptureConfig.ConfigManager.SaveSettings();
			ACTWrapper.GetInstance().Restart(Strings.PluginInstalled);
		}

		private void SetupKaptureService()
		{
			_httpClient = new HttpClient();
			_kaptureVersion = Assembly.GetExecutingAssembly()
				.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;

			_updaterSettings = new PluginUpdaterSettings
			{
				AuthorName = "kalilistic",
				RepoName = "Kapture",
				IncludePreRelease = _configuration.General.CheckForBetaEnabled,
				PluginPath = ActGlobals.oFormActMain.PluginGetSelfData(this).pluginFile.DirectoryName,
				HTTPClient = _httpClient,
				Version = _kaptureVersion,
				UpdateMessage = Strings.PluginUpdateAvailable,
				RestartMessage = Strings.PluginUpdateSuccess,
				FailureMessage = Strings.PluginUpdateFailed
			};

			UniversalisWrapper.Initialize(_httpClient);
		}

		private void CreateLogDirectory()
		{
			if (_configuration.Logging.LogLocation != null) return;
			var path = Path.Combine(_kaptureData.GetAppDirectory(), "KaptureLogs");
			Directory.CreateDirectory(path);
			_configuration.Logging.LogLocation = path;
			_kaptureConfig.ConfigManager.Config = _configuration;
			_kaptureConfig.ConfigManager.SaveSettings();
		}

		private void SetupDiscord()
		{
			lock (DiscordLock)
			{
				_discordQueue = new Queue<string>();
			}

			_discordTimer = new Timer {Interval = 1000};
			_discordTimer.Elapsed += SendToDiscord;
			_discordTimer.Start();
		}

		private void SetupHTTP()
		{
			lock (HTTPLock)
			{
				_httpQueue = new Queue<string>();
			}

			_httpTimer = new Timer {Interval = 1000};
			_httpTimer.Elapsed += SendToHTTP;
			_httpTimer.Start();
		}

		private void SetupJsonSerializer()
		{
			var contractResolver = new DefaultContractResolver
			{
				NamingStrategy = new CamelCaseNamingStrategy()
			};
			_jsonSerializerSettings = new JsonSerializerSettings
			{
				ContractResolver = contractResolver,
				Formatting = Formatting.Indented
			};
		}

		private static void SetupEventSource()
		{
			EventSource.Register(new EventSourceContext
			{
				Name = "Kapture",
				EventTypes = new List<string>
				{
					"LootData"
				},
				EventHandlers = new List<EventHandler>
				{
					new EventHandler
					{
						Name = "kaptureHandler",
						Handler = msg => null
					}
				},
				OverlayPresets = new List<OverlayPreset>
				{
					new OverlayPreset
					{
						Name = "Log",
						Url = @"https://kalilistic.github.io/kapture-log-overlay/",
						Size = new[] {400, 250}
					},
					new OverlayPreset
					{
						Name = "Price",
						Url = @"https://kalilistic.github.io/kapture-price-overlay/",
						Size = new[] {400, 250}
					}
				}
			});
			Registry.RegisterEventSource<EventSource>();
		}

		private void SubscribeToLogLineEvents()
		{
			_kaptureData.EnableLogLineParser();
			_kaptureData.LogLineCaptured += HandleLootEvent;
		}

		private void LoadLocalizedData()
		{
			Task.Run(() => _kaptureData.Initialize(_configuration.XIVPlugin.LanguageId));
		}

		private void CheckForUpdates()
		{
			Task.Run(() => UpdateService.UpdatePlugin(_updaterSettings));
		}

		private void HandleLootEvent(object sender, LogLineEvent logLineEvent)
		{
			try
			{
				if (logLineEvent == null) return;
				_configuration = (Configuration) KaptureConfig.GetInstance().ConfigManager.Config;
				_kaptureGuiLogger.Info(logLineEvent.LogMessage);
				LogMessage(logLineEvent);
				SendToDiscordQueue(logLineEvent);
				SendToHTTPQueue(logLineEvent);
				EventSource.SendEvent("LootData", logLineEvent);
			}
			catch (Exception ex)
			{
				_kaptureGuiLogger.Error(logLineEvent?.LogMessage + "." + Environment.NewLine, ex);
			}
		}

		private void LogMessage(LogLineEvent logLineEvent)
		{
			if (!_configuration.Logging.LoggingEnabled) return;
			if (_configuration.Logging.LogFormat.ToString().Equals(LogFormat.BattleLog.ToString()))
				LogBattleFormat(logLineEvent);
			else if (_configuration.Logging.LogFormat.ToString().Equals(LogFormat.CSV.ToString()))
				LogCsvFormat(logLineEvent);
			else if (_configuration.Logging.LogFormat.ToString().Equals(LogFormat.JSON.ToString()))
				LogJsonFormat(logLineEvent);
		}

		private void LogBattleFormat(LogLineEvent logLineEvent)
		{
			var filePath = Path.Combine(_configuration.Logging.LogLocation,
				"Kapture_" + _kaptureVersion + "_" + DateTime.Now.ToString("yyyyMMdd") + ".log");
			lock (Lock)
			{
				File.AppendAllText(filePath, logLineEvent.GetMessageWithTimestamp() + Environment.NewLine);
			}
		}

		private void LogCsvFormat(LogLineEvent logLineEvent)
		{
			var filePath = Path.Combine(_configuration.Logging.LogLocation,
				"Kapture_" + _kaptureVersion + "_" + DateTime.Now.ToString("yyyyMMdd") + ".csv");
			lock (Lock)
			{
				var csvMsg = logLineEvent.Id + PluginConstants.CsvSep +
				             logLineEvent.ACTLogLineEvent.DetectedTime + PluginConstants.CsvSep +
				             logLineEvent.KaptureEvent?.EventType + PluginConstants.CsvSep +
				             logLineEvent.KaptureEvent?.Actor?.Name + PluginConstants.CsvSep +
				             logLineEvent.KaptureEvent?.Item?.ProperName + PluginConstants.CsvSep +
				             logLineEvent.KaptureEvent?.Item?.Quantity + PluginConstants.CsvSep +
				             logLineEvent.KaptureEvent?.Roll;
				File.AppendAllText(filePath, csvMsg + Environment.NewLine);
			}
		}

		private void LogJsonFormat(LogLineEvent logLineEvent)
		{
			var filePath = Path.Combine(_configuration.Logging.LogLocation,
				"Kapture_" + _kaptureVersion + "_" + DateTime.Now.ToString("yyyyMMdd") + ".json");
			var json = JsonConvert.SerializeObject(logLineEvent, _jsonSerializerSettings);
			lock (Lock)
			{
				File.AppendAllText(filePath, json + Environment.NewLine);
			}
		}

		private void SendToDiscordQueue(LogLineEvent logLineEvent)
		{
			if (!_configuration.Discord.DiscordEnabled) return;
			if (_configuration.Discord.Endpoint == null) return;
			lock (DiscordLock)
			{
				var json = "{\"content\": \"" + logLineEvent.GetShorthand() + "\"}";
				_discordQueue.Enqueue(json);
			}
		}

		private void SendToHTTPQueue(LogLineEvent logLineEvent)
		{
			if (!_configuration.HTTP.HTTPEnabled) return;
			if (_configuration.HTTP.Endpoint == null) return;
			lock (HTTPLock)
			{
				var json = JsonConvert.SerializeObject(new object[] {logLineEvent, _configuration.HTTP.CustomJson},
					_jsonSerializerSettings);
				_httpQueue.Enqueue(json);
			}
		}

		private async void SendToDiscord(object source, ElapsedEventArgs e)
		{
			if (_discordQueue == null || _discordQueue.Count == 0) return;
			try
			{
				var result = await _httpClient.PostAsync(new Uri(_configuration.Discord.Endpoint),
					new StringContent(_discordQueue.Peek(), Encoding.UTF8, "application/json"));
				if (result.IsSuccessStatusCode) _discordQueue.Dequeue();
			}
			catch (Exception)
			{
				_kaptureGuiLogger.Info("Discord failed but will retry.");
			}
		}

		private async void SendToHTTP(object source, ElapsedEventArgs e)
		{
			if (_httpQueue == null || _httpQueue.Count == 0) return;
			try
			{
				await _httpClient.PostAsync(new Uri(_configuration.HTTP.Endpoint),
					new StringContent(_httpQueue.Peek(), Encoding.UTF8, "application/json"));
				_httpQueue.Dequeue();
			}
			catch (Exception)
			{
				_kaptureGuiLogger.Info("HTTP request failed.");
			}
		}
	}
}