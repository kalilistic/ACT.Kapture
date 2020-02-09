using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ACT_FFXIV_Kapture.Config;
using ACT_FFXIV_Kapture.Resource;

namespace ACT_FFXIV_Kapture.Presentation
{
	public partial class MainView : UserControl
	{
		public MainView()
		{
			InitializeComponent();
			SetupGeneral();
			SetupFilters();
			SetupLogging();
			SetupDiscord();
			SetupHTTP();
			SetupMessageLog();
		}

		public bool GeneralPluginEnabled
		{
			get => generalPluginEnabledCheckBox.Checked;
			set => generalPluginEnabledCheckBox.Checked = value;
		}

		public bool GeneralLogImportsEnabled
		{
			get => generalLogImportsEnabledCheckBox.Checked;
			set => generalLogImportsEnabledCheckBox.Checked = value;
		}

		public bool GeneralCheckForBetaEnabled
		{
			get => generalCheckForBetaVersionsCheckBox.Checked;
			set => generalCheckForBetaVersionsCheckBox.Checked = value;
		}

		public bool FiltersItemAddedEnabled
		{
			get => filtersItemAddedCheckBox.Checked;
			set => filtersItemAddedCheckBox.Checked = value;
		}

		public bool FiltersItemObtainedEnabled
		{
			get => filtersItemObtainedCheckBox.Checked;
			set => filtersItemObtainedCheckBox.Checked = value;
		}

		public bool FiltersItemRolledOnEnabled
		{
			get => filtersItemRolledOnCheckBox.Checked;
			set => filtersItemRolledOnCheckBox.Checked = value;
		}

		public bool FiltersItemLostEnabled
		{
			get => filtersItemLostCheckBox.Checked;
			set => filtersItemLostCheckBox.Checked = value;
		}

		public bool FiltersSelfEnabled
		{
			get => filtersSelfCheckBox.Checked;
			set => filtersSelfCheckBox.Checked = value;
		}

		public bool FiltersPartyEnabled
		{
			get => filtersPartyCheckBox.Checked;
			set => filtersPartyCheckBox.Checked = value;
		}

		public bool FiltersAllianceEnabled
		{
			get => filtersAllianceCheckBox.Checked;
			set => filtersAllianceCheckBox.Checked = value;
		}

		public bool FiltersExcludeCommonItems
		{
			get => filtersExcludeCommonItemsCheckBox.Checked;
			set => filtersExcludeCommonItemsCheckBox.Checked = value;
		}

		public bool FiltersHighEndDutyOnly
		{
			get => filtersHighEndDutyOnlyCheckBox.Checked;
			set => filtersHighEndDutyOnlyCheckBox.Checked = value;
		}

		public bool LoggingEnabled
		{
			get => loggingEnabledCheckBox.Checked;
			set => loggingEnabledCheckBox.Checked = value;
		}

		public LogFormat LogFormat
		{
			set
			{
				if (loggingFormatComboBox?.SelectedIndex != null)
					loggingFormatComboBox.SelectedIndex = loggingFormatComboBox.FindStringExact(value.Name);
			}
		}

		public string LogLocation
		{
			get => loggingLocationTextBox.Text;
			set => loggingLocationTextBox.Text = value;
		}

		public IList<LogFormat> LogFormatList
		{
			get => (List<LogFormat>) loggingFormatComboBox.DataSource;
			set => loggingFormatComboBox.DataSource = value;
		}

		public bool DiscordEnabled
		{
			get => discordEnabledCheckBox.Checked;
			set => discordEnabledCheckBox.Checked = value;
		}

		public string DiscordEndpoint
		{
			get => discordWebhookTextBox.Text;
			set => discordWebhookTextBox.Text = value;
		}

		public bool HTTPEnabled
		{
			get => httpEnabledCheckBox.Checked;
			set => httpEnabledCheckBox.Checked = value;
		}

		public string HTTPEndpoint
		{
			get => httpEndpointTextBox.Text;
			set => httpEndpointTextBox.Text = value;
		}

		public string HTTPCustomJson
		{
			get => httpCustomJsonTextBox.Text;
			set => httpCustomJsonTextBox.Text = value;
		}

		private void SetupGeneral()
		{
			generalGroupBox.Text = Strings.General;
			generalPluginEnabledCheckBox.Text = Strings.PluginEnabled;
			generalLogImportsEnabledCheckBox.Text = Strings.LogImportsEnabled;
			generalCheckForBetaVersionsCheckBox.Text = Strings.CheckForBeta;
			generalPluginEnabledCheckBox.CheckedChanged += GeneralPluginEnabledCheckBoxChanged;
			generalLogImportsEnabledCheckBox.CheckedChanged += GeneralLogImportsEnabledCheckBoxChanged;
			generalCheckForBetaVersionsCheckBox.CheckedChanged += GeneralCheckForBetaCheckBoxChanged;
		}

