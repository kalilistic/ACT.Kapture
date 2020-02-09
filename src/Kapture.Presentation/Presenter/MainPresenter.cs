using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ACT_FFXIV_Aetherbridge;
using ACT_FFXIV_Kapture.Config;
using ACT_FFXIV_Kapture.Service;
using Configuration = ACT_FFXIV_Kapture.Config.Config;

namespace ACT_FFXIV_Kapture.Presentation
{
	public class MainPresenter
	{
		public Configuration Configuration;
		public KaptureConfig KaptureConfig;
		public Logger Logger;

		public MainPresenter(MainView mainView, Logger logger)
		{
			MainView = mainView;
			Logger = logger;
			KaptureConfig = KaptureConfig.GetInstance();
			Configuration = (Configuration) KaptureConfig.ConfigManager.Config;
			SetupGeneral();
			SetupFilters();
			SetupLogging();
			SetupDiscord();
			SetupHTTP();
			SetupMessageLog();
		}


		public MainView MainView { get; set; }

		private void SetupGeneral()
		{
			MainView.GeneralPluginEnabled = Configuration.General.PluginEnabled;
			MainView.GeneralLogImportsEnabled = Configuration.General.LogImportsEnabled;
			MainView.GeneralCheckForBetaEnabled = Configuration.General.CheckForBetaEnabled;
			MainView.GeneralPluginEnabledChanged += GeneralPluginEnabledChanged;
			MainView.GeneralLogImportsEnabledChanged += GeneralLogImportsEnabledChanged;
			MainView.GeneralCheckForBetaChanged += GeneralCheckForBetaEnabledChanged;
		}

		private void SetupFilters()
		{
			MainView.FiltersItemAddedEnabled = Configuration.Filters.ItemAdded;
			MainView.FiltersItemObtainedEnabled = Configuration.Filters.ItemObtained;
			MainView.FiltersItemRolledOnEnabled = Configuration.Filters.ItemRolledOn;
			MainView.FiltersItemLostEnabled = Configuration.Filters.ItemLost;
			MainView.FiltersSelfEnabled = Configuration.Filters.Self;
			MainView.FiltersPartyEnabled = Configuration.Filters.Party;
			MainView.FiltersAllianceEnabled = Configuration.Filters.Alliance;
			MainView.FiltersExcludeCommonItems = Configuration.Filters.ExcludeCommonItems;
			MainView.FiltersHighEndDutyOnly = Configuration.Filters.HighEndDutyOnly;

			if (Configuration.Items.ItemPreset.Equals(ItemPreset.ExcludeCommonItems))
			{
				Configuration.Items.ItemsList = Aetherbridge.GetInstance().ItemService.GetCommonItemNames();
				Configuration.Items.ExcludeItems = true;
				Configuration.Items.FilterByItems = true;
			}

			if (Configuration.Zones.ZonePreset.Equals(ZonePreset.HighEndDuty))
			{
				Configuration.Zones.ZonesList = Aetherbridge.GetInstance().ContentService.GetHighEndContentNames();
				Configuration.Zones.IncludeZones = true;
				Configuration.Zones.FilterByZones = true;
			}

			MainView.FiltersItemAddedEnabledChanged += FiltersItemAddedEnabledChanged;
			MainView.FiltersItemLostEnabledChanged += FiltersItemLostEnabledChanged;
			MainView.FiltersItemObtainedEnabledChanged += FiltersItemObtainedEnabledChanged;
			MainView.FiltersItemRolledOnEnabledChanged += FiltersItemRolledOnEnabledChanged;
			MainView.FiltersSelfEnabledChanged += FiltersSelfEnabledChanged;
			MainView.FiltersPartyEnabledChanged += FiltersPartyEnabledChanged;
			MainView.FiltersAllianceEnabledChanged += FiltersAllianceEnabledChanged;
			MainView.FiltersExcludeCommonItemsChanged += FiltersExcludeCommonItemsChanged;
			MainView.FiltersHighEndDutyOnlyChanged += FiltersHighEndDutyOnlyChanged;
		}

