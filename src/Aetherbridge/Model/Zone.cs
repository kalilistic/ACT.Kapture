namespace ACT_FFXIV.Aetherbridge
{
	public class Zone
	{
		public Zone()
		{
		}

		public Zone(uint id, string name)
		{
			Id = id;
			Name = name;
		}

		public uint Id { get; set; }
		public string Name { get; set; }

		public override string ToString()
		{
			return Name + "(" + Id + ")";
		}
	}
}