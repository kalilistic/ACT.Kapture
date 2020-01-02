namespace ACT_FFXIV_Kapture.Config
{
    public class Logging
    {
        public bool LoggingEnabled { get; set; } = true;
        public LogFormat LogFormat { get; set; } = LogFormat.LogFile;
        public string LogLocation { get; set; }
    }
}