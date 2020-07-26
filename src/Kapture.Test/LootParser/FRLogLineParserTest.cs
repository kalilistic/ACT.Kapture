using System;
using ACT_FFXIV_Kapture.Aetherbridge;
using ACT_FFXIV_Kapture.Config;
using ACT_FFXIV_Kapture.Plugin;
using NUnit.Framework;

namespace ACT_FFXIV_Kapture.Test.LootParser
{
	[TestFixture]
	public class FRLogLineParserTest
	{
		private Config.Config _configuration;
		private IKaptureData _kaptureData;
		private ILogLineParser _parser;

		[OneTimeSetUp]
		public void SetUp()
		{
			var language = new Language(2, "French", "fr");
			_kaptureData = KaptureDataMock.GetInstance();
			_kaptureData.ACTConfig.GameLanguageId = language.Id;
			_kaptureData.Initialize(language.Id);
			KaptureConfig.Initialize(AppDomain.CurrentDomain.BaseDirectory);
			_configuration = (Config.Config) KaptureConfig.GetInstance().ConfigManager.Config;
			_configuration.General.PluginEnabled = true;
			_configuration.Filters.ItemRolledOn = true;
			_configuration.Filters.ItemLost = true;
			_configuration.Filters.ItemCastLot = true;
			_parser = new FRLogLineParser(new FRLogLineParserContext(_kaptureData));
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
				@"[17:41:23.000] 00:0039:Une  paire de bottines YoRHa type 51: unité de soin  a été ajoutée au butin.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Une paire de bottines YoRHa type 51: unité de soin a été ajoutée au butin.",
				logEvent.LogMessage);
			Assert.AreEqual("paire de bottines YoRHa type 51: unité de soin", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
		}

