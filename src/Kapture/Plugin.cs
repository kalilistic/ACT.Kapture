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
using ACT_FFXIV_Aetherbridge;
using ACT_FFXIV_Kapture.Config;
using ACT_FFXIV_Kapture.Presentation;
using ACT_FFXIV_Kapture.Service;
using Advanced_Combat_Tracker;
using Manatee.Json.Serialization;
using Configuration = ACT_FFXIV_Kapture.Config.Config;
using Timer = System.Timers.Timer;

// ReSharper disable ConvertIfStatementToSwitchStatement
#pragma warning disable 4014

namespace ACT_FFXIV_Kapture.Plugin
{
	public class Plugin : IActPluginV1
	{
		private static readonly object Lock = new object();
		private static readonly object DiscordLock = new object();
		private Aetherbridge _aetherbridge;
		private BasePresenter _basePresenter;
		private Configuration _configuration;
		private Queue<string> _discordQueue;
		private Timer _discordTimer;
		private HttpClient _httpClient;
		private KaptureConfig _kaptureConfig;
		private string _kaptureVersion;
		private Language _language;
		private Logger _logger;
		private Label _pluginStatus;
		private JsonSerializer _serializer;
		private TabPage _tabPage;

		public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
		{
			try
			{
				InitAetherbridge();
				SetupLogger();
				SetupJsonSerializer();
				SetLanguage();
				LoadSettings();
				SetupKaptureService();
				CreateLogDirectory();
				SetupDiscord();
				SubscribeToLogLineEvents();
				SetupUI(pluginScreenSpace, pluginStatusText);
				LoadLocalizedData();
				CheckForUpdates();
			}
			catch (Exception ex)
			{
				_logger?.Error("Failed to initialize plugin.", ex);
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
			_kaptureConfig.ConfigManager.SaveSettings();
			_aetherbridge.LogLineCaptured -= ParseLootEvents;
			_aetherbridge.DeInit();
			_kaptureConfig?.DeInit();
			UpdateService.GetInstance().DeInit();
			_httpClient.Dispose();
			_pluginStatus.Text = PluginConstants.PluginStatusDisabled;
			_basePresenter.DeInit();
		}

		private void SetupUI(TabPage pluginScreenSpace, Label pluginStatusText)
		{
			_tabPage = pluginScreenSpace;
			_pluginStatus = pluginStatusText;
			_tabPage.Text = PluginConstants.TabLabel;
			var baseView = new BaseView {Dock = DockStyle.Fill};
			_tabPage.Controls.Add(baseView);
			_basePresenter = new BasePresenter(baseView, _aetherbridge, _logger);
			_pluginStatus.Text = PluginConstants.PluginStatusEnabled;
		}

		private void InitAetherbridge()
		{
			_aetherbridge = Aetherbridge.GetInstance();
		}

		private void SetupLogger()
		{
			_logger = Logger.GetInstance(_aetherbridge.GetAppDirectory());
		}

		private void SetupJsonSerializer()
		{
			_serializer = new JsonSerializer
			{
				Options = new JsonSerializerOptions
				{
					TypeNameSerializationBehavior = TypeNameSerializationBehavior.Never
				}
			};
		}

		private void SetLanguage()
		{
			_language = _aetherbridge.LanguageService.GetCurrentLanguage();
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
			KaptureConfig.Initialize(_aetherbridge.GetAppDirectory());
			_kaptureConfig = KaptureConfig.GetInstance();
			_configuration = (Configuration) _kaptureConfig.ConfigManager.Config;
			if (_language.Id == _configuration.XIVPlugin.LanguageId)
			{
				_kaptureConfig.ConfigManager.LoadSettings();
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

		private void SetupKaptureService()
		{
			_httpClient = new HttpClient();
			_kaptureVersion = Assembly.GetExecutingAssembly()
				.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
			UpdateService.Initialize(_httpClient, _kaptureVersion,
				ActGlobals.oFormActMain.PluginGetSelfData(this).pluginFile.DirectoryName, _language.Abbreviation,
				_logger);
			UpdateService.GetInstance().KaptureLog =
				Path.Combine(_aetherbridge.GetAppDirectory(), PluginConstants.LogFileName);
		}

		private void CreateLogDirectory()
		{
			if (_configuration.Logging.LogLocation != null) return;
			var path = Path.Combine(_aetherbridge.GetAppDirectory(), "KaptureLogs");
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

		private void SubscribeToLogLineEvents()
		{
			_aetherbridge.EnableLogLineParser();
			_aetherbridge.LogLineCaptured += ParseLootEvents;
		}

		private void LoadLocalizedData()
		{
			Task.Run(() => _aetherbridge.AddLanguage(_configuration.XIVPlugin.LanguageId));
		}

		private void CheckForUpdates()
		{
			Task.Run(() => UpdateService.GetInstance().UpdatePlugin(_configuration.General.CheckForBetaEnabled, false));
		}

		private static bool IsNonLootEvent(LogLineEvent logLineEvent)
		{
			if (logLineEvent?.XIVEvent == null) return true;
			return logLineEvent.XIVEvent.XIVEventType != XIVEventTypeEnum.Loot;
		}

		private bool IsPluginDisabled()
		{
			return !_configuration.General.PluginEnabled;
		}

		private bool IsImportWithImportsDisabled(LogLineEvent logLineEvent)
		{
			return logLineEvent.ACTLogLineEvent.IsImport && !_configuration.General.LogImportsEnabled;
		}

		private bool IsExcludedLootEvent(XIVEvent lootEvent)
		{
			if (lootEvent.XIVEventSubType == XIVEventSubTypeEnum.AddLoot) return !_configuration.Filters.ItemAdded;

			if (lootEvent.XIVEventSubType == XIVEventSubTypeEnum.ObtainLoot)
				return !_configuration.Filters.ItemObtained;

			if (lootEvent.XIVEventSubType == XIVEventSubTypeEnum.NeedLoot ||
			    lootEvent.XIVEventSubType == XIVEventSubTypeEnum.GreedLoot)
				return !_configuration.Filters.ItemRolledOn;

			if (lootEvent.XIVEventSubType == XIVEventSubTypeEnum.LostLoot) return !_configuration.Filters.ItemLost;

			return false;
		}

		private bool IsExcludedPlayerType(LogLineEvent logLineEvent, XIVEvent lootEvent)
		{
			if (logLineEvent.ACTLogLineEvent.IsImport) return false;
			if (logLineEvent.XIVEvent.Actor == null) return false;
			if (lootEvent.Actor.IsReporter) return !_configuration.Filters.Self;
			if (lootEvent.Actor.PartyType == PartyTypeEnum.Party) return !_configuration.Filters.Party;
			if (lootEvent.Actor.PartyType == PartyTypeEnum.Alliance) return !_configuration.Filters.Alliance;
			return false;
		}

		private bool IsExcludedItem(XIVEvent lootEvent)
		{
			if (!_configuration.Items.FilterByItems) return false;
			if (_configuration.Items.IncludeItems)
				return !_configuration.Items.ItemsList.Contains(lootEvent.Item.ProperName);
			return _configuration.Items.ExcludeItems &&
			       _configuration.Items.ItemsList.Contains(lootEvent.Item.ProperName);
		}

		private bool IsExcludedZone(LogLineEvent logLineEvent)
		{
			if (!_configuration.Zones.FilterByZones || logLineEvent.ACTLogLineEvent.IsImport) return false;
			var territoryTypeId = _aetherbridge.LocationService.GetCurrentLocation().TerritoryTypeId;
			var contentName = _aetherbridge.ContentService.GetContentByTerritoryTypeId(territoryTypeId).Name;
			if (contentName == null || contentName.Equals(string.Empty)) return false;
			if (_configuration.Zones.IncludeZones) return !_configuration.Zones.ZonesList.Contains(contentName);
			return _configuration.Zones.ExcludeZones && _configuration.Zones.ZonesList.Contains(contentName);
		}

		private bool IsExcludedEvent(LogLineEvent logLineEvent, XIVEvent lootEvent)
		{
			return
				IsNonLootEvent(logLineEvent) ||
				IsPluginDisabled() ||
				IsImportWithImportsDisabled(logLineEvent) ||
				IsExcludedLootEvent(lootEvent) ||
				IsExcludedPlayerType(logLineEvent, lootEvent) ||
				IsExcludedItem(lootEvent) ||
				IsExcludedZone(logLineEvent);
		}

		private void ParseLootEvents(object sender, LogLineEvent logLineEvent)
		{
			try
			{
				var lootEvent = logLineEvent.XIVEvent;
				_configuration = (Configuration) KaptureConfig.GetInstance().ConfigManager.Config;
				if (IsExcludedEvent(logLineEvent, lootEvent)) return;
				_logger.Info(logLineEvent.LogMessage);
				LogMessage(logLineEvent);
				SendToDiscordQueue(logLineEvent);
				SendToHTTP(logLineEvent);
			}
			catch (Exception ex)
			{
				_logger.Error(logLineEvent?.LogMessage + "." + Environment.NewLine, ex);
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
				             logLineEvent.XIVEvent?.XIVEventType + PluginConstants.CsvSep +
				             logLineEvent.XIVEvent?.XIVEventSubType + PluginConstants.CsvSep +
				             logLineEvent.XIVEvent?.Actor?.Name + PluginConstants.CsvSep +
				             logLineEvent.XIVEvent?.Item?.ProperName + PluginConstants.CsvSep +
				             logLineEvent.XIVEvent?.Item?.Quantity + PluginConstants.CsvSep +
				             logLineEvent.XIVEvent?.Roll;
				File.AppendAllText(filePath, csvMsg + Environment.NewLine);
			}
		}

		private void LogJsonFormat(LogLineEvent logLineEvent)
		{
			var filePath = Path.Combine(_configuration.Logging.LogLocation,
				"Kapture_" + _kaptureVersion + "_" + DateTime.Now.ToString("yyyyMMdd") + ".json");
			var json = _serializer.Serialize(logLineEvent);
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
				var json = "{\"content\": \"" + logLineEvent.GetMessageWithTimestamp() + "\"}";
				_discordQueue.Enqueue(json);
			}
		}

		private async void SendToDiscord(object source, ElapsedEventArgs e)
		{
			if (_discordQueue == null || _discordQueue.Count == 0) return;
			var result = await _httpClient.PostAsync(new Uri(_configuration.Discord.Endpoint),
				new StringContent(_discordQueue.Peek(), Encoding.UTF8, "application/json"));
			if (result.IsSuccessStatusCode) _discordQueue.Dequeue();
		}

		private async Task SendToHTTP(LogLineEvent logLineEvent)
		{
			if (!_configuration.HTTP.HTTPEnabled) return;
			if (_configuration.HTTP.Endpoint == null) return;
			var json = _serializer.Serialize(new object[] {logLineEvent, _configuration.HTTP.CustomJson});
			try
			{
				await _httpClient.PostAsync(new Uri(_configuration.HTTP.Endpoint),
					new StringContent(json.ToString(), Encoding.UTF8, "application/json"));
			}
			catch (Exception ex)
			{
				_logger.Error(nameof(SendToHTTP) + ": " + logLineEvent?.LogMessage + "." + Environment.NewLine,
					ex);
			}
		}
	}
}