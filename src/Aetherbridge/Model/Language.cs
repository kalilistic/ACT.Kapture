namespace ACT_FFXIV.Aetherbridge
{
	public class Language
	{
		public Language(int id, string name, string abbreviation)
		{
			Id = id;
			Index = id - 1;
			Name = name;
			Abbreviation = abbreviation;
		}

		public int Id { get; set; }
		public int Index { get; set; }
		public string Name { get; set; }
		public string Abbreviation { get; set; }

		public override string ToString()
		{
			return Name + "(" + Id + ")";
		}
	}
}