namespace ACT_FFXIV.Aetherbridge.Updater.ReleaseDownloader
{
	public interface IReleaseDownloader
	{
		bool IsLatestRelease(string version);
		bool DownloadLatestRelease();
		void DeInit();
	}
}