using System;

namespace ACT_FFXIV.Aetherbridge
{
	public class Location
	{
		public int TerritoryTypeId { get; set; }
		public PlaceName Region { get; set; }
		public PlaceName Zone { get; set; }
		public PlaceName Territory { get; set; }
		public PlaceName Map { get; set; }


		public override string ToString()
		{
			return "TerritoryTypeId=" + TerritoryTypeId + Environment.NewLine +
			       "Region=" + Region + Environment.NewLine +
			       "Zone=" + Zone + Environment.NewLine +
			       "Territory=" + Territory + Environment.NewLine +
			       "Map=" + Map + Environment.NewLine;
		}
	}
}