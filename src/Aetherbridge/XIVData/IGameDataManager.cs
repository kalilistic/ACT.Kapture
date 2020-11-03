namespace ACT_FFXIV.Aetherbridge.XIVData
{
	public interface IGameDataManager
	{
		string ClassJob { get; }
		string Item { get; }
		string ItemAction { get; }
		string World { get; }
		string ContentFinderCondition { get; }
		string TerritoryType { get; }
		string PlaceName { get; }
		string Map { get; }
		string Language { get; }
	}
}