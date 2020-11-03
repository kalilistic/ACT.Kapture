namespace ACT_FFXIV.Aetherbridge.XIVData.Model
{
	public class Map : IGameData
	{
		public int MapPlaceNameId { get; set; }
		public int TerritoryTypeId { get; set; }
		public int Id { get; set; }

		public void SetPropsByStr(string[] propertyStr)
		{
			Id = int.Parse(propertyStr[0]);
			MapPlaceNameId = int.Parse(propertyStr[1]);
			TerritoryTypeId = int.Parse(propertyStr[2]);
		}
	}
}