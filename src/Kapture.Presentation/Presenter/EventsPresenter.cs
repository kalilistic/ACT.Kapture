using ACT_FFXIV_Kapture.Config;
using Configuration = ACT_FFXIV_Kapture.Config.Config;

namespace ACT_FFXIV_Kapture.Presentation
{
	public class EventsPresenter
	{
		public Configuration Configuration;
		public KaptureConfig KaptureConfig;

		public EventsPresenter(EventsView eventsView)
		{
			EventsView = eventsView;

			KaptureConfig = KaptureConfig.GetInstance();
			Configuration = (Configuration) KaptureConfig.ConfigManager.Config;

			EventsView.ItemAddedEnabled = Configuration.Events.ItemAddedEnabled;
			EventsView.ItemLostEnabled = Configuration.Events.ItemDroppedEnabled;
			EventsView.YouObtainedEnabled = Configuration.Events.YouObtainedEnabled;
			EventsView.TheyObtainedEnabled = Configuration.Events.TheyObtainedEnabled;
			EventsView.YouRolledEnabled = Configuration.Events.YouRolledEnabled;
			EventsView.TheyRolledEnabled = Configuration.Events.TheyRolledEnabled;

			EventsView.ItemAddedEnabledChanged += ItemAddedEnabledChanged;
			EventsView.ItemDroppedEnabledChanged += ItemDroppedEnabledChanged;
			EventsView.YouObtainedEnabledChanged += YouObtainedEnabledChanged;
			EventsView.TheyObtainedEnabledChanged += TheyObtainedEnabledChanged;
			EventsView.YouRolledEnabledChanged += YouRolledEnabledChanged;
			EventsView.TheyRolledEnabledChanged += TheyRolledEnabledChanged;
		}

		public EventsView EventsView { get; }

		private void ItemAddedEnabledChanged(object sender, bool e)
		{
			Configuration.Events.ItemAddedEnabled = e;
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void ItemDroppedEnabledChanged(object sender, bool e)
		{
			Configuration.Events.ItemDroppedEnabled = e;
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void YouObtainedEnabledChanged(object sender, bool e)
		{
			Configuration.Events.YouObtainedEnabled = e;
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void TheyObtainedEnabledChanged(object sender, bool e)
		{
			Configuration.Events.TheyObtainedEnabled = e;
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void YouRolledEnabledChanged(object sender, bool e)
		{
			Configuration.Events.YouRolledEnabled = e;
			KaptureConfig.ConfigManager.SaveSettings();
		}

		private void TheyRolledEnabledChanged(object sender, bool e)
		{
			Configuration.Events.TheyRolledEnabled = e;
			KaptureConfig.ConfigManager.SaveSettings();
		}
	}
}