using StarkUserConfig;

namespace ACT_FFXIV_Kapture.Config
{
	public class Config : IConfig
	{
		public Config()
		{
			General = new General();
			Items = new Items();
			Filters = new Filters();
			Zones = new Zones();
			Logging = new Logging();
			Discord = new Discord();
			HTTP = new HTTP();
			XIVPlugin = new XIVPlugin();
		}

		public General General { get; set; }
		public Items Items { get; set; }
		public Filters Filters { get; set; }
		public Zones Zones { get; set; }
		public Logging Logging { get; set; }
		public Discord Discord { get; set; }
		public HTTP HTTP { get; set; }
		public XIVPlugin XIVPlugin { get; set; }
	}
}