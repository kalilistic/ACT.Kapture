using System.Linq;
using System.Text.RegularExpressions;
using ACT_FFXIV_Kapture.Aetherbridge;
using ACT_FFXIV_Kapture.Config;
using ACT_FFXIV_Kapture.Model;
using ACT_FFXIV_Kapture.Resource;
using Configuration = ACT_FFXIV_Kapture.Config.Config;

// ReSharper disable UseObjectOrCollectionInitializer

#pragma warning disable 642

// ReSharper disable InvertIf

namespace ACT_FFXIV_Kapture.Plugin
{
	public abstract class LogLineParserBase
	{
		protected Configuration Configuration;
		protected ILogLineParserContext Context;
		protected LogLineEvent LogLineEvent;

		protected LogLineParserBase(ILogLineParserContext context)
		{
			Context = context;
			Configuration = (Configuration) KaptureConfig.GetInstance().ConfigManager.Config;
		}

		public void Parse(ACTLogLineEvent actLogLineEvent)
		{
			if (IsExcludedEvent(actLogLineEvent)) return;
			CreateEvent(actLogLineEvent);
			PreUpdateMessage();
			ParseLootEvent();
			if (IsExcludedLootEvent())
			{
				LogLineEvent = null;
				return;
			}

			PostUpdateMessage();
			ExtractStaticFields();
			GetMarketBoardData();
		}

		private void CreateEvent(ACTLogLineEvent actLogLineEvent)
		{
			LogLineEvent = new LogLineEvent {ACTLogLineEvent = actLogLineEvent};
			LogLineEvent.LogMessage = LogLineEvent.ACTLogLineEvent.LogLine;
			var match = Context.PrefixRegex.Match(LogLineEvent.LogMessage);
			LogLineEvent.LogMessage = match.Groups["Residual"].Value;
		}

		private void GetMarketBoardData()
		{
			if (!Configuration.General.GetMarketBoardData) return;
			if (LogLineEvent?.KaptureEvent?.Item == null) return;
			if (!LogLineEvent.KaptureEvent.Item.IsMarketable) return;
			if (LogLineEvent?.KaptureEvent?.Reporter?.HomeWorld == null) return;
			var worldId = LogLineEvent.KaptureEvent.Reporter.HomeWorld.Id;
			var itemId = LogLineEvent.KaptureEvent.Item.Id;
			if (worldId == 0 || itemId == 0) return;
			LogLineEvent.KaptureEvent.Item.MarketBoard =
				UniversalisWrapper.GetInstance().GetMarketBoard(worldId, itemId);
		}

		private bool IsExcludedEvent(ACTLogLineEvent actLogLineEvent)
		{
			return actLogLineEvent == null || !Configuration.General.PluginEnabled ||
			       actLogLineEvent.IsImport && !Configuration.General.LogImportsEnabled ||
			       !Context.PrefixRegex.Match(actLogLineEvent.LogLine).Success;
		}

