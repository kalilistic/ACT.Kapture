using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ACT_FFXIV_Kapture.Resource;

namespace ACT_FFXIV_Kapture.Plugin
{
	public class KaptureGUILogger
	{
		private static volatile KaptureGUILogger _kaptureGuiLogger;
		private static readonly object Lock = new object();
		private readonly string _logFilePath;

		private KaptureGUILogger(string logDirectory)
		{
			_logFilePath = Path.Combine(logDirectory, "Kapture.log");
			if (!File.Exists(_logFilePath)) File.Create(_logFilePath).Dispose();
			UpdateLogFormat();
		}

		public event EventHandler<string> LogMessageAdded;

		public static KaptureGUILogger GetInstance(string logDirectory)
		{
			if (_kaptureGuiLogger != null) return _kaptureGuiLogger;

			lock (Lock)
			{
				if (_kaptureGuiLogger == null) _kaptureGuiLogger = new KaptureGUILogger(logDirectory);
			}

			return _kaptureGuiLogger;
		}

		public void UpdateLogFormat()
		{
			var sr = new StreamReader(_logFilePath);
			var line = sr.ReadLine();
			if (line != null && line.Contains("LogEntry"))
			{
				sr.Close();
				ClearLog();
			}
			else
			{
				sr.Close();
			}
		}

		public void ClearLog()
		{
			File.WriteAllText(_logFilePath, string.Empty);
			Log(Strings.LogCleared);
		}

		public List<string> GetLogMessages()
		{
			return File.ReadLines(_logFilePath).Reverse().Take(100).Reverse().ToList();
		}

		public void Info(string message)
		{
			Log(message);
		}

		public void Error(string message, Exception exception)
		{
			Log("ERROR: " + message + exception.Message + Environment.NewLine + exception.StackTrace);
		}


		private void Log(string message)
		{
			lock (Lock)
			{
				message = "[" + DateTime.Now.ToString("HH:mm") + "] " + message;
				File.AppendAllText(_logFilePath, Environment.NewLine + message);
				LogMessageAdded?.Invoke(this, message);
			}
		}
	}
}