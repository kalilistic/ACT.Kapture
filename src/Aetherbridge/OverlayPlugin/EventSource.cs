using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using RainbowMage.OverlayPlugin;

namespace ACT_FFXIV.Aetherbridge
{
	public class EventSource : EventSourceBase
	{
		private static volatile EventSource _eventSource;
		private static volatile EventSourceContext _context;
		private static volatile Logger _logger;
		private static JsonSerializer _jsonSerializer;
		private static readonly object Lock = new object();

		public EventSource(ILogger logger) : base(logger)
		{
			Name = _context.Name;
		}

		public static void Register(EventSourceContext context)
		{
			if (_eventSource != null) return;

			lock (Lock)
			{
				if (_eventSource != null) return;
				_context = context;
				_logger = new Logger();
				_jsonSerializer = new JsonSerializer {ContractResolver = new CamelCasePropertyNamesContractResolver()};
				_eventSource = new EventSource(_logger);
				_eventSource.Register();
			}
		}

		public static void SendEvent(string eventType, dynamic eventObj)
		{
			_eventSource.DispatchEvent(JObject.FromObject(new
			{
				type = eventType,
				message = eventObj
			}, _jsonSerializer));
		}

		private void Register()
		{
			if (_context == null) return;
			Name = _context.Name;
			if (_context.EventTypes != null && _context.EventTypes.Count > 0) RegisterEventTypes(_context.EventTypes);

			if (_context.EventHandlers != null && _context.EventHandlers.Count > 0)
				foreach (var eventHandler in _context.EventHandlers)
					RegisterEventHandler(eventHandler.Name, eventHandler.Handler);

			if (_context.OverlayPresets == null || _context.OverlayPresets.Count <= 0) return;
			foreach (var overlayPreset in _context.OverlayPresets)
				Registry.RegisterOverlayPreset(new OverlayPreset
				{
					Name = _context.Name + " " + overlayPreset.Name,
					Url = overlayPreset.Url,
					Size = overlayPreset.Size
				});
		}

		public override Control CreateConfigControl()
		{
			return null;
		}

		public override void LoadConfig(IPluginConfig config)
		{
		}

		public override void SaveConfig(IPluginConfig config)
		{
		}

		protected override void Update()
		{
		}
	}
}