using System.Collections.Generic;
using System.Linq;

namespace ACT_FFXIV_Kapture.Config
{
	public class LogFormat
	{
		private static readonly List<LogFormat> LogFormatList = new List<LogFormat>();

		public static readonly LogFormat LogFile = new LogFormat("Log File");
		public static readonly LogFormat CSV = new LogFormat("CSV");
		public static readonly LogFormat JSON = new LogFormat("JSON");

		public LogFormat()
		{
		}

		private LogFormat(string name)
		{
			Name = name;
			LogFormatList.Add(this);
		}

		public string Name { get; set; }

		public static IList<LogFormat> LogFormats => LogFormatList;

		public static LogFormat Parse(string strToParse)
		{
			return LogFormats.FirstOrDefault(str => strToParse == str.Name);
		}

		public override string ToString()
		{
			return Name;
		}
	}
}