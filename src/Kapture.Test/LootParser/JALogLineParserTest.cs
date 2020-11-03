using System;
using ACT_FFXIV.Aetherbridge;
using ACT_FFXIV_Kapture.Config;
using ACT_FFXIV_Kapture.Plugin;
using NUnit.Framework;

namespace ACT_FFXIV_Kapture.Test.LootParser
{
	[TestFixture]
	public class JALogLineParserTest
	{
		private Config.Model.Config _configuration;
		private IKaptureData _kaptureData;
		private ILogLineParser _parser;

		[OneTimeSetUp]
		public void SetUp()
		{
			var language = new Language(4, "Japanese", "ja");
			_kaptureData = KaptureDataMock.GetInstance();
			_kaptureData.ACTConfig.GameLanguageId = language.Id;
			_kaptureData.Initialize(language.Id);
			KaptureConfig.Initialize(AppDomain.CurrentDomain.BaseDirectory);
			_configuration = (Config.Model.Config) KaptureConfig.GetInstance().ConfigManager.Config;
			_configuration.General.PluginEnabled = true;
			_configuration.Filters.ItemRolledOn = true;
			_configuration.Filters.ItemLost = true;
			_configuration.Filters.ItemCastLot = true;
			_parser = new JALogLineParser(new JALogLineParserContext(_kaptureData));
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
				@"[17:41:23.000] 00:0039:ヨルハ五一式軍装:射が戦利品に追加されました。";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("ヨルハ五一式軍装:射が戦利品に追加されました。", logEvent.LogMessage);
			Assert.AreEqual("ヨルハ五一式軍装:射", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
		}

		[Test]
		public void Parse_LogLine_CastLot_TheyCast()
		{
			const string logLine =
				@"[21:20:24.000] 00:1041:Pika Chuはオーケストリオン譜:イニシエノウタ／贖罪にロットした。";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Pika Chuはオーケストリオン譜:イニシエノウタ／贖罪にロットした。", logEvent.LogMessage);
			Assert.AreEqual("オーケストリオン譜:イニシエノウタ／贖罪", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Pika Chu", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_CastsLot_YouCast()
		{
			const string logLine = @"[16:35:53.000] 00:0841:Combatant Oneはオーケストリオン譜:イニシエノウタ／贖罪にロットした。";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Combatant Oneはオーケストリオン譜:イニシエノウタ／贖罪にロットした。", logEvent.LogMessage);
			Assert.AreEqual("オーケストリオン譜:イニシエノウタ／贖罪", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ClaimLoot_TheyClaim()
		{
			const string logLine = @"[16:35:53.000] 00:103e:Blue Zooにエーテリアル・ウールローブが分配されました。";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Blue Zooにエーテリアル・ウールローブが分配されました。", logEvent.LogMessage);
			Assert.AreEqual("エーテリアル・ウールローブ", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Blue Zoo", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ClaimLoot_YouClaim()
		{
			const string logLine = @"[16:35:53.000] 00:083e:Combatant Oneにエーテリアル・ウールサッシュが分配されました。";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Combatant Oneにエーテリアル・ウールサッシュが分配されました。", logEvent.LogMessage);
			Assert.AreEqual("エーテリアル・ウールサッシュ", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_GreedLoot_TheyRoll()
		{
			const string logLine = @"[23:08:44.000] 00:1041:Blue ZooJenovaはヨルハ五一式軍靴:重にGREEDのダイスで64を出した。";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Blue Zooはヨルハ五一式軍靴:重にGREEDのダイスで64を出した。", logEvent.LogMessage);
			Assert.AreEqual("ヨルハ五一式軍靴:重", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
		}


		[Test]
		public void Parse_LogLine_GreedLoot_YouRoll()
		{
			const string logLine =
				@"[23:03:55.000] 00:0841:Combatant Oneはカード:９ＳにGREEDのダイスで81を出した。";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Combatant Oneはカード:９ＳにGREEDのダイスで81を出した。",
				logEvent.LogMessage);
			Assert.AreEqual("カード:９Ｓ", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
		}

		[Test]
		public void Parse_LogLine_LostLoot_Standard()
		{
			const string logLine = @"[23:13:29.000] 00:0039:物資コンテナ:二号B型防具を手に入れることができなかった。";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("物資コンテナ:二号B型防具を手に入れることができなかった。", logEvent.LogMessage);
			Assert.AreEqual("物資コンテナ:二号B型防具", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
		}

		[Test]
		public void Parse_LogLine_NeedLoot_TheyRoll()
		{
			const string logLine = @"[23:08:44.000] 00:1041:Blue ZooJenovaはヨルハ五一式軍靴:重にNEEDのダイスで64を出した。";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Blue Zooはヨルハ五一式軍靴:重にNEEDのダイスで64を出した。", logEvent.LogMessage);
			Assert.AreEqual("ヨルハ五一式軍靴:重", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
		}

		[Test]
		public void Parse_LogLine_NeedLoot_YouRoll()
		{
			const string logLine =
				@"[23:03:55.000] 00:0841:Combatant Oneはカード:９ＳにNEEDのダイスで81を出した。";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Combatant Oneはカード:９ＳにNEEDのダイスで81を出した。",
				logEvent.LogMessage);
			Assert.AreEqual("カード:９Ｓ", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_BadItem()
		{
			const string logLine = @"[20:30:25.000] 00:0839:Y1,000ギギギを手に入れた。";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			Assert.IsNull(logEvent);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_Craft()
		{
			const string logLine = @"[21:23:42.000] 00:083e:Combatant Oneはアルドゴートジャケットを完成させた！";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Combatant Oneはアルドゴートジャケットを完成させた！", logEvent.LogMessage);
			Assert.AreEqual("アルドゴートジャケット", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}


		[Test]
		public void Parse_LogLine_ObtainsLoot_FishLand()
		{
			const string logLine = @"[21:23:42.000] 00:083e:Combatant Oneはピピラ（8.2イルム）を釣り上げた。";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Combatant Oneはピピラ（8.2イルム）を釣り上げた。", logEvent.LogMessage);
			Assert.AreEqual("ピピラ", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
			Assert.AreEqual("8.2イルム", lootEvent.Item.Size);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_FishSpear()
		{
			const string logLine = @"[21:23:42.000] 00:083e:Combatant Oneはヒラマサ（79.2イルム）を入手した。";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Combatant Oneはヒラマサ（79.2イルム）を入手した。", logEvent.LogMessage);
			Assert.AreEqual("ヒラマサ", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
			Assert.AreEqual("79.2イルム", lootEvent.Item.Size);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_HQ()
		{
			const string logLine =
				@"[21:56:57.000] 00:083e:Combatant Oneはドードーの笹身を手に入れた。";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Combatant Oneはドードーの笹身(HQ)を手に入れた。", logEvent.LogMessage);
			Assert.AreEqual("ドードーの笹身", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(true, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_ItemMostRare()
		{
			const string logLine =
				@"[21:56:57.000] 00:083e:Combatant Oneは希少なほりだしもの博識のメガマテリジャを入手した！";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Combatant Oneは希少なほりだしもの博識のメガマテリジャを入手した！", logEvent.LogMessage);
			Assert.AreEqual("博識のメガマテリジャ", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_ItemsMostRare()
		{
			const string logLine =
				@"[16:35:53.000] 00:083e:Combatant Oneは希少なほりだしものカララント:ダークグリーン×2を入手した！";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Combatant Oneは希少なほりだしものカララント:ダークグリーン×2を入手した！", logEvent.LogMessage);
			Assert.AreEqual("カララント:ダークグリーン", lootEvent.Item.SingularName);
			Assert.AreEqual(2, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_MultipleWorlds()
		{
			const string logLine =
				@"[21:20:24.000] 00:103e:Flying SirenGilgameshはカード:９Ｓを手に入れた。";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Flying Sirenはカード:９Ｓを手に入れた。", logEvent.LogMessage);
			Assert.AreEqual("カード:９Ｓ", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Flying Siren", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_Purchase()
		{
			const string logLine = @"[21:23:42.000] 00:083e:ハードレザー・マーチャントポーチをマーケットで購入しました。";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("ハードレザー・マーチャントポーチをマーケットで購入しました。", logEvent.LogMessage);
			Assert.AreEqual("ハードレザー・マーチャントポーチ", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_PurchaseWithAmount()
		{
			const string logLine = @"[21:23:42.000] 00:083e:トリフェーンディフェンダーイヤリング×2を15,147ギルで購入しました。";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("トリフェーンディフェンダーイヤリング×2を15,147ギルで購入しました。", logEvent.LogMessage);
			Assert.AreEqual("トリフェーンディフェンダーイヤリング", lootEvent.Item.SingularName);
			Assert.AreEqual(2, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_Standard()
		{
			const string logLine = @"[21:56:57.000] 00:083e:1,000ギルを手に入れた。";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("1,000ギルを手に入れた。", logEvent.LogMessage);
			Assert.AreEqual("ギル", lootEvent.Item.SingularName);
			Assert.AreEqual(1000, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_TheyObtain()
		{
			const string logLine =
				@"[21:20:24.000] 00:103e:Flying Hippoはカード:９Ｓを手に入れた。";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Flying Hippoはカード:９Ｓを手に入れた。", logEvent.LogMessage);
			Assert.AreEqual("カード:９Ｓ", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Flying Hippo", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_WithNumber()
		{
			const string logLine = @"[16:35:53.000] 00:103e:Jane Doeはエデンコーラス・ネックレスチェスト【ILv500】を手に入れた。";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Jane Doeはエデンコーラス・ネックレスチェスト【ILv500】を手に入れた。", logEvent.LogMessage);
			Assert.AreEqual("エデンコーラス・ネックレスチェスト【ILv500】", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Jane Doe", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_YouObtain()
		{
			const string logLine = @"[16:35:53.000] 00:083e:Combatant Oneは白銀床板を入手した。";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Combatant Oneは白銀床板を入手した。", logEvent.LogMessage);
			Assert.AreEqual("白銀床板", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_ObtainsLoot_YouObtain_MultipleItems()
		{
			const string logLine = @"[21:23:42.000] 00:083e:Combatant Oneは発光性アイスクリスタル×3を手に入れた。";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("Combatant Oneは発光性アイスクリスタル×3を手に入れた。", logEvent.LogMessage);
			Assert.AreEqual("発光性アイスクリスタル", lootEvent.Item.SingularName);
			Assert.AreEqual(3, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_PassiveObtainLoot()
		{
			const string logLine = @"[21:23:42.000] 00:083e: 古樹の霊砂を手に入れた。";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("古樹の霊砂を手に入れた。", logEvent.LogMessage);
			Assert.AreEqual("古樹の霊砂", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_PassiveObtainLoot_MultipleItems()
		{
			const string logLine = @"[21:23:42.000] 00:083e: 古樹の霊砂×3を手に入れた。";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("古樹の霊砂×3を手に入れた。", logEvent.LogMessage);
			Assert.AreEqual("古樹の霊砂", lootEvent.Item.SingularName);
			Assert.AreEqual(3, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
			Assert.AreEqual("Combatant One", lootEvent.Actor.Name);
		}

		[Test]
		public void Parse_LogLine_SearchLoot_Standard()
		{
			const string logLine = @"[21:23:42.000] 00:083e:信力のメガマテリジャの所持状況を確認します。";
			var logEvent = _parser.Parse(new ACTLogLineEvent {LogLine = logLine});
			var lootEvent = logEvent.KaptureEvent;
			Assert.IsNotNull(logEvent.Id);
			Assert.IsNotNull(logEvent.KaptureEvent);
			Assert.AreEqual("信力のメガマテリジャの所持状況を確認します。", logEvent.LogMessage);
			Assert.AreEqual("信力のメガマテリジャ", lootEvent.Item.SingularName);
			Assert.AreEqual(1, lootEvent.Item.Quantity);
			Assert.AreEqual(false, lootEvent.Item.IsHQ);
		}
	}
}