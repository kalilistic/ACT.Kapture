using System;
using System.Windows.Forms;
using ACT_FFXIV_Kapture.Resource;

namespace ACT_FFXIV_Kapture.Presentation
{
	public partial class BaseView : UserControl
	{
		public BaseView()
		{
			InitializeComponent();
			ViewPanel = (CustomPanel) Controls["viewPanel"];
			mainButton.Text = Strings.Main;
			advancedFiltersButton.Text = Strings.AdvancedFilters;
			checkForUpdatesButton.Text = Strings.CheckForUpdates;
			aboutButton.Text = Strings.About;
			mainButton.Click += MainButtonClicked;
			advancedFiltersButton.Click += AdvancedFiltersButtonClicked;
			checkForUpdatesButton.Click += CheckForUpdatesButtonClicked;
			aboutButton.Click += AboutButtonClicked;
		}

		public CustomPanel ViewPanel { get; set; }
		public event EventHandler<EventArgs> MainClicked;
		public event EventHandler<EventArgs> AdvancedFiltersClicked;
		public event EventHandler<EventArgs> CheckForUpdatesClicked;
		public event EventHandler<EventArgs> AboutClicked;


		private void MainButtonClicked(object sender, EventArgs e)
		{
			MainClicked?.Invoke(this, e);
		}

		private void AdvancedFiltersButtonClicked(object sender, EventArgs e)
		{
			AdvancedFiltersClicked?.Invoke(this, e);
		}

		private void CheckForUpdatesButtonClicked(object sender, EventArgs e)
		{
			CheckForUpdatesClicked?.Invoke(this, e);
		}

		private void AboutButtonClicked(object sender, EventArgs e)
		{
			AboutClicked?.Invoke(this, e);
		}
	}
}