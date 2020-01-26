using System;
using System.Windows.Forms;

namespace ACT_FFXIV_Kapture.Presentation
{
	public partial class EventsView : UserControl
	{
		public EventsView()
		{
			InitializeComponent();
			events_ItemAddedCheckBox.CheckedChanged += ItemAddedEnabledCheckBox_CheckedChanged;
			events_ItemLostCheckBox.CheckedChanged += ItemLostEnabledCheckBox_CheckedChanged;
			events_YouObtainCheckBox.CheckedChanged += YouObtainCheckBox_CheckedChanged;
			events_TheyObtainCheckBox.CheckedChanged += TheyObtainCheckBox_CheckedChanged;
			events_YouRollCheckBox.CheckedChanged += YouRolledCheckBox_CheckedChanged;
			events_TheyRollCheckBox.CheckedChanged += TheyRolledCheckBox_CheckedChanged;
		}

		public bool ItemAddedEnabled
		{
			get => events_ItemAddedCheckBox.Checked;
			set => events_ItemAddedCheckBox.Checked = value;
		}

		public bool ItemLostEnabled
		{
			get => events_ItemLostCheckBox.Checked;
			set => events_ItemLostCheckBox.Checked = value;
		}

		public bool YouObtainedEnabled
		{
			get => events_YouObtainCheckBox.Checked;
			set => events_YouObtainCheckBox.Checked = value;
		}

		public bool TheyObtainedEnabled
		{
			get => events_TheyObtainCheckBox.Checked;
			set => events_TheyObtainCheckBox.Checked = value;
		}

		public bool YouRolledEnabled
		{
			get => events_YouRollCheckBox.Checked;
			set => events_YouRollCheckBox.Checked = value;
		}

		public bool TheyRolledEnabled
		{
			get => events_TheyRollCheckBox.Checked;
			set => events_TheyRollCheckBox.Checked = value;
		}

		public event EventHandler<bool> ItemAddedEnabledChanged;
		public event EventHandler<bool> ItemDroppedEnabledChanged;
		public event EventHandler<bool> YouObtainedEnabledChanged;
		public event EventHandler<bool> TheyObtainedEnabledChanged;
		public event EventHandler<bool> YouRolledEnabledChanged;
		public event EventHandler<bool> TheyRolledEnabledChanged;

		private void ItemAddedEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			ItemAddedEnabledChanged?.Invoke(sender, ((CheckBox) sender).Checked);
		}

		private void ItemLostEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			ItemDroppedEnabledChanged?.Invoke(sender, ((CheckBox) sender).Checked);
		}

		private void YouObtainCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			YouObtainedEnabledChanged?.Invoke(sender, ((CheckBox) sender).Checked);
		}

		private void TheyObtainCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			TheyObtainedEnabledChanged?.Invoke(sender, ((CheckBox) sender).Checked);
		}

		private void YouRolledCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			YouRolledEnabledChanged?.Invoke(sender, ((CheckBox) sender).Checked);
		}

		private void TheyRolledCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			TheyRolledEnabledChanged?.Invoke(sender, ((CheckBox) sender).Checked);
		}
	}
}