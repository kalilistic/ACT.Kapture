namespace ACT_FFXIV_Kapture.Service
{
    public interface IPluginService
    {
        string KaptureLog { get; set; }
        string Version { get; set; }
        void UpdatePlugin(bool includeBeta, bool includeSuccessPrompt);
        void DeInit();
    }
}