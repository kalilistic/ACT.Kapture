using ACT_FFXIV.Aetherbridge.Mocks;
using ACT_FFXIV.Aetherbridge.XIVData;
using NUnit.Framework;

namespace ACT_FFXIV.Aetherbridge.Test.DataService
{
	[TestFixture]
	public class ClassJobServiceTest
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
			IGameDataRepository<XIVData.Model.ClassJob> classJobRepository =
				new GameDataRepository<XIVData.Model.ClassJob>(gameDataManager.ClassJob);
			_classJobService = new ClassJobService(classJobRepository);
			_classJobService.Initialize(language);
		}

		private ClassJobService _classJobService;

		[Test]
		public void DeInit_SetsNull()
		{
			_classJobService.DeInit();
		}

		[Test]
		public void GetClassJobByID_BadID_ReturnsNull()
		{
			var classJob = _classJobService.GetClassJobById(-1);
			Assert.IsNull(classJob);
		}

		[Test]
		public void GetClassJobByID_ReturnsClassJob()
		{
			var classJob = _classJobService.GetClassJobById(2);
			Assert.AreEqual("PGL", classJob.Abbreviation);
		}
	}
}