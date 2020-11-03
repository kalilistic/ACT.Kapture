using ACT_FFXIV_Kapture.Config.Enum;

namespace ACT_FFXIV_Kapture.Config.Model
{
	public class Logging
	{
		public bool LoggingEnabled { get; set; } = false;
		public LogFormat LogFormat { get; set; } = LogFormat.BattleLog;
		public string LogLocation { get; set; }
	}
}