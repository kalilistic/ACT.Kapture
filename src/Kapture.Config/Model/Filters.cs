namespace ACT_FFXIV_Kapture.Config
{
	public class Filters
	{
		public bool ItemAdded { get; set; } = true;
		public bool ItemObtained { get; set; } = true;
		public bool ItemRolledOn { get; set; } = false;
		public bool ItemLost { get; set; } = false;
		public bool Self { get; set; } = true;
		public bool Party { get; set; } = true;
		public bool Alliance { get; set; } = false;
		public bool ExcludeCommonItems { get; set; } = true;
		public bool HighEndDutyOnly { get; set; } = false;
		public bool FilterByZones { get; set; } = false;
	}
}