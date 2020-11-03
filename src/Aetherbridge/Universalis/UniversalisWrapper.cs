using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

// ReSharper disable ConvertIfStatementToReturnStatement

namespace ACT_FFXIV.Aetherbridge
{
	public class UniversalisWrapper : IUniversalisWrapper
	{
		private const string Endpoint = "https://universalis.app/api/";
		private static volatile IUniversalisWrapper _wrapper;
		private static readonly object Lock = new object();
		private static HttpClient _httpClient;
		private static MemoryCache _cache;

		public UniversalisWrapper(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_cache = new MemoryCache(new MemoryCacheOptions
			{
				CompactionPercentage = .50,
				SizeLimit = 1000
			});
		}

		public MarketBoard GetMarketBoard(int worldId, int itemId)
		{
			var requestKey = Convert.ToInt64(string.Empty + worldId + itemId);
			var marketBoardFromCache = _cache.Get(requestKey);
			if (marketBoardFromCache != null) return (MarketBoard) marketBoardFromCache;
			var marketBoardFromAPI = GetMarketBoardData(worldId, itemId);
			_cache.Set(requestKey, marketBoardFromAPI, new MemoryCacheEntryOptions
			{
				Size = 1,
				SlidingExpiration = TimeSpan.FromMinutes(90)
			});
			return marketBoardFromAPI;
		}

		public static IUniversalisWrapper GetInstance()
		{
			return _wrapper;
		}

		private static MarketBoard GetMarketBoardData(int worldId, int itemId)
		{
			var result = GetMarketBoardDataAsync(worldId, itemId).Result;
			if (result.StatusCode != HttpStatusCode.OK) return null;
			var json = JsonConvert.DeserializeObject<dynamic>(result.Content.ReadAsStringAsync().Result);
			if (json == null) return null;
			if (json.lastUploadTime.Value == 0) return null;
			try
			{
				return new MarketBoard(json);
			}
			catch (Exception)
			{
				return null;
			}
		}

		private static async Task<HttpResponseMessage> GetMarketBoardDataAsync(int worldId, int itemId)
		{
			return await _httpClient.GetAsync(new Uri(Endpoint + "/" + worldId + "/" + itemId));
		}


		public static void Initialize(HttpClient httpClient)
		{
			if (_wrapper != null) return;
			lock (Lock)
			{
				if (_wrapper == null)
					_wrapper = new UniversalisWrapper(httpClient);
			}
		}
	}
}