		private void SetupLogging()
		{
			MainView.LoggingEnabled = Configuration.Logging.LoggingEnabled;
			MainView.LogFormatList = LogFormat.LogFormats;
			MainView.LogFormat = Configuration.Logging.LogFormat;
			MainView.LogLocation = Configuration.Logging.LogLocation;
			MainView.LoggingEnabledChanged += LoggingEnabledChanged;
			MainView.LogFormatChanged += LogFormatChanged;
			MainView.LogLocationChanged += LogLocationChanged;
		}

		private void SetupDiscord()
		{
			MainView.DiscordEnabled = Configuration.Discord.DiscordEnabled;
			MainView.DiscordEndpoint = Configuration.Discord.Endpoint;
			MainView.DiscordEnabledChanged += DiscordEnabledChanged;
			MainView.DiscordWebhookUrlChanged += DiscordWebhookUrlChanged;
		}

		private void SetupHTTP()
		{
			MainView.HTTPEnabled = Configuration.HTTP.HTTPEnabled;
			MainView.HTTPEndpoint = Configuration.HTTP.Endpoint;
			MainView.HTTPCustomJson = Configuration.HTTP.CustomJson;
			MainView.HTTPEnabledChanged += HTTPEnabledChanged;
			MainView.HTTPChanged += HTTPChanged;
		}

		private void SetupMessageLog()
		{
			var messages = Logger.GetLogMessages();
			foreach (var message in messages.Where(message => message != null && !message.Equals(string.Empty)))
				MainView.AddMessageToLog(message);
			Logger.LogMessageAdded += LogMessageAdded;
		}

		private void LogMessageAdded(object sender, string e)
		{
			MainView.AddMessageToLog(e);
		}

