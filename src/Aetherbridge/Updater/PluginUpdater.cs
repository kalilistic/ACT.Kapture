using System;
using System.Windows.Forms;

namespace ACT_FFXIV.Aetherbridge.Updater
{
	public class UpdateService
	{
		public static void UpdatePlugin(PluginUpdaterSettings settings)
		{
			try
			{
				var downloader = new ReleaseDownloader.ReleaseDownloader(new ReleaseDownloaderSettings.ReleaseDownloaderSettings(
					settings.HTTPClient, settings.AuthorName, settings.RepoName, settings.IncludePreRelease,
					settings.PluginPath));
				if (downloader.IsLatestRelease(settings.Version)) return;
				var result = MessageBox.Show(settings.UpdateMessage,
					settings.RepoName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result != DialogResult.Yes) return;
				var status = downloader.DownloadLatestRelease();
				if (status)
				{
					ACTWrapper.GetInstance().Restart(settings.RestartMessage);
				}
				else
				{
					MessageBox.Show(settings.FailureMessage, settings.RepoName,
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (Exception)
			{
				MessageBox.Show(settings.FailureMessage, settings.RepoName,
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}