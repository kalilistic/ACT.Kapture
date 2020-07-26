using System;
using ACT_FFXIV_Kapture.Aetherbridge;
using ACT_FFXIV_Kapture.Model;
using ACTConfig = ACT_FFXIV_Kapture.Aetherbridge.ACTConfig;

namespace ACT_FFXIV_Kapture.Plugin
{
	public interface IKaptureData
	{
		ClassJobService ClassJobService { get; set; }
		WorldService WorldService { get; set; }
		LocationService LocationService { get; set; }
		ContentService ContentService { get; set; }
		ItemService ItemService { get; set; }
		LanguageService LanguageService { get; set; }
		PlayerService PlayerService { get; set; }
		ACTConfig ACTConfig { get; set; }
		event EventHandler<LogLineEvent> LogLineCaptured;
		void InitGameData();
		void Initialize();
		void Initialize(int languageId);
		void DeInit();
		void EnableLogLineParser();
		void InitLogLineParser();
	}
}