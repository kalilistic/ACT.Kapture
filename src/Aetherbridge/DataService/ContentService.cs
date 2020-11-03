using System.Collections.Generic;
using System.Linq;
using ACT_FFXIV.Aetherbridge.XIVData;
using ACT_FFXIV.Aetherbridge.XIVData.Model;

namespace ACT_FFXIV.Aetherbridge
{
	public class ContentService
	{
		private readonly IReadOnlyCollection<Zone> _pluginZones;
		private readonly IGameDataRepository<ContentFinderCondition> _repository;
		private List<Content> _content = new List<Content>();
		private List<Content> _highEndContent = new List<Content>();

		public ContentService(IReadOnlyCollection<Zone> pluginZones,
			IGameDataRepository<ContentFinderCondition> repository)
		{
			_repository = repository;
			_pluginZones = pluginZones;
		}

		public void Initialize(Language language)
		{
			var contentFinderConditionList = _repository.GetAll();
			contentFinderConditionList = contentFinderConditionList.OrderBy(content => content.Name);
			foreach (var contentFinderCondition in contentFinderConditionList)
			{
				var inPluginZones = false;
				foreach (var _ in _pluginZones.Where(
					pluginZone => pluginZone.Id == contentFinderCondition.TerritoryType))
					inPluginZones = true;
				if (!inPluginZones) continue;
				var contentName = contentFinderCondition.Localized[language.Index]?.Name;
				if (contentName == null || contentName.Equals(string.Empty)) continue;
				var content = new Content
				{
					Id = contentFinderCondition.Id,
					TerritoryTypeId = contentFinderCondition.TerritoryType,
					IsHighEndDuty = contentFinderCondition.HighEndDuty,
					Name = contentName
				};
				_content.Add(content);
				if (content.IsHighEndDuty) _highEndContent.Add(content);
			}
		}

		public List<Content> GetHighEndContent()
		{
			return _highEndContent;
		}

		public List<Content> GetContent()
		{
			return _content;
		}

		public Content GetContentByTerritoryTypeId(int territoryTypeId)
		{
			return _content
				.Find(content => content.TerritoryTypeId == territoryTypeId);
		}

		public List<string> GetContentNames()
		{
			return _content.Select(content => content.Name).ToList();
		}

		public List<string> GetHighEndContentNames()
		{
			return GetHighEndContent().Select(content => content.Name).ToList();
		}

		public void DeInit()
		{
			_content = null;
			_highEndContent = null;
		}
	}
}