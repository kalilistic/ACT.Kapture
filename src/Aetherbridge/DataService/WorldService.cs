using System;
using System.Collections.Generic;
using System.Linq;
using ACT_FFXIV.Aetherbridge.XIVData;

namespace ACT_FFXIV.Aetherbridge
{
	public class WorldService
	{
		private IGameDataRepository<XIVData.Model.World> _repository;

		public WorldService(IGameDataRepository<XIVData.Model.World> repository)
		{
			_repository = repository;
		}

		public World GetWorldById(int id)
		{
			return MapToWorld(_repository.GetById(id));
		}

		public World GetWorldById(uint id)
		{
			return MapToWorld(_repository.GetById(Convert.ToInt32(id)));
		}

		public List<World> GetWorlds()
		{
			return MapToWorlds(_repository.GetAll().ToList());
		}

		public string GetWorldsAsDelimitedString()
		{
			var worldsStr = string.Empty;
			var worlds = GetWorlds();
			worldsStr = worlds.Aggregate(worldsStr, (current, world) => current + world.Name + "|");
			worldsStr = worldsStr.TrimEnd('|');
			return worldsStr;
		}

		public void DeInit()
		{
			_repository = null;
		}

		public static List<World> MapToWorlds(List<XIVData.Model.World> gameDataWorlds)
		{
			return gameDataWorlds?.Select(MapToWorld).ToList();
		}

		public static World MapToWorld(XIVData.Model.World gameDataWorld)
		{
			if (gameDataWorld == null) return null;
			return new World
			{
				Id = gameDataWorld.Id,
				Name = gameDataWorld.Name
			};
		}
	}
}