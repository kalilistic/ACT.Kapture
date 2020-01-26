using System;
using System.Windows.Forms;
using ACT_FFXIV_Kapture.Config;
using Configuration = ACT_FFXIV_Kapture.Config.Config;

namespace ACT_FFXIV_Kapture.Presentation
{
	public class HTTPPresenter
	{
		public Configuration Configuration;
		public KaptureConfig KaptureConfig;

		public HTTPPresenter(HTTPView httpView)
		{
			HTTPView = httpView;
			KaptureConfig = KaptureConfig.GetInstance();
			Configuration = (Configuration) KaptureConfig.ConfigManager.Config;

			HTTPView.HTTPEnabled = Configuration.HTTP.HTTPEnabled;
			HTTPView.Endpoint = Configuration.HTTP.Endpoint;
			HTTPView.CustomJson = Configuration.HTTP.CustomJson;

			HTTPView.HTTPEnabledChanged += HTTPEnabledChanged;
			HTTPView.HTTPUpdated += HTTPUpdated;
		}

		public HTTPView HTTPView { get; set; }

		private void HTTPEnabledChanged(object sender, bool e)
		{
			Configuration.HTTP.HTTPEnabled = e;
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void HTTPUpdated(object sender, string[] e)
		{
			if (HTTPView.Endpoint == null || HTTPView.Endpoint.Equals("")) return;
			if (IsValidUrl(HTTPView.Endpoint))
			{
				Configuration.HTTP.Endpoint = HTTPView.Endpoint;
				Configuration.HTTP.CustomJson = HTTPView.CustomJson;
				KaptureConfig.ConfigManager.SaveSettings();
			}
			else
			{
				MessageBox.Show(@"Please enter valid http server url.", @"HTTP Error", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		internal static bool IsValidUrl(string url)
		{
			return url != null &&
			       !url.Equals("") &&
			       Uri.IsWellFormedUriString(url, UriKind.Absolute);
		}
	}
}