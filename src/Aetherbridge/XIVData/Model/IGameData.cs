namespace ACT_FFXIV.Aetherbridge.XIVData.Model
{
	public interface IGameData
	{
		int Id { get; set; }
		void SetPropsByStr(string[] propertyStr);
	}
}