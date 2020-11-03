namespace ACT_FFXIV.Aetherbridge
{
	public class Content
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public bool IsHighEndDuty { get; set; }
		public int TerritoryTypeId { get; set; }

		public override string ToString()
		{
			return Id + ":" + Name;
		}
	}
}