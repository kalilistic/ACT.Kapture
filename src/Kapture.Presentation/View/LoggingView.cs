using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ACT_FFXIV_Kapture.Config;
using ACT_FFXIV_Kapture.Presentation.CustomControl;
using ACT_FFXIV_Kapture.Resource;

namespace ACT_FFXIV_Kapture.Presentation
{
	public partial class LoggingView : UserControl
	{
		public LoggingView()
		{
			InitializeComponent();
			logging_LoggingEnabledCheckBox.Text = Strings.LoggingEnabled;
			logging_LogFormatLabel.Text = Strings.LogFormat;
			logging_LogLocationLabel.Text = Strings.LogLocation;
			logging_BrowseButton.Text = Strings.Browse;
			logging_UpdateButton.Text = Strings.Update;
			logging_LoggingEnabledCheckBox.CheckedChanged += LoggingEnabledCheckBox_Changed;
			logging_LogFormatComboBox.SelectedValueChanged += LogFormatComboBox_Changed;
			logging_UpdateButton.Click += UpdateButton_Clicked;
			logging_BrowseButton.Click += BrowseButton_Clicked;
		}

		public bool LoggingEnabled
		{
			get => logging_LoggingEnabledCheckBox.Checked;
			set => logging_LoggingEnabledCheckBox.Checked = value;
		}

		public LogFormat LogFormat
		{
			set
			{
				if (logging_LogFormatComboBox?.SelectedIndex != null)
					logging_LogFormatComboBox.SelectedIndex = logging_LogFormatComboBox.FindStringExact(value.Name);
			}
		}

		public string LogLocation
		{
			get => logging_LogLocationTextBox.Text;
			set => logging_LogLocationTextBox.Text = value;
		}

		public IList<LogFormat> LogFormatList
		{
			get => (List<LogFormat>) logging_LogFormatComboBox.DataSource;
			set => logging_LogFormatComboBox.DataSource = value;
		}

		public event EventHandler<bool> LoggingEnabledChanged;
		public event EventHandler<LogFormat> LogFormatChanged;
		public event EventHandler<string> LogLocationUpdated;

		private void LoggingEnabledCheckBox_Changed(object sender, EventArgs e)
		{
			LoggingEnabledChanged?.Invoke(sender, ((CheckBox) sender).Checked);
		}

		private void LogFormatComboBox_Changed(object sender, EventArgs e)
		{
			var customComboBox = (CustomComboBox) sender;
			if (!customComboBox.Focused) return;
			try
			{
				LogFormatChanged?.Invoke(sender, LogFormat.Parse(logging_LogFormatComboBox.SelectedItem.ToString()));
			}
			catch
			{
				// ignored
			}
		}

		private void UpdateButton_Clicked(object sender, EventArgs e)
		{
			LogLocationUpdated?.Invoke(sender, logging_LogLocationTextBox.Text);
		}

		private void BrowseButton_Clicked(object sender, EventArgs e)
		{
			using (var fbd = new FolderBrowserDialog())
			{
				var result = fbd.ShowDialog();

				if (result != DialogResult.OK || string.IsNullOrWhiteSpace(fbd.SelectedPath)) return;
				LogLocation = fbd.SelectedPath;
				LogLocationUpdated?.Invoke(sender, LogLocation);
			}
		}

		private void logging_LogLocationTextBox_TextChanged(object sender, EventArgs e)
		{
		}
	}
}