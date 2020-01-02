using System.Collections.Generic;
using System.Linq;
using ACT_FFXIV_Aetherbridge;
using ACT_FFXIV_Kapture.Config;
using Configuration = ACT_FFXIV_Kapture.Config.Config;

namespace ACT_FFXIV_Kapture.Presentation
{
    public class ZonesPresenter
    {
        private readonly IContentService _contentService;
        public Configuration Configuration;
        public KaptureConfig KaptureConfig;
        public Zones ZonesConfig;

        public ZonesPresenter(ZonesView zonesView, IContentService contentService)
        {
            ZonesView = zonesView;
            _contentService = contentService;


            KaptureConfig = KaptureConfig.GetInstance();
            Configuration = (Configuration) KaptureConfig.ConfigManager.Config;
            ZonesConfig = Configuration.Zones;

            ZonesView.FilterByZones = ZonesConfig.FilterByZones;
            ZonesView.ZonePresetList = ZonePreset.ZonePresets;
            ZonesView.ZonePreset = ZonesConfig.ZonePreset;
            ZonesView.AddZone = _contentService.GetContentNames();

            SetFilterByPreset();

            ZonesView.FilterByZonesChanged += FilterByZonesChanged;
            ZonesView.ZonePresentChanged += ZonePresetChanged;
            ZonesView.IncludeZonesEnabledChanged += IncludeZonesEnabledChanged;
            ZonesView.ExcludeZonesEnabledChanged += ExcludeZonesEnabledChanged;
            ZonesView.ZonesListChanged += ZonesListChanged;
            ZonesView.ZonesListAdded += ZonesListAdded;
        }

        public ZonesView ZonesView { get; set; }

        private void SetFilterByPreset()
        {
            var zonePresent = ZonesView.ZonePreset;
            if (zonePresent.Equals(ZonePreset.HighEndDuty))
            {
                ZonesConfig.ZonesList = new List<string>(_contentService.GetHighEndContentNames());
                ZonesView.ZonesList = ZonesConfig.ZonesList;
                ZonesConfig.IncludeZones = true;
                ZonesConfig.ExcludeZones = false;
                ZonesView.IncludeZonesEnabled = ZonesConfig.IncludeZones;
                ZonesView.ExcludeZonesEnabled = ZonesConfig.ExcludeZones;
            }
            else
            {
                ZonesView.ZonesList = ZonesConfig.ZonesList;
                ZonesView.IncludeZonesEnabled = ZonesConfig.IncludeZones;
                ZonesView.ExcludeZonesEnabled = ZonesConfig.ExcludeZones;
            }

            KaptureConfig.ConfigManager.SaveSettings();
        }

        private void SetFilterToCustomPreset()
        {
            ZonesConfig.ZonePreset = ZonePreset.Custom;
            ZonesView.ZonePreset = ZonesConfig.ZonePreset;
        }

        private void FilterByZonesChanged(object sender, bool e)
        {
            ZonesConfig.FilterByZones = e;
            KaptureConfig.ConfigManager.SaveSettings();
        }

        private void ZonePresetChanged(object sender, ZonePreset e)
        {
            ZonesConfig.ZonePreset = e;
            SetFilterByPreset();
            KaptureConfig.ConfigManager.SaveSettings();
        }

        private void IncludeZonesEnabledChanged(object sender, bool e)
        {
            ZonesConfig.IncludeZones = e;
            SetFilterToCustomPreset();
            KaptureConfig.ConfigManager.SaveSettings();
        }

        private void ExcludeZonesEnabledChanged(object sender, bool e)
        {
            ZonesConfig.ExcludeZones = e;
            SetFilterToCustomPreset();
            KaptureConfig.ConfigManager.SaveSettings();
        }

        private void ZonesListChanged(object sender, List<string> e)
        {
            ZonesConfig.ZonesList = e;
            SetFilterToCustomPreset();
            KaptureConfig.ConfigManager.SaveSettings();
        }

        private void ZonesListAdded(object sender, string e)
        {
            if (!ZonesView.AddZone.Contains(e)) return;
            if (ZonesView.ZonesList.Contains(e)) return;
            var zonesList = ZonesConfig.ZonesList;
            zonesList.Add(e);
            zonesList = zonesList.OrderBy(x => x).ToList();
            ZonesView.ZonesList = zonesList;
            ZonesConfig.ZonesList = zonesList;
            SetFilterToCustomPreset();
            KaptureConfig.ConfigManager.SaveSettings();
        }
    }
}