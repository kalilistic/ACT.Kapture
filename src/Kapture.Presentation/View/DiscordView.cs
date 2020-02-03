using System;
using System.Windows.Forms;
using ACT_FFXIV_Kapture.Resource;

namespace ACT_FFXIV_Kapture.Presentation
{
	public partial class DiscordView : UserControl
	{
		public DiscordView()
		{
			InitializeComponent();
			discord_DiscordEnabledCheckBox.Text = Strings.DiscordEnabled;
			discord_UpdateButton.Text = Strings.Update;
			discord_WebhookLabel.Text = Strings.WebhookURL;
			discord_DiscordEnabledCheckBox.CheckedChanged += DiscordEnabledCheckBox_Changed;
			discord_UpdateButton.Click += UpdateButton_Clicked;
		}

		public bool DiscordEnabled
		{
			get => discord_DiscordEnabledCheckBox.Checked;
			set => discord_DiscordEnabledCheckBox.Checked = value;
		}

		public string Endpoint
		{
			get => discord_EndpointTextBox.Text;
			set => discord_EndpointTextBox.Text = value;
		}

		public event EventHandler<bool> DiscordEnabledChanged;
		public event EventHandler<string> DiscordUpdated;

		private void DiscordEnabledCheckBox_Changed(object sender, EventArgs e)
		{
			DiscordEnabledChanged?.Invoke(sender, ((CheckBox) sender).Checked);
		}

		private void UpdateButton_Clicked(object sender, EventArgs e)
		{
			DiscordUpdated?.Invoke(sender, discord_EndpointTextBox.Text);
		}
	}
}