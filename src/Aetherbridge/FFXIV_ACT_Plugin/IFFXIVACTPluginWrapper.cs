using System.Collections.Generic;
using FFXIV_ACT_Plugin.Common.Models;

namespace ACT_FFXIV.Aetherbridge
{
	public interface IFFXIVACTPluginWrapper
	{
		FFXIV_ACT_Plugin.Common.Language GetSelectedLanguage();
		uint GetCurrentTerritoryId();
		Combatant GetCurrentCombatant();
		List<Combatant> GetPartyCombatants();
		List<Combatant> GetAllianceCombatants();
		Combatant GetCombatantByName(string name);
		List<Zone> GetZoneList();
	}
}