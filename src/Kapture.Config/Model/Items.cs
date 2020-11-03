using System.Collections.Generic;
using ACT_FFXIV_Kapture.Config.Enum;

namespace ACT_FFXIV_Kapture.Config.Model
{
	public class Items
	{
		public bool FilterByItems { get; set; } = false;
		public ItemPreset ItemPreset { get; set; } = ItemPreset.Custom;
		public bool IncludeItems { get; set; }
		public bool ExcludeItems { get; set; }
		public List<string> ItemsList { get; set; } = new List<string>();
	}
}