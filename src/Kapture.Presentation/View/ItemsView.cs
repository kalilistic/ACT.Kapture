using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ACT_FFXIV_Kapture.Config;
using ACT_FFXIV_Kapture.Presentation.CustomControl;

namespace ACT_FFXIV_Kapture.Presentation
{
	public partial class ItemsView : UserControl
	{
		public ItemsView(List<string> list)
		{
			InitializeComponent();
			items_ItemsListDataGridView.CreateDataTable(list);
			items_ItemAddComboBox.SelectedValueChanged += ItemAddComboBox_SelectedValueChanged;
			items_ItemsListDataGridView.CustomDataGridViewChanged += ItemsListDgv_Changed;
			items_ItemFilterCheckBox.CheckedChanged += ItemFilterCheckBox_CheckedChanged;
			items_ItemPresetComboBox.TextChanged += ItemPresetComboBox_CheckedChanged;
			items_ItemIncludeRadioButton.CheckedChanged += IncludeItemsEnabledRadioButton_CheckedChanged;
			items_ItemExcludeRadioButton.CheckedChanged += ExcludeItemsEnabled_CheckedChanged;
		}

		public bool FilterByItems
		{
			get => items_ItemFilterCheckBox.Checked;
			set => items_ItemFilterCheckBox.Checked = value;
		}

		public ItemPreset ItemPreset
		{
			get => ItemPreset.Parse(items_ItemPresetComboBox.SelectedItem.ToString());
			set => items_ItemPresetComboBox.SelectedIndex = items_ItemPresetComboBox.FindStringExact(value.Name);
		}

		public IList<ItemPreset> ItemPresetList
		{
			get => (List<ItemPreset>) items_ItemPresetComboBox.DataSource;
			set => items_ItemPresetComboBox.DataSource = value;
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

		public event EventHandler<bool> FilterByItemsChanged;
		public event EventHandler<ItemPreset> ItemPresentChanged;
		public event EventHandler<bool> IncludeItemsEnabledChanged;
		public event EventHandler<bool> ExcludeItemsEnabledChanged;
		public event EventHandler<List<string>> ItemsListChanged;
		public event EventHandler<string> ItemsListAdded;

		private void ItemFilterCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			FilterByItemsChanged?.Invoke(sender, ((CheckBox) sender).Checked);
		}

		private void ItemPresetComboBox_CheckedChanged(object sender, EventArgs e)
		{
			var customComboBox = (CustomComboBox) sender;
			if (!customComboBox.Focused) return;
			try
			{
				ItemPresentChanged?.Invoke(sender, ItemPreset.Parse(items_ItemPresetComboBox.SelectedItem.ToString()));
			}
			catch
			{
				// ignored
			}
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
	}
}