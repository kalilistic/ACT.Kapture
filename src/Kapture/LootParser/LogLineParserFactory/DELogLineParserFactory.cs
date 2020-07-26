namespace ACT_FFXIV_Kapture.Plugin
{
	internal class DELogLineParserFactory : ILogLineParserFactory
	{
		public DELogLineParserFactory(IKaptureData kaptureData)
		{
			Context = new DELogLineParserContext(kaptureData);
		}

		public ILogLineParserContext Context { get; set; }

		public ILogLineParser CreateParser()
		{
			return new DELogLineParser(Context);
		}
	}
}