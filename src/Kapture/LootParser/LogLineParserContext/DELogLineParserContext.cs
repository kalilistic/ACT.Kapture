using System.Collections.Generic;
using ACT_FFXIV_Kapture.Aetherbridge;

namespace ACT_FFXIV_Kapture.Plugin
{
	internal class DELogLineParserContext : LogLineParserContextBase, ILogLineParserContext
	{
		public DELogLineParserContext(IKaptureData kaptureData) : base(kaptureData)
		{
			ObtainRegex =
				LogLineParserUtil.CreateRegex(
					@"^(?<ActorNameWithWorldName>[^\s]+ ?[^\s]+).+?(?:hast|hat) (?:erfolgreich )?(?:einen |eine |ein )?(?<RawItemName>.*?) (?:für [1-9]|(?:erhalten|hergestellt|gekauft).)");
			ObtainWithMostRareRegex =
				LogLineParserUtil.CreateRegex(
					@"^(?<ActorNameWithWorldName>[^\s]+ ?[^\s]+).+?findest und erhältst (?:einen |eine |ein )?(?<RawItemName>.*?) - (?:einen |eine |ein )?höchst seltener (?:Fund|Gegenstand)!");
			FishRegex = LogLineParserUtil.CreateRegex(
				@"^(?<ActorNameWithWorldName>[^\s]+ ?[^\s]+).+?(?:hast|hat) (?:einen |eine |ein )?(?<RawItemName>.*?) \((?<Size>.*?)\) (?:gefangen|aufgespießt).");
			UnableToObtainRegex =
				LogLineParserUtil.CreateRegex(@"^Du konntest (?:das |der |die )?(?<RawItemName>.*?) nicht erhalten\.");
			ItemNameRegex = LogLineParserUtil.CreateRegex(@"^((the )?(?<Quantity>[\d,\.]+[^\s]?) )?(?<ItemName>.*)");
			ItemAddedRegex =
				LogLineParserUtil.CreateRegex(
					@"^Ihr habt Beutegut \((?:einen |eine |ein )?(?<RawItemName>.*?)\) erhalten\.");
			GreedRegex =
				LogLineParserUtil.CreateRegex(
					@"^(?<ActorNameWithWorldName>[^\s]+ ?[^\s]+) würfel(s)?t mit „Gier“ (?:einen |eine |ein )?(?<Roll>.*) auf (?:das |der |die )?(?<RawItemName>.+)\.");
			NeedRegex = LogLineParserUtil.CreateRegex(
				@"^(?<ActorNameWithWorldName>[^\s]+ ?[^\s]+) würfel(s)?t mit „Bedarf“ (?:einen |eine |ein )?(?<Roll>.*) auf (?:das |der |die )?(?<RawItemName>.+)\.");
			CastLotRegex =
				LogLineParserUtil.CreateRegex(
					@"^(?<ActorNameWithWorldName>[^\s]+ ?[^\s]+) würfel(s)?t um d(?:en|ie) (?<RawItemName>.+)\.");
			SearchRegex = LogLineParserUtil.CreateRegex(@"^(?:Das |Der |Die )(?<RawItemName>.+) wird gesucht.");
			ActorWithWorldNameRegex =
				LogLineParserUtil.CreateRegex(@"(?<ActorName>[A-Za-z'\-\.]+ [A-Za-z'\-\.]+)(?<WorldName>" + WorldsList +
				                              ")");
			LootFalsePositives = new List<string>();
			LeadingArticles = new List<string>();
			YouLocalized = "DU";
			NumberDelimiterLocalized = ".";
		}
	}
}