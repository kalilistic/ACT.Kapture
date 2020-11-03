using ACT_FFXIV.Aetherbridge;
using ACT_FFXIV_Kapture.Model;

namespace ACT_FFXIV_Kapture.Plugin
{
	internal class DELogLineParser : LogLineParserBase, ILogLineParser
	{
		public DELogLineParser(ILogLineParserContext context) : base(context)
		{
		}

		public new LogLineEvent Parse(ACTLogLineEvent actLogLineEvent)
		{
			base.Parse(actLogLineEvent);
			return LogLineEvent;
		}

		public override Item FindItem(string itemName, int quantity)
		{
			return quantity > 1
				? Context.KaptureData.ItemService.GetItemByPluralSearchTermDE(itemName)
				: Context.KaptureData.ItemService.GetItemBySingularSearchTermDE(itemName);
		}
	}
}