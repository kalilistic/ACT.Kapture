namespace ACT_FFXIV.Aetherbridge
{
	public class PlaceName
	{
		public PlaceName(int id, string name)
		{
			Id = id;
			Name = name;
		}

		public int Id { get; set; }
		public string Name { get; set; }

		public override string ToString()
		{
			return Id + ":" + Name;
		}
	}
}