		private void GeneralPluginEnabledChanged(object sender, bool e)
		{
			Configuration.General.PluginEnabled = e;
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void GeneralLogImportsEnabledChanged(object sender, bool e)
		{
			Configuration.General.LogImportsEnabled = e;
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void GeneralCheckForBetaEnabledChanged(object sender, bool e)
		{
			Configuration.General.CheckForBetaEnabled = e;
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void FiltersItemAddedEnabledChanged(object sender, bool e)
		{
			Configuration.Filters.ItemAdded = e;
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void FiltersItemObtainedEnabledChanged(object sender, bool e)
		{
			Configuration.Filters.ItemObtained = e;
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void FiltersItemRolledOnEnabledChanged(object sender, bool e)
		{
			Configuration.Filters.ItemRolledOn = e;
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void FiltersItemLostEnabledChanged(object sender, bool e)
		{
			Configuration.Filters.ItemLost = e;
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void FiltersSelfEnabledChanged(object sender, bool e)
		{
			Configuration.Filters.Self = e;
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void FiltersPartyEnabledChanged(object sender, bool e)
		{
			Configuration.Filters.Party = e;
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void FiltersAllianceEnabledChanged(object sender, bool e)
		{
			Configuration.Filters.Alliance = e;
			KaptureConfig.ConfigManager.SaveSettings();
		}


		private void FiltersExcludeCommonItemsChanged(object sender, bool e)
		{
			// update filter
			Configuration.Filters.ExcludeCommonItems = e;

			// update advanced filter
			var itemPreset = Configuration.Filters.ExcludeCommonItems
				? ItemPreset.ExcludeCommonItems
				: ItemPreset.Custom;
			Configuration.Items.ItemPreset = itemPreset;
			Configuration.Items.ItemsList = new List<string>();
			Configuration.Items.FilterByItems = false;
			Configuration.Items.IncludeItems = false;
			Configuration.Items.ExcludeItems = false;

			// update advanced filter common items
			if (itemPreset.Equals(ItemPreset.ExcludeCommonItems))
			{
				Configuration.Items.ItemsList = Aetherbridge.GetInstance().ItemService.GetCommonItemNames();
				Configuration.Items.ExcludeItems = true;
				Configuration.Items.FilterByItems = true;
			}

			// save config
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void FiltersHighEndDutyOnlyChanged(object sender, bool e)
		{
			// update filter
			Configuration.Filters.HighEndDutyOnly = e;

			// update advanced filter
			var zonePreset = Configuration.Filters.HighEndDutyOnly ? ZonePreset.HighEndDuty : ZonePreset.Custom;
			Configuration.Zones.ZonePreset = zonePreset;
			Configuration.Zones.ZonesList = new List<string>();
			Configuration.Zones.FilterByZones = false;
			Configuration.Zones.IncludeZones = false;
			Configuration.Zones.ExcludeZones = false;

			// update advanced filter for high end duty zones
			if (zonePreset.Equals(ZonePreset.HighEndDuty))
			{
				Configuration.Zones.ZonesList = Aetherbridge.GetInstance().ContentService.GetHighEndContentNames();
				Configuration.Zones.IncludeZones = true;
				Configuration.Zones.FilterByZones = true;
			}

			// save config
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void LoggingEnabledChanged(object sender, bool e)
		{
			Configuration.Logging.LoggingEnabled = e;
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void LogFormatChanged(object sender, LogFormat e)
		{
			Configuration.Logging.LogFormat = e;
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void LogLocationChanged(object sender, string e)
		{
			if (e == null) return;
			if (e.Equals(string.Empty)) return;
			if (IsValidLogPath(e))
			{
				Configuration.Logging.LogLocation = e;
				KaptureConfig.ConfigManager.SaveSettings();
			}
			else
			{
				MessageBox.Show(@"Please enter valid log path.", @"Logging Error", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private void DiscordEnabledChanged(object sender, bool e)
		{
			Configuration.Discord.DiscordEnabled = e;
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void DiscordWebhookUrlChanged(object sender, string e)
		{
			if (e == null) return;
			if (e.Equals(string.Empty)) return;
			if (IsValidDiscordUrl(e))
			{
				Configuration.Discord.Endpoint = e;
				KaptureConfig.ConfigManager.SaveSettings();
			}
			else
			{
				MessageBox.Show(@"Please enter valid discord web hook.", @"Discord Error", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private void HTTPEnabledChanged(object sender, bool e)
		{
			Configuration.HTTP.HTTPEnabled = e;
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void HTTPChanged(object sender, string[] e)
		{
			if (e?[0] == null) return;
			if (e[0].Equals(string.Empty)) return;
			if (IsValidUrl(e[0]))
			{
				Configuration.HTTP.Endpoint = e[0];
				Configuration.HTTP.CustomJson = e[1];
				KaptureConfig.ConfigManager.SaveSettings();
			}
			else
			{
				MessageBox.Show(@"Please enter valid http server url.", @"HTTP Error", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		// MOVE TO SEPARATE CLASS...
		internal static bool IsValidUrl(string url)
		{
			return url != null &&
			       !url.Equals("") &&
			       Uri.IsWellFormedUriString(url, UriKind.Absolute);
		}

		private static bool IsValidLogPath(string path)
		{
			if (path == null || path.Equals(string.Empty)) return false;

			bool isValid;
			try
			{
				var _ = Path.GetFullPath(path);
				var root = Path.GetPathRoot(path);
				isValid = string.IsNullOrEmpty(root.Trim('\\', '/')) == false;
			}
			catch (Exception)
			{
				isValid = false;
			}

			return isValid;
		}

		internal static bool IsValidDiscordUrl(string url)
		{
			return url != null &&
			       !url.Equals("") &&
			       Uri.IsWellFormedUriString(url, UriKind.Absolute) && url.Contains(@"discordapp");
		}
	}
}