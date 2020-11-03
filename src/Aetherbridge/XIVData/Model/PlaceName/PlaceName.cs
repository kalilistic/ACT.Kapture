namespace ACT_FFXIV.Aetherbridge.XIVData.Model
{
	public class PlaceName : IGameData
	{
		public PlaceNameLocalized[] Localized { get; set; }

		public string Name { get; set; }
		public int Id { get; set; }

		public void SetPropsByStr(string[] propertyStr)
		{
			Id = int.Parse(propertyStr[0]);
			Localized = new[]
			{
				new PlaceNameLocalized
				{
					Language = LanguageEnum.en,
					Name = propertyStr[1]
				},
				new PlaceNameLocalized
				{
					Language = LanguageEnum.fr,
					Name = propertyStr[2]
				},
				new PlaceNameLocalized
				{
					Language = LanguageEnum.de,
					Name = propertyStr[3]
				},
				new PlaceNameLocalized
				{
					Language = LanguageEnum.ja,
					Name = propertyStr[4]
				}
			};
		}
	}
}