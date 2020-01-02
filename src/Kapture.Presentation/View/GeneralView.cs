using System;
using System.Windows.Forms;

namespace ACT_FFXIV_Kapture.Presentation
{
    public partial class GeneralView : UserControl
    {
        public GeneralView()
        {
            InitializeComponent();
        }

        public bool PluginEnabled
        {
            get => general_PluginEnabledCheckBox.Checked;
            set => general_PluginEnabledCheckBox.Checked = value;
        }

        public bool LogImportsEnabled
        {
            get => general_LogImportsEnabledCheckBox.Checked;
            set => general_LogImportsEnabledCheckBox.Checked = value;
        }

        public bool CheckForBetaEnabled
        {
            get => general_CheckForBetaVersionsCheckBox.Checked;
            set => general_CheckForBetaVersionsCheckBox.Checked = value;
        }

        public event EventHandler<bool> PluginEnabledChanged;
        public event EventHandler<bool> LogImportsEnabledChanged;
        public event EventHandler<bool> CheckForBetaChanged;

        private void PluginEnabledCheckBox_Changed(object sender, EventArgs e)
        {
            PluginEnabledChanged?.Invoke(sender, ((CheckBox) sender).Checked);
        }

        private void LogImportsEnabledCheckBox_Changed(object sender, EventArgs e)
        {
            LogImportsEnabledChanged?.Invoke(sender, ((CheckBox) sender).Checked);
        }

        private void CheckForBetaCheckBox_Changed(object sender, EventArgs e)
        {
            CheckForBetaChanged?.Invoke(sender, ((CheckBox) sender).Checked);
        }
    }
}