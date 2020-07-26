using System;
using ACT_FFXIV_Kapture.Aetherbridge;
using ACT_FFXIV_Kapture.Config;
using ACT_FFXIV_Kapture.Plugin;
using NUnit.Framework;

namespace ACT_FFXIV_Kapture.Test.LootParser
{
	[TestFixture]
	public class LogLineParserBaseTest
	{
		private Config.Config _configuration;
		private IKaptureData _kaptureData;
		private ILogLineParser _parser;

		[OneTimeSetUp]
		public void SetUp()
		{
			var language = new Language(1, "English", "en");
			_kaptureData = KaptureDataMock.GetInstance();
			_kaptureData.ACTConfig.GameLanguageId = language.Id;
			_kaptureData.Initialize(language.Id);
			KaptureConfig.Initialize(AppDomain.CurrentDomain.BaseDirectory);
			_configuration = (Config.Config) KaptureConfig.GetInstance().ConfigManager.Config;
			_configuration.General.PluginEnabled = true;
			_parser = new ENLogLineParser(new ENLogLineParserContext(_kaptureData));
		}

		[OneTimeTearDown]
		public void TearDown()
		{
			_kaptureData.DeInit();
		}

		[Test]
		public void Parse_LogLine_00_GameLog_01()
		{
			const string logLine = @"[18:30:00.000] 00:12a9:⇒ Direct hit! The drowned deckhand takes 180 damage.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			Assert.IsNull(logEvent);
		}

		[Test]
		public void Parse_LogLine_00_GameLog_02()
		{
			const string logLine = @"[20:33:25.000] 00:282b:The magitek vangob G-III uses Needle Burst.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			Assert.IsNull(logEvent);
		}

		[Test]
		public void Parse_LogLine_01_ChangeZone()
		{
			const string logLine = @"[18:41:52.820] 01:Changed Zone to Limsa Lominsa Lower Decks.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			Assert.IsNull(logEvent);
		}

		[Test]
		public void Parse_LogLine_StaticFields()
		{
			const string logLine =
				@"[17:41:23.000] 00:0039:A pair of warlock's tights has been added to the loot list.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			Assert.AreEqual("17:41:23", logEvent.Timestamp);
			Assert.AreEqual("00", logEvent.LogCode);
			Assert.AreEqual("0039", logEvent.GameLogCode);
		}
	}
}