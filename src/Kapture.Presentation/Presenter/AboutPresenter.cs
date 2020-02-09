﻿using System.Diagnostics;
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
			AboutView.Version = UpdateService.GetInstance().Version;
			AboutView.LinkClicked += OpenLink;
		}

		public AboutView AboutView { get; set; }

		private static void OpenLink(object sender, string e)
		{
			if (e == null || e.Equals(string.Empty)) return;
			Process.Start(e);
		}
	}
}