		private void SetupFilters()
		{
			filtersGroupBox.Text = Strings.Filters;
			filtersItemAddedCheckBox.Text = Strings.ItemAdded;
			filtersItemObtainedCheckBox.Text = Strings.ItemObtained;
			filtersItemRolledOnCheckBox.Text = Strings.ItemRolled;
			filtersItemLostCheckBox.Text = Strings.ItemLost;
			filtersSelfCheckBox.Text = Strings.Self;
			filtersPartyCheckBox.Text = Strings.Party;
			filtersAllianceCheckBox.Text = Strings.Alliance;
			filtersExcludeCommonItemsCheckBox.Text = Strings.ExcludeCommonItems;
			filtersHighEndDutyOnlyCheckBox.Text = Strings.HighEndDutyOnly;
			filtersItemAddedCheckBox.CheckedChanged += FiltersItemAddedEnabledCheckBoxChanged;
			filtersItemObtainedCheckBox.CheckedChanged += FiltersItemObtainedCheckBoxChanged;
			filtersItemLostCheckBox.CheckedChanged += FiltersItemLostEnabledCheckBoxChanged;
			filtersItemRolledOnCheckBox.CheckedChanged += FiltersItemRolledOnCheckBoxChanged;
			filtersSelfCheckBox.CheckedChanged += FiltersSelfEnabledCheckBoxChanged;
			filtersPartyCheckBox.CheckedChanged += FiltersPartyEnabledCheckBoxChanged;
			filtersAllianceCheckBox.CheckedChanged += FiltersAllianceEnabledCheckBoxChanged;
			filtersExcludeCommonItemsCheckBox.CheckedChanged += FiltersExcludeCommonItemsCheckBoxChanged;
			filtersHighEndDutyOnlyCheckBox.CheckedChanged += FiltersHighEndDutyOnlyCheckBoxChanged;
		}

		private void SetupLogging()
		{
			loggingGroupBox.Text = Strings.Logging;
			loggingEnabledCheckBox.Text = Strings.Enabled;
			loggingLocationLabel.Text = Strings.LogLocation;
			loggingFormatLabel.Text = Strings.LogFormat;
			loggingBrowseButton.Text = Strings.Browse;
			loggingUpdateButton.Text = Strings.Update;
			loggingEnabledCheckBox.CheckedChanged += LoggingEnabledCheckBoxChanged;
			loggingFormatComboBox.SelectedValueChanged += LogFormatComboBoxChanged;
			loggingBrowseButton.Click += LoggingBrowseButtonClicked;
			loggingUpdateButton.Click += LoggingUpdateButtonClicked;
		}

		private void SetupDiscord()
		{
			discordGroupBox.Text = Strings.Discord;
			discordEnabledCheckBox.Text = Strings.Enabled;
			discordWebhookLabel.Text = Strings.WebhookURL;
			discordUpdateButton.Text = Strings.Update;
			discordEnabledCheckBox.CheckedChanged += DiscordEnabledCheckBoxChanged;
			discordUpdateButton.Click += DiscordUpdateButtonClicked;
		}

		private void SetupHTTP()
		{
			httpGroupBox.Text = Strings.HTTP;
			httpEnabledCheckBox.Text = Strings.Enabled;
			httpEndpointLabel.Text = Strings.Endpoint;
			httpCustomJsonLabel.Text = Strings.CustomJSON;
			httpUpdateButton.Text = Strings.Update;

			httpEnabledCheckBox.CheckedChanged += HTTPEnabledCheckBoxChanged;
			httpUpdateButton.Click += HTTPUpdateButtonClicked;
		}

		private void SetupMessageLog()
		{
			messageLogGroupBox.Text = Strings.MessageLog;
		}

		public event EventHandler<bool> GeneralPluginEnabledChanged;
		public event EventHandler<bool> GeneralLogImportsEnabledChanged;
		public event EventHandler<bool> GeneralCheckForBetaChanged;
		public event EventHandler<bool> FiltersItemAddedEnabledChanged;
		public event EventHandler<bool> FiltersItemObtainedEnabledChanged;
		public event EventHandler<bool> FiltersItemRolledOnEnabledChanged;
		public event EventHandler<bool> FiltersItemLostEnabledChanged;
		public event EventHandler<bool> FiltersSelfEnabledChanged;
		public event EventHandler<bool> FiltersPartyEnabledChanged;
		public event EventHandler<bool> FiltersAllianceEnabledChanged;
		public event EventHandler<bool> FiltersExcludeCommonItemsChanged;
		public event EventHandler<bool> FiltersHighEndDutyOnlyChanged;
		public event EventHandler<bool> LoggingEnabledChanged;
		public event EventHandler<LogFormat> LogFormatChanged;
		public event EventHandler<string> LogLocationChanged;
		public event EventHandler<bool> DiscordEnabledChanged;
		public event EventHandler<string> DiscordWebhookUrlChanged;
		public event EventHandler<bool> HTTPEnabledChanged;
		public event EventHandler<string[]> HTTPChanged;

