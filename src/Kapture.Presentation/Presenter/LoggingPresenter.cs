using System;
using System.IO;
using System.Windows.Forms;
using ACT_FFXIV_Kapture.Config;
using Configuration = ACT_FFXIV_Kapture.Config.Config;

namespace ACT_FFXIV_Kapture.Presentation
{
	public class LoggingPresenter
	{
		public Configuration Configuration;
		public KaptureConfig KaptureConfig;
		public Logging LoggingConfig;

		public LoggingPresenter(LoggingView loggingView)
		{
			LoggingView = loggingView;

			KaptureConfig = KaptureConfig.GetInstance();
			Configuration = (Configuration) KaptureConfig.ConfigManager.Config;
			LoggingConfig = Configuration.Logging;

			LoggingView.LoggingEnabled = LoggingConfig.LoggingEnabled;
			LoggingView.LogFormatList = LogFormat.LogFormats;
			LoggingView.LogFormat = LoggingConfig.LogFormat;
			LoggingView.LogLocation = LoggingConfig.LogLocation;

			LoggingView.LoggingEnabledChanged += LoggingEnabledChanged;
			LoggingView.LogFormatChanged += LogFormatChanged;
			LoggingView.LogLocationUpdated += LogLocationUpdated;
		}

		public LoggingView LoggingView { get; set; }

		private void LoggingEnabledChanged(object sender, bool e)
		{
			LoggingConfig.LoggingEnabled = e;
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void LogFormatChanged(object sender, LogFormat e)
		{
			LoggingConfig.LogFormat = e;
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void LogLocationUpdated(object sender, string e)
		{
			if (e == null) return;
			if (e.Equals(string.Empty)) return;
			if (IsValidLogPath(e))
			{
				LoggingConfig.LogLocation = e;
				KaptureConfig.ConfigManager.SaveSettings();
			}
			else
			{
				MessageBox.Show(@"Please enter valid log path.", @"Logging Error", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private static bool IsValidLogPath(string path)
		{
			if (path == null || path.Equals(string.Empty)) return false;

			bool isValid;
			try
			{
				var _ = Path.GetFullPath(path);
				var root = Path.GetPathRoot(path);
				isValid = string.IsNullOrEmpty(root.Trim('\\', '/')) == false;
			}
			catch (Exception)
			{
				isValid = false;
			}

			return isValid;
		}
	}
}