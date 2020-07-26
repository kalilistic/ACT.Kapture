using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ACT_FFXIV_Kapture.Plugin
{
	public interface ILogLineParserContext
	{
		Regex ObtainRegex { get; set; }
		Regex ObtainWithMostRareRegex { get; set; }
		Regex ObtainPassiveRegex { get; set; }
		Regex FishRegex { get; set; }
		Regex UnableToObtainRegex { get; set; }
		Regex ItemNameRegex { get; set; }
		Regex ItemAddedRegex { get; set; }
		Regex GreedRegex { get; set; }
		Regex NeedRegex { get; set; }
		Regex CastLotRegex { get; set; }
		Regex SearchRegex { get; set; }
		Regex ActorWithWorldNameRegex { get; set; }
		Regex PrefixRegex { get; set; }
		List<string> LootFalsePositives { get; set; }
		List<string> LeadingArticles { get; set; }
		string YouLocalized { get; set; }
		string NumberDelimiterLocalized { get; set; }
		Regex ItemQuantityRegex { get; set; }
		Regex ObtainAltRegex { get; set; }
		List<string> HQChars { get; set; }
		string HQString { get; set; }
		string WorldsList { get; set; }
		IKaptureData KaptureData { get; set; }
	}
}