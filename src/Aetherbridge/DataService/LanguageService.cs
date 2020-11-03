using System.Collections.Generic;
using System.Linq;
using ACT_FFXIV.Aetherbridge.XIVData;

namespace ACT_FFXIV.Aetherbridge
{
	public class LanguageService
	{
		private readonly ACTConfig _actConfig;
		private readonly IFFXIVACTPluginWrapper _ffxivACTPluginWrapper;
		private readonly List<Language> _languages;
		private IGameDataRepository<XIVData.Model.Language> _repository;

		public LanguageService(IGameDataRepository<XIVData.Model.Language> repository,
			IFFXIVACTPluginWrapper ffxivACTPluginWrapper, ACTConfig actConfig)
		{
			_repository = repository;
			_languages = MapToLanguages(_repository.GetAll().ToList());
			_ffxivACTPluginWrapper = ffxivACTPluginWrapper;
			_actConfig = actConfig;
		}

		public Language GetLanguageById(int id)
		{
			return MapToLanguage(_repository.GetById(id));
		}

		public List<Language> GetLanguages()
		{
			return _languages;
		}

		public void DeInit()
		{
			_repository = null;
		}

		public static List<Language> MapToLanguages(List<XIVData.Model.Language> gameDataLanguages)
		{
			return gameDataLanguages?.Select(MapToLanguage).ToList();
		}

		public static Language MapToLanguage(XIVData.Model.Language gameDataLanguage)
		{
			return gameDataLanguage == null
				? null
				: new Language(gameDataLanguage.Id, gameDataLanguage.Name, gameDataLanguage.Abbreviation);
		}

		public Language GetCurrentLanguage()
		{
			if (_actConfig != null && IsSupported(_actConfig.GameLanguageId))
				return GetLanguageById(_actConfig.GameLanguageId);
			if (IsSupported((int) _ffxivACTPluginWrapper.GetSelectedLanguage()))
				return GetLanguageById((int) _ffxivACTPluginWrapper.GetSelectedLanguage());
			return GetLanguageById(1);
		}

		private static bool IsSupported(int languageId)
		{
			return languageId > 0 && languageId < 5;
		}
	}
}