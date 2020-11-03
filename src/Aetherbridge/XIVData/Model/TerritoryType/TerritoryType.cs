namespace ACT_FFXIV.Aetherbridge.XIVData.Model
{
	public class TerritoryType : IGameData
	{
		public int RegionPlaceNameId { get; set; }
		public int ZonePlaceNameId { get; set; }
		public int TerritoryPlaceNameId { get; set; }
		public int MapId { get; set; }
		public int Id { get; set; }

		public void SetPropsByStr(string[] propertyStr)
		{
			Id = int.Parse(propertyStr[0]);
			RegionPlaceNameId = int.Parse(propertyStr[1]);
			ZonePlaceNameId = int.Parse(propertyStr[2]);
			TerritoryPlaceNameId = int.Parse(propertyStr[3]);
			MapId = int.Parse(propertyStr[4]);
		}
	}
}