using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace ACT_FFXIV.Aetherbridge
{
	public class Item
	{
		public int Id { get; set; }
		public string ProperName { get; set; }
		public string SingularName { get; set; }
		public string PluralName { get; set; }
		public bool IsUntradable { get; set; }
		public bool IsMarketable { get; set; }
		public int VendorBuyPrice { get; set; }
		public int Quantity { get; set; }
		public bool IsHQ { get; set; }
		public bool IsCommon { get; set; }
		public string Size { get; set; }
		public MarketBoard MarketBoard { get; set; }

		[JsonIgnore] public bool IsRetired { get; set; }

		[JsonIgnore] public string SingularSearchTerm { get; set; }

		[JsonIgnore] public string PluralSearchTerm { get; set; }

		[JsonIgnore] public string SingularREP { get; set; }

		[JsonIgnore] public string PluralREP { get; set; }

		[JsonIgnore] public Regex SingularRegex { get; set; }

		[JsonIgnore] public Regex PluralRegex { get; set; }
	}
}