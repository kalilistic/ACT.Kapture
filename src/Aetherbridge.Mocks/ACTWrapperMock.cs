using System;

namespace ACT_FFXIV.Aetherbridge.Mocks
{
	public class ACTWrapperMock : IACTWrapper
	{
		public event EventHandler<ACTLogLineEvent> ACTLogLineCaptured;

		public dynamic GetACTPlugin(string pluginFileName, string pluginStatus)
		{
			return new ACTPluginMock();
		}

		public void DeInit()
		{
		}

		public string GetAppDataFolderFullName()
		{
			return AppDomain.CurrentDomain.BaseDirectory;
		}

		public string GetCharacterName()
		{
			return "John Smith";
		}

		public void Restart(string message)
		{
			throw new NotImplementedException();
		}

		public bool ACTLogLineParserEnabled { get; set; }

		protected virtual void OnACTLogLineCaptured(ACTLogLineEvent e)
		{
			ACTLogLineCaptured?.Invoke(this, e);
		}
	}
}