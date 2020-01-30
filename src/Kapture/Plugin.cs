using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACT_FFXIV_Aetherbridge;
using ACT_FFXIV_Kapture.Config;
using ACT_FFXIV_Kapture.Presentation;
using ACT_FFXIV_Kapture.Service;
using Advanced_Combat_Tracker;
using Manatee.Json.Serialization;
using StarkLogger;
using Configuration = ACT_FFXIV_Kapture.Config.Config;

// ReSharper disable ConvertIfStatementToSwitchStatement
#pragma warning disable 4014

namespace ACT_FFXIV_Kapture.Plugin
{
	public class Plugin : IActPluginV1
	{
		private static readonly object Lock = new object();
		private Aetherbridge _aetherbridge;
		private HttpClient _httpClient;
		private ILogger _logger;

		private Label _pluginStatus;
		private JsonSerializer _serializer;
		private TabPage _tabPage;

		public Configuration Configuration;
		public KaptureConfig KaptureConfig;

		public string KaptureVersion;

		public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
		{
			try
			{
				// setup tab space
				_tabPage = pluginScreenSpace;
				_pluginStatus = pluginStatusText;
				_tabPage.Text = PluginConstants.TabLabel;

				// setup aetherbridge
				_aetherbridge = Aetherbridge.GetInstance();

				// setup logger
				Logger.Initialize(_aetherbridge.GetAppDirectory(), PluginConstants.LogFileName);
				var logPath = Path.Combine(_aetherbridge.GetAppDirectory(), PluginConstants.LogFileName);
				_logger = Logger.GetInstance();
				if (!File.Exists(logPath)) _logger.Info("Log file initialized.");

				// setup serializer for json logs/rest calls
				_serializer = new JsonSerializer
				{
					Options = new JsonSerializerOptions
					{
						TypeNameSerializationBehavior = TypeNameSerializationBehavior.Never
					}
				};

				// setup config
				KaptureConfig.Initialize(_aetherbridge.GetAppDirectory());
				KaptureConfig = KaptureConfig.GetInstance();
				Configuration = (Configuration) KaptureConfig.ConfigManager.Config;
				KaptureConfig.ConfigManager.LoadSettings();

				// setup plugin service
				_httpClient = new HttpClient();
				KaptureVersion = Assembly.GetExecutingAssembly()
					.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
				PluginService.Initialize(_httpClient, KaptureVersion,
					ActGlobals.oFormActMain.PluginGetSelfData(this).pluginFile.DirectoryName);
				PluginService.GetInstance().KaptureLog =
					Path.Combine(_aetherbridge.GetAppDirectory(), PluginConstants.LogFileName);

				// create log dir if empty
				if (Configuration.Logging.LogLocation == null)
				{
					var path = Path.Combine(_aetherbridge.GetAppDirectory(), "KaptureLogs");
					Directory.CreateDirectory(path);
					Configuration.Logging.LogLocation = path;
					KaptureConfig.ConfigManager.Config = Configuration;
					KaptureConfig.ConfigManager.SaveSettings();
				}

				// setup loot parser event handler
				_aetherbridge.EnableLogLineParser();
				_aetherbridge.LogLineCaptured += ParseLootEvents;

				// setup user interface
				var mainView = new MainView {Dock = DockStyle.Fill};
				_tabPage.Controls.Add(mainView);
				_ = new MainPresenter(mainView, _aetherbridge);

				// update plugin status
				_pluginStatus.Text = PluginConstants.PluginStatusEnabled;

				// kick off update check
				Task.Run(() =>
					PluginService.GetInstance().UpdatePlugin(Configuration.General.CheckForBetaEnabled, false));
			}
			catch (Exception ex)
			{
				_logger?.Error(ex);
				MessageBox.Show(PluginConstants.CriticalFailureMsg + Environment.NewLine +
				                PluginConstants.ErrorPrefix + ex.StackTrace);
				_pluginStatus.Text = PluginConstants.PluginStatusDisabledFailure;
				ActGlobals.oFormActMain.PluginGetSelfData(this).cbEnabled.Checked = false;
			}
		}

		public void DeInitPlugin()
		{
			if (_aetherbridge.LanguageService.GetCurrentLanguage().Id != Configuration.General.GameLanguageId)
			{
				KaptureConfig = KaptureConfig.GetInstance();
				Configuration = (Configuration) KaptureConfig.ConfigManager.Config;
				Configuration.General.GameLanguageId = _aetherbridge.LanguageService.GetCurrentLanguage().Id;
				Configuration.Items.ItemPreset = ItemPreset.ExcludeCommonItems;
				Configuration.Items.ItemsList = new List<string>();
				Configuration.Zones.ZonePreset = ZonePreset.HighEndDuty;
				Configuration.Zones.ZonesList = new List<string>();
			}

			KaptureConfig.ConfigManager.SaveSettings();
			_aetherbridge.LogLineCaptured -= ParseLootEvents;
			_aetherbridge.DeInit();
			KaptureConfig?.DeInit();
			_logger.DeInit();
			PluginService.GetInstance().DeInit();
			_httpClient.Dispose();
			_pluginStatus.Text = PluginConstants.PluginStatusDisabled;
		}

