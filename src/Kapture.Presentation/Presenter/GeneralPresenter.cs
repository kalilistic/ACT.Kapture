using ACT_FFXIV_Kapture.Config;
using Configuration = ACT_FFXIV_Kapture.Config.Config;

namespace ACT_FFXIV_Kapture.Presentation
{
    public class GeneralPresenter
    {
        public Configuration Configuration;
        public KaptureConfig KaptureConfig;

        public GeneralPresenter(GeneralView generalView)
        {
            GeneralView = generalView;

            KaptureConfig = KaptureConfig.GetInstance();
            Configuration = (Configuration) KaptureConfig.ConfigManager.Config;

            GeneralView.PluginEnabled = Configuration.General.PluginEnabled;
            GeneralView.LogImportsEnabled = Configuration.General.LogImportsEnabled;
            GeneralView.CheckForBetaEnabled = Configuration.General.CheckForBetaEnabled;

            GeneralView.PluginEnabledChanged += PluginEnabledChanged;
            GeneralView.LogImportsEnabledChanged += LogImportsEnabledChanged;
            GeneralView.CheckForBetaChanged += CheckForBetaEnabledChanged;
        }

        public GeneralView GeneralView { get; set; }

        private void PluginEnabledChanged(object sender, bool e)
        {
            Configuration.General.PluginEnabled = e;
            KaptureConfig.ConfigManager.SaveSettings();
        }

        private void LogImportsEnabledChanged(object sender, bool e)
        {
            Configuration.General.LogImportsEnabled = e;
            KaptureConfig.ConfigManager.SaveSettings();
        }

        private void CheckForBetaEnabledChanged(object sender, bool e)
        {
            Configuration.General.CheckForBetaEnabled = e;
            KaptureConfig.ConfigManager.SaveSettings();
        }
    }
}