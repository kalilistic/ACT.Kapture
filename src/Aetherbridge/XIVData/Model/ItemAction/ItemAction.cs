namespace ACT_FFXIV.Aetherbridge.XIVData.Model
{
	public class ItemAction : IGameData
	{
		public int Type { get; set; }
		public int Id { get; set; }

		public void SetPropsByStr(string[] propertyStr)
		{
			Id = int.Parse(propertyStr[0]);
			Type = int.Parse(propertyStr[1]);
		}
	}
}