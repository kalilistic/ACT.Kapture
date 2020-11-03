using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ACT_FFXIV.Aetherbridge.XIVData.Model;

namespace ACT_FFXIV.Aetherbridge.XIVData
{
	public interface IGameDataRepository<T> where T : IGameData, new()
	{
		IEnumerable<T> GetAll();
		IEnumerable<T> Find(Expression<Func<T, bool>> query);
		T GetById(int id);
		T GetById(uint id);
	}
}