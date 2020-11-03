using System.Net.Http;

namespace ACT_FFXIV.Aetherbridge
{
	public class PluginUpdaterSettings
	{
		public string AuthorName;
		public string FailureMessage;
		public HttpClient HTTPClient;
		public bool IncludePreRelease;
		public string PluginPath;
		public string RepoName;
		public string RestartMessage;
		public string UpdateMessage;
		public string Version;
	}
}