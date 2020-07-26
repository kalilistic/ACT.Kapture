using System;
using ACT_FFXIV_Kapture.Aetherbridge;
using ACT_FFXIV_Kapture.Config;
using ACT_FFXIV_Kapture.Plugin;
using NUnit.Framework;

namespace ACT_FFXIV_Kapture.Test.LootParser
{
	[TestFixture]
	public class DELogLineParserTest
	{
		private Config.Config _configuration;
		private IKaptureData _kaptureData;
		private ILogLineParser _parser;

		[OneTimeSetUp]
		public void SetUp()
		{
			var language = new Language(3, "German", "de");
			_kaptureData = KaptureDataMock.GetInstance();
			_kaptureData.ACTConfig.GameLanguageId = language.Id;
			_kaptureData.Initialize(language.Id);
			KaptureConfig.Initialize(AppDomain.CurrentDomain.BaseDirectory);
			_configuration = (Config.Config) KaptureConfig.GetInstance().ConfigManager.Config;
			_configuration.General.PluginEnabled = true;
			_configuration.Filters.ItemRolledOn = true;
			_configuration.Filters.ItemLost = true;
			_configuration.Filters.ItemCastLot = true;
			_parser = new DELogLineParser(new DELogLineParserContext(_kaptureData));
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
				@"[17:41:23.000] 00:0039:Ihr habt Beutegut (eine  YoRHa-Haube des Spähens Modell Nr. 51) erhalten.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Ihr habt Beutegut (eine YoRHa-Haube des Spähens Modell Nr. 51) erhalten.",
				logEvent.LogMessage);
			Assert.AreEqual("YoRHa-Haube[p] des Spähens Modell Nr. 51", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
		}

