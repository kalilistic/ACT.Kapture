using System.Net.Http;

namespace ACT_FFXIV.Aetherbridge.Updater.ReleaseDownloaderSettings
{
	public interface IReleaseDownloaderSettings
	{
		HttpClient HTTPClient { get; set; }
		string Author { get; set; }
		string Repository { get; set; }
		bool IncludePreRelease { get; set; }
		string DownloadDirPath { get; set; }
		IReleaseDownloaderSettings Copy();
	}
}