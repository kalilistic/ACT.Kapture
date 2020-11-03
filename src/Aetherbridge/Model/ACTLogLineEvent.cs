using System;

namespace ACT_FFXIV.Aetherbridge
{
	public class ACTLogLineEvent
	{
		public DateTime DetectedTime { get; set; }
		public string DetectedZone { get; set; }
		public bool InCombat { get; set; }
		public bool IsImport { get; set; }
		public string LogLine { get; set; }
	}
}