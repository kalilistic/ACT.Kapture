using System.Diagnostics;
using System.Threading.Tasks;
using ACT_FFXIV_Kapture.Config;
using ACT_FFXIV_Kapture.Service;
using Configuration = ACT_FFXIV_Kapture.Config.Config;

namespace ACT_FFXIV_Kapture.Presentation
{
    public class AboutPresenter
    {
        public Configuration Configuration;
        public KaptureConfig KaptureConfig;

        public AboutPresenter(AboutView aboutView)
        {
            KaptureConfig = KaptureConfig.GetInstance();
            Configuration = (Configuration) KaptureConfig.ConfigManager.Config;
            AboutView = aboutView;
            AboutView.Version = PluginService.GetInstance().Version;
            AboutView.UpdateClicked += CheckForUpdates;
            AboutView.LinkClicked += OpenLink;
            AboutView.ViewLogsClicked += OpenPluginLog;
        }

        public AboutView AboutView { get; set; }

        private static void OpenLink(object sender, string e)
        {
            if (e == null || e.Equals(string.Empty)) return;
            Process.Start(e);
        }

        private static void OpenPluginLog(object sender, bool e)
        {
            Process.Start(PluginService.GetInstance().KaptureLog);
        }

        private void CheckForUpdates(object sender, bool e)
        {
            Task.Run(() => PluginService.GetInstance().UpdatePlugin(Configuration.General.CheckForBetaEnabled, true));
        }
    }
}