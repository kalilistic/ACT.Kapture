using System.Collections.Generic;
using System.Text.RegularExpressions;
using ACT_FFXIV_Kapture.Aetherbridge;

namespace ACT_FFXIV_Kapture.Plugin
{
	public abstract class LogLineParserContextBase
	{
		protected LogLineParserContextBase(IKaptureData kaptureData)
		{
			KaptureData = kaptureData;
			WorldsList = KaptureData.WorldService.GetWorldsAsDelimitedString();
			PrefixRegex = LogLineParserUtil.CreateRegex(@"\[.{14}00:.{4}:(?<Residual>.*)");
			GameLogRegex = LogLineParserUtil.CreateRegex(@"\[.{14}00:");
			HQChars = new List<string> {"\uE03C", "\uE03D"};
			HQString = "(HQ)";
		}

		public Regex ObtainRegex { get; set; }
		public Regex ObtainWithMostRareRegex { get; set; }
		public Regex ObtainPassiveRegex { get; set; }
		public Regex FishRegex { get; set; }
		public Regex UnableToObtainRegex { get; set; }
		public Regex ItemNameRegex { get; set; }
		public Regex ItemAddedRegex { get; set; }
		public Regex GreedRegex { get; set; }
		public Regex NeedRegex { get; set; }
		public Regex CastLotRegex { get; set; }
		public Regex SearchRegex { get; set; }
		public Regex ActorWithWorldNameRegex { get; set; }
		public Regex PrefixRegex { get; set; }
		public Regex GameLogRegex { get; set; }
		public List<string> LootFalsePositives { get; set; }
		public List<string> LeadingArticles { get; set; }
		public string YouLocalized { get; set; }
		public string NumberDelimiterLocalized { get; set; }
		public Regex ItemQuantityRegex { get; set; }
		public Regex ObtainAltRegex { get; set; }
		public List<string> HQChars { get; set; }
		public string HQString { get; set; }
		public string WorldsList { get; set; }
		public IKaptureData KaptureData { get; set; }
	}
}