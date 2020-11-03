using System.Collections.Generic;
using RainbowMage.OverlayPlugin;
// ReSharper disable UnassignedGetOnlyAutoProperty

namespace ACT_FFXIV.Aetherbridge
{
	public class OverlayPreset : IOverlayPreset
	{
		public string Name { get; set; }
		public string Url { get; set; }
		public int[] Size { get; set; }
		public bool Locked { get; }
		public string Type { get; } = "MiniParse";
		public List<string> Supports { get; } = new List<string> {"modern"};
	}
}