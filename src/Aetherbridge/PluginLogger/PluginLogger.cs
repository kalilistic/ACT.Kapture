using System;
using System.Globalization;
using System.IO;
using System.Xml.Linq;
using static System.IO.File;

namespace ACT_FFXIV.Aetherbridge
{
	public class PluginLogger : IPluginLogger
	{
		private static volatile PluginLogger _logger;
		private static readonly object Lock = new object();
		private static string _logFilePath;

		private PluginLogger(string path, string fileName)
		{
			_logFilePath = Path.Combine(path, fileName);
			if (!Exists(_logFilePath)) Create(_logFilePath).Dispose();
		}

		public void Info(string message)
		{
			var sw = new StreamWriter(_logFilePath, true);
			var xmlEntry = new XElement("LogEntry",
				new XElement("Type", LogEntryType.Info),
				new XElement("Date", DateTime.UtcNow.ToString(CultureInfo.CurrentCulture)),
				new XElement("Message", message));
			sw.WriteLine(xmlEntry);
			sw.Close();
		}

		public void Error(Exception ex)
		{
			var sw = new StreamWriter(_logFilePath, true);
			var xmlEntry = new XElement("LogEntry",
				new XElement("Type", LogEntryType.Error),
				new XElement("Date", DateTime.UtcNow.ToString(CultureInfo.CurrentCulture)),
				new XElement("Exception",
					new XElement("Data", ex.Data),
					new XElement("HelpLink", ex.HelpLink),
					new XElement("HResult", ex.HResult),
					new XElement("Message", ex.Message),
					new XElement("Source", ex.Source),
					new XElement("Stack", ex.StackTrace),
					new XElement("TargetSite", ex.TargetSite)
				)
			);
			while (ex.InnerException != null)
			{
				xmlEntry.Element("Exception")?.Add(
					new XElement("InnerException",
						new XElement("Data", ex.InnerException.Data),
						new XElement("HelpLink", ex.InnerException.HelpLink),
						new XElement("HResult", ex.InnerException.HResult),
						new XElement("Message", ex.InnerException.Message),
						new XElement("Source", ex.InnerException.Source),
						new XElement("Stack", ex.InnerException.StackTrace),
						new XElement("TargetSite", ex.InnerException.TargetSite))
				);
				ex = ex.InnerException;
			}

			sw.WriteLine(xmlEntry);
			sw.Close();
		}

		public void DeInit()
		{
			_logger = null;
		}

		public static void Initialize(string path, string fileName)
		{
			if (_logger != null) return;
			lock (Lock)
			{
				if (_logger == null) _logger = new PluginLogger(path, fileName);
			}
		}

		public static IPluginLogger GetInstance()
		{
			return _logger;
		}

		private enum LogEntryType
		{
			Error = 0,
			Info = 1
		}
	}
}