namespace ACT_FFXIV_Kapture.Plugin
{
	internal class ENLogLineParserFactory : ILogLineParserFactory
	{
		public ENLogLineParserFactory(IKaptureData kaptureData)
		{
			Context = new ENLogLineParserContext(kaptureData);
		}

		public ILogLineParserContext Context { get; set; }

		public ILogLineParser CreateParser()
		{
			return new ENLogLineParser(Context);
		}
	}
}