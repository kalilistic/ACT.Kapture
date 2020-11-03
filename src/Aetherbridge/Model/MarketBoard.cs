using System;

namespace ACT_FFXIV.Aetherbridge
{
	public class MarketBoard
	{
		public MarketBoard(dynamic json)
		{
			LastCheckTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
			LastUploadTime = json.lastUploadTime?.Value;
			ListingsCount = json.listings?.Count;
			SaleVelocity = json.regularSaleVelocity?.Value;
			SaleVelocityNQ = json.nqSaleVelocity?.Value;
			SaleVelocityHQ = json.hqSaleVelocity?.Value;
			AveragePrice = json.averagePrice?.Value;
			AveragePriceNQ = json.averagePriceNQ?.Value;
			AveragePriceHQ = json.averagePriceHQ?.Value;
		}

		public long LastCheckTime { get; set; }
		public long? LastUploadTime { get; set; }
		public int? ListingsCount { get; set; }
		public double? SaleVelocity { get; set; }
		public double? SaleVelocityNQ { get; set; }
		public double? SaleVelocityHQ { get; set; }
		public double? AveragePrice { get; set; }
		public double? AveragePriceNQ { get; set; }
		public double? AveragePriceHQ { get; set; }
	}
}