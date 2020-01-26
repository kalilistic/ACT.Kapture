using StarkUserConfig;

namespace ACT_FFXIV_Kapture.Config
{
	public class Config : IConfig
	{
		public Config()
		{
			General = new General();
			Items = new Items();
			Events = new Events();
			Zones = new Zones();
			Logging = new Logging();
			Discord = new Discord();
			HTTP = new HTTP();
		}

		public General General { get; set; }
		public Items Items { get; set; }
		public Events Events { get; set; }
		public Zones Zones { get; set; }
		public Logging Logging { get; set; }
		public Discord Discord { get; set; }
		public HTTP HTTP { get; set; }
	}
}