using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ACT_FFXIV_Kapture.Resource;

namespace ACT_FFXIV_Kapture.Service
{
	public class Logger
	{
		private static volatile Logger _logger;
		private static readonly object Lock = new object();
		private readonly string _logFilePath;

		private Logger(string logDirectory)
		{
			_logFilePath = Path.Combine(logDirectory, "Kapture.log");
			if (!File.Exists(_logFilePath)) File.Create(_logFilePath).Dispose();
			UpdateLogFormat();
		}

		public event EventHandler<string> LogMessageAdded;

		public static Logger GetInstance(string logDirectory)
		{
			if (_logger != null) return _logger;

			lock (Lock)
			{
				if (_logger == null) _logger = new Logger(logDirectory);
			}

			return _logger;
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