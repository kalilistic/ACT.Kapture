using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ACT_FFXIV.Aetherbridge
{
	public class Player
	{
		public uint Id { get; set; }
		public ClassJob ClassJob { get; set; }
		public int Level { get; set; }
		public string Name { get; set; }
		public World CurrentWorld { get; set; }
		public World HomeWorld { get; set; }

		[JsonConverter(typeof(StringEnumConverter))]
		public PartyTypeEnum PartyType { get; set; }

		public int Order { get; set; }
		public bool IsReporter { get; set; } = false;
	}
}