using System.Collections.Generic;
using ACT_FFXIV_Kapture.Config.Enum;

namespace ACT_FFXIV_Kapture.Config.Model
{
	public class Zones
	{
		public bool FilterByZones { get; set; } = false;
		public ZonePreset ZonePreset { get; set; } = ZonePreset.Custom;
		public bool IncludeZones { get; set; }
		public bool ExcludeZones { get; set; }
		public List<string> ZonesList { get; set; } = new List<string>();
	}
}