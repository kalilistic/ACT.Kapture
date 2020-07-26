using System.Collections.Generic;
using ACT_FFXIV_Kapture.Aetherbridge;

namespace ACT_FFXIV_Kapture.Plugin
{
	internal class FRLogLineParserContext : LogLineParserContextBase, ILogLineParserContext
	{
		public FRLogLineParserContext(IKaptureData kaptureData) : base(kaptureData)
		{
			ObtainRegex =
				LogLineParserUtil.CreateRegex(
					@"^(?<ActorNameWithWorldName>[^\s]+ ?[^\s]+).+?(?:obtenez|obtient|fabriquez|achetez) (?:une |un )?(?<RawItemName>.*?)(?:\.| pour )");
			ObtainWithMostRareRegex =
				LogLineParserUtil.CreateRegex(
					@"^(?<ActorNameWithWorldName>[^\s]+ ?[^\s]+).+?(?:découvrez et obtenez) (?:une |un )?(?<RawItemName>.*?)\.");
			FishRegex = LogLineParserUtil.CreateRegex(
				@"^(?<ActorNameWithWorldName>[^\s]+ ?[^\s]+).+?(?:avez pêché) (?:une |un )?(?<RawItemName>.*?) de (?<Size>.*).");
			UnableToObtainRegex =
				LogLineParserUtil.CreateRegex(@"^Impossible d'obtenir (?:les |le |la |)?(?<RawItemName>.*?)\.");
			ItemNameRegex =
				LogLineParserUtil.CreateRegex(@"^(?:(?:the )?(?<Quantity>[\d,\.]+[^\s]?) )?(?<ItemName>.*)");
			ItemAddedRegex =
				LogLineParserUtil.CreateRegex(@"^(?:Une |Un )(?<RawItemName>.*?) a été ajoutée au butin\.");
			GreedRegex =
				LogLineParserUtil.CreateRegex(
					@"^(?<ActorNameWithWorldName>[^\s]+(?: )?[^\s]+) (?:jette |jetez )les dés \(Cupidité\) pour (?:les |le |la |)(?<RawItemName>.*?)\. (?<Roll>.*)!");
			NeedRegex = LogLineParserUtil.CreateRegex(
				@"^(?<ActorNameWithWorldName>[^\s]+(?: )?[^\s]+) (?:jette |jetez )les dés \(Besoin\) pour (?:les |le |la |)(?<RawItemName>.*?)\. (?<Roll>.*)!");
			CastLotRegex = LogLineParserUtil.CreateRegex(
				@"^(?<ActorNameWithWorldName>[^\s]+(?: )?[^\s]+) (?:lance ses dés pour |lancez vos dés pour )(?:les |le |la |)(?<RawItemName>.*?)\.");
			SearchRegex = LogLineParserUtil.CreateRegex("^Recherche de l'objet “(?<RawItemName>.+)”...");
			ActorWithWorldNameRegex =
				LogLineParserUtil.CreateRegex(@"(?<ActorName>[A-Za-z'\-\.]+ [A-Za-z'\-\.]+)(?<WorldName>" + WorldsList +
				                              ")");
			LootFalsePositives = new List<string>();
			LeadingArticles = new List<string>();
			YouLocalized = "VOUS";
			NumberDelimiterLocalized = ",";
		}
	}
}