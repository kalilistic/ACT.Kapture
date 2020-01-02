using System;
using System.Windows.Forms;
using ACT_FFXIV_Kapture.Config;
using Configuration = ACT_FFXIV_Kapture.Config.Config;

namespace ACT_FFXIV_Kapture.Presentation
{
    public class DiscordPresenter
    {
        public Configuration Configuration;
        public Discord DiscordConfig;
        public KaptureConfig KaptureConfig;

        public DiscordPresenter(DiscordView discordView)
        {
            KaptureConfig = KaptureConfig.GetInstance();
            Configuration = (Configuration) KaptureConfig.ConfigManager.Config;

            DiscordView = discordView;
            DiscordConfig = Configuration.Discord;

            DiscordView.DiscordEnabled = DiscordConfig.DiscordEnabled;
            DiscordView.Endpoint = DiscordConfig.Endpoint;

            DiscordView.DiscordEnabledChanged += DiscordEnabledChanged;
            DiscordView.DiscordUpdated += DiscordUpdated;
        }

        public DiscordView DiscordView { get; set; }

        private void DiscordEnabledChanged(object sender, bool e)
        {
            DiscordConfig.DiscordEnabled = e;
            KaptureConfig.ConfigManager.SaveSettings();
        }

        private void DiscordUpdated(object sender, string e)
        {
            if (DiscordView.Endpoint == null || DiscordView.Endpoint.Equals("")) return;
            if (IsValidDiscordUrl(e))
            {
                DiscordConfig.Endpoint = DiscordView.Endpoint;
                KaptureConfig.ConfigManager.SaveSettings();
            }
            else
            {
                MessageBox.Show(@"Please enter valid discord web hook.", @"Discord Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        internal static bool IsValidDiscordUrl(string url)
        {
            return url != null &&
                   !url.Equals("") &&
                   Uri.IsWellFormedUriString(url, UriKind.Absolute) && url.Contains(@"discordapp");
        }
    }
}