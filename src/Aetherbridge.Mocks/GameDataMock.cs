using ACT_FFXIV.Aetherbridge.XIVData.Model;

namespace ACT_FFXIV.Aetherbridge.Mocks
{
	public class GameDataMock : IGameData
	{
		public int TerritoryType { get; set; }
		public bool HighEndDuty { get; set; }
		public GameDataLocalizedMock[] Localized { get; set; }
		public int Id { get; set; }

		public void SetPropsByStr(string[] propertyStr)
		{
			Id = int.Parse(propertyStr[0]);
			TerritoryType = int.Parse(propertyStr[1]);
			HighEndDuty = bool.Parse(propertyStr[2]);
			Localized = new[]
			{
				new GameDataLocalizedMock
				{
					Language = LanguageEnum.en,
					Name = propertyStr[3]
				},
				new GameDataLocalizedMock
				{
					Language = LanguageEnum.fr,
					Name = propertyStr[4]
				},
				new GameDataLocalizedMock
				{
					Language = LanguageEnum.de,
					Name = propertyStr[5]
				},
				new GameDataLocalizedMock
				{
					Language = LanguageEnum.ja,
					Name = propertyStr[6]
				}
			};
		}
	}
}