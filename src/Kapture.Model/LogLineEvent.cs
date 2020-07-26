using System;
using ACT_FFXIV_Kapture.Aetherbridge;

namespace ACT_FFXIV_Kapture.Model
{
	public class LogLineEvent
	{
		public LogLineEvent()
		{
			Id = Guid.NewGuid().ToString();
		}

		public string Id { get; set; }
		public ACTLogLineEvent ACTLogLineEvent { get; set; }
		public KaptureEvent KaptureEvent { get; set; }
		public string Timestamp { get; set; }
		public string LogCode { get; set; }
		public string GameLogCode { get; set; }
		public string LogMessage { get; set; }

		public string GetMessageWithTimestamp()
		{
			return @"[" + Timestamp + @"] " + LogMessage;
		}

		public string GetShorthand()
		{
			var shorthand = KaptureEvent.EventTypeDesc;
			if (KaptureEvent.Actor != null) shorthand = shorthand + " [" + KaptureEvent.Actor.Name + "]";
			shorthand = shorthand + ": " + KaptureEvent.Item.ProperName;
			if (KaptureEvent.Item.Quantity > 1) shorthand = shorthand + " ×" + KaptureEvent.Item.Quantity;
			return shorthand;
		}
	}
}