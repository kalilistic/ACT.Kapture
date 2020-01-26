using System.Collections.Generic;
using System.Linq;

namespace ACT_FFXIV_Kapture.Config
{
	public class ZonePreset
	{
		private static readonly List<ZonePreset> ZonePresetList = new List<ZonePreset>();

		public static readonly ZonePreset HighEndDuty = new ZonePreset("High-end Duty");
		public static readonly ZonePreset Custom = new ZonePreset("Custom");

		public ZonePreset()
		{
		}

		private ZonePreset(string name)
		{
			Name = name;
			ZonePresetList.Add(this);
		}

		public string Name { get; set; }

		public static IList<ZonePreset> ZonePresets => ZonePresetList;

		public static ZonePreset Parse(string strToParse)
		{
			return ZonePresets.FirstOrDefault(str => strToParse == str.Name);
		}

		public override string ToString()
		{
			return Name;
		}
	}
}