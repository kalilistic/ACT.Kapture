using ACT_FFXIV_Kapture.Aetherbridge;
using ACT_FFXIV_Kapture.Model;
using ACT_FFXIV_Kapture.Resource;

namespace ACT_FFXIV_Kapture.Plugin
{
	internal class JALogLineParser : LogLineParserBase, ILogLineParser
	{
		public JALogLineParser(ILogLineParserContext context) : base(context)
		{
		}

		public new LogLineEvent Parse(ACTLogLineEvent actLogLineEvent)
		{
			base.Parse(actLogLineEvent);
			return LogLineEvent;
		}

		public override Item FindItem(string itemName, int quantity)
		{
			return Context.KaptureData.ItemService.GetItemBySingularName(itemName);
		}

		protected override bool IsObtainLoot()
		{
			var match = Context.ObtainRegex.Match(LogLineEvent.LogMessage);
			if (match.Success)
			{
				LogLineEvent.KaptureEvent =
					new KaptureEvent(EventType.ObtainLoot, Strings.ItemObtained)
					{
						Item = CreateItem(match),
						Actor = CreateActor(match)
					};
				return match.Success;
			}

			match = Context.ObtainAltRegex.Match(LogLineEvent.LogMessage);
			if (!match.Success) return match.Success;
			LogLineEvent.KaptureEvent = new KaptureEvent(EventType.ObtainLoot, Strings.ItemObtained)
			{
				Item = CreateItem(match),
				Actor = CreateActor(match)
			};
			return match.Success;
		}

		protected override void ParseItemNameAndQuantity(DraftItem draftItem)
		{
			const string gil = @"ギル";
			const char currencyIndicator = '×';
			string quantityStr;
			if (draftItem.RawItemName.EndsWith(gil))
			{
				quantityStr = draftItem.RawItemName.Replace(gil, string.Empty);
			}
			else
			{
				var match = Context.ItemQuantityRegex.Match(draftItem.RawItemName);
				quantityStr = match.Groups["Quantity"].Value;
			}

			try
			{
				draftItem.Quantity = int.Parse(quantityStr.Replace(Context.NumberDelimiterLocalized, string.Empty));
				draftItem.ItemName = draftItem.RawItemName.Replace(quantityStr, string.Empty);
				if (draftItem.ItemName[draftItem.ItemName.Length - 1] == currencyIndicator)
					draftItem.ItemName = draftItem.ItemName.Remove(draftItem.ItemName.Length - 1);
			}
			catch
			{
				draftItem.Quantity = 1;
				draftItem.ItemName = draftItem.RawItemName;
			}
		}

		private void NormalizeObtainCommon()
		{
			if (LogLineEvent.KaptureEvent.Item == null) return;
			var itemName = LogLineEvent.KaptureEvent.Item.ProperName;
			if (LogLineEvent.KaptureEvent.Item.IsHQ) itemName += Context.HQString;

			if (LogLineEvent.KaptureEvent.Item.Quantity > 1)
				itemName += "×" + $"{LogLineEvent.KaptureEvent.Item.Quantity:n0}";
			LogLineEvent.LogMessage =
				LogLineEvent.KaptureEvent.Actor.Name + "は" + itemName + "を手に入れた。";
		}
	}
}