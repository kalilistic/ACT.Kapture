using System;
using System.Windows.Forms;

namespace ACT_FFXIV_Kapture.Presentation
{
    public partial class HTTPView : UserControl
    {
        public HTTPView()
        {
            InitializeComponent();
            http_HTTPEnabledCheckBox.CheckedChanged += HTTPEnabledCheckBox_Changed;
            http_UpdateButton.Click += UpdateButton_Clicked;
        }

        public bool HTTPEnabled
        {
            get => http_HTTPEnabledCheckBox.Checked;
            set => http_HTTPEnabledCheckBox.Checked = value;
        }

        public string Endpoint
        {
            get => http_EndpointTextBox.Text;
            set => http_EndpointTextBox.Text = value;
        }

        public string CustomJson
        {
            get => http_CustomJsonTextBox.Text;
            set => http_CustomJsonTextBox.Text = value;
        }

        public event EventHandler<bool> HTTPEnabledChanged;
        public event EventHandler<string[]> HTTPUpdated;

        private void HTTPEnabledCheckBox_Changed(object sender, EventArgs e)
        {
            HTTPEnabledChanged?.Invoke(sender, ((CheckBox) sender).Checked);
        }

        private void UpdateButton_Clicked(object sender, EventArgs e)
        {
            var httpFields = new[] {http_EndpointTextBox.Text, http_CustomJsonTextBox.Text};
            HTTPUpdated?.Invoke(sender, httpFields);
        }
    }
}