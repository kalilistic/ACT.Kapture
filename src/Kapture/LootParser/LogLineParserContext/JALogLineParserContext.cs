using System.Collections.Generic;
using ACT_FFXIV_Kapture.Aetherbridge;

namespace ACT_FFXIV_Kapture.Plugin
{
	internal class JALogLineParserContext : LogLineParserContextBase, ILogLineParserContext
	{
		public JALogLineParserContext(IKaptureData kaptureData) : base(kaptureData)
		{
			ObtainRegex =
				LogLineParserUtil.CreateRegex(
					@"^(?<ActorNameWithWorldName>.+)(?:は|に)(?<RawItemName>.+)(?:を入手した|を手に入れた|が分配されました|を完成させた)(?:。|！)");
			ObtainWithMostRareRegex =
				LogLineParserUtil.CreateRegex(@"^(?<ActorNameWithWorldName>.+)は希少なほりだしもの(?<RawItemName>.+)を入手した！");
			FishRegex = LogLineParserUtil.CreateRegex(
				@"^(?<ActorNameWithWorldName>.+)(?:は|に)(?<RawItemName>.+)（(?<Size>[\d,\.,\,]+イルム)）(?:を(?:釣り上げた|入手した))。");
			UnableToObtainRegex = LogLineParserUtil.CreateRegex(@"^(?<RawItemName>.+)を手に入れることができなかった。");
			ItemNameRegex = null;
			ItemAddedRegex = LogLineParserUtil.CreateRegex(@"^(?<RawItemName>.+)が戦利品に追加されました。");
			GreedRegex =
				LogLineParserUtil.CreateRegex(
					@"^(?<ActorNameWithWorldName>.+)は(?<RawItemName>.+)にGREEDのダイスで(?<Roll>.*)を出した。");
			NeedRegex = LogLineParserUtil.CreateRegex(
				@"^(?<ActorNameWithWorldName>.+)は(?<RawItemName>.+)にNEEDのダイスで(?<Roll>.*)を出した。");
			CastLotRegex = LogLineParserUtil.CreateRegex(@"^(?<ActorNameWithWorldName>.+)は(?<RawItemName>.+)にロットした。");
			SearchRegex = LogLineParserUtil.CreateRegex(@"^(?<RawItemName>.+)の所持状況を確認します。");
			ActorWithWorldNameRegex =
				LogLineParserUtil.CreateRegex(@"(?<ActorName>[A-Za-z'\-\.]+ [A-Za-z'\-\.]+)(?<WorldName>" + WorldsList +
				                              ")");
			LootFalsePositives = new List<string>();
			LeadingArticles = new List<string>();
			NumberDelimiterLocalized = ",";
			ObtainAltRegex =
				LogLineParserUtil.CreateRegex(@"^(?<RawItemName>.+)(?:(?:を入手した|を手に入れた|をマーケットで購入しました)。|を[1-9])");
			ItemQuantityRegex = LogLineParserUtil.CreateRegex(@"×(?<Quantity>[0-9,]+)");
		}
	}
}