		[Test]
		public void Parse_LogLine_CastLot_TheyCast()
		{
			const string logLine =
				@"[21:20:24.000] 00:1041:Pika ChuSiren lance ses dés pour la  ceinture d'archer d'Ivalice.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Pika Chu lance ses dés pour la ceinture d'archer d'Ivalice.", logEvent.LogMessage);
			Assert.AreEqual("ceinture d'archer d'Ivalice", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Pika Chu", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_CastsLot_YouCast()
		{
			const string logLine =
				@"[16:35:53.000] 00:0841:Vous lancez vos dés pour le  surcot d'archichevalier d'Ivalice.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Vous lancez vos dés pour le surcot d'archichevalier d'Ivalice.",
				logEvent.LogMessage);
			Assert.AreEqual("surcot d'archichevalier d'Ivalice", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_GreedLoot_TheyRoll()
		{
			const string logLine =
				@"[23:08:44.000] 00:1041:Elmo Dy'grunJenova jette les dés (Cupidité) pour le  masque YoRHa type 51: unité de mêlée . 82!";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Elmo Dy'grun jette les dés (Cupidité) pour le masque YoRHa type 51: unité de mêlée. 82!",
				logEvent.LogMessage);
			Assert.AreEqual("masque YoRHa type 51: unité de mêlée", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
		}


		[Test]
		public void Parse_LogLine_GreedLoot_YouRoll()
		{
			const string logLine =
				@"[23:03:55.000] 00:0841:Vous jetez les dés (Cupidité) pour le  rouleau d'orchestrion “Alien Manifestation”. 71!";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual(
				"Vous jetez les dés (Cupidité) pour le rouleau d'orchestrion “Alien Manifestation”. 71!",
				logEvent.LogMessage);
			Assert.AreEqual("rouleau d'orchestrion “Alien Manifestation”", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
		}

		[Test]
		public void Parse_LogLine_LostLoot_Standard()
		{
			const string logLine =
				@"[23:13:29.000] 00:0039:Impossible d'obtenir la  paire de bottines YoRHa type 51: unité paranormale .";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Impossible d'obtenir la paire de bottines YoRHa type 51: unité paranormale.",
				logEvent.LogMessage);
			Assert.AreEqual("paire de bottines YoRHa type 51: unité paranormale", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
		}

		[Test]
		public void Parse_LogLine_NeedLoot_MultipleItems()
		{
			const string logLine =
				@"[22:07:14.000] 00:1041:Frank Sun-d'azur jette les dés (Besoin) pour la 2  cartes 9S. 67!";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Frank Sun-d'azur jette les dés (Besoin) pour la 2 cartes 9S. 67!", logEvent.LogMessage);
			Assert.AreEqual("carte 9S", lootEvent.Item.SingularName);
			Assert.AreEqual(2, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
		}

		[Test]
		public void Parse_LogLine_NeedLoot_TheyRoll()
		{
			const string logLine =
				@"[23:08:44.000] 00:1041:Frank Sun-d'azur jette les dés (Besoin) pour la  carte 9S. 67!";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Frank Sun-d'azur jette les dés (Besoin) pour la carte 9S. 67!", logEvent.LogMessage);
			Assert.AreEqual("carte 9S", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
		}

		[Test]
		public void Parse_LogLine_NeedLoot_YouRoll()
		{
			const string logLine =
				@"[23:12:36.000] 00:0841:Vous jetez les dés (Besoin) pour le  rouleau d'orchestrion “Alien Manifestation”. 71!";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual(
				"Vous jetez les dés (Besoin) pour le rouleau d'orchestrion “Alien Manifestation”. 71!",
				logEvent.LogMessage);
			Assert.AreEqual("rouleau d'orchestrion “Alien Manifestation”", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_BadItem()
		{
			const string logLine = @"[20:30:25.000] 00:0839:Vous obtenez 2057 gills.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			Assert.IsNull(logEvent);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_Craft()
		{
			const string logLine = @"[21:23:42.000] 00:083e:Vous fabriquez une  jaque en cuir de bouquetin.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Vous fabriquez une jaque en cuir de bouquetin.", logEvent.LogMessage);
			Assert.AreEqual("jaque en cuir de bouquetin", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_Fish()
		{
			const string logLine = @"[21:23:42.000] 00:083e:Vous avez pêché un  pipira  de 9,9 ilms.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Vous avez pêché un pipira (HQ) de 9,9 ilms.", logEvent.LogMessage);
			Assert.AreEqual("pipira", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(true, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
			Assert.AreEqual("9,9 ilms", lootEvent.Item.Size);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_HQ()
		{
			const string logLine =
				@"[21:56:57.000] 00:083e:Vous obtenez un  tendon flexible.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Vous obtenez un tendon flexible (HQ).", logEvent.LogMessage);
			Assert.AreEqual("tendon flexible", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(true, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_ItemMostRare()
		{
			const string logLine =
				@"[21:56:57.000] 00:083e:Vous découvrez et obtenez une  matéria de la collecte VIII. Un objet des plus rares!";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Vous découvrez et obtenez une matéria de la collecte VIII. Un objet des plus rares!",
				logEvent.LogMessage);
			Assert.AreEqual("matéria de la collecte VIII", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_ItemsMostRare()
		{
			const string logLine =
				@"[16:35:53.000] 00:083e:Vous découvrez et obtenez 2  pots de teinture orange métallique. Des objets rares!";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Vous découvrez et obtenez 2 pots de teinture orange métallique. Des objets rares!",
				logEvent.LogMessage);
			Assert.AreEqual("pot de teinture orange métallique", lootEvent.Item.SingularName);
			Assert.AreEqual(2, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_MultipleWorlds()
		{
			const string logLine =
				@"[17:37:35.000] 00:103e:John GilgameshSiren obtient une  paire de bottines YoRHa type 51: unité de soin .";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("John Gilgamesh obtient une paire de bottines YoRHa type 51: unité de soin.",
				logEvent.LogMessage);
			Assert.AreEqual("paires de bottines YoRHa type 51: unité de soin", lootEvent.Item.PluralName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("John Gilgamesh", lootEvent.Actor.Name);
		}


		[Test]
		public void Parse_LogLine_ObtainsLoot_Purchase()
		{
			const string logLine = @"[21:23:42.000] 00:083e:Vous achetez 4   morceaux de cuir .";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Vous achetez 4 morceaux de cuir (HQ).", logEvent.LogMessage);
			Assert.AreEqual("morceau de cuir", lootEvent.Item.SingularName);
			Assert.AreEqual(4, lootEvent.Item.Quantity);
			Assert.AreEqual(true, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_PurchaseWithAmount()
		{
			const string logLine =
				@"[21:23:42.000] 00:083e:Vous achetez 2  fragments de matière sombre grade I pour 8 gils.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Vous achetez 2 fragments de matière sombre grade I pour 8 gils.", logEvent.LogMessage);
			Assert.AreEqual("fragment de matière sombre grade I", lootEvent.Item.SingularName);
			Assert.AreEqual(2, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_Standard()
		{
			const string logLine = @"[21:56:57.000] 00:083e:Vous obtenez 1000 gils.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Vous obtenez 1000 gils.", logEvent.LogMessage);
			Assert.AreEqual("gil", lootEvent.Item.SingularName);
			Assert.AreEqual(1000, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_TheyObtain()
		{
			const string logLine =
				@"[21:20:24.000] 00:103e:Purple Gr'eenJenova obtient une  carte 9S.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Purple Gr'een obtient une carte 9S.", logEvent.LogMessage);
			Assert.AreEqual("carte 9S", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Purple Gr'een", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_WithNumber()
		{
			const string logLine =
				@"[16:35:53.000] 00:103e:Purple Gr'eenJenova obtient une  coffre de bague des chœurs édéniques [NvObj 500].";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Purple Gr'een obtient une coffre de bague des chœurs édéniques [NvObj 500].",
				logEvent.LogMessage);
			Assert.AreEqual("coffre de bague des chœurs édéniques [NvObj 500]", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Purple Gr'een", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_YouObtain()
		{
			const string logLine = @"[16:35:53.000] 00:083e:Vous obtenez une  matéria du regard divin VII.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Vous obtenez une matéria du regard divin VII.", logEvent.LogMessage);
			Assert.AreEqual("matéria du regard divin VII", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_YouObtain_MultipleItems()
		{
			const string logLine = @"[21:23:42.000] 00:083e:Vous obtenez 2  peaux souples.";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Vous obtenez 2 peaux souples.", logEvent.LogMessage);
			Assert.AreEqual("peaux souples", lootEvent.Item.PluralName);
			Assert.AreEqual(2, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_SearchLoot_Standard()
		{
			const string logLine = @"[21:23:42.000] 00:083e:Recherche de l'objet “ Robe de loup ”...";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Recherche de l'objet “Robe de loup (HQ)”...", logEvent.LogMessage);
			Assert.AreEqual("robe de loup", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(true, lootEvent.Item.IsHQ);
		}
	}
}