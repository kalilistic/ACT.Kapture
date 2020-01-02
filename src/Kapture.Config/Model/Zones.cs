using System.Collections.Generic;

namespace ACT_FFXIV_Kapture.Config
{
    public class Zones
    {
        public bool FilterByZones { get; set; } = false;
        public ZonePreset ZonePreset { get; set; } = ZonePreset.HighEndDuty;
        public bool IncludeZones { get; set; }
        public bool ExcludeZones { get; set; }
        public List<string> ZonesList { get; set; } = new List<string>();
    }
}