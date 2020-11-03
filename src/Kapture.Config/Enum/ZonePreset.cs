using System.Collections.Generic;
using System.Linq;
using ACT_FFXIV_Kapture.Resource;

namespace ACT_FFXIV_Kapture.Config.Enum
{
	public class ZonePreset
	{
		private static readonly List<ZonePreset> ZonePresetList = new List<ZonePreset>();

		public static readonly ZonePreset HighEndDuty = new ZonePreset(Strings.HighEndDuty);
		public static readonly ZonePreset Custom = new ZonePreset(Strings.Custom);

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