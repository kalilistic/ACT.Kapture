using ACT_FFXIV_Kapture.Aetherbridge;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ACT_FFXIV_Kapture.Model
{
	public class KaptureEvent : IXIVEvent
	{
		public KaptureEvent(EventType eventType, string eventTypeDesc)
		{
			EventType = eventType;
			EventTypeDesc = eventTypeDesc;
		}

		[JsonConverter(typeof(StringEnumConverter))]
		public EventType EventType { get; set; }

		public string EventTypeDesc { get; set; }

		public Item Item { get; set; }
		public Player Reporter { get; set; }
		public Player Actor { get; set; }
		public int Roll { get; set; }
		public Location Location { get; set; }
	}
}