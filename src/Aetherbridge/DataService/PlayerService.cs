using System.Collections.Generic;
using System.Linq;
using FFXIV_ACT_Plugin.Common.Models;

namespace ACT_FFXIV.Aetherbridge
{
	public class PlayerService
	{
		private readonly IACTWrapper _actWrapper;
		private readonly ClassJobService _classJobService;
		private readonly IFFXIVACTPluginWrapper _ffxivACTPluginWrapper;
		private readonly WorldService _worldService;

		public PlayerService(IACTWrapper actWrapper, IFFXIVACTPluginWrapper ffxivACTPluginWrapper,
			WorldService worldService, ClassJobService classJobService)
		{
			_worldService = worldService;
			_classJobService = classJobService;
			_actWrapper = actWrapper;
			_ffxivACTPluginWrapper = ffxivACTPluginWrapper;
		}

		internal List<Player> MapToPlayers(IEnumerable<Combatant> combatants)
		{
			return combatants?.Select(MapToPlayer).ToList();
		}

		internal Player MapToPlayer(Combatant combatant)
		{
			if (combatant == null) return null;
			var player = new Player
			{
				Id = combatant.ID,
				Name = combatant.Name,
				Level = combatant.Level,
				PartyType = (PartyTypeEnum) combatant.PartyType,
				Order = combatant.Order,
				CurrentWorld = _worldService.GetWorldById(combatant.CurrentWorldID),
				HomeWorld = _worldService.GetWorldById(combatant.WorldID),
				ClassJob = _classJobService.GetClassJobById(combatant.Job)
			};
			return player;
		}

		public Player GetCurrentPlayer()
		{
			var combatant = _ffxivACTPluginWrapper.GetCurrentCombatant();
			Player player;
			if (combatant == null)
			{
				var importName = ACTWrapper.GetInstance().GetCharacterName();
				player = importName.Equals(string.Empty) || !importName.Contains(" ")
					? new Player {Name = "Your Character"}
					: new Player {Name = ACTWrapper.GetInstance().GetCharacterName()};
			}
			else
			{
				player = MapToPlayer(combatant);
			}

			player.IsReporter = true;
			return player;
		}

		public List<Player> GetPartyMembers()
		{
			return MapToPlayers(_ffxivACTPluginWrapper.GetPartyCombatants());
		}

		public List<Player> GetAllianceMembers()
		{
			return MapToPlayers(_ffxivACTPluginWrapper.GetAllianceCombatants());
		}

		public Player GetPlayerByName(string name)
		{
			var combatant = _ffxivACTPluginWrapper.GetCombatantByName(name);
			return combatant == null ? null : MapToPlayer(combatant);
		}
	}
}