		private void ParseLootEvents(object sender, LogLineEvent logLineEvent)
		{
			try
			{
				// loot filter
				if (logLineEvent?.XIVEvent == null) return;
				if (logLineEvent.XIVEvent.XIVEventType != XIVEventTypeEnum.Loot) return;

				// set vars
				var lootEvent = logLineEvent.XIVEvent;
				Configuration = (Configuration) KaptureConfig.ConfigManager.Config;

				// general filter
				if (!Configuration.General.PluginEnabled) return;
				if (logLineEvent.ACTLogLineEvent.IsImport && !Configuration.General.LogImportsEnabled) return;

				// events filter
				if (lootEvent.XIVEventSubType == XIVEventSubTypeEnum.AddLoot)
				{
					if (!Configuration.Events.ItemAddedEnabled) return;
				}
				else if (lootEvent.XIVEventSubType == XIVEventSubTypeEnum.LostLoot)
				{
					if (!Configuration.Events.ItemDroppedEnabled) return;
				}
				else if (lootEvent.XIVEventSubType == XIVEventSubTypeEnum.ObtainLoot)
				{
					if (lootEvent.Actor.IsReporter)
					{
						if (!Configuration.Events.YouObtainedEnabled) return;
					}
					else if (!lootEvent.Actor.IsReporter)
					{
						if (!Configuration.Events.TheyObtainedEnabled) return;
					}
					else
					{
						return;
					}
				}
				else if (lootEvent.XIVEventSubType == XIVEventSubTypeEnum.NeedLoot ||
				         lootEvent.XIVEventSubType == XIVEventSubTypeEnum.GreedLoot)
				{
					if (lootEvent.Actor.IsReporter)
					{
						if (!Configuration.Events.YouRolledEnabled) return;
					}
					else if (!lootEvent.Actor.IsReporter)
					{
						if (!Configuration.Events.TheyRolledEnabled) return;
					}
					else
					{
						return;
					}
				}

				// items filter
				if (Configuration.Items.FilterByItems)
				{
					if (Configuration.Items.IncludeItems)
					{
						if (!Configuration.Items.ItemsList.Contains(lootEvent.Item.ProperName)) return;
					}
					else if (Configuration.Items.ExcludeItems)
					{
						if (Configuration.Items.ItemsList.Contains(lootEvent.Item.ProperName)) return;
					}
				}

				// zones filter
				if (Configuration.Zones.FilterByZones && !logLineEvent.ACTLogLineEvent.IsImport)
				{
					if (Configuration.Zones.IncludeZones)
					{
						if (!Configuration.Zones.ZonesList.Contains(lootEvent.Location.Zone.Name)) return;
					}
					else if (Configuration.Zones.ExcludeZones)
					{
						if (Configuration.Zones.ZonesList.Contains(lootEvent.Location.Zone.Name)) return;
					}
				}

				// log messages
				if (Configuration.Logging.LoggingEnabled)
				{
					if (Configuration.Logging.LogFormat.ToString().Equals(LogFormat.LogFile.ToString()))
						LogSimpleFormat(logLineEvent);
					else if (Configuration.Logging.LogFormat.ToString().Equals(LogFormat.CSV.ToString()))
						LogCsvFormat(logLineEvent);
					else if (Configuration.Logging.LogFormat.ToString().Equals(LogFormat.JSON.ToString()))
						LogJsonFormat(logLineEvent);
				}

				// send message to discord
				if (Configuration.Discord.DiscordEnabled) SendToDiscordWebHook(logLineEvent);

				// send message to rest endpoint
				if (Configuration.HTTP.HTTPEnabled) SendRestCall(logLineEvent);
			}
			catch (Exception ex)
			{
				_logger.Info("Failed on log line: " + logLineEvent?.LogMessage);
				_logger.Error(ex);
			}
		}

		private void LogSimpleFormat(LogLineEvent logLineEvent)
		{
			var filePath = Path.Combine(Configuration.Logging.LogLocation,
				"Kapture_" + KaptureVersion + "_" + DateTime.Now.ToString("yyyyMMdd") + ".log");
			lock (Lock)
			{
				File.AppendAllText(filePath, logLineEvent.LogMessage + Environment.NewLine);
			}
		}

		private void LogCsvFormat(LogLineEvent logLineEvent)
		{
			var filePath = Path.Combine(Configuration.Logging.LogLocation,
				"Kapture_" + KaptureVersion + "_" + DateTime.Now.ToString("yyyyMMdd") + ".csv");
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
			var filePath = Path.Combine(Configuration.Logging.LogLocation,
				"Kapture_" + KaptureVersion + "_" + DateTime.Now.ToString("yyyyMMdd") + ".json");
			var json = _serializer.Serialize(logLineEvent);
			lock (Lock)
			{
				File.AppendAllText(filePath, json + Environment.NewLine);
			}
		}

		private async Task SendToDiscordWebHook(LogLineEvent logLineEvent)
		{
			if (Configuration.Discord.Endpoint == null) return;
			var json = "{\"content\": \"" + logLineEvent.LogMessage + "\"}";
			try
			{
				await _httpClient.PostAsync(new Uri(Configuration.Discord.Endpoint),
					new StringContent(json, Encoding.UTF8, "application/json"));
			}
			catch (Exception ex)
			{
				_logger.Error(ex);
			}
		}

		private async Task SendRestCall(LogLineEvent logLineEvent)
		{
			if (Configuration.HTTP.Endpoint == null) return;
			var json = _serializer.Serialize(new object[] {logLineEvent, Configuration.HTTP.CustomJson});
			try
			{
				await _httpClient.PostAsync(new Uri(Configuration.HTTP.Endpoint),
					new StringContent(json.ToString(), Encoding.UTF8, "application/json"));
			}
			catch (Exception ex)
			{
				Logger.GetInstance().Error(ex);
			}
		}
	}
}