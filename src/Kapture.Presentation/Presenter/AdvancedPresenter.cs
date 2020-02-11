using System.Collections.Generic;
using System.Linq;
using ACT_FFXIV_Aetherbridge;
using ACT_FFXIV_Kapture.Config;
using Configuration = ACT_FFXIV_Kapture.Config.Config;

namespace ACT_FFXIV_Kapture.Presentation
{
	public class AdvancedPresenter
	{
		private readonly ContentService _contentService;
		private readonly ItemService _itemService;
		public Configuration Configuration;
		public KaptureConfig KaptureConfig;

		public AdvancedPresenter(AdvancedView advancedView, ItemService itemService, ContentService contentService)
		{
			AdvancedView = advancedView;
			_itemService = itemService;
			_contentService = contentService;
			KaptureConfig = KaptureConfig.GetInstance();
			Configuration = (Configuration) KaptureConfig.ConfigManager.Config;
			SetupItemsFilter();
			SetupZonesFilter();
		}

		public AdvancedView AdvancedView { get; set; }

		private void SetupItemsFilter()
		{
			AdvancedView.FilterByItems = Configuration.Items.FilterByItems;
			AdvancedView.AddItem = _itemService.GetItemNames();
			AdvancedView.ItemsList = Configuration.Items.ItemsList;
			AdvancedView.ExcludeItemsEnabled = Configuration.Items.ExcludeItems;
			AdvancedView.IncludeItemsEnabled = Configuration.Items.IncludeItems;
			AdvancedView.FilterByItemsChanged += FilterByItemsChanged;
			AdvancedView.IncludeItemsEnabledChanged += IncludeItemsEnabledChanged;
			AdvancedView.ExcludeItemsEnabledChanged += ExcludeItemsEnabledChanged;
			AdvancedView.ItemsListChanged += ItemsListChanged;
			AdvancedView.ItemsListAdded += ItemsListAdded;
		}

		private void SetupZonesFilter()
		{
			AdvancedView.FilterByZones = Configuration.Zones.FilterByZones;
			AdvancedView.AddZone = _contentService.GetContentNames();
			AdvancedView.ZonesList = Configuration.Zones.ZonesList;
			AdvancedView.ExcludeZonesEnabled = Configuration.Zones.ExcludeZones;
			AdvancedView.IncludeZonesEnabled = Configuration.Zones.IncludeZones;
			AdvancedView.FilterByZonesChanged += FilterByZonesChanged;
			AdvancedView.IncludeZonesEnabledChanged += IncludeZonesEnabledChanged;
			AdvancedView.ExcludeZonesEnabledChanged += ExcludeZonesEnabledChanged;
			AdvancedView.ZonesListChanged += ZonesListChanged;
			AdvancedView.ZonesListAdded += ZonesListAdded;
		}

		private void UpdateSimpleItemFilter()
		{
			Configuration.Filters.ExcludeCommonItems = false;
		}

		private void UpdateSimpleZoneFilter()
		{
			Configuration.Filters.HighEndDutyOnly = false;
		}

		private void SetItemFilterToCustomPreset()
		{
			Configuration.Items.ItemPreset = ItemPreset.Custom;
			UpdateSimpleItemFilter();
		}

		private void FilterByItemsChanged(object sender, bool e)
		{
			Configuration.Items.FilterByItems = e;
			UpdateSimpleItemFilter();
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void IncludeItemsEnabledChanged(object sender, bool e)
		{
			Configuration.Items.IncludeItems = e;
			Configuration.Items.ExcludeItems = !e;
			SetItemFilterToCustomPreset();
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void ExcludeItemsEnabledChanged(object sender, bool e)
		{
			Configuration.Items.ExcludeItems = e;
			Configuration.Items.IncludeItems = !e;
			SetItemFilterToCustomPreset();
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void ItemsListChanged(object sender, List<string> e)
		{
			Configuration.Items.ItemsList = e;
			SetItemFilterToCustomPreset();
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void ItemsListAdded(object sender, string e)
		{
			if (!AdvancedView.AddItem.Contains(e)) return;
			if (AdvancedView.ItemsList.Contains(e)) return;
			var itemsList = Configuration.Items.ItemsList;
			itemsList.Add(e);
			itemsList = itemsList.OrderBy(x => x).ToList();
			AdvancedView.ItemsList = itemsList;
			Configuration.Items.ItemsList = itemsList;
			SetItemFilterToCustomPreset();
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void SetZoneFilterToCustomPreset()
		{
			Configuration.Zones.ZonePreset = ZonePreset.Custom;
			UpdateSimpleZoneFilter();
		}

		private void FilterByZonesChanged(object sender, bool e)
		{
			Configuration.Zones.FilterByZones = e;
			UpdateSimpleZoneFilter();
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void IncludeZonesEnabledChanged(object sender, bool e)
		{
			Configuration.Zones.IncludeZones = e;
			Configuration.Zones.ExcludeZones = !e;
			SetZoneFilterToCustomPreset();
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void ExcludeZonesEnabledChanged(object sender, bool e)
		{
			Configuration.Zones.ExcludeZones = e;
			Configuration.Zones.IncludeZones = !e;
			SetZoneFilterToCustomPreset();
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void ZonesListChanged(object sender, List<string> e)
		{
			Configuration.Zones.ZonesList = e;
			SetZoneFilterToCustomPreset();
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void ZonesListAdded(object sender, string e)
		{
			if (!AdvancedView.AddZone.Contains(e)) return;
			if (AdvancedView.ZonesList.Contains(e)) return;
			var zonesList = Configuration.Zones.ZonesList;
			zonesList.Add(e);
			zonesList = zonesList.OrderBy(x => x).ToList();
			AdvancedView.ZonesList = zonesList;
			Configuration.Zones.ZonesList = zonesList;
			SetZoneFilterToCustomPreset();
			KaptureConfig.ConfigManager.SaveSettings();
		}
	}
}