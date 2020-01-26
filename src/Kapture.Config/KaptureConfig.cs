using System;
using System.IO;
using StarkLogger;
using StarkUserConfig;

namespace ACT_FFXIV_Kapture.Config
{
	public class KaptureConfig : IKaptureConfig
	{
		private static volatile KaptureConfig _kaptureConfig;
		private static readonly object Lock = new object();
		public IConfig Config;

		public ConfigManager ConfigManager;

		private KaptureConfig(string appDataFolder)
		{
			try
			{
				Config = new Config();
				var configFilePath = Path.Combine(appDataFolder, KaptureConfigConstants.ConfigDirName);
				ConfigManager.Initialize(configFilePath, KaptureConfigConstants.ConfigFileName, Config);
				ConfigManager = (ConfigManager) ConfigManager.GetInstance();
				ConfigManager.LoadSettings();
			}
			catch (Exception ex)
			{
				Logger.GetInstance().Error(ex);
			}
		}

		public void DeInit()
		{
			ConfigManager.DeInit();
			_kaptureConfig = null;
		}

		public static KaptureConfig GetInstance()
		{
			return _kaptureConfig;
		}

		public static void Initialize(string appDataFolder)
		{
			if (_kaptureConfig != null) return;
			lock (Lock)
			{
				if (_kaptureConfig == null)
					_kaptureConfig = new KaptureConfig(appDataFolder);
			}
		}
	}
}