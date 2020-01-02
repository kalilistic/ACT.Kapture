using System;
using System.Windows.Forms;

namespace ACT_FFXIV_Kapture.Presentation
{
    public partial class AboutView : UserControl
    {
        public AboutView()
        {
            InitializeComponent();

            about_AuthorLabel.Tag = "https://github.com/kalilistic";
            about_SupportLabel.Tag = "https://discord.gg/ftn4k7x";
            about_SourceLabel.Tag = "https://github.com/kalilistic/Kapture";
            about_LicenseLabel.Tag = "https://github.com/kalilistic/Kapture/blob/master/LICENSE";

            about_AuthorLabel.Click += Link_Click;
            about_SupportLabel.Click += Link_Click;
            about_SourceLabel.Click += Link_Click;
            about_LicenseLabel.Click += Link_Click;

            about_UpdateButton.Click += UpdateBtn_Click;
            about_ViewLogsButton.Click += ViewLogsBtn_Click;
        }

        public string Version
        {
            get => about_VersionLabel.Text;
            set => about_VersionLabel.Text = value;
        }

        public event EventHandler<string> LinkClicked;
        public event EventHandler<bool> UpdateClicked;
        public event EventHandler<bool> ViewLogsClicked;

        private void Link_Click(object sender, EventArgs e)
        {
            LinkClicked?.Invoke(this, ((Label) sender).Tag.ToString());
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            UpdateClicked?.Invoke(this, true);
        }

        private void ViewLogsBtn_Click(object sender, EventArgs e)
        {
            ViewLogsClicked?.Invoke(this, true);
        }
    }
}