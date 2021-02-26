using System.Net.Http;
using ACT_FFXIV.Aetherbridge.Mocks.Properties;
using Newtonsoft.Json;
using NUnit.Framework;

namespace ACT_FFXIV.Aetherbridge.Test
{
	[TestFixture]
	public class UniversalisTest
	{
		[SetUp]
		public void Setup()
		{
			_httpClient = new HttpClient();
			_wrapper = new UniversalisWrapper(_httpClient);
		}

		[TearDown]
		public void TearDown()
		{
			_httpClient.Dispose();
		}

		private HttpClient _httpClient;
		private IUniversalisWrapper _wrapper;

		[Test]
		public void GetSummary_IT_ReturnsSummary()
		{
			var result = _wrapper.GetMarketBoard(63, 29436);
			Assert.IsNotNull(result);
		}

		[Test]
		public void GetSummary_ReturnsSuccess()
		{
			var response = Resources.universalis_response_success;
			var json = JsonConvert.DeserializeObject<dynamic>(response);
			var marketBoard = new MarketBoard(json);
			Assert.AreEqual(marketBoard.LastUploadTime, 1594492318137);
			Assert.AreEqual(marketBoard.ListingsCount, 28);
			Assert.AreEqual(marketBoard.SaleVelocity, 2.857142857142857);
			Assert.AreEqual(marketBoard.SaleVelocityNQ, 2);
			Assert.AreEqual(marketBoard.SaleVelocityHQ, 0.8571428571428571);
			Assert.AreEqual(marketBoard.AveragePrice, 1357.4);
			Assert.AreEqual(marketBoard.AveragePriceNQ, 886);
			Assert.AreEqual(marketBoard.AveragePriceHQ, 1832.3333333333333);
		}

		[Test]
		public void GetSummaryWithCache_IT_ReturnsSummaryFromCache()
		{
			var result1 = _wrapper.GetMarketBoard(63, 29436);
			var result2 = _wrapper.GetMarketBoard(63, 29436);
			Assert.AreEqual(result1.LastCheckTime, result2.LastCheckTime);
		}

		[Test]
		public void GetSummary_IT_ReturnsSummaryEmptyItem()
		{
			var result = _wrapper.GetMarketBoard(63, 6760);
			Assert.NotNull(result.LastCheckTime);
		}
	}
}