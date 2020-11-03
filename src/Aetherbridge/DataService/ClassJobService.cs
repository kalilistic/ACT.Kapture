using System.Collections.Generic;
using System.Linq;
using ACT_FFXIV.Aetherbridge.XIVData;

namespace ACT_FFXIV.Aetherbridge
{
	public class ClassJobService
	{
		private readonly IGameDataRepository<XIVData.Model.ClassJob> _repository;
		private List<ClassJob> _classJobs = new List<ClassJob>();

		public ClassJobService(IGameDataRepository<XIVData.Model.ClassJob> repository)
		{
			_repository = repository;
		}

		public void Initialize(Language language)
		{
			var xivDataClassJobs = _repository.GetAll();
			foreach (var xivDataClassJob in xivDataClassJobs)
				_classJobs.Add(MapToClassJob(xivDataClassJob, language));
		}

		public ClassJob GetClassJobById(int id)
		{
			return _classJobs.FirstOrDefault(classJob => classJob.Id == id);
		}

		public void DeInit()
		{
			_classJobs = null;
		}

		public static ClassJob MapToClassJob(XIVData.Model.ClassJob classJob, Language language)
		{
			if (classJob == null) return null;
			return new ClassJob
			{
				Id = classJob.Id,
				Name = classJob.Localized[language.Index].Name,
				Abbreviation = classJob.Localized[language.Index].Abbreviation
			};
		}
	}
}