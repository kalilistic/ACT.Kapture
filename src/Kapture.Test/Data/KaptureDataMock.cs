using System;
using ACT_FFXIV_Kapture.Aetherbridge;
using ACT_FFXIV_Kapture.Aetherbridge.Mocks;
using ACT_FFXIV_Kapture.Aetherbridge.XIVData;
using ACT_FFXIV_Kapture.Aetherbridge.XIVData.Model;
using ACT_FFXIV_Kapture.Model;
using ACT_FFXIV_Kapture.Plugin;
using ACTConfig = ACT_FFXIV_Kapture.Model.ACTConfig;
using ClassJob = ACT_FFXIV_Kapture.Aetherbridge.XIVData.Model.ClassJob;
using Item = ACT_FFXIV_Kapture.Aetherbridge.XIVData.Model.Item;
using Language = ACT_FFXIV_Kapture.Aetherbridge.XIVData.Model.Language;
using World = ACT_FFXIV_Kapture.Aetherbridge.XIVData.Model.World;

namespace ACT_FFXIV_Kapture.Test
{
	public class KaptureDataMock : IKaptureData
	{
		private static volatile KaptureDataMock _kaptureCore;
		private static readonly object Lock = new object();
		private static IACTWrapper _actWrapper;
		private static IFFXIVACTPluginWrapper _ffxivACTPluginWrapper;
		internal ILogLineParserFactory LogLineParserFactory;

		private KaptureDataMock()
		{
			ACTConfig = new Aetherbridge.ACTConfig();
			InitWrappers();
			InitGameData();
		}

		public ACTConfig KaptureACTConfig { get; set; }

		public ClassJobService ClassJobService { get; set; }
		public WorldService WorldService { get; set; }
		public LocationService LocationService { get; set; }
		public ContentService ContentService { get; set; }
		public ItemService ItemService { get; set; }
		public LanguageService LanguageService { get; set; }
		public PlayerService PlayerService { get; set; }
		public Aetherbridge.ACTConfig ACTConfig { get; set; }
#pragma warning disable 67
		public event EventHandler<LogLineEvent> LogLineCaptured;
#pragma warning restore 67
		public void InitGameData()
		{
			var gameDataManager = new GameDataManager();
			var languageRepository = new GameDataRepository<Language>(gameDataManager.Language);
			LanguageService = new LanguageService(languageRepository, _ffxivACTPluginWrapper, ACTConfig);
			var worldRepository = new GameDataRepository<World>(gameDataManager.World);
			WorldService = new WorldService(worldRepository);
			var classJobRepository = new GameDataRepository<ClassJob>(gameDataManager.ClassJob);
			ClassJobService = new ClassJobService(classJobRepository);
			LocationService = new LocationService(gameDataManager, _ffxivACTPluginWrapper);
			var contentRepository =
				new GameDataRepository<ContentFinderCondition>(gameDataManager.ContentFinderCondition);
			ContentService =
				new ContentService(_ffxivACTPluginWrapper.GetZoneList(), contentRepository);
			var itemRepository = new GameDataRepository<Item>(gameDataManager.Item);
			var itemActionRepository = new GameDataRepository<ItemAction>(gameDataManager.ItemAction);
			ItemService = new ItemService(itemRepository, itemActionRepository);
			PlayerService = new PlayerService(_actWrapper, _ffxivACTPluginWrapper, WorldService, ClassJobService);
		}

		public void Initialize()
		{
			InitGameData();
			EnableLogLineParser();
		}

		public void Initialize(int languageId)
		{
			var language = LanguageService.GetLanguageById(languageId);
			ClassJobService.Initialize(language);
			LocationService.Initialize(language);
			ContentService.Initialize(language);
			ItemService.Initialize(language);
		}

		public void DeInit()
		{
			_kaptureCore = null;
			LogLineParserFactory = null;
			KaptureACTConfig = null;
		}

		public void EnableLogLineParser()
		{
			if (KaptureACTConfig.LogLineParserEnabled) return;
			if (LogLineParserFactory == null) InitLogLineParser();
			KaptureACTConfig.LogLineParserEnabled = true;
		}

		public void InitLogLineParser()
		{
			var lang = LanguageService.GetCurrentLanguage();
			switch (lang.Id)
			{
				case 1:
					LogLineParserFactory = new ENLogLineParserFactory(this);
					break;
				case 2:
					LogLineParserFactory = new FRLogLineParserFactory(this);
					break;
				case 3:
					LogLineParserFactory = new DELogLineParserFactory(this);
					break;
				case 4:
					LogLineParserFactory = new JALogLineParserFactory(this);
					break;
			}
		}

		private static void InitWrappers()
		{
			_actWrapper = new ACTWrapperMock();
			_ffxivACTPluginWrapper = new FFXIVACTPluginWrapperMock();
		}

		public static KaptureDataMock GetInstance()
		{
			if (_kaptureCore != null) return _kaptureCore;

			lock (Lock)
			{
				if (_kaptureCore == null) _kaptureCore = new KaptureDataMock();
			}

			return _kaptureCore;
		}
	}
}