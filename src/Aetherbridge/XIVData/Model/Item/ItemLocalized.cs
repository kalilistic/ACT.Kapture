namespace ACT_FFXIV.Aetherbridge.XIVData.Model
{
	public class ItemLocalized : ILocalizedData
	{
		public string ProperName { get; set; }
		public string SingularName { get; set; }
		public string PluralName { get; set; }
		public string SingularSearchTerm { get; set; }
		public string PluralSearchTerm { get; set; }
		public string SingularREP { get; set; }
		public string PluralREP { get; set; }
		public LanguageEnum Language { get; set; }
	}
}