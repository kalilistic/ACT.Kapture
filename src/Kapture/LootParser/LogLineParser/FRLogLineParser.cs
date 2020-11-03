using ACT_FFXIV.Aetherbridge;
using ACT_FFXIV_Kapture.Model;

namespace ACT_FFXIV_Kapture.Plugin
{
	internal class FRLogLineParser : LogLineParserBase, ILogLineParser
	{
		public FRLogLineParser(ILogLineParserContext context) : base(context)
		{
		}

		public new LogLineEvent Parse(ACTLogLineEvent actLogLineEvent)
		{
			base.Parse(actLogLineEvent);
			if (LogLineEvent == null) return LogLineEvent;
			LogLineEvent.LogMessage = LogLineEvent.LogMessage.Replace(Context.HQString, " " + Context.HQString);
			LogLineEvent.LogMessage = LogLineEvent.LogMessage.Replace("  ", " ");
			return LogLineEvent;
		}

		public override Item FindItem(string itemName, int quantity)
		{
			if (LogLineEvent.KaptureEvent.EventType == EventType.SearchLoot)
				return Context.KaptureData.ItemService.GetItemByProperName(itemName);
			return quantity > 1
				? Context.KaptureData.ItemService.GetItemByPluralName(itemName)
				: Context.KaptureData.ItemService.GetItemBySingularName(itemName);
		}
	}
}