		private bool IsExcludedLootEvent()
		{
			if (LogLineEvent?.KaptureEvent?.Item == null) return true;
			if (!LogLineEvent.ACTLogLineEvent.IsImport && LogLineEvent.KaptureEvent != null)
			{
				if (Configuration?.Items?.FilterByItems != null && Configuration.Items.FilterByItems)
				{
					if (Configuration.Items.IncludeItems &&
					    !Configuration.Items.ItemsList.Contains(LogLineEvent.KaptureEvent.Item.ProperName)) return true;
					if (Configuration.Items.ExcludeItems &&
					    Configuration.Items.ItemsList.Contains(LogLineEvent.KaptureEvent.Item.ProperName)) return true;
				}

				LogLineEvent.KaptureEvent.Location = Context.KaptureData.LocationService.GetCurrentLocation();
				LogLineEvent.KaptureEvent.Reporter = Context.KaptureData.PlayerService.GetCurrentPlayer();
				if (Configuration?.Zones?.FilterByZones != null && Configuration.Zones.FilterByZones)
				{
					var territoryTypeId = Context.KaptureData.LocationService.GetCurrentLocation().TerritoryTypeId;
					var contentName = Context.KaptureData.ContentService.GetContentByTerritoryTypeId(territoryTypeId)
						?.Name;
					if (contentName != null && !contentName.Equals(string.Empty))
					{
						if (Configuration.Zones.IncludeZones &&
						    !Configuration.Zones.ZonesList.Contains(contentName)) return true;
						if (Configuration.Zones.ExcludeZones &&
						    Configuration.Zones.ZonesList.Contains(contentName)) return true;
					}
					else
					{
						return Configuration.Zones.IncludeZones;
					}
				}

				if (LogLineEvent.KaptureEvent.Actor != null && Configuration != null)
				{
					var actor = Context.KaptureData.PlayerService.GetPlayerByName(LogLineEvent.KaptureEvent.Actor.Name);
					if (actor != null)
					{
						actor.IsReporter = LogLineEvent.KaptureEvent.Actor.IsReporter;
						LogLineEvent.KaptureEvent.Actor = actor;
					}

					if (LogLineEvent.KaptureEvent.Actor.IsReporter && !Configuration.Filters.Self) return true;
					if (LogLineEvent.KaptureEvent.Actor.PartyType == PartyTypeEnum.Party &&
					    !Configuration.Filters.Party) return true;
					if (LogLineEvent.KaptureEvent.Actor.PartyType == PartyTypeEnum.Alliance &&
					    !Configuration.Filters.Alliance) return true;
				}
			}

			return false;
		}

		private void PreUpdateMessage()
		{
			LogLineEvent.LogMessage = LogLineEvent.LogMessage.Replace("\uE0BB ", string.Empty);
			LogLineEvent.LogMessage = LogLineEvent.LogMessage.Replace("\uE0BB", string.Empty);
			LogLineEvent.LogMessage = LogLineEvent.LogMessage.Replace("\uE06F ", string.Empty);
			LogLineEvent.LogMessage = LogLineEvent.LogMessage.Replace("No. ", "No# ");
		}

		private void PostUpdateMessage()
		{
			if (LogLineEvent == null) return;
			if (LogLineEvent?.KaptureEvent?.Item == null)
			{
				LogLineEvent.KaptureEvent = null;
			}
			else
			{
				if (LogLineEvent.KaptureEvent.Actor != null)
				{
					var matches = Context.ActorWithWorldNameRegex.Matches(LogLineEvent.LogMessage);

					foreach (Match match in matches)
					{
						var actorName = match.Groups["ActorName"].Value;
						var worldName = match.Groups["WorldName"].Value;
						LogLineEvent.LogMessage = LogLineEvent.LogMessage.Replace(actorName + worldName, actorName);
						LogLineEvent.KaptureEvent.Actor.Name = actorName;
					}
				}

				LogLineEvent.LogMessage = LogLineEvent.LogMessage.Trim();
				LogLineEvent.LogMessage = LogLineEvent.LogMessage.Replace(" .", ".");
				foreach (var hqChar in Context.HQChars)
					LogLineEvent.LogMessage = LogLineEvent.LogMessage.Replace(hqChar, Context.HQString);
				LogLineEvent.LogMessage = LogLineEvent.LogMessage.Replace("No# ", "No. ");
				LogLineEvent.LogMessage = LogLineEvent.LogMessage.Replace("  ", " ");
			}
		}

		protected void ParseRawItemName(Match match, DraftItem draftItem)
		{
			var rawItemName = match.Groups["RawItemName"].Value;
			foreach (var hqChar in Context.HQChars)
			{
				rawItemName = rawItemName.Replace(" " + hqChar, string.Empty);
				rawItemName = rawItemName.Replace(hqChar, string.Empty);
			}

			draftItem.RawItemName = rawItemName;
			draftItem.RawItemName = draftItem.RawItemName.Replace("No# ", "No. ");
			foreach (var leadingArticle in Context.LeadingArticles)
				draftItem.RawItemName = draftItem.RawItemName.Replace(leadingArticle, string.Empty);
		}

