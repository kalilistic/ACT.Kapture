using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using ACT_FFXIV.Aetherbridge.XIVData.Model;

namespace ACT_FFXIV.Aetherbridge.XIVData
{
	public class GameDataRepository<T> : IGameDataRepository<T> where T : IGameData, new()
	{
		private readonly List<T> _gameDataList;

		public GameDataRepository(string gameDataListStr)
		{
			_gameDataList = new List<T>();
			using (var sr = new StringReader(gameDataListStr))
			{
				string gameDataStr;
				while ((gameDataStr = sr.ReadLine()) != null)
					try
					{
						var gameDataStrFields = gameDataStr.Split(GameDataConstants.Separator);
						var gameData = new T();
						gameData.SetPropsByStr(gameDataStrFields);
						_gameDataList.Add(gameData);
					}
					catch (Exception)
					{
						// ignored
					}
			}
		}

		public IEnumerable<T> GetAll()
		{
			return _gameDataList;
		}

		public IEnumerable<T> Find(Expression<Func<T, bool>> query)
		{
			var func = query.Compile();
			var predicate = new Predicate<T>(func);
			return _gameDataList.FindAll(predicate);
		}

		public T GetById(int id)
		{
			try
			{
				return _gameDataList.First(gameData => gameData.Id == id);
			}
			catch (Exception)
			{
				return default;
			}
		}

		public T GetById(uint id)
		{
			return GetById(Convert.ToInt32(id));
		}
	}
}