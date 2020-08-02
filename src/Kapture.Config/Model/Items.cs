using System.Collections.Generic;

namespace ACT_FFXIV_Kapture.Config
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