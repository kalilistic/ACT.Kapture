using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ACT_FFXIV.Aetherbridge.XIVData;
using ACT_FFXIV.Aetherbridge.XIVData.Model;
// ReSharper disable ConvertIfStatementToConditionalTernaryExpression
// ReSharper disable InconsistentNaming

// ReSharper disable InvertIf
namespace ACT_FFXIV.Aetherbridge
{
	public class ItemService
	{
		private readonly IGameDataRepository<ItemAction> _itemActionRepository;
		private readonly IGameDataRepository<XIVData.Model.Item> _itemRepository;
		private readonly List<string> _mountItemNames = new List<string>();
		private List<string> _commonItemNames = new List<string>();
		private List<string> _itemNames = new List<string>();
		private List<Item> _items = new List<Item>();

		public ItemService(IGameDataRepository<XIVData.Model.Item> itemRepository,
			IGameDataRepository<ItemAction> itemActionRepository)
		{
			_itemRepository = itemRepository;
			_itemActionRepository = itemActionRepository;
		}

		public void Initialize(Language language)
		{
			var xivDataItems = _itemRepository.GetAll();
			var itemActions = _itemActionRepository.GetAll();

			foreach (var xivDataItem in xivDataItems)
			{
				var item = MapToItem(xivDataItem, language);
				_items.Add(item);
				_itemNames.Add(item.ProperName);
				if (item.IsCommon) _commonItemNames.Add(item.ProperName);

				// ReSharper disable once PossibleMultipleEnumeration
				var itemAction = itemActions.FirstOrDefault(action => action.Id == xivDataItem.ItemAction);

				if (itemAction != null && itemAction.Type == GameDataConstants.MountUnlock)
					_mountItemNames.Add(item.ProperName);
			}

			if (language.Id == 3)
				foreach (var item in _items)
				{
					if (!string.IsNullOrEmpty(item.SingularREP))
					{
						item.SingularRegex = new Regex(item.SingularREP, RegexOptions.Compiled);
					}
					else
					{
						item.SingularRegex = new Regex("^NO_GERMAN_LOCALIZATION", RegexOptions.Compiled);
					}
					if (!string.IsNullOrEmpty(item.PluralREP))
					{
						item.PluralRegex = new Regex(item.PluralREP, RegexOptions.Compiled);
					}
					else
					{
						item.PluralRegex = new Regex("^NO_GERMAN_LOCALIZATION", RegexOptions.Compiled);
					}
				}
		}

		public Item GetItemById(int id)
		{
			return _items.FirstOrDefault(item => item.Id == id);
		}

		public Item GetItemBySingularName(string singularName)
		{
			var item = _items.FirstOrDefault(i => i.SingularName.Equals(singularName));
			return item;
		}

		public Item GetItemByPluralName(string pluralName)
		{
			var item = _items.FirstOrDefault(i => i.PluralName.Equals(pluralName));
			return item;
		}

		public Item GetItemByProperName(string properName)
		{
			var item = _items.FirstOrDefault(i => i.ProperName.Equals(properName));
			return item;
		}

		public Item GetItemBySingularSearchTerm(string singularName)
		{
			var item = _items.FirstOrDefault(i => i.SingularSearchTerm.Equals(singularName));
			return item;
		}

		public Item GetItemByPluralSearchTerm(string pluralName)
		{
			var item = _items.FirstOrDefault(i => i.PluralSearchTerm.Equals(pluralName));
			return item;
		}

		public Item GetItemBySingularSearchTermDE(string singularName)
		{
			var items = _items.FindAll(i => singularName.StartsWith(i.SingularSearchTerm) && !string.IsNullOrEmpty(i.SingularName));
			switch (items.Count)
			{
				case 0:
					return null;
				case 1:
					return items[0];
			}

			return items.FirstOrDefault(item => item.SingularRegex.Match(singularName).Success);
		}

		public Item GetItemByPluralSearchTermDE(string pluralName)
		{
			var items = _items.FindAll(i => pluralName.StartsWith(i.PluralSearchTerm) && !string.IsNullOrEmpty(i.PluralName));
			switch (items.Count)
			{
				case 0:
					return null;
				case 1:
					return items[0];
			}

			return items.FirstOrDefault(item => item.PluralRegex.Match(pluralName).Success);
		}

		public List<string> GetItemNames()
		{
			return _itemNames;
		}

		public List<string> GetCommonItemNames()
		{
			return _commonItemNames;
		}

		public List<string> GetMountItemNames()
		{
			return _mountItemNames;
		}

		public void DeInit()
		{
			_items = null;
			_commonItemNames = null;
			_itemNames = null;
		}

		public static Item MapToItem(XIVData.Model.Item item, Language language)
		{
			if (item == null) return null;
			return new Item
			{
				Id = item.Id,
				IsUntradable = item.IsUntradable,
				IsMarketable = item.ItemSearchCategory != 0,
				VendorBuyPrice = item.VendorBuyPrice,
				ProperName = item.Localized[language.Index].ProperName,
				SingularName = item.Localized[language.Index].SingularName,
				PluralName = item.Localized[language.Index].PluralName,
				SingularSearchTerm = item.Localized[language.Index].SingularSearchTerm,
				PluralSearchTerm = item.Localized[language.Index].PluralSearchTerm,
				SingularREP = item.Localized[language.Index].SingularREP,
				PluralREP = item.Localized[language.Index].PluralREP,
				IsCommon = item.IsCommon
			};
		}
	}
}