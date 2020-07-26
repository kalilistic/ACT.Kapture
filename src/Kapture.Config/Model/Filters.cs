namespace ACT_FFXIV_Kapture.Config
{
	public class Filters
	{
		public bool ItemAdded { get; set; } = true;
		public bool ItemObtained { get; set; } = true;
		public bool ItemRolledOn { get; set; } = true;
		public bool ItemLost { get; set; } = true;
		public bool ItemCastLot { get; set; } = true;
		public bool ItemSearched { get; set; } = true;
		public bool Self { get; set; } = true;
		public bool Party { get; set; } = true;
		public bool Alliance { get; set; } = false;
		public bool ExcludeCommonItems { get; set; } = true;
		public bool IncludeMountsOnly { get; set; } = false;
		public bool HighEndDutyOnly { get; set; } = false;
	}
}