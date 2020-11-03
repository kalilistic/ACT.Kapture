using ACT_FFXIV.Aetherbridge.Mocks;
using ACT_FFXIV.Aetherbridge.XIVData;
using ACT_FFXIV.Aetherbridge.XIVData.Model;
using NUnit.Framework;

namespace ACT_FFXIV.Aetherbridge.Test.DataService
{
	[TestFixture]
	public class ItemServiceTest
	{
		[SetUp]
		public void TestInitialize()
		{
			var language = new Language(1, "English", "en");
			var gameDataManager = new GameDataManager();
			var languageRepository =
				new GameDataRepository<XIVData.Model.Language>(gameDataManager.Language);
			var languageService = new LanguageService(languageRepository, new FFXIVACTPluginWrapperMock(),
				new ACTConfig());
			IGameDataRepository<XIVData.Model.Item> itemRepository =
				new GameDataRepository<XIVData.Model.Item>(gameDataManager.Item);
			var itemActionRepository = new GameDataRepository<ItemAction>(gameDataManager.ItemAction);
			_itemService = new ItemService(itemRepository, itemActionRepository);
			_itemService.Initialize(language);
		}

		private ItemService _itemService;


		[Test]
		public void DeInit_SetsNull()
		{
			_itemService.DeInit();
		}

		[Test]
		public void GetCommonItemNames_CallTwice_ReturnsItemName()
		{
			_itemService.GetCommonItemNames();
			Assert.AreEqual("Luminous Water Crystal", _itemService.GetCommonItemNames()[0]);
		}

		[Test]
		public void GetCommonItemNames_ReturnsItemName()
		{
			Assert.AreEqual("Luminous Water Crystal", _itemService.GetCommonItemNames()[0]);
		}

		[Test]
		public void GetItemByID_BadID_ReturnsNull()
		{
			var item = _itemService.GetItemById(-1);
			Assert.IsNull(item);
		}

		[Test]
		public void GetItemByID_ReturnsItem()
		{
			var item = _itemService.GetItemById(10);
			Assert.AreEqual("Wind Crystal", item.ProperName);
		}

		[Test]
		public void GetItemByPluralName_ReturnsItem()
		{
			Assert.AreEqual(typeof(Item),
				_itemService.GetItemByPluralName("gil").GetType());
		}

		[Test]
		public void GetItemBySingularName_ReturnsItem()
		{
			Assert.AreEqual(typeof(Item),
				_itemService.GetItemBySingularName("gil").GetType());
		}

		[Test]
		public void GetItemNames_CallTwice_ReturnsItemName()
		{
			_itemService.GetItemNames();
			Assert.AreEqual("Luminous Water Crystal", _itemService.GetItemNames()[0]);
		}

		[Test]
		public void GetItemNames_ReturnsItemName()
		{
			Assert.AreEqual("Luminous Water Crystal", _itemService.GetItemNames()[0]);
		}

		[Test]
		public void GetMountItemNames_ReturnsItemName()
		{
			Assert.AreEqual("Magitek Hyperconveyor Identification Key", _itemService.GetMountItemNames()[0]);
		}
	}
}