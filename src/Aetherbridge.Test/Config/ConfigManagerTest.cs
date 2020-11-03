using System;
using System.IO;
using ACT_FFXIV.Aetherbridge.Mocks;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace ACT_FFXIV.Aetherbridge.Test
{
	[TestFixture]
	public class ConfigManagerTest
	{
		[SetUp]
		public void TestInitialize()
		{
			DeleteDirAndFiles();
			Directory.CreateDirectory(ConfigDirPath);
		}

		[TearDown]
		public void TestCleanup()
		{
			DeleteDirAndFiles();
			ConfigManager.GetInstance()?.DeInit();
		}

		private const string ConfigFileName = "Config.xml";
		private const string ConfigPreviousFileName = "Config.xml.previous";
		private static readonly string ConfigDirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config");
		private readonly string ConfigFilePath = Path.Combine(ConfigDirPath, ConfigFileName);
		private readonly string ConfigPreviousFilePath = Path.Combine(ConfigDirPath, ConfigPreviousFileName);

		private void DeleteDirAndFiles()
		{
			// delete config file
			try
			{
				File.Delete(ConfigFilePath);
			}
			catch
			{
				// ignored
			}

			// delete config previous file
			try
			{
				File.Delete(ConfigPreviousFilePath);
			}
			catch
			{
				// ignored
			}

			// delete config dir
			try
			{
				Directory.Delete(ConfigDirPath);
			}
			catch
			{
				// ignored
			}
		}

		[Test]
		public void InitializeSettings_Repeat_NoError()
		{
			ConfigManager.Initialize(ConfigFilePath, ConfigFileName, new ConfigMock());
			ConfigManager.Initialize(ConfigFilePath, ConfigFileName, new ConfigMock());
		}

		[Test]
		public void LoadSettings_BadConfigWithInvalidXML_RenamesConfigFile()
		{
			// create bad config
			File.WriteAllText(ConfigFilePath, "Bad file...");

			// load settings
			ConfigManager.Initialize(ConfigDirPath, ConfigFileName, new ConfigMock());
			var configMgr = (ConfigManager) ConfigManager.GetInstance();
			configMgr.Config = new ConfigMock();
			ConfigManager.GetInstance().LoadSettings();
			ConfigManager.GetInstance().SaveSettings();
			Assert.IsTrue(File.Exists(ConfigFilePath));
			Assert.IsTrue(File.Exists(ConfigPreviousFilePath));
		}

		[Test]
		public void LoadSettings_BadConfigWithValidXML_RenamesConfigFile()
		{
			// create bad config
			ConfigSerializer.WriteXml(ConfigFilePath, new object());

			// load settings
			ConfigManager.Initialize(ConfigDirPath, ConfigFileName, new ConfigMock());
			var configMgr = (ConfigManager) ConfigManager.GetInstance();
			configMgr.Config = new ConfigMock();
			ConfigManager.GetInstance().LoadSettings();
			ConfigManager.GetInstance().SaveSettings();
			Assert.IsTrue(File.Exists(ConfigFilePath));
			Assert.IsTrue(File.Exists(ConfigPreviousFilePath));
		}

		[Test]
		public void LoadSettings_BadConfigWithValidXMLExistingPrevious_RenamesConfigFile()
		{
			// create bad config
			ConfigSerializer.WriteXml(ConfigFilePath, new object());

			// create previous config
			ConfigSerializer.WriteXml(ConfigPreviousFilePath, new ConfigMock());

			// load settings
			ConfigManager.Initialize(ConfigDirPath, ConfigFileName, new ConfigMock());
			var configMgr = (ConfigManager) ConfigManager.GetInstance();
			configMgr.Config = new ConfigMock();
			ConfigManager.GetInstance().LoadSettings();
			Assert.IsTrue(File.Exists(ConfigPreviousFilePath));
		}

		[Test]
		public void LoadSettings_NoConfigFile_NoError()
		{
			ConfigManager.Initialize(ConfigDirPath, ConfigFileName, new ConfigMock());
			File.Delete(ConfigFilePath);
			ConfigManager.GetInstance()?.LoadSettings();
		}

		[Test]
		public void LoadSettings_NoInitialize_NoError()
		{
			ConfigManager.GetInstance()?.LoadSettings();
		}

		[Test]
		public void SaveAndLoadSettings_SavesConfig()
		{
			// save settings
			ConfigManager.Initialize(AppDomain.CurrentDomain.BaseDirectory, ConfigFileName, new ConfigMock());
			var configMgr = (ConfigManager) ConfigManager.GetInstance();
			((ConfigMock) configMgr.Config).Name = "Test";
			ConfigManager.GetInstance().SaveSettings();
			ConfigManager.GetInstance().DeInit();

			// load settings
			ConfigManager.Initialize(AppDomain.CurrentDomain.BaseDirectory, ConfigFileName, new ConfigMock());
			configMgr = (ConfigManager) ConfigManager.GetInstance();
			configMgr.LoadSettings();
			configMgr.SaveSettings();
			Assert.AreEqual("Test", ((ConfigMock) configMgr.Config).Name);
		}

		[Test]
		public void SaveSettings_NoInitialize_NoError()
		{
			ConfigManager.GetInstance()?.SaveSettings();
		}
	}
}