		protected virtual void ParseItemNameAndQuantity(DraftItem draftItem)
		{
			var match = Context.ItemNameRegex.Match(draftItem.RawItemName);
			draftItem.ItemName = match.Groups["ItemName"].Value.Trim();
			var quantityStr = match.Groups["Quantity"].Value.Replace(Context.NumberDelimiterLocalized, string.Empty);
			try
			{
				draftItem.Quantity = int.Parse(quantityStr);
			}
			catch
			{
				draftItem.Quantity = 1;
			}
		}

		protected Item CreateItemFromDraft(DraftItem draftItem)
		{
			var item = FindItem(draftItem.ItemName, draftItem.Quantity);
			if (item == null) return null;
			item.Quantity = draftItem.Quantity;
			item.IsHQ = IsHQ();
			return item;
		}

		protected Item CreateItem(Match rawItemMatch)
		{
			var draftItem = new DraftItem();
			ParseRawItemName(rawItemMatch, draftItem);
			ParseItemNameAndQuantity(draftItem);
			return CreateItemFromDraft(draftItem);
		}

		protected virtual Player CreateActor(Match actorMatch)
		{
			var actorName = actorMatch.Groups["ActorNameWithWorldName"].Value;
			var currentPlayer = Context.KaptureData.PlayerService.GetCurrentPlayer();

			if (actorName.Equals(string.Empty) || actorName.ToUpper().Equals(Context.YouLocalized))
				return currentPlayer;

			return actorName.Equals(currentPlayer.Name)
				? currentPlayer
				: new Player {Name = actorName, IsReporter = false};
		}

		protected bool IsFalsePositive()
		{
			return Context.LootFalsePositives.Any(falsePositive => LogLineEvent.LogMessage.Contains(falsePositive));
		}

		protected bool IsHQ()
		{
			return Context.HQChars.Any(hqChar => LogLineEvent.LogMessage.Contains(hqChar));
		}

		protected bool IsCastLot()
		{
			var match = Context.CastLotRegex.Match(LogLineEvent.LogMessage);
			if (match.Success)
			{
				LogLineEvent.KaptureEvent = new KaptureEvent(EventType.CastLoot, Strings.ItemCastLot);
				LogLineEvent.KaptureEvent.Item = CreateItem(match);
				LogLineEvent.KaptureEvent.Actor = CreateActor(match);
			}

			;

			return match.Success;
		}

		protected bool IsAddLoot()
		{
			var match = Context.ItemAddedRegex.Match(LogLineEvent.LogMessage);
			if (match.Success)
			{
				LogLineEvent.KaptureEvent = new KaptureEvent(EventType.AddLoot, Strings.AddItem);
				LogLineEvent.KaptureEvent.Item = CreateItem(match);
			}

			return match.Success;
		}

		protected bool IsLostLoot()
		{
			var match = Context.UnableToObtainRegex.Match(LogLineEvent.LogMessage);
			if (match.Success)
			{
				LogLineEvent.KaptureEvent = new KaptureEvent(EventType.LostLoot, Strings.ItemLost);
				LogLineEvent.KaptureEvent.Item = CreateItem(match);
			}

			return match.Success;
		}

		protected bool IsObtainMostRareLoot()
		{
			var match = Context.ObtainWithMostRareRegex.Match(LogLineEvent.LogMessage);
			if (match.Success)
			{
				LogLineEvent.KaptureEvent = new KaptureEvent(EventType.ObtainLoot, Strings.ItemObtained);
				LogLineEvent.KaptureEvent.Item = CreateItem(match);
				LogLineEvent.KaptureEvent.Actor = CreateActor(match);
			}

			return match.Success;
		}

