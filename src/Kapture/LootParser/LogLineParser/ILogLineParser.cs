using ACT_FFXIV_Kapture.Aetherbridge;
using ACT_FFXIV_Kapture.Model;

namespace ACT_FFXIV_Kapture.Plugin
{
	internal interface ILogLineParser
	{
		LogLineEvent Parse(ACTLogLineEvent actLogLineEvent);
		Item FindItem(string itemName, int quantity);
	}
}