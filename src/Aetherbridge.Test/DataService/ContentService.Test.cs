using ACT_FFXIV.Aetherbridge.Mocks;
using ACT_FFXIV.Aetherbridge.XIVData;
using ACT_FFXIV.Aetherbridge.XIVData.Model;
using NUnit.Framework;

// ReSharper disable IsExpressionAlwaysTrue

namespace ACT_FFXIV.Aetherbridge.Test.DataService
{
	[TestFixture]
	public class ContentServiceTest
	{
		[SetUp]
		public void TestInitialize()
		{
			var language = new Language(1, "English", "en");
			var gameDataManager = new GameDataManager();
			IGameDataRepository<ContentFinderCondition> contentRepository =
				new GameDataRepository<ContentFinderCondition>(gameDataManager.ContentFinderCondition);
			var pluginZones = new FFXIVACTPluginWrapperMock().GetZoneList();
			_contentService = new ContentService(pluginZones, contentRepository);
			_contentService.Initialize(language);
		}

		private ContentService _contentService;

		[Test]
		public void DeInit_SetsNull()
		{
			_contentService.DeInit();
		}

		[Test]
		public void GetContent_ReturnsContent()
		{
			var contents = _contentService.GetContent();
			Assert.IsTrue(contents.Count > 0);
		}

		[Test]
		public void GetContentNames_ReturnsContentNames()
		{
			var zones = _contentService.GetContentNames();
			Assert.IsTrue(zones.Count > 0);
		}

		[Test]
		public void GetHighEndContentNames_ReturnsHighEndContentNames()
		{
			var zones = _contentService.GetHighEndContentNames();
			Assert.IsTrue(zones.Count > 0);
		}
	}
}