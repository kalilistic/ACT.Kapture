using ACT_FFXIV_Kapture.Aetherbridge;
using ACT_FFXIV_Kapture.Model;

namespace ACT_FFXIV_Kapture.Plugin
{
	internal class ENLogLineParser : LogLineParserBase, ILogLineParser
	{
		public ENLogLineParser(ILogLineParserContext context) : base(context)
		{
			Context = context;
		}

		public new LogLineEvent Parse(ACTLogLineEvent actLogLineEvent)
		{
			base.Parse(actLogLineEvent);
			return LogLineEvent;
		}

		public override Item FindItem(string itemName, int quantity)
		{
			return quantity > 1 || LogLineEvent.KaptureEvent.EventType == EventType.SearchLoot
				? Context.KaptureData.ItemService.GetItemByPluralSearchTerm(itemName)
				: Context.KaptureData.ItemService.GetItemBySingularSearchTerm(itemName);
		}
	}
}