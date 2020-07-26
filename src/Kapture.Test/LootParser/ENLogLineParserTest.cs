using System;
using ACT_FFXIV_Kapture.Aetherbridge;
using ACT_FFXIV_Kapture.Config;
using ACT_FFXIV_Kapture.Plugin;
using NUnit.Framework;

namespace ACT_FFXIV_Kapture.Test.LootParser
{
	[TestFixture]
	public class ENLogLineParserTest
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
			_configuration.Filters.ItemRolledOn = true;
			_configuration.Filters.ItemCastLot = true;
			_parser = new ENLogLineParser(new ENLogLineParserContext(_kaptureData));
		}

		[OneTimeTearDown]
		public void TearDown()
		{
			_kaptureData.DeInit();
		}

		[Test]
		public void Parse_LogLine_AddedLoot_Standard()
		{
			const string logLine =
				@"[17:41:23.000] 00:0039:A pair of warlock's tights has been added to the loot list.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("A pair of warlock's tights has been added to the loot list.", logEvent.LogMessage);
			Assert.AreEqual("pair of warlock's tights", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
		}

		[Test]
		public void Parse_LogLine_CastLot_TheyCast()
		{
			const string logLine =
				@"[21:20:24.000] 00:1041:Pika ChuSiren casts his lot for the ghost barque ring of aiming.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Pika Chu casts his lot for the ghost barque ring of aiming.", logEvent.LogMessage);
			Assert.AreEqual("ghost barque ring of aiming", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Pika Chu", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_CastsLot_YouCast()
		{
			const string logLine =
				@"[16:35:53.000] 00:0841:You cast your lot for the pair of ghost barque vambraces of striking.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("You cast your lot for the pair of ghost barque vambraces of striking.",
				logEvent.LogMessage);
			Assert.AreEqual("pair of ghost barque vambraces of striking", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ClaimLoot_TheyClaim()
		{
			const string logLine = @"[16:35:53.000] 00:103e:Blue Zoo claims the plundered haubergeon.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Blue Zoo claims the plundered haubergeon.", logEvent.LogMessage);
			Assert.AreEqual("plundered haubergeon", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Blue Zoo", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ClaimLoot_YouClaim()
		{
			const string logLine = @"[16:35:53.000] 00:083e:You claim the plundered haubergeon.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("You claim the plundered haubergeon.", logEvent.LogMessage);
			Assert.AreEqual("plundered haubergeon", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_GreedLoot_TheyRoll()
		{
			const string logLine = @"[23:08:44.000] 00:1041:Blue Zoo rolls Greed on the Dravanian hat of healing. 92!";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Blue Zoo rolls Greed on the Dravanian hat of healing. 92!", logEvent.LogMessage);
			Assert.AreEqual("Dravanian hat of healing", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
		}


		[Test]
		public void Parse_LogLine_GreedLoot_YouRoll()
		{
			const string logLine =
				@"[23:03:55.000] 00:0841:You roll Greed on the pair of Dravanian jackboots of healing. 28!";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("You roll Greed on the pair of Dravanian jackboots of healing. 28!",
				logEvent.LogMessage);
			Assert.AreEqual("pair of Dravanian jackboots of healing", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
		}

		[Test]
		public void Parse_LogLine_LostLoot_Standard()
		{
			const string logLine = @"[23:13:29.000] 00:0039:Unable to obtain the lump of dryad sap.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Unable to obtain the lump of dryad sap.", logEvent.LogMessage);
			Assert.AreEqual("lump of dryad sap", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
		}

		[Test]
		public void Parse_LogLine_NeedLoot_ItemWithPeriod()
		{
			const string logLine =
				@"[23:12:36.000] 00:1041:Blue Zoo rolls Need on the Pressure (No. 1) orchestrion roll. 24!";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Blue Zoo rolls Need on the Pressure (No. 1) orchestrion roll. 24!", logEvent.LogMessage);
			Assert.AreEqual("Pressure (No. 1) orchestrion roll", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
		}

		[Test]
		public void Parse_LogLine_NeedLoot_MultipleItems()
		{
			const string logLine =
				@"[22:07:14.000] 00:1041:Blue ZooMidgardsormr rolls Need on the 5 bottles of lime sulphur. 15!";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Blue Zoo rolls Need on the 5 bottles of lime sulphur. 15!", logEvent.LogMessage);
			Assert.AreEqual("bottle of lime sulphur", lootEvent.Item.SingularName);
			Assert.AreEqual(5, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
		}

		[Test]
		public void Parse_LogLine_NeedLoot_TheyRoll()
		{
			const string logLine =
				@"[23:12:36.000] 00:1041:Blue Zoo rolls Need on the Dravanian bracelet of casting. 11!";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Blue Zoo rolls Need on the Dravanian bracelet of casting. 11!", logEvent.LogMessage);
			Assert.AreEqual("Dravanian bracelet of casting", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
		}

		[Test]
		public void Parse_LogLine_NeedLoot_YouRoll()
		{
			const string logLine = @"[23:12:36.000] 00:0841:You roll Need on the Dravanian bracelet of casting. 22!";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("You roll Need on the Dravanian bracelet of casting. 22!", logEvent.LogMessage);
			Assert.AreEqual("Dravanian bracelet of casting", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_BadItem()
		{
			const string logLine = @"[20:30:25.000] 00:0839:You obtain a tiny key.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			Assert.IsNull(logEvent);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_Craft()
		{
			const string logLine = @"[21:23:42.000] 00:083e:You synthesize a gaganaskin bush hat .";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("You synthesize a gaganaskin bush hat (HQ).", logEvent.LogMessage);
			Assert.AreEqual("gaganaskin bush hat", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(true, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_FishLand()
		{
			const string logLine = @"[21:23:42.000] 00:083e:You land a pipira measuring 7.8 ilms!";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("You land a pipira measuring 7.8 ilms!", logEvent.LogMessage);
			Assert.AreEqual("pipira", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
			Assert.AreEqual("7.8 ilms", lootEvent.Item.Size);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_FishSpear()
		{
			const string logLine = @"[21:23:42.000] 00:083e:You spear a wentletrap  measuring 1.8 ilms!";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("You spear a wentletrap (HQ) measuring 1.8 ilms!", logEvent.LogMessage);
			Assert.AreEqual("wentletrap", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(true, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
			Assert.AreEqual("1.8 ilms", lootEvent.Item.Size);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_HQ()
		{
			const string logLine =
				@"[21:56:57.000] 00:083e:You obtain a pot of honey .";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("You obtain a pot of honey (HQ).", logEvent.LogMessage);
			Assert.AreEqual("pot of honey", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(true, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_ItemMostRare()
		{
			const string logLine =
				@"[21:56:57.000] 00:083e:You discover and obtain a gatherer's guerdon materia VII─an item most rare!";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("You discover and obtain a gatherer's guerdon materia VII─an item most rare!",
				logEvent.LogMessage);
			Assert.AreEqual("gatherer's guerdon materia VII", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_ItemsMostRare()
		{
			const string logLine =
				@"[16:35:53.000] 00:083e:You discover and obtain 2 pots of general-purpose pastel purple dye─items most rare!";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("You discover and obtain 2 pots of general-purpose pastel purple dye─items most rare!",
				logEvent.LogMessage);
			Assert.AreEqual("pot of general-purpose pastel purple dye", lootEvent.Item.SingularName);
			Assert.AreEqual(2, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_MultipleWorlds()
		{
			const string logLine = @"[17:37:35.000] 00:103e:John GilgameshSiren obtains 2 pieces of hippogryph sinew.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("John Gilgamesh obtains 2 pieces of hippogryph sinew.", logEvent.LogMessage);
			Assert.AreEqual("pieces of hippogryph sinew", lootEvent.Item.PluralName);
			Assert.AreEqual(2, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("John Gilgamesh", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_Passive()
		{
			const string logLine = @"[21:23:42.000] 00:083e:A handful of agewood aethersand is obtained.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("A handful of agewood aethersand is obtained.", logEvent.LogMessage);
			Assert.AreEqual("handfuls of agewood aethersand", lootEvent.Item.PluralName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_PassiveMultipleItems()
		{
			const string logLine = @"[21:23:42.000] 00:083e:2 handfuls of agewood aethersand is obtained.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("2 handfuls of agewood aethersand is obtained.", logEvent.LogMessage);
			Assert.AreEqual("handful of agewood aethersand", lootEvent.Item.SingularName);
			Assert.AreEqual(2, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_Purchase()
		{
			const string logLine = @"[21:23:42.000] 00:083e:You purchase a circle of gagana leather.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("You purchase a circle of gagana leather.", logEvent.LogMessage);
			Assert.AreEqual("circle of gagana leather", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_PurchaseWithAmount()
		{
			const string logLine = @"[21:23:42.000] 00:083e:You purchase a high steel katzbalger for 24,235 gil.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("You purchase a high steel katzbalger for 24,235 gil.", logEvent.LogMessage);
			Assert.AreEqual("high steel katzbalger", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_Standard()
		{
			const string logLine = @"[21:56:57.000] 00:083e:You obtain 1,200 gil.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("You obtain 1,200 gil.", logEvent.LogMessage);
			Assert.AreEqual("gil", lootEvent.Item.SingularName);
			Assert.AreEqual(1200, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_TheyObtain()
		{
			const string logLine =
				@"[21:20:24.000] 00:103e:Blue ZooAdamantoise obtains a pair of Valerian terror knight's sollerets.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Blue Zoo obtains a pair of Valerian terror knight's sollerets.", logEvent.LogMessage);
			Assert.AreEqual("pair of Valerian terror knight's sollerets", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Blue Zoo", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_WithNumber()
		{
			const string logLine = @"[16:35:53.000] 00:103e:Blue Zoo obtains 4 grade 2 tinctures of vitality.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Blue Zoo obtains 4 grade 2 tinctures of vitality.", logEvent.LogMessage);
			Assert.AreEqual("grade 2 tincture of vitality", lootEvent.Item.SingularName);
			Assert.AreEqual(4, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Blue Zoo", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_YouObtain()
		{
			const string logLine = @"[16:35:53.000] 00:083e:You obtain the Blazing Sun.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("You obtain the Blazing Sun.", logEvent.LogMessage);
			Assert.AreEqual("the Blazing Sun", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_YouObtain_MultipleItems()
		{
			const string logLine = @"[21:23:42.000] 00:083e:You obtain 60 Allagan tomestones of poetics.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("You obtain 60 Allagan tomestones of poetics.", logEvent.LogMessage);
			Assert.AreEqual("Allagan tomestones of poetics", lootEvent.Item.PluralName);
			Assert.AreEqual(60, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_SearchLoot_Standard()
		{
			const string logLine = @"[21:23:42.000] 00:083e:Searching for wolf robes ...";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Searching for wolf robes (HQ)...", logEvent.LogMessage);
			Assert.AreEqual("wolf robe", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(true, lootEvent.Item.IsHQ);
		}
	}
}