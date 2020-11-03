using System;
using System.Linq;
using System.Linq.Expressions;
using ACT_FFXIV.Aetherbridge.Mocks;
using ACT_FFXIV.Aetherbridge.XIVData;
using NUnit.Framework;

namespace ACT_FFXIV.Aetherbridge.Test
{
	[TestFixture]
	public class GameDataRepositoryTest
	{
		[SetUp]
		public void TestInitialize()
		{
			_gameDataMockRepository = new GameDataRepository<GameDataMock>(MockDataUtil.GetGameData());
		}

		private GameDataRepository<GameDataMock> _gameDataMockRepository;

		[Test]
		public void Find_ReturnsGameDataList()
		{
			Expression<Func<GameDataMock, bool>> query = gameDataMock => gameDataMock.Id == 690;
			var gameDataMockList = _gameDataMockRepository.Find(query).ToList();
			Assert.IsNotNull(gameDataMockList);
			Assert.AreEqual(690, gameDataMockList[0].Id);
		}

		[Test]
		public void GetAll_ReturnsGameDataList()
		{
			var gameDataMockList = _gameDataMockRepository.GetAll().ToList();
			Assert.IsNotNull(gameDataMockList);
			Assert.AreEqual(690, gameDataMockList[0].Id);
			Assert.AreEqual(856, gameDataMockList[0].TerritoryType);
			Assert.IsTrue(gameDataMockList[0].HighEndDuty);
			Assert.AreEqual("Eden's Gate: Sepulture (Savage)", gameDataMockList[0].Localized[0].Name);
			Assert.AreEqual("L'Éveil d'Éden - Inhumation (sadique)", gameDataMockList[0].Localized[1].Name);
			Assert.AreEqual("Edens Erwachen - Beerdigung (episch)", gameDataMockList[0].Localized[2].Name);
			Assert.AreEqual("希望の園エデン零式：覚醒編4", gameDataMockList[0].Localized[3].Name);
		}

		[Test]
		public void GetById_BadID_ReturnsGameData()
		{
			var gameDataMock = _gameDataMockRepository.GetById(-1);
			Assert.IsNull(gameDataMock);
		}

		[Test]
		public void GetById_MissingID_ReturnsGameData()
		{
			var gameDataMock = _gameDataMockRepository.GetById(5);
			Assert.IsNull(gameDataMock);
		}

		[Test]
		public void GetById_ReturnsGameData()
		{
			var gameDataMock = _gameDataMockRepository.GetById(690);
			Assert.AreEqual(typeof(GameDataMock), gameDataMock.GetType());
		}
	}
}