		protected virtual bool IsObtainLoot()
		{
			var match = Context.ObtainRegex.Match(LogLineEvent.LogMessage);
			if (match.Success)
			{
				LogLineEvent.KaptureEvent = new KaptureEvent(EventType.ObtainLoot, Strings.ItemObtained);
				LogLineEvent.KaptureEvent.Item = CreateItem(match);
				LogLineEvent.KaptureEvent.Actor = CreateActor(match);
			}

			return match.Success;
		}

		protected virtual bool IsObtainPassive()
		{
			if (Context.ObtainPassiveRegex == null) return false;
			var match = Context.ObtainPassiveRegex.Match(LogLineEvent.LogMessage);
			if (match.Success)
			{
				LogLineEvent.KaptureEvent = new KaptureEvent(EventType.ObtainLoot, Strings.ItemObtained);
				LogLineEvent.KaptureEvent.Item = CreateItem(match);
				LogLineEvent.KaptureEvent.Actor = CreateActor(match);
			}

			return match.Success;
		}

		protected virtual bool IsObtainFish()
		{
			var match = Context.FishRegex.Match(LogLineEvent.LogMessage);
			if (match.Success)
			{
				LogLineEvent.KaptureEvent = new KaptureEvent(EventType.ObtainLoot, Strings.ItemObtained);
				LogLineEvent.KaptureEvent.Item = CreateItem(match);
				LogLineEvent.KaptureEvent.Actor = CreateActor(match);
				LogLineEvent.KaptureEvent.Item.Size = match.Groups["Size"].Value;
			}

			return match.Success;
		}

		protected bool IsGreedLoot()
		{
			var match = Context.GreedRegex.Match(LogLineEvent.LogMessage);
			if (match.Success)
			{
				LogLineEvent.KaptureEvent = new KaptureEvent(EventType.GreedLoot, Strings.ItemRolled);
				LogLineEvent.KaptureEvent.Item = CreateItem(match);
				LogLineEvent.KaptureEvent.Actor = CreateActor(match);
				LogLineEvent.KaptureEvent.Roll = int.Parse(match.Groups["Roll"].Value);
			}

			return match.Success;
		}

		protected bool IsNeedLoot()
		{
			var match = Context.NeedRegex.Match(LogLineEvent.LogMessage);
			if (match.Success)
			{
				LogLineEvent.KaptureEvent = new KaptureEvent(EventType.NeedLoot, Strings.ItemRolled);
				LogLineEvent.KaptureEvent.Item = CreateItem(match);
				LogLineEvent.KaptureEvent.Actor = CreateActor(match);
				LogLineEvent.KaptureEvent.Roll = int.Parse(match.Groups["Roll"].Value);
			}

			return match.Success;
		}

		protected bool IsSearchLoot()
		{
			var match = Context.SearchRegex.Match(LogLineEvent.LogMessage);
			if (match.Success)
			{
				LogLineEvent.KaptureEvent = new KaptureEvent(EventType.SearchLoot, Strings.ItemSearched);
				LogLineEvent.KaptureEvent.Item = CreateItem(match);
			}

			return match.Success;
		}

		private void ParseLootEvent()
		{
			if (IsFalsePositive()) return;
			if (Configuration.Filters.ItemCastLot && IsCastLot()) return;
			if (Configuration.Filters.ItemAdded && IsAddLoot()) return;
			if (Configuration.Filters.ItemLost && IsLostLoot()) return;
			if (Configuration.Filters.ItemRolledOn && (IsGreedLoot() || IsNeedLoot())) return;
			if (Configuration.Filters.ItemObtained &&
			    (IsObtainMostRareLoot() || IsObtainFish() || IsObtainLoot() || IsObtainPassive())) return;
			if (Configuration.Filters.ItemSearched && IsSearchLoot()) ;
		}

		private void ExtractStaticFields()
		{
			LogLineEvent.LogCode = "00";
			LogLineEvent.Timestamp = LogLineEvent.ACTLogLineEvent.LogLine.Substring(1, 8);
			LogLineEvent.GameLogCode = LogLineEvent.ACTLogLineEvent.LogLine.Substring(18, 4);
		}

		public abstract Item FindItem(string itemName, int quantity);
	}
}