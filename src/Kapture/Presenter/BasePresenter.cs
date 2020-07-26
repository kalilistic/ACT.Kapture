using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACT_FFXIV_Kapture.Aetherbridge;
using ACT_FFXIV_Kapture.Config;
using Configuration = ACT_FFXIV_Kapture.Config.Config;

namespace ACT_FFXIV_Kapture.Plugin
{
	public class BasePresenter
	{
		private readonly IKaptureData _kaptureData;
		private readonly KaptureGUILogger _logger;
		private readonly CustomPanel _viewPanel;
		private AboutPresenter _aboutPresenter;
		private AdvancedPresenter _advancedPresenter;
		private BaseView _baseView;
		private MainPresenter _mainPresenter;

		public BasePresenter(BaseView baseView, IKaptureData kaptureData, KaptureGUILogger logger)
		{
			_kaptureData = kaptureData;
			_logger = logger;
			SetupBaseView(baseView);
			_viewPanel = _baseView.ViewPanel;
			OpenMainView(this, null);
			Task.Run(InitAdvancedPresenter);
		}

		public void DeInit()
		{
			_mainPresenter.MainView.Dispose();
			_advancedPresenter.AdvancedView.Dispose();
			_aboutPresenter.AboutView.Dispose();
			_viewPanel.Dispose();
		}

		private void SetupBaseView(BaseView baseView)
		{
			_baseView = baseView;
			_baseView.MainClicked += OpenMainView;
			_baseView.AdvancedFiltersClicked += OpenAdvancedView;
			_baseView.AboutClicked += OpenAboutView;
		}

		private void UpdateViewPanel(Control userControl)
		{
			Cursor.Current = Cursors.WaitCursor;
			if (_viewPanel.Controls.Count > 0)
			{
				var oldView = _viewPanel.Controls[0] as UserControl;
				if (oldView != null && oldView.Name.Equals(userControl.Name)) return;
				if (oldView != null)
				{
					_viewPanel.Visible = false;
					_viewPanel.Controls.Remove(oldView);
					oldView.Dispose();
				}
			}

			_viewPanel.Controls.Add(userControl);
			_viewPanel.Visible = true;
			Cursor.Current = Cursors.Default;
		}

		private void OpenMainView(object sender, EventArgs e)
		{
			var mainView = new MainView();
			_mainPresenter = new MainPresenter(mainView, _logger);
			UpdateViewPanel(_mainPresenter.MainView);
		}

		private void OpenAdvancedView(object sender, EventArgs e)
		{
			InitAdvancedPresenter();
			UpdateViewPanel(_advancedPresenter.AdvancedView);
		}

		private void InitAdvancedPresenter()
		{
			var config = (Configuration) KaptureConfig.GetInstance().Config;
			var itemsList = config.Items.ItemsList;
			var zonesList = new List<string>();
			var advancedView = new AdvancedView(itemsList, zonesList);
			_advancedPresenter =
				new AdvancedPresenter(advancedView, _kaptureData.ItemService, _kaptureData.ContentService);
		}

		private void OpenAboutView(object sender, EventArgs e)
		{
			var aboutView = new AboutView();
			_aboutPresenter = new AboutPresenter(aboutView);
			UpdateViewPanel(_aboutPresenter.AboutView);
		}
	}
}