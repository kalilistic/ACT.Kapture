using System.Text.RegularExpressions;

namespace ACT_FFXIV.Aetherbridge
{
	public static class LogLineParserUtil
	{
		public static Regex CreateRegex(string pattern)
		{
			return new Regex(pattern, RegexOptions.Compiled);
		}
	}
}