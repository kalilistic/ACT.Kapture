namespace ACT_FFXIV.Aetherbridge.XIVData.Model
{
	public class World : IGameData
	{
		public World()
		{
		}

		public World(int id)
		{
			Id = id;
		}

		public string Name { get; set; }

		public int Id { get; set; }

		public void SetPropsByStr(string[] propertyStr)
		{
			Id = int.Parse(propertyStr[0]);
			Name = propertyStr[1];
		}
	}
}