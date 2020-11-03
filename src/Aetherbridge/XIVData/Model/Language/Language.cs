namespace ACT_FFXIV.Aetherbridge.XIVData.Model
{
	public class Language : IGameData
	{
		public string Name { get; set; }
		public string Abbreviation { get; set; }
		public int Id { get; set; }

		public void SetPropsByStr(string[] propertyStr)
		{
			Id = int.Parse(propertyStr[0]);
			Name = propertyStr[1];
			Abbreviation = propertyStr[2];
		}
	}
}