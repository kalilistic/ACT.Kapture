using System.Collections.Generic;
using ACT_FFXIV_Kapture.Aetherbridge;

namespace ACT_FFXIV_Kapture.Plugin
{
	internal class ENLogLineParserContext : LogLineParserContextBase, ILogLineParserContext
	{
		public ENLogLineParserContext(IKaptureData kaptureData) : base(kaptureData)
		{
			ObtainRegex =
				LogLineParserUtil.CreateRegex(
					@"^(?<ActorNameWithWorldName>[^\s]+ ?[^\s]+).+?(?:(obtain|claim|(?<!de)synthesize|purchase)(?:s)? )(?:the |an |a )?(?<RawItemName>.*?)(?:\.| for )");
			ObtainWithMostRareRegex =
				LogLineParserUtil.CreateRegex(
					@"^(?<ActorNameWithWorldName>[^\s]+ ?[^\s]+) discover and obtain (?:the |an |a )?(?<RawItemName>.*?)─(?:items|an item) most rare!");
			ObtainPassiveRegex =
				LogLineParserUtil.CreateRegex(@"(?<RawItemName>(^([0-9]{1}:?){1,4})?.+?(?= is obtained.))");
			FishRegex = LogLineParserUtil.CreateRegex(
				@"^(?<ActorNameWithWorldName>[^\s]+ ?[^\s]+).+?(?:(?:land|spear)(?:s)? )(?:the |an |a )?(?<RawItemName>.*?) measuring (?<Size>.*?)!");
			UnableToObtainRegex =
				LogLineParserUtil.CreateRegex(@"^Unable to obtain (?:the |an |a )?(?<RawItemName>.*?)\.");
			ItemNameRegex = LogLineParserUtil.CreateRegex(@"^(?<Quantity>[\d,\,]+[^\s]?)? ?(?<ItemName>.*)");
			ItemAddedRegex =
				LogLineParserUtil.CreateRegex(@"^(?:The |An |A )?(?<RawItemName>.*?) has been added to the loot list.");
			GreedRegex =
				LogLineParserUtil.CreateRegex(
					@"^(?<ActorNameWithWorldName>[^\s]+ ?[^\s]+) roll[s]? Greed on (?:the |an |a )?(?<RawItemName>.*?)\. (?<Roll>.*)!");
			NeedRegex = LogLineParserUtil.CreateRegex(
				@"^(?<ActorNameWithWorldName>[^\s]+ ?[^\s]+) roll[s]? Need on (?:the |an |a )?(?<RawItemName>.*?)\. (?<Roll>.*)!");
			CastLotRegex = LogLineParserUtil.CreateRegex(
				@"^(?<ActorNameWithWorldName>[^\s]+ ?[^\s]+) cast[s]? (?:your|his|her) lot for (?:the |an |a )?(?<RawItemName>.*?)\.");
			SearchRegex = LogLineParserUtil.CreateRegex(@"^Searching for (?<RawItemName>.*?)\...");
			ActorWithWorldNameRegex =
				LogLineParserUtil.CreateRegex(@"(?<ActorName>[A-Za-z'\-\.]+ [A-Za-z'\-\.]+)(?<WorldName>" + WorldsList +
				                              ")");
			LootFalsePositives = new List<string> {"the company action", "achievement data."};
			LeadingArticles = new List<string> {"The ", "An ", "A "};
			YouLocalized = "YOU";
			NumberDelimiterLocalized = ",";
		}
	}
}