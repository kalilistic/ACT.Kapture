using ACT_FFXIV.Aetherbridge.Properties;

namespace ACT_FFXIV.Aetherbridge.XIVData
{
	public class GameDataManager : IGameDataManager
	{
		public string ClassJob { get; } = Resources.ClassJob;
		public string Item { get; } = Resources.Item;
		public string ItemAction { get; } = Resources.ItemAction;
		public string World { get; } = Resources.World;
		public string ContentFinderCondition { get; } = Resources.ContentFinderCondition;
		public string TerritoryType { get; } = Resources.TerritoryType;
		public string PlaceName { get; } = Resources.PlaceName;
		public string Map { get; } = Resources.Map;
		public string Language { get; } = Resources.Language;
	}
}