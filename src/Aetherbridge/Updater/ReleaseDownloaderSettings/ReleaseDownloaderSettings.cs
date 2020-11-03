using System;
using System.Net.Http;

namespace ACT_FFXIV.Aetherbridge.Updater.ReleaseDownloaderSettings
{
	public class ReleaseDownloaderSettings : IReleaseDownloaderSettings
	{
		public ReleaseDownloaderSettings(HttpClient httpClient, string author, string repository,
			bool includePreRelease, string downloadDirPath)
		{
			HTTPClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
			Author = author ?? throw new ArgumentNullException(nameof(author));
			Repository = repository ?? throw new ArgumentNullException(nameof(repository));
			IncludePreRelease = includePreRelease;
			DownloadDirPath = downloadDirPath;
		}

		public HttpClient HTTPClient { get; set; }
		public string Author { get; set; }
		public string Repository { get; set; }
		public bool IncludePreRelease { get; set; }
		public string DownloadDirPath { get; set; }

		public IReleaseDownloaderSettings Copy()
		{
			return new ReleaseDownloaderSettings(HTTPClient, string.Copy(Author),
				string.Copy(Repository),
				IncludePreRelease, string.Copy(DownloadDirPath));
		}
	}
}