using System;
using System.Linq;
using Advanced_Combat_Tracker;
using static Advanced_Combat_Tracker.ActGlobals;

namespace ACT_FFXIV.Aetherbridge
{
	public class ACTWrapper : IACTWrapper
	{
		private static volatile ACTWrapper _actWrapper;
		private static readonly object Lock = new object();

		private ACTWrapper()
		{
			EnableOnLogLineRead();
		}

		public bool ACTLogLineParserEnabled { get; set; }
		public event EventHandler<ACTLogLineEvent> ACTLogLineCaptured;

		public dynamic GetACTPlugin(string pluginFileName, string pluginStatus)
		{
			var actPluginInstances = oFormActMain.ActPlugins.Where(actPlugin =>
					actPlugin.pluginFile.Name.ToUpper().Contains(pluginFileName.ToUpper()) &&
					actPlugin.lblPluginStatus.Text.ToUpper().Contains(pluginStatus.ToUpper()))
				.Select(actPlugin => actPlugin.pluginObj).Cast<dynamic>().ToList();

			switch (actPluginInstances.Count)
			{
				case 0:
					throw new Exception("Plugin not found: " + pluginFileName);
				case 1:
					return actPluginInstances[0];
				default:
					throw new Exception("Multiple plugins found: " + pluginFileName);
			}
		}

		public string GetAppDataFolderFullName()
		{
			return oFormActMain.AppDataFolder.FullName;
		}

		public string GetCharacterName()
		{
			return charName;
		}

		public void Restart(string message)
		{
			var method = oFormActMain.GetType().GetMethod("RestartACT");
			if (method != null) method.Invoke(oFormActMain, new object[] {true, message});
		}

		public void DeInit()
		{
			DisableOnLogLineRead();
		}

		public static IACTWrapper GetInstance()
		{
			if (_actWrapper != null) return _actWrapper;

			lock (Lock)
			{
				if (_actWrapper == null) _actWrapper = new ACTWrapper();
			}

			return _actWrapper;
		}

		public void EnableOnLogLineRead()
		{
			if (ACTLogLineParserEnabled) return;
			ACTLogLineParserEnabled = true;
			oFormActMain.OnLogLineRead += OnLogLineRead;
		}

		public void DisableOnLogLineRead()
		{
			if (!ACTLogLineParserEnabled) return;
			ACTLogLineParserEnabled = false;
			oFormActMain.OnLogLineRead -= OnLogLineRead;
		}

		internal void OnLogLineRead(bool isImport, LogLineEventArgs logInfo)
		{
			var logLineEvent = new ACTLogLineEvent
			{
				DetectedTime = logInfo.detectedTime,
				DetectedZone = logInfo.detectedZone,
				InCombat = logInfo.inCombat,
				IsImport = isImport,
				LogLine = logInfo.logLine
			};
			ACTLogLineCaptured?.Invoke(this, logLineEvent);
		}
	}
}