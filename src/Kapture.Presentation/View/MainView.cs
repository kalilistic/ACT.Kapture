using System;
using System.Windows.Forms;
using ACT_FFXIV_Kapture.Presentation.CustomControl;

namespace ACT_FFXIV_Kapture.Presentation
{
	public partial class MainView : UserControl
	{
		public MainView()
		{
			InitializeComponent();
			ViewPanel = (CustomPanel) Controls["viewPanel"];
			generalButton.Click += GeneralBtn_Click;
			eventsButton.Click += EventsBtn_Click;
			itemsButton.Click += ItemsBtn_Click;
			zonesButton.Click += ZonesBtn_Click;
			loggingButton.Click += LoggingBtn_Click;
			discordButton.Click += DiscordBtn_Click;
			httpButton.Click += HTTPBtn_Click;
			aboutButton.Click += AboutBtn_Click;
		}

		public CustomPanel ViewPanel { get; set; }
		public event EventHandler<EventArgs> GeneralClicked;
		public event EventHandler<EventArgs> EventsClicked;
		public event EventHandler<EventArgs> ItemsClicked;
		public event EventHandler<EventArgs> ZonesClicked;
		public event EventHandler<EventArgs> LoggingClicked;
		public event EventHandler<EventArgs> DiscordClicked;
		public event EventHandler<EventArgs> HTTPClicked;
		public event EventHandler<EventArgs> AboutClicked;

		private void GeneralBtn_Click(object sender, EventArgs e)
		{
			GeneralClicked?.Invoke(this, e);
		}

		private void EventsBtn_Click(object sender, EventArgs e)
		{
			EventsClicked?.Invoke(this, e);
		}

		private void ItemsBtn_Click(object sender, EventArgs e)
		{
			ItemsClicked?.Invoke(this, e);
		}

		private void ZonesBtn_Click(object sender, EventArgs e)
		{
			ZonesClicked?.Invoke(this, e);
		}

		private void LoggingBtn_Click(object sender, EventArgs e)
		{
			LoggingClicked?.Invoke(this, e);
		}

		private void DiscordBtn_Click(object sender, EventArgs e)
		{
			DiscordClicked?.Invoke(this, e);
		}

		private void HTTPBtn_Click(object sender, EventArgs e)
		{
			HTTPClicked?.Invoke(this, e);
		}

		private void AboutBtn_Click(object sender, EventArgs e)
		{
			AboutClicked?.Invoke(this, e);
		}
	}
}