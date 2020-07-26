namespace ACT_FFXIV_Kapture.Plugin
{
	internal class FRLogLineParserFactory : ILogLineParserFactory
	{
		public FRLogLineParserFactory(IKaptureData kaptureData)
		{
			Context = new FRLogLineParserContext(kaptureData);
		}

		public ILogLineParserContext Context { get; set; }

		public ILogLineParser CreateParser()
		{
			return new FRLogLineParser(Context);
		}
	}
}