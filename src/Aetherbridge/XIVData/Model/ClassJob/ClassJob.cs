namespace ACT_FFXIV.Aetherbridge.XIVData.Model
{
	public class ClassJob : IGameData
	{
		public ClassJob()
		{
		}

		public ClassJob(int id)
		{
			Id = id;
		}

		public int Category { get; set; }
		public string Role { get; set; }
		public ClassJobLocalized[] Localized { get; set; }

		public int Id { get; set; }

		public void SetPropsByStr(string[] propertyStr)
		{
			Id = int.Parse(propertyStr[0]);
			Category = int.Parse(propertyStr[1]);
			Role = propertyStr[2];
			Localized = new[]
			{
				new ClassJobLocalized
				{
					Language = LanguageEnum.en,
					Name = propertyStr[3],
					Abbreviation = propertyStr[4]
				},
				new ClassJobLocalized
				{
					Language = LanguageEnum.fr,
					Name = propertyStr[5],
					Abbreviation = propertyStr[6]
				},
				new ClassJobLocalized
				{
					Language = LanguageEnum.de,
					Name = propertyStr[7],
					Abbreviation = propertyStr[8]
				},
				new ClassJobLocalized
				{
					Language = LanguageEnum.ja,
					Name = propertyStr[9],
					Abbreviation = propertyStr[10]
				}
			};
		}
	}
}