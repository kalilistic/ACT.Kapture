using System;

namespace ACT_FFXIV.Aetherbridge
{
	public interface IPluginLogger
	{
		void Info(string message);
		void Error(Exception ex);
		void DeInit();
	}
}