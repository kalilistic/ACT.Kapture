using System.Collections.Generic;
using System.Linq;

namespace ACT_FFXIV_Kapture.Config
{
	public class ItemPreset
	{
		private static readonly List<ItemPreset> ItemPresetList = new List<ItemPreset>();

		public static readonly ItemPreset ExcludeCommonItems = new ItemPreset("Common Items");
		public static readonly ItemPreset Custom = new ItemPreset("Custom");

		public ItemPreset()
		{
		}

		private ItemPreset(string name)
		{
			Name = name;
			ItemPresetList.Add(this);
		}

		public string Name { get; set; }

		public static IList<ItemPreset> ItemPresets => ItemPresetList;

		public static ItemPreset Parse(string strToParse)
		{
			return ItemPresets.FirstOrDefault(str => strToParse == str.Name);
		}

		public override string ToString()
		{
			return Name;
		}
	}
}