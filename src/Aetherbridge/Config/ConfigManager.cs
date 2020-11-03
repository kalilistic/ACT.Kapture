using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace ACT_FFXIV.Aetherbridge
{
	public class ConfigManager : IConfigManager
	{
		private static volatile ConfigManager _configManager;
		private static readonly object Lock = new object();
		private static string _configFilePath;
		private static bool _configLoaded;

		public IConfig Config;

		private ConfigManager(string configFilePath, string configFileName, IConfig config)
		{
			_configFilePath = Path.Combine(configFilePath, configFileName);
			Config = config;
		}

		public void SaveSettings()
		{
			if (!_configLoaded) return;
			ConfigSerializer.WriteXml(_configFilePath, Config);
		}

		public void LoadSettings()
		{
			if (!File.Exists(_configFilePath))
				CreateConfigFile();
			else
				try
				{
					var config = ConfigSerializer.ReadXml(_configFilePath, Config);
					if (config != null)
						Config = config;
					else
						RenameConfigFile();
				}
				catch (Exception)
				{
					RenameConfigFile();
				}

			_configLoaded = true;
		}

		public void DeInit()
		{
			Config = null;
			_configManager = null;
			_configFilePath = null;
		}

		private void CreateConfigFile()
		{
			ConfigSerializer.WriteXml(_configFilePath, Config);
		}

		public static IConfigManager GetInstance()
		{
			return _configManager;
		}

		public static void Initialize(string configFilePath, string configFileName, IConfig config)
		{
			if (_configManager != null) return;
			lock (Lock)
			{
				if (_configManager == null)
					_configManager = new ConfigManager(configFilePath, configFileName, config);
			}
		}

		private static string GetPreviousConfigPath()
		{
			return Path.Combine(_configFilePath + ".previous");
		}

		[ExcludeFromCodeCoverage]
		private static void RenameConfigFile()
		{
			try
			{
				if (File.Exists(GetPreviousConfigPath())) File.Delete(GetPreviousConfigPath());
				File.Move(_configFilePath, GetPreviousConfigPath());
				File.Delete(_configFilePath);
			}

			catch (Exception)
			{
				// ignored
			}
		}
	}
}