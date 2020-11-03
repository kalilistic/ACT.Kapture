using System;
using Newtonsoft.Json.Linq;

namespace ACT_FFXIV.Aetherbridge
{
	public class EventHandler
	{
		public string Name { get; set; }
		public Func<JObject, JToken> Handler { get; set; }
	}
}