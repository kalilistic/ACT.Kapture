namespace ACT_FFXIV_Kapture.Plugin
{
	internal interface ILogLineParserFactory
	{
		ILogLineParserContext Context { get; set; }
		ILogLineParser CreateParser();
	}
}