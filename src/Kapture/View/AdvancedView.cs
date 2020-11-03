using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ACT_FFXIV.Aetherbridge;
using ACT_FFXIV_Kapture.Resource;

namespace ACT_FFXIV_Kapture.Plugin
{
	public partial class AdvancedView : UserControl
	{
		public AdvancedView(List<string> itemsList, List<string> zonesList)
		{
			InitializeComponent();
			itemsGroupBox.Text = Strings.Items;
			items_AddItemLabel.Text = Strings.AddItem;
			items_ItemFilterCheckBox.Text = Strings.FilterByItems;
			items_ItemIncludeRadioButton.Text = Strings.IncludeItems;
			items_ItemExcludeRadioButton.Text = Strings.ExcludeItems;
			items_ItemsListDataGridView.CreateDataTable(itemsList);
			items_ItemAddComboBox.SelectedValueChanged += ItemAddComboBox_SelectedValueChanged;
			items_ItemsListDataGridView.CustomDataGridViewChanged += ItemsListDgv_Changed;
			items_ItemFilterCheckBox.CheckedChanged += ItemFilterCheckBox_CheckedChanged;
			items_ItemIncludeRadioButton.CheckedChanged += IncludeItemsEnabledRadioButton_CheckedChanged;
			items_ItemExcludeRadioButton.CheckedChanged += ExcludeItemsEnabled_CheckedChanged;

			zonesGroupBox.Text = Strings.Zones;
			zones_AddZoneLabel.Text = Strings.AddZone;
			zones_ZoneFilterCheckBox.Text = Strings.FilterByZones;
			zones_ZoneIncludeRadioButton.Text = Strings.IncludeZones;
			zones_ZoneExcludeRadioButton.Text = Strings.ExcludeZones;
			zones_ZonesListDataGridView.CreateDataTable(zonesList);
			zones_ZoneAddComboBox.SelectedValueChanged += ZoneAddComboBox_SelectedValueChanged;
			zones_ZonesListDataGridView.CustomDataGridViewChanged += ZonesListDgv_Changed;
			zones_ZoneFilterCheckBox.CheckedChanged += ZoneFilterCheckBox_CheckedChanged;
			zones_ZoneIncludeRadioButton.CheckedChanged += IncludeZonesEnabledRadioButton_CheckedChanged;
			zones_ZoneExcludeRadioButton.CheckedChanged += ExcludeZonesEnabled_CheckedChanged;
		}

		public bool FilterByItems
		{
			get => items_ItemFilterCheckBox.Checked;
			set => items_ItemFilterCheckBox.Checked = value;
		}

		public bool IncludeItemsEnabled
		{
			get => items_ItemIncludeRadioButton.Checked;
			set => items_ItemIncludeRadioButton.Checked = value;
		}

		public bool ExcludeItemsEnabled
		{
			get => items_ItemExcludeRadioButton.Checked;
			set => items_ItemExcludeRadioButton.Checked = value;
		}

		public List<string> AddItem
		{
			get => (List<string>) items_ItemAddComboBox.DataSource;
			set
			{
				items_ItemAddComboBox.BeginUpdate();
				items_ItemAddComboBox.DataSource = value;
				items_ItemAddComboBox.EndUpdate();
			}
		}

		public List<string> ItemsList
		{
			get => items_ItemsListDataGridView.GetListFromDataTable();
			set => items_ItemsListDataGridView.CreateDataTable(value);
		}

		public bool FilterByZones
		{
			get => zones_ZoneFilterCheckBox.Checked;
			set => zones_ZoneFilterCheckBox.Checked = value;
		}

		public bool IncludeZonesEnabled
		{
			get => zones_ZoneIncludeRadioButton.Checked;
			set => zones_ZoneIncludeRadioButton.Checked = value;
		}

		public bool ExcludeZonesEnabled
		{
			get => zones_ZoneExcludeRadioButton.Checked;
			set => zones_ZoneExcludeRadioButton.Checked = value;
		}

		public List<string> AddZone
		{
			get => (List<string>) zones_ZoneAddComboBox.DataSource;
			set
			{
				zones_ZoneAddComboBox.BeginUpdate();
				zones_ZoneAddComboBox.DataSource = value;
				zones_ZoneAddComboBox.EndUpdate();
			}
		}

		public List<string> ZonesList
		{
			get => zones_ZonesListDataGridView.GetListFromDataTable();
			set => zones_ZonesListDataGridView.CreateDataTable(value);
		}

		public event EventHandler<bool> FilterByItemsChanged;
		public event EventHandler<bool> IncludeItemsEnabledChanged;
		public event EventHandler<bool> ExcludeItemsEnabledChanged;
		public event EventHandler<List<string>> ItemsListChanged;
		public event EventHandler<string> ItemsListAdded;

		public event EventHandler<bool> FilterByZonesChanged;
		public event EventHandler<bool> IncludeZonesEnabledChanged;
		public event EventHandler<bool> ExcludeZonesEnabledChanged;
		public event EventHandler<List<string>> ZonesListChanged;
		public event EventHandler<string> ZonesListAdded;

		private void ItemFilterCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			FilterByItemsChanged?.Invoke(sender, ((CheckBox) sender).Checked);
		}

		private void IncludeItemsEnabledRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			var radioButton = (RadioButton) sender;
			if (!radioButton.Focused) return;
			IncludeItemsEnabledChanged?.Invoke(sender, radioButton.Checked);
		}

		private void ExcludeItemsEnabled_CheckedChanged(object sender, EventArgs e)
		{
			var radioButton = (RadioButton) sender;
			if (!radioButton.Focused) return;
			ExcludeItemsEnabledChanged?.Invoke(sender, radioButton.Checked);
		}

		private void ItemsListDgv_Changed(object sender, List<string> e)
		{
			ItemsListChanged?.Invoke(sender, ((CustomDataGridView) sender).GetListFromDataTable());
		}

		private void ItemAddComboBox_SelectedValueChanged(object sender, EventArgs e)
		{
			var customComboBox = (CustomComboBox) sender;
			if (!customComboBox.Focused) return;
			ItemsListAdded?.Invoke(sender, customComboBox.Text);
		}

		private void ZoneFilterCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			FilterByZonesChanged?.Invoke(sender, ((CheckBox) sender).Checked);
		}

		private void IncludeZonesEnabledRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			var radioButton = (RadioButton) sender;
			if (!radioButton.Focused) return;
			IncludeZonesEnabledChanged?.Invoke(sender, radioButton.Checked);
		}

		private void ExcludeZonesEnabled_CheckedChanged(object sender, EventArgs e)
		{
			var radioButton = (RadioButton) sender;
			if (!radioButton.Focused) return;
			ExcludeZonesEnabledChanged?.Invoke(sender, radioButton.Checked);
		}

		private void ZonesListDgv_Changed(object sender, List<string> e)
		{
			ZonesListChanged?.Invoke(sender, ((CustomDataGridView) sender).GetListFromDataTable());
		}

		private void ZoneAddComboBox_SelectedValueChanged(object sender, EventArgs e)
		{
			var customComboBox = (CustomComboBox) sender;
			if (!customComboBox.Focused) return;
			ZonesListAdded?.Invoke(sender, customComboBox.Text);
		}
	}
}