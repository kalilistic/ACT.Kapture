using System.Collections.Generic;
using System.Collections.ObjectModel;
using FFXIV_ACT_Plugin.Common.Models;

namespace ACT_FFXIV.Aetherbridge.Mocks
{
	// ReSharper disable InconsistentNaming
	public class DataRepositoryMock
	{
		public string GetSelectedLanguageID()
		{
			return "1";
		}

		public uint GetCurrentTerritoryID()
		{
			return 1;
		}

		public uint GetCurrentPlayerID()
		{
			return 12345;
		}

		public ReadOnlyCollection<Combatant> GetCombatantList()
		{
			var combatants = new List<Combatant>
			{
				new Combatant
				{
					ID = 12345,
					Job = 1,
					Level = 80,
					Name = "Player One",
					CurrentWorldID = 63,
					WorldID = 63,
					PartyType = FFXIV_ACT_Plugin.Common.Models.PartyTypeEnum.Party
				},
				new Combatant
				{
					ID = 43432,
					Job = 1,
					Level = 80,
					Name = "Player Two",
					CurrentWorldID = 63,
					WorldID = 63,
					PartyType = FFXIV_ACT_Plugin.Common.Models.PartyTypeEnum.Party
				},
				new Combatant
				{
					ID = 23232,
					Job = 1,
					Level = 80,
					Name = "Player Three",
					CurrentWorldID = 63,
					WorldID = 63,
					PartyType = FFXIV_ACT_Plugin.Common.Models.PartyTypeEnum.Party
				},
				new Combatant
				{
					ID = 5454345,
					Job = 1,
					Level = 80,
					Name = "Player Four",
					CurrentWorldID = 63,
					WorldID = 63,
					PartyType = FFXIV_ACT_Plugin.Common.Models.PartyTypeEnum.Party
				},
				new Combatant
				{
					ID = 767566,
					Job = 1,
					Level = 80,
					Name = "Player Five",
					CurrentWorldID = 63,
					WorldID = 63,
					PartyType = FFXIV_ACT_Plugin.Common.Models.PartyTypeEnum.Party
				},
				new Combatant
				{
					ID = 956756,
					Job = 1,
					Level = 80,
					Name = "Player Six",
					CurrentWorldID = 63,
					WorldID = 63,
					PartyType = FFXIV_ACT_Plugin.Common.Models.PartyTypeEnum.Party
				},
				new Combatant
				{
					ID = 1213476,
					Job = 1,
					Level = 80,
					Name = "Player Seven",
					CurrentWorldID = 63,
					WorldID = 63,
					PartyType = FFXIV_ACT_Plugin.Common.Models.PartyTypeEnum.Party
				},
				new Combatant
				{
					ID = 6575634,
					Job = 1,
					Level = 80,
					Name = "Player Eight",
					CurrentWorldID = 63,
					WorldID = 63,
					PartyType = FFXIV_ACT_Plugin.Common.Models.PartyTypeEnum.Party
				},
				new Combatant
				{
					ID = 222426,
					Job = 1,
					Level = 80,
					Name = "Player Nine",
					CurrentWorldID = 63,
					WorldID = 63,
					PartyType = FFXIV_ACT_Plugin.Common.Models.PartyTypeEnum.Alliance
				},
				new Combatant
				{
					ID = 157777,
					Job = 1,
					Level = 80,
					Name = "Player Ten",
					CurrentWorldID = 63,
					WorldID = 63,
					PartyType = FFXIV_ACT_Plugin.Common.Models.PartyTypeEnum.Alliance
				},
				new Combatant
				{
					ID = 5433433,
					Job = 1,
					Level = 80,
					Name = "Player Eleven",
					CurrentWorldID = 63,
					WorldID = 63,
					PartyType = FFXIV_ACT_Plugin.Common.Models.PartyTypeEnum.None
				},
				new Combatant
				{
					ID = 9999887,
					Job = 1,
					Level = 80,
					Name = "Player Twelve",
					CurrentWorldID = 63,
					WorldID = 63,
					PartyType = FFXIV_ACT_Plugin.Common.Models.PartyTypeEnum.None
				}
			};
			return combatants.AsReadOnly();
		}
	}
}