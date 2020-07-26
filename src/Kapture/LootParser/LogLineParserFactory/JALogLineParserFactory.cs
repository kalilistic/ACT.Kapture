namespace ACT_FFXIV_Kapture.Plugin
{
	internal class JALogLineParserFactory : ILogLineParserFactory
	{
		public JALogLineParserFactory(IKaptureData kaptureData)
		{
			Context = new JALogLineParserContext(kaptureData);
		}

		public ILogLineParserContext Context { get; set; }

		public ILogLineParser CreateParser()
		{
			return new JALogLineParser(Context);
		}
	}
}