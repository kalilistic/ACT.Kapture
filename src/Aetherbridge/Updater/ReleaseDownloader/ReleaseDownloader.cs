using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using ACT_FFXIV.Aetherbridge.Updater.ReleaseDownloaderSettings;
using Semver;

namespace ACT_FFXIV.Aetherbridge.Updater.ReleaseDownloader
{
	public class ReleaseDownloader : IReleaseDownloader
	{
		private readonly string _releasesEndpoint;
		private readonly IReleaseDownloaderSettings _settings;

		public ReleaseDownloader(IReleaseDownloaderSettings settings)
		{
			_settings = settings.Copy();
			_settings.HTTPClient.DefaultRequestHeaders.Add("User-Agent", _settings.Repository);
			_releasesEndpoint = "https://api.github.com/repos/" + _settings.Author + "/" + _settings.Repository +
			                    "/releases";
		}

		public bool IsLatestRelease(string version)
		{
			SemVersion semVersion;
			try
			{
				semVersion = SemVersion.Parse(CleanVersion(version));
			}
			catch (Exception)
			{
				throw new Exception("Invalid version.");
			}

			var latestRelease = GetLatestRelease();
			return semVersion >= latestRelease.Value;
		}

		public bool DownloadLatestRelease()
		{
			var latestReleaseId = GetLatestRelease().Key;
			var assetUrls = GetAssetUrlsAsync(latestReleaseId).Result;

			while (!Directory.Exists(_settings.DownloadDirPath))
			{
				Directory.CreateDirectory(_settings.DownloadDirPath);
				Thread.Sleep(1);
			}

			foreach (var assetUrl in assetUrls) GetAssetsAsync(assetUrl);

			return true;
		}

		public void DeInit()
		{
			_settings.HTTPClient.DefaultRequestHeaders.Remove("User-Agent");
		}

		private static string CleanVersion(string version)
		{
			var cleanedVersion = version;
			cleanedVersion = cleanedVersion.StartsWith("v") ? cleanedVersion.Substring(1) : cleanedVersion;
			var buildDelimiterIndex = cleanedVersion.LastIndexOf("+", StringComparison.Ordinal);
			cleanedVersion = buildDelimiterIndex > 0
				? cleanedVersion.Substring(0, buildDelimiterIndex)
				: cleanedVersion;
			return cleanedVersion;
		}

		// ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
		private KeyValuePair<string, SemVersion> GetLatestRelease()
		{
			var releases = GetReleasesAsync().Result;
			var latestRelease = releases.First();

			foreach (var release in releases)
				if (SemVersion.Compare(release.Value, latestRelease.Value) > 0)
					latestRelease = release;

			return latestRelease;
		}

		// ReSharper disable once SwitchStatementMissingSomeCases
		private static void VerifyGitHubAPIResponse(HttpStatusCode statusCode, string content)
		{
			switch (statusCode)
			{
				case HttpStatusCode.Forbidden when content.Contains("API rate limit exceeded"):
					throw new Exception("GitHub API rate limit exceeded.");
				case HttpStatusCode.NotFound when content.Contains("Not Found"):
					throw new Exception("GitHub Repo not found.");
				default:
				{
					if (statusCode != HttpStatusCode.OK) throw new Exception("GitHub API call failed.");
					break;
				}
			}
		}

		private async Task<List<string>> GetAssetUrlsAsync(string releaseId)
		{
			var assets = new List<string>();
			var assetsEndpoint = _releasesEndpoint + "/" + releaseId + "/assets";
			var response = await _settings.HTTPClient.GetAsync(new Uri(assetsEndpoint));
			var contentJson = await response.Content.ReadAsStringAsync();
			VerifyGitHubAPIResponse(response.StatusCode, contentJson);
			var jsonSerializer = new JavaScriptSerializer();
			var assetsJson = jsonSerializer.Deserialize<dynamic>(contentJson);
			foreach (var assetJson in assetsJson) assets.Add(assetJson["browser_download_url"].ToString());

			return assets;
		}

		// ReSharper disable once AssignNullToNotNullAttribute
		private void GetAssetsAsync(string assetUrl)
		{
			try
			{
				var path = Path.Combine(_settings.DownloadDirPath, Path.GetFileName(assetUrl));
				using (var client = new WebClient())
				{
					Console.WriteLine(assetUrl + " | " + path);
					client.DownloadFile(new Uri(assetUrl), path);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message + " | " + ex.StackTrace);
				throw new Exception("Release assets download failed.");
			}
		}

		private async Task<Dictionary<string, SemVersion>> GetReleasesAsync()
		{
			var pageNumber = "1";
			var releases = new Dictionary<string, SemVersion>();
			while (pageNumber != null)
			{
				var response = await _settings.HTTPClient.GetAsync(new Uri(_releasesEndpoint + "?page=" + pageNumber));
				var contentJson = await response.Content.ReadAsStringAsync();
				VerifyGitHubAPIResponse(response.StatusCode, contentJson);
				var jsonSerializer = new JavaScriptSerializer();
				var releasesJson = jsonSerializer.Deserialize<dynamic>(contentJson);
				foreach (var releaseJson in releasesJson)
				{
					bool preRelease = releaseJson["prerelease"];
					if (!_settings.IncludePreRelease && preRelease) continue;
					var releaseId = releaseJson["id"].ToString();
					try
					{
						string tagName = releaseJson["tag_name"].ToString();
						var version = CleanVersion(tagName);
						var semVersion = SemVersion.Parse(version);
						releases.Add(releaseId, semVersion);
					}
					catch (Exception)
					{
						// ignored
					}
				}

				pageNumber = GetNextPageNumber(response.Headers);
			}

			return releases;
		}

		private static string GetNextPageNumber(HttpHeaders headers)
		{
			string linkHeader;
			try
			{
				linkHeader = headers.GetValues("Link").FirstOrDefault();
			}
			catch (Exception)
			{
				return null;
			}

			if (string.IsNullOrWhiteSpace(linkHeader)) return null;
			var links = linkHeader.Split(',');
			return !links.Any()
				? null
				: (
					from link in links
					where link.Contains(@"rel=""next""")
					select Regex.Match(link, "(?<=page=)(.*)(?=>;)").Value).FirstOrDefault();
		}
	}
}