using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ACT_FFXIV_Kapture.Config;
using ACT_FFXIV_Kapture.Presentation.CustomControl;

namespace ACT_FFXIV_Kapture.Presentation
{
    public partial class ZonesView : UserControl
    {
        public ZonesView(List<string> list)
        {
            InitializeComponent();
            zones_ZonesListDataGridView.CreateDataTable(list);
            zones_ZoneAddComboBox.SelectedValueChanged += ZoneAddComboBox_SelectedValueChanged;
            zones_ZonesListDataGridView.CustomDataGridViewChanged += ZonesListDgv_Changed;
            zones_ZoneFilterCheckBox.CheckedChanged += ZoneFilterCheckBox_CheckedChanged;
            zones_ZonePresetComboBox.TextChanged += ZonePresetComboBox_CheckedChanged;
            zones_ZoneIncludeRadioButton.CheckedChanged += IncludeZonesEnabledRadioButton_CheckedChanged;
            zones_ZoneExcludeRadioButton.CheckedChanged += ExcludeZonesEnabled_CheckedChanged;
        }

        public bool FilterByZones
        {
            get => zones_ZoneFilterCheckBox.Checked;
            set => zones_ZoneFilterCheckBox.Checked = value;
        }

        public ZonePreset ZonePreset
        {
            get => ZonePreset.Parse(zones_ZonePresetComboBox.SelectedItem.ToString());
            set => zones_ZonePresetComboBox.SelectedIndex = zones_ZonePresetComboBox.FindStringExact(value.Name);
        }

        public IList<ZonePreset> ZonePresetList
        {
            get => (List<ZonePreset>) zones_ZonePresetComboBox.DataSource;
            set => zones_ZonePresetComboBox.DataSource = value;
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

        public event EventHandler<bool> FilterByZonesChanged;
        public event EventHandler<ZonePreset> ZonePresentChanged;
        public event EventHandler<bool> IncludeZonesEnabledChanged;
        public event EventHandler<bool> ExcludeZonesEnabledChanged;
        public event EventHandler<List<string>> ZonesListChanged;
        public event EventHandler<string> ZonesListAdded;

        private void ZoneFilterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            FilterByZonesChanged?.Invoke(sender, ((CheckBox) sender).Checked);
        }

        private void ZonePresetComboBox_CheckedChanged(object sender, EventArgs e)
        {
            var customComboBox = (CustomComboBox) sender;
            if (!customComboBox.Focused) return;
            try
            {
                ZonePresentChanged?.Invoke(sender, ZonePreset.Parse(zones_ZonePresetComboBox.SelectedItem.ToString()));
            }
            catch
            {
                // ignored
            }
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