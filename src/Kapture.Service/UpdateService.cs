using System;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Windows.Forms;
using ACT_FFXIV_Kapture.Resource;
using GitHub.ReleaseDownloader;

namespace ACT_FFXIV_Kapture.Service
{
	public class UpdateService
	{
		private static volatile UpdateService _updateService;
		private static readonly object Lock = new object();
		private static ReleaseDownloader _betaDownloader;
		private static ReleaseDownloader _downloader;
		private static CultureInfo _cultureInfo;
		private static Logger _logger;


		private UpdateService(HttpClient httpClient, string version, string pluginPath, string lang, Logger logger)
		{
			_cultureInfo = new CultureInfo(lang);
			_logger = logger;
			Version = version;
			_betaDownloader =
				new ReleaseDownloader(new ReleaseDownloaderSettings(httpClient, AuthorName, RepoName, true,
					pluginPath));
			_downloader =
				new ReleaseDownloader(
					new ReleaseDownloaderSettings(httpClient, AuthorName, RepoName, false, pluginPath));
		}

		public string AppName { get; } = @"Kapture";
		public string RepoName { get; } = @"Kapture";
		public string AuthorName { get; } = @"kalilistic";
		public string KaptureLog { get; set; }
		public string Version { get; set; }

		public void UpdatePlugin(bool includeBeta, bool includeSuccessPrompt)
		{
			Thread.CurrentThread.CurrentUICulture = _cultureInfo;
			Thread.CurrentThread.CurrentCulture = _cultureInfo;
			try
			{
				var downloader = includeBeta ? _betaDownloader : _downloader;
				var isMostRecentVersion = downloader.IsLatestRelease(Version);
				if (isMostRecentVersion)
				{
					if (includeSuccessPrompt)
						MessageBox.Show(Strings.PluginHaveLatest, AppName,
							MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					var result = MessageBox.Show(Strings.PluginUpdateAvailable,
						AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (result != DialogResult.Yes) return;
					var status = downloader.DownloadLatestRelease();
					if (status)
						MessageBox.Show(Strings.PluginNeedRestart, AppName,
							MessageBoxButtons.OK, MessageBoxIcon.Information);
					else
						MessageBox.Show(Strings.PluginUpdateFailed, AppName,
							MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{
				_logger.Error(Strings.PluginUpdateFailed, ex);
				MessageBox.Show(Strings.PluginUpdateFailed, AppName,
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void DeInit()
		{
			_betaDownloader.DeInit();
			_downloader.DeInit();
			_updateService = null;
		}

		public static UpdateService GetInstance()
		{
			return _updateService;
		}

		public static void Initialize(HttpClient httpClient, string version, string pluginPath, string lang,
			Logger logger)
		{
			if (_updateService != null) return;
			lock (Lock)
			{
				if (_updateService == null)
					_updateService = new UpdateService(httpClient, version, pluginPath, lang, logger);
			}
		}
	}
}