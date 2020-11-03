using ACT_FFXIV.Aetherbridge.XIVData.Model;

namespace ACT_FFXIV.Aetherbridge.Mocks
{
	public class GameDataLocalizedMock : ILocalizedData
	{
		public string Name { get; set; }
		public LanguageEnum Language { get; set; }
	}
}