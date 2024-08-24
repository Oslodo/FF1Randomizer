using FF1Lib.Helpers;
using RomUtilities;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FF1Lib
{
	public partial class GameClasses
	{

		public List<string> PlandoBlursing(List<string> olditemnames, ItemNames itemnames, Flags flags, FF1Rom rom)
		{

			// Hardcoded spell lists and MP Growth lists for trickier blessings
			var wmWhiteSpells = _spellPermissions[Classes.WhiteMage].ToList();
			var bmBlackSpells = _spellPermissions[Classes.BlackMage].ToList();

			var wwWhiteSpells = _spellPermissions[Classes.WhiteWizard].ToList();
			var bwBlackSpells = _spellPermissions[Classes.BlackWizard].ToList();

			var exKnightMPlist = new List<byte> { 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07,
				0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00 };
			var exNinjaMPlist = new List<byte> { 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F,
				0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00 };

			// Blursings List
			List<BonusMalusPlando> bonuslist = new();
			List<BonusMalusPlando> maluses = new();
			/*Dictionary<Classes, List<BonusMalus>> classBlessings = new()
			{
				{ Classes.Fighter, new() },
				{ Classes.Thief, new() },
				{ Classes.BlackBelt, new() },
				{ Classes.RedMage, new() },
				{ Classes.WhiteMage, new() },
				{ Classes.BlackMage, new() },
			};*/
			var descriptionList = new List<string>();

			GenerateListsPlando(bonuslist, maluses, olditemnames, itemnames, flags, rom);

			var StartwithKIPlando = KeyItemList(flags, olditemnames);


			Dictionary<Classes, List<BonusMalusPlando>> assignedBlessings = new();
			Dictionary<Classes, List<BonusMalusPlando>> assignedMaluses = new();

			List<Classes> classList = Enumerable.Range(0, 6).Select(c => (Classes)c).ToList();
			List<Classes> validClasses = new();

			//KI First

			if (flags.FighterKI != FiKeyItems.FiKeyItemsNone)
			{
				switch (flags.FighterKI)
				{
					case FiKeyItems.FiKeyItemsCrown:
						assignedBlessings[Classes.Fighter].Add(StartwithKIPlando[(int)Item.Crown]);
						break;

					case FiKeyItems.FiKeyItemsCrystal:
						assignedBlessings[Classes.Fighter].Add(StartwithKIPlando[(int)Item.Crystal]);
						break;

					case FiKeyItems.FiKeyItemsHerb:
						assignedBlessings[Classes.Fighter].Add(StartwithKIPlando[(int)Item.Herb]);
						break;

					case FiKeyItems.FiKeyItemsTNT:
						assignedBlessings[Classes.Fighter].Add(StartwithKIPlando[(int)Item.Tnt]);
						break;

					case FiKeyItems.FiKeyItemsAdamant:
						assignedBlessings[Classes.Fighter].Add(StartwithKIPlando[(int)Item.Adamant]);
						break;

					case FiKeyItems.FiKeyItemsSlab:
						assignedBlessings[Classes.Fighter].Add(StartwithKIPlando[(int)Item.Slab]);
						break;

					case FiKeyItems.FiKeyItemsRuby:
						assignedBlessings[Classes.Fighter].Add(StartwithKIPlando[(int)Item.Ruby]);
						break;

					case FiKeyItems.FiKeyItemsRod:
						assignedBlessings[Classes.Fighter].Add(StartwithKIPlando[(int)Item.Rod]);
						break;

					case FiKeyItems.FiKeyItemsChime:
						assignedBlessings[Classes.Fighter].Add(StartwithKIPlando[(int)Item.Chime]);
						break;

					case FiKeyItems.FiKeyItemsCube:
						assignedBlessings[Classes.Fighter].Add(StartwithKIPlando[(int)Item.Cube]);
						break;

					case FiKeyItems.FiKeyItemsBottle:
						assignedBlessings[Classes.Fighter].Add(StartwithKIPlando[(int)Item.Bottle]);
						break;

					case FiKeyItems.FiKeyItemsOxyale:
						assignedBlessings[Classes.Fighter].Add(StartwithKIPlando[(int)Item.Oxyale]);
						break;

					case FiKeyItems.FiKeyItemsLute:
						assignedBlessings[Classes.Fighter].Add(StartwithKIPlando[(int)Item.Lute]);
						break;

					case FiKeyItems.FiKeyItemsTail:
						assignedBlessings[Classes.Fighter].Add(StartwithKIPlando[(int)Item.Tail]);
						break;

					case FiKeyItems.FiKeyItemsKey:
						assignedBlessings[Classes.Fighter].Add(StartwithKIPlando[(int)Item.Key]);
						break;
				}

			};

			if (flags.ThKeyItems != ThKeyItems.ThKeyItemsNone)
			{
				switch (flags.ThKeyItems)
				{
					case ThKeyItems.ThKeyItemsCrown:
						assignedBlessings[Classes.Thief].Add(StartwithKIPlando[(int)Item.Crown]);
						break;

					case ThKeyItems.ThKeyItemsCrystal:
						assignedBlessings[Classes.Thief].Add(StartwithKIPlando[(int)Item.Crystal]);
						break;

					case ThKeyItems.ThKeyItemsHerb:
						assignedBlessings[Classes.Thief].Add(StartwithKIPlando[(int)Item.Herb]);
						break;

					case ThKeyItems.ThKeyItemsTNT:
						assignedBlessings[Classes.Thief].Add(StartwithKIPlando[(int)Item.Tnt]);
						break;

					case ThKeyItems.ThKeyItemsAdamant:
						assignedBlessings[Classes.Thief].Add(StartwithKIPlando[(int)Item.Adamant]);
						break;

					case ThKeyItems.ThKeyItemsSlab:
						assignedBlessings[Classes.Thief].Add(StartwithKIPlando[(int)Item.Slab]);
						break;

					case ThKeyItems.ThKeyItemsRuby:
						assignedBlessings[Classes.Thief].Add(StartwithKIPlando[(int)Item.Ruby]);
						break;

					case ThKeyItems.ThKeyItemsRod:
						assignedBlessings[Classes.Thief].Add(StartwithKIPlando[(int)Item.Rod]);
						break;

					case ThKeyItems.ThKeyItemsChime:
						assignedBlessings[Classes.Thief].Add(StartwithKIPlando[(int)Item.Chime]);
						break;

					case ThKeyItems.ThKeyItemsCube:
						assignedBlessings[Classes.Thief].Add(StartwithKIPlando[(int)Item.Cube]);
						break;

					case ThKeyItems.ThKeyItemsBottle:
						assignedBlessings[Classes.Thief].Add(StartwithKIPlando[(int)Item.Bottle]);
						break;

					case ThKeyItems.ThKeyItemsOxyale:
						assignedBlessings[Classes.Thief].Add(StartwithKIPlando[(int)Item.Oxyale]);
						break;

					case ThKeyItems.ThKeyItemsLute:
						assignedBlessings[Classes.Thief].Add(StartwithKIPlando[(int)Item.Lute]);
						break;

					case ThKeyItems.ThKeyItemsTail:
						assignedBlessings[Classes.Thief].Add(StartwithKIPlando[(int)Item.Tail]);
						break;

					case ThKeyItems.ThKeyItemsKey:
						assignedBlessings[Classes.Thief].Add(StartwithKIPlando[(int)Item.Key]);
						break;
				}
			};

		}
		private List<BonusMalusPlando> KeyItemList(Flags flags, List<string> olditemnames)
		{
			List<BonusMalusPlando> kiPlando = new()
			{
				new BonusMalusPlando(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Crown], mod: (int)Item.Crown),
				new BonusMalusPlando(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Crystal], mod: (int)Item.Crystal),
				new BonusMalusPlando(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Herb], mod: (int)Item.Herb),
				new BonusMalusPlando(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Tnt], mod: (int)Item.Tnt),
				new BonusMalusPlando(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Adamant], mod: (int)Item.Adamant),
				new BonusMalusPlando(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Slab], mod: (int)Item.Slab),
				new BonusMalusPlando(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Ruby], mod: (int)Item.Ruby),
				new BonusMalusPlando(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Rod], mod: (int)Item.Rod),
				new BonusMalusPlando(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Chime], mod: (int)Item.Chime),
				new BonusMalusPlando(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Cube], mod: (int)Item.Cube),
				new BonusMalusPlando(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Bottle], mod: (int)Item.Bottle),
				new BonusMalusPlando(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Oxyale], mod: (int)Item.Oxyale),
				new BonusMalusPlando(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Lute], mod: (int)Item.Lute),
				new BonusMalusPlando(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Tail], mod: (int)Item.Tail),
				new BonusMalusPlando(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Key], mod: (int)Item.Key),

			
			};
			return kiPlando;
		}
	}
}

