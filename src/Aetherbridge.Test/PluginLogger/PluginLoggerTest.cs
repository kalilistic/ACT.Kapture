using System;
using System.IO;
using NUnit.Framework;

namespace ACT_FFXIV.Aetherbridge.Test
{
	[TestFixture]
	public class PluginLoggerTest
	{
		public string LogDirPath;
		public string LogFileName = "Log.log";

		private void InitializeLogger()
		{
			LogDirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
			Directory.CreateDirectory(LogDirPath);
			PluginLogger.Initialize(LogDirPath, LogFileName);
		}

		[Test]
		public void Error_CreatesLogFile()
		{
			var exception =
				new Exception("message",
					new Exception("inner message",
						new Exception("inner most message")));
			InitializeLogger();
			PluginLogger.GetInstance().Error(exception);
			PluginLogger.GetInstance().DeInit();
			Assert.IsTrue(File.Exists(Path.Combine(LogDirPath, LogFileName)));
			File.Delete(Path.Combine(LogDirPath, LogFileName));
		}

		[Test]
		public void Info_CreatesLogFile()
		{
			InitializeLogger();
			PluginLogger.GetInstance().Info("Info");
			PluginLogger.GetInstance().DeInit();
			Assert.IsTrue(File.Exists(Path.Combine(LogDirPath, LogFileName)));
			File.Delete(Path.Combine(LogDirPath, LogFileName));
		}

		[Test]
		public void Initialize_Again_NoChange()
		{
			InitializeLogger();
			InitializeLogger();
			Assert.IsNotNull(PluginLogger.GetInstance());
		}
	}
}