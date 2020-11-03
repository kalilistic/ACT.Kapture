namespace ACT_FFXIV_Kapture.Config.Model
{
	public class Filters
	{
		public bool ItemAdded { get; set; } = false;
		public bool ItemObtained { get; set; } = true;
		public bool ItemRolledOn { get; set; } = false;
		public bool ItemLost { get; set; } = false;
		public bool ItemCastLot { get; set; } = false;
		public bool ItemSearched { get; set; } = true;
		public bool Self { get; set; } = true;
		public bool Party { get; set; } = false;
		public bool Alliance { get; set; } = false;
		public bool ExcludeCommonItems { get; set; } = false;
		public bool IncludeMountsOnly { get; set; } = false;
		public bool HighEndDutyOnly { get; set; } = false;
	}
}