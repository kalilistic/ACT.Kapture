namespace ACT_FFXIV.Aetherbridge
{
	public interface IConfigManager
	{
		void SaveSettings();
		void LoadSettings();
		void DeInit();
	}
}