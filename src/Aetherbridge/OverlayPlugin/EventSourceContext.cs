using System.Collections.Generic;

namespace ACT_FFXIV.Aetherbridge
{
	public class EventSourceContext
	{
		public string Name { get; set; }
		public List<string> EventTypes { get; set; }
		public List<EventHandler> EventHandlers { get; set; }
		public List<OverlayPreset> OverlayPresets { get; set; }
	}
}