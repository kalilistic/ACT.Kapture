using System;
using System.Net.Http;
using System.Windows.Forms;
using GitHub.ReleaseDownloader;

namespace ACT_FFXIV_Kapture.Service
{
    public class PluginService : IPluginService
    {
        private static volatile PluginService _pluginService;
        private static readonly object Lock = new object();
        private static ReleaseDownloader _betaDownloader;
        private static ReleaseDownloader _downloader;


        private PluginService(HttpClient httpClient, string version, string pluginPath)
        {
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
            try
            {
                var downloader = includeBeta ? _betaDownloader : _downloader;
                var isMostRecentVersion = downloader.IsLatestRelease(Version);
                if (isMostRecentVersion)
                {
                    if (includeSuccessPrompt)
                        MessageBox.Show("You already have the latest version of the Kapture plugin.", AppName,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var result = MessageBox.Show("Update for Kapture plugin available. Do you want to download it now?",
                        AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result != DialogResult.Yes) return;
                    var status = downloader.DownloadLatestRelease();
                    if (status)
                        MessageBox.Show("Kapture plugin updated successfully. Please restart ACT now.", AppName,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Failed to download update. Please try again later or check GitHub.", AppName,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Update check failed. Please try again later or check GitHub.", AppName,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeInit()
        {
            _betaDownloader.DeInit();
            _downloader.DeInit();
            _pluginService = null;
        }

        public static IPluginService GetInstance()
        {
            return _pluginService;
        }

        public static void Initialize(HttpClient httpClient, string version, string pluginPath)
        {
            if (_pluginService != null) return;
            lock (Lock)
            {
                if (_pluginService == null)
                    _pluginService = new PluginService(httpClient, version, pluginPath);
            }
        }
    }
}