using System;
using System.Net.Http;
using ACT_FFXIV_Kapture.Aetherbridge;
using ACT_FFXIV_Kapture.Aetherbridge.XIVData;
using ACT_FFXIV_Kapture.Aetherbridge.XIVData.Model;
using ACT_FFXIV_Kapture.Model;
using ACTConfig = ACT_FFXIV_Kapture.Aetherbridge.ACTConfig;
using ClassJob = ACT_FFXIV_Kapture.Aetherbridge.XIVData.Model.ClassJob;
using Configuration = ACT_FFXIV_Kapture.Config.Config;
using Item = ACT_FFXIV_Kapture.Aetherbridge.XIVData.Model.Item;
using Language = ACT_FFXIV_Kapture.Aetherbridge.XIVData.Model.Language;
using World = ACT_FFXIV_Kapture.Aetherbridge.XIVData.Model.World;

// ReSharper disable ConvertIfStatementToSwitchStatement

namespace ACT_FFXIV_Kapture.Plugin
{
	public class KaptureData : IKaptureData
	{
		private static volatile KaptureData _kaptureData;
		private static readonly object Lock = new object();
		private static IACTWrapper _actWrapper;
		private static IFFXIVACTPluginWrapper _ffxivACTPluginWrapper;
		private static HttpClient _httpClient;
		internal ILogLineParserFactory LogLineParserFactory;

		private KaptureData()
		{
			ACTConfig = new ACTConfig();
			InitWrappers();
			InitGameData();
		}

		public ClassJobService ClassJobService { get; set; }
		public WorldService WorldService { get; set; }
		public LocationService LocationService { get; set; }
		public ContentService ContentService { get; set; }
		public ItemService ItemService { get; set; }
		public LanguageService LanguageService { get; set; }
		public PlayerService PlayerService { get; set; }
		public ACTConfig ACTConfig { get; set; }

		public void Initialize(int languageId)
		{
			var language = LanguageService.GetLanguageById(languageId);
			_httpClient = new HttpClient();
			ClassJobService.Initialize(language);
			LocationService.Initialize(language);
			ContentService.Initialize(language);
			ItemService.Initialize(language);
		}

		public event EventHandler<LogLineEvent> LogLineCaptured;


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

		public void EnableLogLineParser()
		{
			if (ACTConfig.LogLineParserEnabled) return;
			if (LogLineParserFactory == null) InitLogLineParser();
			ACTConfig.LogLineParserEnabled = true;
			_actWrapper.ACTLogLineParserEnabled = true;
			_actWrapper.ACTLogLineCaptured += ACTLogLineCaptured;
		}

		public void DeInit()
		{
			DisableLogLineParser();
			_httpClient.Dispose();
		}

		public void DisableLogLineParser()
		{
			if (!ACTConfig.LogLineParserEnabled) return;
			ACTConfig.LogLineParserEnabled = false;
			_actWrapper.ACTLogLineParserEnabled = false;
			_actWrapper.ACTLogLineCaptured -= ACTLogLineCaptured;
		}

		public void ACTLogLineCaptured(object sender, ACTLogLineEvent actLogLineEvent)
		{
			var logLineEvent = LogLineParserFactory.CreateParser().Parse(actLogLineEvent);
			if (logLineEvent == null) return;
			LogLineCaptured?.Invoke(this, logLineEvent);
		}

		private static void InitWrappers()
		{
			_actWrapper = ACTWrapper.GetInstance();
			FFXIVACTPluginWrapper.Initialize(_actWrapper);
			_ffxivACTPluginWrapper = FFXIVACTPluginWrapper.GetInstance();
		}

		public string GetAppDirectory()
		{
			return _actWrapper.GetAppDataFolderFullName();
		}

		public static KaptureData GetInstance()
		{
			if (_kaptureData != null) return _kaptureData;

			lock (Lock)
			{
				if (_kaptureData == null) _kaptureData = new KaptureData();
			}

			return _kaptureData;
		}
	}
}