using System;
using System.Collections.Generic;
using System.Linq;
using ACT_FFXIV.Aetherbridge.XIVData;
using ACT_FFXIV.Aetherbridge.XIVData.Model;

namespace ACT_FFXIV.Aetherbridge
{
	public class LocationService
	{
		private readonly IFFXIVACTPluginWrapper _ffxivACTPluginWrapper;
		private readonly IGameDataRepository<Map> _mapRepository;
		private readonly IGameDataRepository<XIVData.Model.PlaceName> _placeNameRepository;
		private readonly IGameDataRepository<TerritoryType> _territoryTypeRepository;
		private List<Location> _locations = new List<Location>();

		public LocationService(IGameDataManager gameDataManager,
			IFFXIVACTPluginWrapper ffxivACTPluginWrapper)
		{
			_territoryTypeRepository = new GameDataRepository<TerritoryType>(gameDataManager.TerritoryType);
			_placeNameRepository = new GameDataRepository<XIVData.Model.PlaceName>(gameDataManager.PlaceName);
			_mapRepository = new GameDataRepository<Map>(gameDataManager.Map);

			_ffxivACTPluginWrapper = ffxivACTPluginWrapper;
		}

		public void Initialize(Language language)
		{
			var territoryList = _territoryTypeRepository.GetAll();
			foreach (var territoryType in territoryList)
			{
				PlaceName regionPlaceName;
				try
				{
					var regionPlaceNameKey = territoryType.RegionPlaceNameId;
					var regionNameValue = _placeNameRepository.Find(pn => pn.Id == territoryType.RegionPlaceNameId)
						.First()?.Localized[language.Index].Name;
					regionPlaceName = new PlaceName(regionPlaceNameKey, regionNameValue);
				}
				catch (Exception)
				{
					regionPlaceName = null;
				}

				PlaceName zonePlaceName;
				try
				{
					var zonePlaceNameKey = territoryType.ZonePlaceNameId;
					var zoneNameValue = _placeNameRepository.Find(pn => pn.Id == territoryType.ZonePlaceNameId).First()
						?.Localized[language.Index].Name;
					zonePlaceName = new PlaceName(zonePlaceNameKey, zoneNameValue);
				}
				catch (Exception)
				{
					zonePlaceName = null;
				}


				PlaceName mapPlaceName;
				try
				{
					var map = _mapRepository.Find(m => m.Id == territoryType.MapId).First();
					var mapPlaceNameKey = map.MapPlaceNameId;
					var mapPlaceNameValue = _placeNameRepository.Find(pn => pn.Id == mapPlaceNameKey).First()
						?.Localized[language.Index].Name;
					mapPlaceName = new PlaceName(mapPlaceNameKey, mapPlaceNameValue);
				}
				catch (Exception)
				{
					mapPlaceName = null;
				}

				PlaceName territoryPlaceName;
				try
				{
					var territoryPlaceNameKey = territoryType.TerritoryPlaceNameId;
					var territoryNameValue = _placeNameRepository
						.Find(pn => pn.Id == territoryType.TerritoryPlaceNameId)
						.First()?.Localized[language.Index].Name;
					territoryPlaceName = new PlaceName(territoryPlaceNameKey, territoryNameValue);
				}
				catch (Exception)
				{
					territoryPlaceName = null;
				}

				var location = new Location
				{
					TerritoryTypeId = territoryType.Id,
					Region = regionPlaceName,
					Zone = zonePlaceName,
					Territory = territoryPlaceName,
					Map = mapPlaceName
				};

				if (location.Region == null && location.Zone == null) continue;
				_locations.Add(location);
			}
		}

		public List<Location> GetLocations()
		{
			return new List<Location>(_locations);
		}

		public Location GetLocationById(int locationId)
		{
			return _locations
				.Find(loc => loc.TerritoryTypeId == locationId);
		}

		public List<string> GetZoneNames()
		{
			var locations = _locations;
			return (from location in locations where location.Zone != null select location.Zone.Name).ToList();
		}

		public void DeInit()
		{
			_locations = null;
		}

		public Location GetCurrentLocation()
		{
			return GetLocationById(Convert.ToInt32(_ffxivACTPluginWrapper.GetCurrentTerritoryId()));
		}
	}
}