namespace ACT_FFXIV.Aetherbridge.XIVData.Model
{
	public class Item : IGameData
	{
		public ItemLocalized[] Localized { get; set; }
		public bool IsCommon { get; set; }
		public bool IsRetired { get; set; }
		public bool IsUntradable { get; set; }
		public int VendorBuyPrice { get; set; }
		public int ItemAction { get; set; }
		public int ItemSearchCategory { get; set; }
		public int Id { get; set; }

		public void SetPropsByStr(string[] propertyStr)
		{
			Id = int.Parse(propertyStr[0]);
			ItemSearchCategory = int.Parse(propertyStr[1]);
			IsUntradable = bool.Parse(propertyStr[2]);
			VendorBuyPrice = int.Parse(propertyStr[3]);
			ItemAction = int.Parse(propertyStr[4]);
			Localized = new[]
			{
				new ItemLocalized
				{
					Language = LanguageEnum.en,
					SingularName = propertyStr[5],
					PluralName = propertyStr[6],
					ProperName = propertyStr[7],
					SingularSearchTerm = propertyStr[8],
					PluralSearchTerm = propertyStr[9],
					SingularREP = propertyStr[10],
					PluralREP = propertyStr[11]
				},
				new ItemLocalized
				{
					Language = LanguageEnum.fr,
					SingularName = propertyStr[12],
					PluralName = propertyStr[13],
					ProperName = propertyStr[14],
					SingularSearchTerm = propertyStr[15],
					PluralSearchTerm = propertyStr[16],
					SingularREP = propertyStr[17],
					PluralREP = propertyStr[18]
				},
				new ItemLocalized
				{
					Language = LanguageEnum.de,
					SingularName = propertyStr[19],
					PluralName = propertyStr[20],
					ProperName = propertyStr[21],
					SingularSearchTerm = propertyStr[22],
					PluralSearchTerm = propertyStr[23],
					SingularREP = propertyStr[24],
					PluralREP = propertyStr[25]
				},
				new ItemLocalized
				{
					Language = LanguageEnum.ja,
					SingularName = propertyStr[26],
					PluralName = propertyStr[27],
					ProperName = propertyStr[28],
					SingularSearchTerm = propertyStr[29],
					PluralSearchTerm = propertyStr[30],
					SingularREP = propertyStr[31],
					PluralREP = propertyStr[32]
				}
			};

			IsCommon = bool.Parse(propertyStr[33]);
			IsRetired = bool.Parse(propertyStr[34]);
		}
	}
}