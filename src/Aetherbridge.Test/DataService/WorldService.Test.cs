using ACT_FFXIV.Aetherbridge.XIVData;
using NUnit.Framework;

namespace ACT_FFXIV.Aetherbridge.Test.DataService
{
	[TestFixture]
	public class WorldServiceTest
	{
		[SetUp]
		public void TestInitialize()
		{
			var gameDataManager = new GameDataManager();
			var worldRepository = new GameDataRepository<XIVData.Model.World>(gameDataManager.World);
			_worldService = new WorldService(worldRepository);
		}

		private WorldService _worldService;

		[Test]
		public void DeInit_SetsNull()
		{
			_worldService.DeInit();
		}


		[Test]
		public void GetWorlds_ReturnsWorlds()
		{
			var worlds = _worldService.GetWorlds();
			Assert.IsTrue(worlds.Count > 0);
		}
	}
}