		private void GeneralPluginEnabledCheckBoxChanged(object sender, EventArgs e)
		{
			GeneralPluginEnabledChanged?.Invoke(sender, ((CheckBox) sender).Checked);
		}

		private void GeneralLogImportsEnabledCheckBoxChanged(object sender, EventArgs e)
		{
			GeneralLogImportsEnabledChanged?.Invoke(sender, ((CheckBox) sender).Checked);
		}

		private void GeneralCheckForBetaCheckBoxChanged(object sender, EventArgs e)
		{
			GeneralCheckForBetaChanged?.Invoke(sender, ((CheckBox) sender).Checked);
		}

		private void FiltersItemAddedEnabledCheckBoxChanged(object sender, EventArgs e)
		{
			FiltersItemAddedEnabledChanged?.Invoke(sender, ((CheckBox) sender).Checked);
		}

		private void FiltersItemObtainedCheckBoxChanged(object sender, EventArgs e)
		{
			FiltersItemObtainedEnabledChanged?.Invoke(sender, ((CheckBox) sender).Checked);
		}

		private void FiltersItemLostEnabledCheckBoxChanged(object sender, EventArgs e)
		{
			FiltersItemLostEnabledChanged?.Invoke(sender, ((CheckBox) sender).Checked);
		}

		private void FiltersItemRolledOnCheckBoxChanged(object sender, EventArgs e)
		{
			FiltersItemRolledOnEnabledChanged?.Invoke(sender, ((CheckBox) sender).Checked);
		}

		private void FiltersSelfEnabledCheckBoxChanged(object sender, EventArgs e)
		{
			FiltersSelfEnabledChanged?.Invoke(sender, ((CheckBox) sender).Checked);
		}

		private void FiltersPartyEnabledCheckBoxChanged(object sender, EventArgs e)
		{
			FiltersPartyEnabledChanged?.Invoke(sender, ((CheckBox) sender).Checked);
		}

		private void FiltersAllianceEnabledCheckBoxChanged(object sender, EventArgs e)
		{
			FiltersAllianceEnabledChanged?.Invoke(sender, ((CheckBox) sender).Checked);
		}

		private void FiltersExcludeCommonItemsCheckBoxChanged(object sender, EventArgs e)
		{
			FiltersExcludeCommonItemsChanged?.Invoke(sender, ((CheckBox) sender).Checked);
		}

		private void FiltersHighEndDutyOnlyCheckBoxChanged(object sender, EventArgs e)
		{
			FiltersHighEndDutyOnlyChanged?.Invoke(sender, ((CheckBox) sender).Checked);
		}

		private void LoggingEnabledCheckBoxChanged(object sender, EventArgs e)
		{
			LoggingEnabledChanged?.Invoke(sender, ((CheckBox) sender).Checked);
		}

		private void LogFormatComboBoxChanged(object sender, EventArgs e)
		{
			var customComboBox = (CustomComboBox) sender;
			if (!customComboBox.Focused) return;
			try
			{
				LogFormatChanged?.Invoke(sender, LogFormat.Parse(loggingFormatComboBox.SelectedItem.ToString()));
			}
			catch
			{
				// ignored
			}
		}

		private void LoggingUpdateButtonClicked(object sender, EventArgs e)
		{
			LogLocationChanged?.Invoke(sender, loggingLocationTextBox.Text);
		}

		private void LoggingBrowseButtonClicked(object sender, EventArgs e)
		{
			using (var fbd = new FolderBrowserDialog())
			{
				var result = fbd.ShowDialog();

				if (result != DialogResult.OK || string.IsNullOrWhiteSpace(fbd.SelectedPath)) return;
				LogLocation = fbd.SelectedPath;
				LogLocationChanged?.Invoke(sender, LogLocation);
			}
		}

		private void DiscordEnabledCheckBoxChanged(object sender, EventArgs e)
		{
			DiscordEnabledChanged?.Invoke(sender, ((CheckBox) sender).Checked);
		}

		private void DiscordUpdateButtonClicked(object sender, EventArgs e)
		{
			DiscordWebhookUrlChanged?.Invoke(sender, discordWebhookTextBox.Text);
		}

		private void HTTPEnabledCheckBoxChanged(object sender, EventArgs e)
		{
			HTTPEnabledChanged?.Invoke(sender, ((CheckBox) sender).Checked);
		}

		private void HTTPUpdateButtonClicked(object sender, EventArgs e)
		{
			var httpFields = new[] {httpEndpointTextBox.Text, httpCustomJsonTextBox.Text};
			HTTPChanged?.Invoke(sender, httpFields);
		}

		public void AddMessageToLog(string message)
		{
			messageLogListBox.Items.Add(message);
			if (messageLogListBox.Items.Count > 100) messageLogListBox.Items.RemoveAt(0);
			messageLogListBox.SelectedIndex = messageLogListBox.Items.Count - 1;
			messageLogListBox.ClearSelected();
		}
	}
}