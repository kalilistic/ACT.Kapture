using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ACT_FFXIV_Aetherbridge;
using ACT_FFXIV_Kapture.Config;
using ACT_FFXIV_Kapture.Presentation.CustomControl;
using Configuration = ACT_FFXIV_Kapture.Config.Config;

namespace ACT_FFXIV_Kapture.Presentation
{
	public class MainPresenter
	{
		private readonly IAetherbridge _aetherbridge;
		private AboutPresenter _aboutPresenter;
		private DiscordPresenter _discordPresenter;
		private EventsPresenter _eventsPresenter;
		private GeneralPresenter _generalPresenter;
		private HTTPPresenter _httpPresenter;
		private ItemsPresenter _itemsPresenter;
		private LoggingPresenter _loggingPresenter;
		private MainView _mainView;
		private CustomPanel _viewPanel;
		private ZonesPresenter _zonesPresenter;

		public MainPresenter(MainView mainView, IAetherbridge aetherbridge)
		{
			_aetherbridge = aetherbridge;
			SetupMainView(mainView);
			SetupSubViews();
			SetupViewPanel();
		}

		private void SetupViewPanel()
		{
			_viewPanel = _mainView.ViewPanel;
			UpdateViewPanel(_generalPresenter.GeneralView);
		}

		private void SetupMainView(MainView mainView)
		{
			_mainView = mainView;
			_mainView.GeneralClicked += OpenGeneralView;
			_mainView.EventsClicked += OpenEventsView;
			_mainView.ItemsClicked += OpenItemsView;
			_mainView.ZonesClicked += OpenZonesView;
			_mainView.LoggingClicked += OpenLoggingView;
			_mainView.DiscordClicked += OpenDiscordView;
			_mainView.HTTPClicked += OpenHTTPView;
			_mainView.AboutClicked += OpenAboutView;
		}

		private void SetupSubViews()
		{
			var generalView = new GeneralView();
			_generalPresenter = new GeneralPresenter(generalView);

			var eventsView = new EventsView();
			_eventsPresenter = new EventsPresenter(eventsView);

			var config = (Configuration) KaptureConfig.GetInstance().Config;
			var itemsList = config.Items.ItemsList;
			var itemsView = new ItemsView(itemsList);
			_itemsPresenter = new ItemsPresenter(itemsView, _aetherbridge.ItemService);

			var zonesList = new List<string>();
			var zonesView = new ZonesView(zonesList);
			_zonesPresenter = new ZonesPresenter(zonesView, _aetherbridge.ContentService);

			var loggingView = new LoggingView();
			_loggingPresenter = new LoggingPresenter(loggingView);

			var discordView = new DiscordView();
			_discordPresenter = new DiscordPresenter(discordView);

			var httpView = new HTTPView();
			_httpPresenter = new HTTPPresenter(httpView);

			var aboutView = new AboutView();
			_aboutPresenter = new AboutPresenter(aboutView);
		}

		private void UpdateViewPanel(Control userControl)
		{
			if (_viewPanel.Controls.Count > 0)
			{
				var oldView = _viewPanel.Controls[0] as UserControl;
				if (oldView != null && oldView.Name.Equals(userControl.Name)) return;
				if (oldView != null) _viewPanel.Controls.Remove(oldView);
			}

			_viewPanel.Controls.Add(userControl);
		}

		private void OpenGeneralView(object sender, EventArgs e)
		{
			UpdateViewPanel(_generalPresenter.GeneralView);
		}

		private void OpenEventsView(object sender, EventArgs e)
		{
			UpdateViewPanel(_eventsPresenter.EventsView);
		}

		private void OpenItemsView(object sender, EventArgs e)
		{
			UpdateViewPanel(_itemsPresenter.ItemsView);
		}

		private void OpenZonesView(object sender, EventArgs e)
		{
			UpdateViewPanel(_zonesPresenter.ZonesView);
		}

		private void OpenLoggingView(object sender, EventArgs e)
		{
			UpdateViewPanel(_loggingPresenter.LoggingView);
		}

		private void OpenDiscordView(object sender, EventArgs e)
		{
			UpdateViewPanel(_discordPresenter.DiscordView);
		}

		private void OpenHTTPView(object sender, EventArgs e)
		{
			UpdateViewPanel(_httpPresenter.HTTPView);
		}

		private void OpenAboutView(object sender, EventArgs e)
		{
			UpdateViewPanel(_aboutPresenter.AboutView);
		}
	}
}