		[Test]
		public void Parse_LogLine_CastLot_TheyCast()
		{
			const string logLine =
				@"[21:20:24.000] 00:1041:Pika ChuSiren würfelt um die  Archen-Kappe des Zielens.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Pika Chu würfelt um die Archen-Kappe des Zielens.", logEvent.LogMessage);
			Assert.AreEqual("Archen-Kappe[p] des Zielens", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Pika Chu", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_CastsLot_YouCast()
		{
			const string logLine = @"[16:35:53.000] 00:0841:Du würfelst um den  Archen-Helm der Verteidigung.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Du würfelst um den Archen-Helm der Verteidigung.", logEvent.LogMessage);
			Assert.AreEqual("Archen-Helm[p] der Verteidigung", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_GreedLoot_TheyRoll()
		{
			const string logLine = @"[23:08:44.000] 00:1041:Blue Zoo würfelt mit „Bedarf“ eine 80 auf die  9S-Karte.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Blue Zoo würfelt mit „Bedarf“ eine 80 auf die 9S-Karte.", logEvent.LogMessage);
			Assert.AreEqual("9S-Karte", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
		}


		[Test]
		public void Parse_LogLine_GreedLoot_YouRoll()
		{
			const string logLine =
				@"[23:03:55.000] 00:0841:Du würfelst mit „Gier“ eine 28 auf die Notenrolle von „Alien Manifestation“.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Du würfelst mit „Gier“ eine 28 auf die Notenrolle von „Alien Manifestation“.",
				logEvent.LogMessage);
			Assert.AreEqual("Notenrolle[p] von „Alien Manifestation“", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
		}

		[Test]
		public void Parse_LogLine_LostLoot_Standard()
		{
			const string logLine =
				@"[23:13:29.000] 00:0039:Du konntest die  YoRHa-Jacke des Spähens Modell Nr. 51 nicht erhalten.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Du konntest die YoRHa-Jacke des Spähens Modell Nr. 51 nicht erhalten.",
				logEvent.LogMessage);
			Assert.AreEqual("YoRHa-Jacke[p] des Spähens Modell Nr. 51", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
		}

		[Test]
		public void Parse_LogLine_NeedLoot_MultipleItems()
		{
			const string logLine =
				@"[22:07:14.000] 00:1041:Blue Zoo würfelt mit „Gier“ eine 80 auf die 2  9S-Karten.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Blue Zoo würfelt mit „Gier“ eine 80 auf die 2 9S-Karten.", logEvent.LogMessage);
			Assert.AreEqual("9S-Karte", lootEvent.Item.SingularName);
			Assert.AreEqual(2, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
		}

		[Test]
		public void Parse_LogLine_NeedLoot_TheyRoll()
		{
			const string logLine = @"[23:08:44.000] 00:1041:Blue Zoo würfelt mit „Gier“ eine 80 auf die  9S-Karte.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Blue Zoo würfelt mit „Gier“ eine 80 auf die 9S-Karte.", logEvent.LogMessage);
			Assert.AreEqual("9S-Karte", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
		}

		[Test]
		public void Parse_LogLine_NeedLoot_YouRoll()
		{
			const string logLine =
				@"[23:12:36.000] 00:0841:Du würfelst mit „Bedarf“ eine 28 auf die Notenrolle von „Alien Manifestation“.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Du würfelst mit „Bedarf“ eine 28 auf die Notenrolle von „Alien Manifestation“.",
				logEvent.LogMessage);
			Assert.AreEqual("Notenrolle[p] von „Alien Manifestation“", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_BadItem()
		{
			const string logLine = @"[20:30:25.000] 00:0839:Du hast 1.000 gil-fake-item erhalten.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			Assert.IsNull(logEvent);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_Craft()
		{
			const string logLine =
				@"[21:23:42.000] 00:083e:Du hast erfolgreich eine  Steinbockleder-Rüstung hergestellt.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Du hast erfolgreich eine Steinbockleder-Rüstung hergestellt.", logEvent.LogMessage);
			Assert.AreEqual("Steinbockleder-Rüstung", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_FishLand()
		{
			const string logLine = @"[21:23:42.000] 00:083e:Du hast einen  Pipira  (9,9 Ilme) gefangen.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Du hast einen Pipira (HQ) (9,9 Ilme) gefangen.", logEvent.LogMessage);
			Assert.AreEqual("Pipira", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(true, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
			Assert.AreEqual("9,9 Ilme", lootEvent.Item.Size);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_FishSpear()
		{
			const string logLine = @"[21:23:42.000] 00:083e:Du hast eine  Bernsteinmakrele (71,6 Ilme) aufgespießt.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Du hast eine Bernsteinmakrele (71,6 Ilme) aufgespießt.", logEvent.LogMessage);
			Assert.AreEqual("Bernsteinmakrele", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
			Assert.AreEqual("71,6 Ilme", lootEvent.Item.Size);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_HQ()
		{
			const string logLine =
				@"[21:56:57.000] 00:083e:Du hast ein  Megalokrabbenbein  erhalten.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Du hast ein Megalokrabbenbein (HQ) erhalten.", logEvent.LogMessage);
			Assert.AreEqual("Megalokrabbenbein", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(true, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_ItemMostRare()
		{
			const string logLine =
				@"[21:56:57.000] 00:083e:Du findest und erhältst eine  Sammlersinn-Materia VII - ein höchst seltener Gegenstand!";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Du findest und erhältst eine Sammlersinn-Materia VII - ein höchst seltener Gegenstand!",
				logEvent.LogMessage);
			Assert.AreEqual("Sammlersinn-Materia[p] VII", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_ItemsMostRare()
		{
			const string logLine =
				@"[16:35:53.000] 00:083e:Du findest und erhältst 2  Töpfe dunkelgrünen Farbstoffs - ein höchst seltener Fund!";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Du findest und erhältst 2 Töpfe dunkelgrünen Farbstoffs - ein höchst seltener Fund!",
				logEvent.LogMessage);
			Assert.AreEqual("Topf[p] dunkelgrünen Farbstoffs", lootEvent.Item.SingularName);
			Assert.AreEqual(2, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_MultipleWorlds()
		{
			const string logLine =
				@"[17:37:35.000] 00:103e:John GilgameshSiren hat ein  Paar YoRHa-Handschuhe der Heilung Modell Nr. 51 erhalten.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("John Gilgamesh hat ein Paar YoRHa-Handschuhe der Heilung Modell Nr. 51 erhalten.",
				logEvent.LogMessage);
			Assert.AreEqual("Paar[p] YoRHa-Handschuhe der Heilung Modell Nr. 51", lootEvent.Item.PluralName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("John Gilgamesh", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_Purchase()
		{
			const string logLine = @"[21:23:42.000] 00:083e:Du hast 2  Strategen-Materia II gekauft.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Du hast 2 Strategen-Materia II gekauft.", logEvent.LogMessage);
			Assert.AreEqual("Strategen-Materia[p] II", lootEvent.Item.SingularName);
			Assert.AreEqual(2, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_PurchaseWithAmount()
		{
			const string logLine = @"[21:23:42.000] 00:083e:Du hast eine  Edelstahl-Säge für 27.086 Gil gekauft.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Du hast eine Edelstahl-Säge für 27.086 Gil gekauft.", logEvent.LogMessage);
			Assert.AreEqual("Edelstahl-Säge", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_Standard()
		{
			const string logLine = @"[21:56:57.000] 00:083e:Du hast 1.000 Gil erhalten.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Du hast 1.000 Gil erhalten.", logEvent.LogMessage);
			Assert.AreEqual("Gil", lootEvent.Item.SingularName);
			Assert.AreEqual(1000, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_TheyObtain()
		{
			const string logLine =
				@"[21:20:24.000] 00:103e:Blue Zoo hat einen  Heiltrank erhalten.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Blue Zoo hat einen Heiltrank erhalten.", logEvent.LogMessage);
			Assert.AreEqual("Heiltrank", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Blue Zoo", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_WithNumber()
		{
			const string logLine =
				@"[16:35:53.000] 00:103e:Blue Zoo hat einen  Edenchor-Kiste mit Ausrüstung für die Füße (G.-St. 500) erhalten.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Blue Zoo hat einen Edenchor-Kiste mit Ausrüstung für die Füße (G.-St. 500) erhalten.",
				logEvent.LogMessage);
			Assert.AreEqual("Edenchor-Kiste[p] mit Ausrüstung für die Füße (G.-St. 500)", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Blue Zoo", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_YouObtain()
		{
			const string logLine = @"[16:35:53.000] 00:083e:Du hast  Die Brennende Sonne erhalten.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Du hast Die Brennende Sonne erhalten.", logEvent.LogMessage);
			Assert.AreEqual("Die Brennende Sonne", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_YouObtain_MultipleItems()
		{
			const string logLine = @"[21:23:42.000] 00:083e:Du hast 20 Allagische Steine der Goëtie erhalten.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Du hast 20 Allagische Steine der Goëtie erhalten.", logEvent.LogMessage);
			Assert.AreEqual("Allagisch[a] Steine[p] der Goëtie", lootEvent.Item.PluralName);
			Assert.AreEqual(20, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_SearchLoot_Standard()
		{
			const string logLine = @"[21:23:42.000] 00:083e:Der naturbelassene Hanfballen  wird gesucht.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Der naturbelassene Hanfballen (HQ) wird gesucht.", logEvent.LogMessage);
			Assert.AreEqual("naturbelassen[a] Hanfballen", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(true, lootEvent.Item.IsHQ);
		}
	}
}