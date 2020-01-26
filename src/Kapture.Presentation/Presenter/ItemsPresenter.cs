using System.Collections.Generic;
using System.Linq;
using ACT_FFXIV_Aetherbridge;
using ACT_FFXIV_Kapture.Config;
using Configuration = ACT_FFXIV_Kapture.Config.Config;

namespace ACT_FFXIV_Kapture.Presentation
{
	public class ItemsPresenter
	{
		private readonly IItemService _itemService;
		public Configuration Configuration;
		public KaptureConfig KaptureConfig;

		public ItemsPresenter(ItemsView itemsView, IItemService itemService)
		{
			ItemsView = itemsView;

			KaptureConfig = KaptureConfig.GetInstance();
			Configuration = (Configuration) KaptureConfig.ConfigManager.Config;
			_itemService = itemService;

			ItemsView.FilterByItems = Configuration.Items.FilterByItems;
			ItemsView.ItemPresetList = ItemPreset.ItemPresets;
			ItemsView.ItemPreset = Configuration.Items.ItemPreset;
			ItemsView.AddItem = itemService.GetItemNames();
			SetFilterByPreset();

			ItemsView.FilterByItemsChanged += FilterByItemsChanged;
			ItemsView.ItemPresentChanged += ItemPresetChanged;
			ItemsView.IncludeItemsEnabledChanged += IncludeItemsEnabledChanged;
			ItemsView.ExcludeItemsEnabledChanged += ExcludeItemsEnabledChanged;
			ItemsView.ItemsListChanged += ItemsListChanged;
			ItemsView.ItemsListAdded += ItemsListAdded;
		}

		public ItemsView ItemsView { get; set; }

		private void SetFilterByPreset()
		{
			var itemPreset = ItemsView.ItemPreset;
			if (itemPreset.Equals(ItemPreset.ExcludeCommonItems))
			{
				ItemsView.ItemsList = _itemService.GetCommonItemNames();
				Configuration.Items.ItemsList = _itemService.GetCommonItemNames();
				Configuration.Items.ExcludeItems = true;
				ItemsView.ExcludeItemsEnabled = Configuration.Items.ExcludeItems;
				KaptureConfig.ConfigManager.SaveSettings();
			}
			else
			{
				ItemsView.IncludeItemsEnabled = Configuration.Items.IncludeItems;
				ItemsView.ExcludeItemsEnabled = Configuration.Items.ExcludeItems;
				ItemsView.ItemsList = Configuration.Items.ItemsList;
			}
		}

		private void SetFilterToCustomPreset()
		{
			Configuration.Items.ItemPreset = ItemPreset.Custom;
			ItemsView.ItemPreset = Configuration.Items.ItemPreset;
		}

		private void FilterByItemsChanged(object sender, bool e)
		{
			Configuration.Items.FilterByItems = e;
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void ItemPresetChanged(object sender, ItemPreset e)
		{
			Configuration.Items.ItemPreset = e;
			SetFilterByPreset();
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void IncludeItemsEnabledChanged(object sender, bool e)
		{
			Configuration.Items.IncludeItems = e;
			SetFilterToCustomPreset();
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void ExcludeItemsEnabledChanged(object sender, bool e)
		{
			Configuration.Items.ExcludeItems = e;
			SetFilterToCustomPreset();
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void ItemsListChanged(object sender, List<string> e)
		{
			Configuration.Items.ItemsList = e;
			SetFilterToCustomPreset();
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void ItemsListAdded(object sender, string e)
		{
			if (!ItemsView.AddItem.Contains(e)) return;
			if (ItemsView.ItemsList.Contains(e)) return;
			var itemsList = Configuration.Items.ItemsList;
			itemsList.Add(e);
			itemsList = itemsList.OrderBy(x => x).ToList();
			ItemsView.ItemsList = itemsList;
			Configuration.Items.ItemsList = itemsList;
			SetFilterToCustomPreset();
			KaptureConfig.ConfigManager.SaveSettings();
		}
	}
}