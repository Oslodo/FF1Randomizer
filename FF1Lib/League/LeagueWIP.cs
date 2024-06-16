﻿using FF1Lib.Helpers;
using RomUtilities;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF1Lib
{
	public partial class GameClasses
	{

		public class BonusMalusLeagueWIP
		{
			public List<Item> Equipment { get; set; }
			public List<SpellSlots> SpellList { get; set; }
			public List<bool> StatGrowth { get; set; }
			public int StatMod { get; set; }
			public int StatMod2 { get; set; }
			public RankedType TargetStat { get; set; }
			public BonusMalusAction Action { get; set; }
			public string Description { get; set; }
			public List<byte> SpcGrowth { get; set; }
			public List<Classes> ClassList { get; set; }
			public SpellSlotInfo SpellSlotMod { get; set; }
			public List<SpellSlotInfo> SpellsMod { get; set; }
			public BonusMalusLeagueWIP(BonusMalusAction action, string description, int mod = 0, int mod2 = 0, List<Item> equipment = null, List<bool> binarylist = null, List<SpellSlots> spelllist = null, List<byte> bytelist = null, SpellSlotInfo spellslotmod = null, List<SpellSlotInfo> spellsmod = null, List<Classes> Classes = null)
			{
				Action = action;
				Description = description;
				StatMod = mod;
				StatMod2 = mod2;
				Equipment = equipment;
				SpellList = spelllist;
				StatGrowth = binarylist;
				SpellSlotMod = spellslotmod;
				SpellsMod = spellsmod;
				if (bytelist == null)
					SpcGrowth = Enumerable.Repeat((byte)0x00, 49).ToList();
				else
					SpcGrowth = bytelist;
				if (Classes == null)
					ClassList = Enum.GetValues<Classes>().ToList();
				else
					ClassList = Classes;
			}
		}


		public List<string> DoRandomizeClassNormalModeLeagueWIP(MT19337 rng, List<string> olditemnames, ItemNames itemnames, Flags flags, FF1Rom rom)
		{
			// Equipment lists
			List<Item> braceletList = new();
			List<Item> ringList = new();
			for (int i = (int)Item.Cloth; i <= (int)Item.ProRing; i++)
			{
				if (itemnames[i].Contains("@B"))
				{
					braceletList.Add((Item)i);
				}
			}

			List<Item> bannableArmor = new List<Item> { Item.Ribbon };
			bannableArmor.AddRange(braceletList);
			if (!(bool)flags.ArmorCrafter)
			{
				bannableArmor.Add(Item.ProRing);
			}

			List<Item> equipFighterArmor = _armorPermissions[Classes.Fighter].ToList().Where(x => !bannableArmor.Contains(x)).ToList();
			List<Item> equipRedMageArmor = _armorPermissions[Classes.RedMage].ToList().Where(x => !bannableArmor.Contains(x)).ToList();

			List<Item> equipFighterArmorFull = _armorPermissions[Classes.Fighter].ToList();
			List<Item> equipRedWizardArmorFull = _armorPermissions[Classes.RedWizard].ToList();

			List<Item> equipFighterWeapon = _weaponPermissions[Classes.Fighter].ToList();
			List<Item> equipThiefWeapon = _weaponPermissions[Classes.Thief].ToList();

			List<Item> equipAxes = new();
			for (int i = (int)Item.WoodenNunchucks; i <= (int)Item.Masamune; i++)
			{
				if (itemnames[i].Contains("@X"))
				{
					equipAxes.Add((Item)i);
				}
			}

			List<Item> equipShirts = new();
			for (int i = (int)Item.Cloth; i <= (int)Item.ProRing; i++)
			{
				if (itemnames[i].Contains("@T"))
				{
					equipShirts.Add((Item)i);
				}
			}
			List<Item> equipShields = new();
			for (int i = (int)Item.Cloth; i <= (int)Item.ProRing; i++)
			{
				if (itemnames[i].Contains("@s") || itemnames[i].Contains("Buckl") || itemnames[i].Contains("ProCa"))
				{
					equipShields.Add((Item)i);
				}
			}
			List<Item> equipGauntletsHelmets = new();
			for (int i = (int)Item.Cloth; i <= (int)Item.ProRing; i++)
			{
				if (itemnames[i].Contains("@G"))
				{
					equipGauntletsHelmets.Add((Item)i);
				}
				else if (itemnames[i].Contains("@h"))
				{
					equipGauntletsHelmets.Add((Item)i);
				}
			}


			List<Item> equipLegendaryWeapons = new() { Item.Vorpal, Item.Katana, Item.Xcalber };

			// Create exceptions for hit bonus
			var hitBonusClass = new List<Classes>();

			for (int i = 0; i < 6; i++)
			{
				if (_classes[i].HitGrowth < 4)
					hitBonusClass.Add((Classes)i);
			}

			// Spells lists
			var nullSpells = Enumerable.Repeat(false, 4 * 8).ToList();

			var lv1WhiteSpells = _spellPermissions[Classes.WhiteMage].OrderBy(x => x).ToList().GetRange(0, 4).ToList();

			var lv1BlackSpells = _spellPermissions[Classes.BlackMage].OrderBy(x => x).ToList().GetRange(0, 4).ToList();

			var lv3WhiteSpells = _spellPermissions[Classes.Knight].ToList();
			var lv4BlackSpells = _spellPermissions[Classes.Ninja].ToList();

			var wmWhiteSpells = _spellPermissions[Classes.WhiteMage].ToList();
			var bmBlackSpells = _spellPermissions[Classes.BlackMage].ToList();

			var wwWhiteSpells = _spellPermissions[Classes.WhiteWizard].ToList();
			var bwBlackSpells = _spellPermissions[Classes.BlackWizard].ToList();

			// MP Growth Lists
			var rmMPlist = new List<byte>(_classes[(int)Classes.RedMage].SpCGrowth);

			var improvedMPlist = new List<byte> { 0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF,
				0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00 };
			var exKnightMPlist = new List<byte> { 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07,
				0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00, 0x07, 0x00 };
			var exNinjaMPlist = new List<byte> { 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F,
				0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00, 0x0F, 0x00 };

			// Normal Bonuses List
			var bonusNormal = new List<BonusMalusLeagueWIP> {
				new BonusMalusLeagueWIP(BonusMalusAction.StrMod, "+10 Str.", mod: 10),
				new BonusMalusLeagueWIP(BonusMalusAction.StrMod, "+20 Str.", mod: 20),
				new BonusMalusLeagueWIP(BonusMalusAction.AgiMod, "+15 Agi.", mod: 15),
				new BonusMalusLeagueWIP(BonusMalusAction.AgiMod, "+25 Agi.", mod: 25),
				new BonusMalusLeagueWIP(BonusMalusAction.VitMod, "+10 Vit.", mod: 10),
				new BonusMalusLeagueWIP(BonusMalusAction.VitMod, "+20 Vit.", mod: 20),
				new BonusMalusLeagueWIP(BonusMalusAction.LckMod, "+5 Luck", mod: 5),
				new BonusMalusLeagueWIP(BonusMalusAction.LckMod, "+10 Luck", mod: 10),
				new BonusMalusLeagueWIP(BonusMalusAction.HpMod, "+20 HP", mod: 20),
				new BonusMalusLeagueWIP(BonusMalusAction.HpMod, "+40 HP", mod: 40),
				new BonusMalusLeagueWIP(BonusMalusAction.HitMod, "+10 Hit%", mod: 10, Classes: hitBonusClass ),
				new BonusMalusLeagueWIP(BonusMalusAction.HitMod, "+20 Hit%", mod: 20, Classes: hitBonusClass ),
				new BonusMalusLeagueWIP(BonusMalusAction.MDefMod, "+10 MDef", mod: 10),
				new BonusMalusLeagueWIP(BonusMalusAction.MDefMod, "+20 MDef", mod: 20),
				new BonusMalusLeagueWIP(BonusMalusAction.WeaponAdd, "+Equip @X", equipment: equipAxes, Classes: new List<Classes> { Classes.Thief, Classes.BlackBelt, Classes.RedMage, Classes.WhiteMage, Classes.BlackMage } ),
				new BonusMalusLeagueWIP(BonusMalusAction.WeaponAdd, "+Legendary@S", equipment: equipLegendaryWeapons),
				new BonusMalusLeagueWIP(BonusMalusAction.ArmorAdd, "+Equip @T", equipment: equipShirts),
				new BonusMalusLeagueWIP(BonusMalusAction.ArmorAdd, "+Equip @s", equipment: equipShields, Classes: new List<Classes> { Classes.Thief, Classes.BlackBelt, Classes.RedMage, Classes.WhiteMage, Classes.BlackMage } ),
				new BonusMalusLeagueWIP(BonusMalusAction.ArmorAdd, "+Equip @G+@h", equipment: equipGauntletsHelmets, Classes: new List<Classes> { Classes.Thief, Classes.BlackBelt, Classes.RedMage, Classes.WhiteMage, Classes.BlackMage } ),
				new BonusMalusLeagueWIP(BonusMalusAction.WeaponAdd, "+Thief @S", equipment: equipThiefWeapon, Classes: new List<Classes> { Classes.BlackBelt, Classes.WhiteMage, Classes.BlackMage } ),
				new BonusMalusLeagueWIP(BonusMalusAction.ArmorAdd, "+Red Mage @A", equipment: equipRedMageArmor, Classes: new List<Classes> { Classes.Thief, Classes.BlackBelt, Classes.WhiteMage, Classes.BlackMage } ),
				new BonusMalusLeagueWIP(BonusMalusAction.SpcMod, "+2 Lv1 MP", mod: 2, Classes: new List<Classes> { Classes.RedMage, Classes.WhiteMage, Classes.BlackMage }),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithMp, "+1 MP LvAll", Classes: new List<Classes> { Classes.RedMage, Classes.WhiteMage, Classes.BlackMage }),
				new BonusMalusLeagueWIP(BonusMalusAction.ThorMaster, "Improved\n Thor@H", equipment: new List<Item>() { Item.ThorHammer }, Classes: new List<Classes> { Classes.Fighter, Classes.Thief, Classes.WhiteMage }),
				new BonusMalusLeagueWIP(BonusMalusAction.Hunter, "Hurt Undead", mod: 0x18),
				new BonusMalusLeagueWIP(BonusMalusAction.Hunter, "Hurt Dragon", mod: 0x02),
				new BonusMalusLeagueWIP(BonusMalusAction.CatClawMaster, "Improved\n CatClaw", equipment: new List<Item>() { Item.CatClaw }, Classes: new List<Classes> { Classes.Fighter, Classes.Thief, Classes.RedMage, Classes.BlackMage }),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithGold, "+200 GP", mod: 2),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithGold, "+400 GP", mod: 4),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithGold, "+600 GP", mod: 6),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithGold, "+800 GP", mod: 8),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithGold, "+1500 GP", mod: 15),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithGold, "+5000 GP", mod: 50),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithGold, "+20,000 GP", mod: 200),
				new BonusMalusLeagueWIP(BonusMalusAction.ArmorAdd, "Promo FI @A", mod: 99, equipment: equipFighterArmor, Classes: new List<Classes> { Classes.BlackBelt, Classes.WhiteMage, Classes.BlackMage, Classes.RedMage }),
				new BonusMalusLeagueWIP(BonusMalusAction.PowerRW, "Promo Sage", mod: 0, spelllist: wmWhiteSpells.Concat(bmBlackSpells).Concat(wwWhiteSpells).Concat(bwBlackSpells).ToList(), Classes: new List<Classes> { Classes.RedMage }),
				new BonusMalusLeagueWIP(BonusMalusAction.WoodAdept, "Wood@A@s@h Set\n Add Evade"),
				new BonusMalusLeagueWIP(BonusMalusAction.LockpickingLevel, "EarlyLokpik", mod: -10, Classes: new List<Classes> { Classes.Thief }),
				new BonusMalusLeagueWIP(BonusMalusAction.BonusXp, "+50% XP", mod: 150, Classes: new List<Classes> { Classes.Thief, Classes.RedMage, Classes.BlackMage, Classes.WhiteMage }),
				new BonusMalusLeagueWIP(BonusMalusAction.BonusXp, "+50% XP", mod: 150, Classes: new List<Classes> { Classes.Thief, Classes.RedMage, Classes.BlackMage, Classes.WhiteMage }),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Crown], mod: (int)Item.Crown),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Crystal], mod: (int)Item.Crystal),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Herb], mod: (int)Item.Herb),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Tnt], mod: (int)Item.Tnt),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Adamant], mod: (int)Item.Adamant),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Slab], mod: (int)Item.Slab),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Ruby], mod: (int)Item.Ruby),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Rod], mod: (int)Item.Rod),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Chime], mod: (int)Item.Chime),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Cube], mod: (int)Item.Cube),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Bottle], mod: (int)Item.Bottle),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Oxyale], mod: (int)Item.Oxyale),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Lute], mod: (int)Item.Lute),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Tail], mod: (int)Item.Tail),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Key], mod: (int)Item.Key),


			};
			// Strong Bonuses List
			var bonusStrong = new List<BonusMalusLeagueWIP> {
				new BonusMalusLeagueWIP(BonusMalusAction.StrMod, "+40 Str.", mod: 40),
				new BonusMalusLeagueWIP(BonusMalusAction.AgiMod, "+50 Agi.", mod: 50),
				new BonusMalusLeagueWIP(BonusMalusAction.VitMod, "+40 Vit.", mod: 40),
				new BonusMalusLeagueWIP(BonusMalusAction.LckMod, "+15 Luck", mod: 15, Classes: new List<Classes> { Classes.Fighter, Classes.BlackBelt, Classes.WhiteMage, Classes.RedMage, Classes.BlackMage } ),
				new BonusMalusLeagueWIP(BonusMalusAction.HpMod, "+80 HP", mod: 80),
				new BonusMalusLeagueWIP(BonusMalusAction.MDefGrowth, "+2 MDef/Lv", mod: 2, Classes: new List<Classes> { Classes.Fighter, Classes.Thief, Classes.RedMage, Classes.WhiteMage, Classes.BlackMage }),
				new BonusMalusLeagueWIP(BonusMalusAction.WeaponAdd, "+Fighter @S", equipment: equipFighterWeapon, Classes: new List<Classes> { Classes.Thief, Classes.BlackBelt, Classes.WhiteMage, Classes.BlackMage } ),
				new BonusMalusLeagueWIP(BonusMalusAction.ArmorAdd, "+Fighter @A", equipment: equipFighterArmor, Classes: new List<Classes> { Classes.Thief, Classes.BlackBelt, Classes.WhiteMage, Classes.BlackMage, Classes.RedMage } ),
				new BonusMalusLeagueWIP(BonusMalusAction.SpcGrowth, "Improved MP", bytelist: improvedMPlist, Classes: new List<Classes> { Classes.RedMage, Classes.WhiteMage, Classes.BlackMage } ),
				new BonusMalusLeagueWIP(BonusMalusAction.PowerRW, "Sage", mod: 1, spelllist: wmWhiteSpells.Concat(bmBlackSpells).Concat(wwWhiteSpells).Concat(bwBlackSpells).ToList(), Classes: new List<Classes> { Classes.RedMage }),
				new BonusMalusLeagueWIP(BonusMalusAction.Hunter, "Hurt All", mod: 0xFF),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithGold, "+1400 GP", mod: 14, Classes: new List<Classes> { Classes.Thief }),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithGold, "+2000 GP", mod: 20, Classes: new List<Classes> { Classes.Thief }),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithGold, "+3000 GP", mod: 30, Classes: new List<Classes> { Classes.Thief }),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithGold, "+4000 GP", mod: 40, Classes: new List<Classes> { Classes.Thief }),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithGold, "+6000 GP", mod: 60, Classes: new List<Classes> { Classes.Thief }),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithGold, "+20,000 GP", mod: 200, Classes: new List<Classes> { Classes.Thief }),
				new BonusMalusLeagueWIP(BonusMalusAction.SteelLord, "Steel@A\n Cast Fast", Classes: new List<Classes> { Classes.Fighter }),
				new BonusMalusLeagueWIP(BonusMalusAction.InnateResist, "Res. All", mod: 0xFF, Classes: new List<Classes> { Classes.Fighter, Classes.Thief, Classes.RedMage, Classes.BlackMage, Classes.WhiteMage }),
				new BonusMalusLeagueWIP(BonusMalusAction.InnateResist, "Res. PEDTS", mod: (int)(SpellElement.Poison | SpellElement.Earth | SpellElement.Death | SpellElement.Time | SpellElement.Status), Classes: new List<Classes> { Classes.Fighter, Classes.Thief, Classes.RedMage, Classes.BlackMage, Classes.WhiteMage }),
				new BonusMalusLeagueWIP(BonusMalusAction.BonusXp, "+50% XP", mod: 150, Classes: new List<Classes> { Classes.Fighter, Classes.BlackBelt }),
				new BonusMalusLeagueWIP(BonusMalusAction.BonusXp, "+100% XP", mod: 200, Classes: new List<Classes> { Classes.Thief, Classes.RedMage, Classes.BlackMage, Classes.WhiteMage }),

			};

			// Maluses List
			var malusNormal = new List<BonusMalusLeagueWIP> {
				new BonusMalusLeagueWIP(BonusMalusAction.StrMod, "-10 Str.", mod: -10, Classes: new List<Classes> { Classes.Fighter, Classes.Thief, Classes.BlackBelt, Classes.WhiteMage, Classes.RedMage } ),
				new BonusMalusLeagueWIP(BonusMalusAction.StrMod, "-20 Str.", mod: -20, Classes: new List<Classes> { Classes.Fighter }),
				new BonusMalusLeagueWIP(BonusMalusAction.AgiMod, "-10 Agi.", mod: -10),
				new BonusMalusLeagueWIP(BonusMalusAction.AgiMod, "-20 Agi.", mod: -20, Classes: new List<Classes> { Classes.Thief }),
				new BonusMalusLeagueWIP(BonusMalusAction.VitMod, "-10 Vit.", mod: -10, Classes: new List<Classes> { Classes.Fighter, Classes.Thief, Classes.BlackBelt, Classes.WhiteMage, Classes.RedMage } ),
				new BonusMalusLeagueWIP(BonusMalusAction.VitMod, "-20 Vit.", mod: -20, Classes: new List<Classes> { Classes.BlackBelt }),
				new BonusMalusLeagueWIP(BonusMalusAction.LckMod, "-5 Luck", mod: -5),
				new BonusMalusLeagueWIP(BonusMalusAction.LckMod, "-10 Luck", mod: -10, Classes: new List<Classes> { Classes.Thief, Classes.BlackMage }),
				new BonusMalusLeagueWIP(BonusMalusAction.HpMod, "-15 HP", mod: -15),
				new BonusMalusLeagueWIP(BonusMalusAction.HpMod, "-30 HP", mod: -30),
				new BonusMalusLeagueWIP(BonusMalusAction.HpGrowth, "BlackM HP", binarylist: _classes[(int)Classes.BlackMage].HpGrowth, Classes: new List<Classes> { Classes.Fighter }),
				new BonusMalusLeagueWIP(BonusMalusAction.HitMod, "-10 Hit%", mod: -10),
				new BonusMalusLeagueWIP(BonusMalusAction.MDefMod, "-10 MDef", mod: -10),
				new BonusMalusLeagueWIP(BonusMalusAction.HitGrowth, "-1 Hit%/Lv", mod: -1),
				new BonusMalusLeagueWIP(BonusMalusAction.MDefGrowth, "-1 MDef/Lv", mod: -1),
				new BonusMalusLeagueWIP(BonusMalusAction.ArmorRemove, "No @B", equipment: braceletList),
				new BonusMalusLeagueWIP(BonusMalusAction.WeaponReplace, "Thief @S", equipment: equipThiefWeapon, Classes: new List<Classes> { Classes.Fighter, Classes.RedMage } ),
				new BonusMalusLeagueWIP(BonusMalusAction.SpcMax, "-4 Max MP", mod: -4, Classes: new List<Classes> {  Classes.RedMage, Classes.WhiteMage, Classes.BlackMage }),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithGold, "-50 GP", mod: -1),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithGold, "-100 GP", mod: -1),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithGold, "-150 GP", mod: -1),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithGold, "-350 GP", mod: -1),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithGold, "-350 GP", mod: -1),
				new BonusMalusLeagueWIP(BonusMalusAction.StartWithGold, "-4500 GP", mod: -1),
				new BonusMalusLeagueWIP(BonusMalusAction.WeaponRemove, "No " + olditemnames[(int)Item.Masamune], equipment: new List<Item> { Item.Masamune }),
				new BonusMalusLeagueWIP(BonusMalusAction.ArmorRemove, "No " + olditemnames[(int)Item.Ribbon], equipment: new List<Item> { Item.Ribbon }),
				new BonusMalusLeagueWIP(BonusMalusAction.ArmorReplace, "No Promo @A", mod: 99, equipment: equipFighterArmorFull, Classes: new List<Classes> { Classes.Fighter }),
				new BonusMalusLeagueWIP(BonusMalusAction.ArmorReplace, "Promo RW @A", mod: 99, equipment: equipRedWizardArmorFull, Classes: new List<Classes> { Classes.Thief }),
				new BonusMalusLeagueWIP(BonusMalusAction.NoPromoMagic, "No Promo Sp", mod: 0, mod2: 0, binarylist: nullSpells, Classes: new List<Classes> { Classes.Fighter, Classes.Thief }),
				new BonusMalusLeagueWIP(BonusMalusAction.ArmorRemove, "-" + olditemnames[(int)Item.ProRing], equipment: new List<Item> { Item.ProRing }),
				new BonusMalusLeagueWIP(BonusMalusAction.IntMod, "+80 Int.", mod: 80),
				new BonusMalusLeagueWIP(BonusMalusAction.LockpickingLevel, "LateLockpik", mod: 10, Classes: new List<Classes> { Classes.Thief }),

			};





			// Single Spells Bonus/Malus Might remove this code and add them all to the master list
			bonusNormal.AddRange(CreateSpellBonusesLeagueWIP(rom, rng, flags));
			malusNormal.AddRange(CreateSpellMalusesLeagueWIP(rom, rng, flags));

			if ((bool)flags.RandomizeClassCasting)
			{
				var magicBonuses = CreateMagicBonusesLeagueWIP(rom, rng, flags);

				bonusNormal.AddRange(magicBonuses.Item1);
				bonusStrong.AddRange(magicBonuses.Item2);
			}


			// Add Natural Resist Bonuses
			bonusNormal.Add(CreateRandomResistBonusMalusLeagueWIP(rng));
			bonusNormal.Add(CreateRandomResistBonusMalusLeagueWIP(rng));



			var assignedBonusMalus = new List<List<BonusMalusLeagueWIP>> { new List<BonusMalusLeagueWIP>(), new List<BonusMalusLeagueWIP>(), new List<BonusMalusLeagueWIP>(), new List<BonusMalusLeagueWIP>(), new List<BonusMalusLeagueWIP>(), new List<BonusMalusLeagueWIP>() };

			// Shuffle bonuses and maluses (odds are not needed for the plando code)
			bonusStrong.Shuffle(rng);
			bonusNormal.AddRange(bonusStrong.GetRange(0, 3));
			bonusNormal.Shuffle(rng);
			malusNormal.Shuffle(rng);

			var descriptionList = new List<string>();

			// Distribute bonuses and maluses (odds are also not needed for plando code)
			int maxbonus = flags.RandomizeClassMaxBonus;
			int maxmalus = flags.RandomizeClassMaxMalus;

			bool validBlursingsDistribution = false;

			var startWithKiBlursesLeageWIP = StartWithKeyItems(flags, rng, olditemnames); //this will not be used but the code will be left here to reference when building

			while (!validBlursingsDistribution)
			{
				validBlursingsDistribution = true;
				assignedBonusMalus = new();
				descriptionList = new();

				for (int i = 0; i < 6; i++)
				{
					var tempstring = new List<(int, string)>();
					var bonuscount = 0;
					var maluscount = 0;
					assignedBonusMalus.Add(new List<BonusMalusLeagueWIP>());

					/*if ((bool)flags.RandomizeClassKeyItems) Using baseline blursings to do this, code saved for future reference
					{
						assignedBonusMalus[i].Add(startWithKiBlurses.SpliceRandom(rng));
						tempstring.Add((0, assignedBonusMalus[i].First().Description));
					}*/

					while (bonuscount < maxbonus)
					{
						var validBonuses = bonusNormal.Where(x => x.ClassList.Contains((Classes)i) && !assignedBonusMalus[i].Select(y => y.Action).ToList().Contains(x.Action)).ToList();

						if (!validBonuses.Any())
						{
							validBlursingsDistribution = false;
							break;
						}

						validBonuses.Shuffle(rng);
						assignedBonusMalus[i].Add(validBonuses.First());
						tempstring.Add((0, validBonuses.First().Description));
						bonusNormal.Remove(validBonuses.First());
						bonuscount++;
					}

					while (maluscount < maxmalus)
					{
						var validMaluses = malusNormal.Where(x => x.ClassList.Contains((Classes)i) && //This seems to be the code to stop both learning and losing a spell, shouldn't be needed for this code.
							!assignedBonusMalus[i].Select(y => y.Action).ToList().Contains(x.Action) &&
							!(x.Action == BonusMalusAction.CantLearnSpell && assignedBonusMalus[i].Where(y => y.Action == BonusMalusAction.InnateSpells).SelectMany(x => x.SpellsMod).ToList().Contains(x.SpellSlotMod)) &&
							!(x.Action == BonusMalusAction.NoPromoMagic && assignedBonusMalus[i].Where(y => y.Action == BonusMalusAction.MpGainOnMaxMpGain).Any()) &&
							!(x.Action == BonusMalusAction.ArmorRemove && x.Equipment.Contains(Item.Ribbon) && assignedBonusMalus[i].Where(y => y.Action == BonusMalusAction.InnateResist && y.StatMod == 0xFF).Any())).ToList();

						if (!validMaluses.Any())
						{
							validBlursingsDistribution = false;
							break;
						}

						validMaluses.Shuffle(rng);
						assignedBonusMalus[i].Add(validMaluses.First());
						if (validMaluses.First().Action == BonusMalusAction.IntMod)
						{
							tempstring.Add((0, validMaluses.First().Description));
						}
						else
						{
							tempstring.Add((1, validMaluses.First().Description));
						}

						malusNormal.Remove(validMaluses.First());
						maluscount++;
					}

					if (!validBlursingsDistribution)
					{
						break;
					}

					descriptionList.Add(string.Join("\n\n", tempstring.Where(x => x.Item1 == 0).Select(x => x.Item2)) + "\n\n\nMALUS\n\n" + string.Join("\n\n", tempstring.Where(x => x.Item1 == 1).Select(x => x.Item2)));
				}
			}

			// Apply bonuses and maluses to stats
			for (int i = 0; i < 6; i++)
			{
				// Order the list so bonuses/maluses interact correctly
				List<BonusMalusAction> priorityAction = new() { BonusMalusAction.SpcMax, BonusMalusAction.CantLearnSpell };

				assignedBonusMalus[i].Reverse();

				assignedBonusMalus[i] = assignedBonusMalus[i]
					.Where(x => !priorityAction.Contains(x.Action))
					.ToList()
					.Concat(assignedBonusMalus[i].Where(x => priorityAction.Contains(x.Action)).ToList())
					.ToList();

				foreach (var bonusmalus in assignedBonusMalus[i])
				{
					switch (bonusmalus.Action)
					{
						case BonusMalusAction.StrMod:
							_classes[i].StrStarting = (byte)Math.Max(_classes[i].StrStarting + bonusmalus.StatMod, 0);
							break;
						case BonusMalusAction.AgiMod:
							_classes[i].AgiStarting = (byte)Math.Max(_classes[i].AgiStarting + bonusmalus.StatMod, 0);
							break;
						case BonusMalusAction.IntMod:
							_classes[i].IntStarting = (byte)Math.Max(_classes[i].IntStarting + bonusmalus.StatMod, 0);
							break;
						case BonusMalusAction.VitMod:
							_classes[i].VitStarting = (byte)Math.Max(_classes[i].VitStarting + bonusmalus.StatMod, 0);
							break;
						case BonusMalusAction.LckMod:
							_classes[i].LckStarting = (byte)Math.Max(_classes[i].LckStarting + bonusmalus.StatMod, 0);
							break;
						case BonusMalusAction.HitMod:
							_classes[i].HitStarting = (byte)Math.Max(_classes[i].HitStarting + bonusmalus.StatMod, 0);
							break;
						case BonusMalusAction.MDefMod:
							_classes[i].MDefStarting = (byte)Math.Max(_classes[i].MDefStarting + bonusmalus.StatMod, 0);
							break;
						case BonusMalusAction.HpMod:
							_classes[i].HpStarting = (byte)Math.Max(_classes[i].HpStarting + bonusmalus.StatMod, 1);
							break;
						case BonusMalusAction.StrGrowth:
							_classes[i].StrGrowth = bonusmalus.StatGrowth;
							break;
						case BonusMalusAction.AgiGrowth:
							_classes[i].AgiGrowth = bonusmalus.StatGrowth;
							break;
						case BonusMalusAction.IntGrowth:
							_classes[i].IntGrowth = bonusmalus.StatGrowth;
							break;
						case BonusMalusAction.VitGrowth:
							_classes[i].VitGrowth = bonusmalus.StatGrowth;
							break;
						case BonusMalusAction.LckGrowth:
							_classes[i].LckGrowth = bonusmalus.StatGrowth;
							break;
						case BonusMalusAction.HpGrowth:
							_classes[i].HpGrowth = bonusmalus.StatGrowth;
							break;
						case BonusMalusAction.HitGrowth:
							_classes[i].HitGrowth = (byte)Math.Max(_classes[i].HitGrowth + bonusmalus.StatMod, 0);
							_classes[i + 6].HitGrowth = (byte)Math.Max(_classes[i + 6].HitGrowth + bonusmalus.StatMod, 0);
							break;
						case BonusMalusAction.MDefGrowth:
							_classes[i].MDefGrowth = (byte)Math.Max(_classes[i].MDefGrowth + bonusmalus.StatMod, 0);
							_classes[i + 6].MDefGrowth = (byte)Math.Max(_classes[i + 6].MDefGrowth + bonusmalus.StatMod, 0);
							break;
						case BonusMalusAction.WeaponAdd:
							_weaponPermissions.AddPermissionsRange(bonusmalus.Equipment.Select(x => ((Classes)i, x)).ToList());
							_weaponPermissions.AddPermissionsRange(bonusmalus.Equipment.Select(x => ((Classes)(i + 6), x)).ToList());
							break;
						case BonusMalusAction.WeaponRemove:
							_weaponPermissions.RemovePermissionsRange(bonusmalus.Equipment.Select(x => ((Classes)i, x)).ToList());
							_weaponPermissions.RemovePermissionsRange(bonusmalus.Equipment.Select(x => ((Classes)(i + 6), x)).ToList());
							break;
						case BonusMalusAction.WeaponReplace:
							_weaponPermissions[(Classes)i] = bonusmalus.Equipment;
							_weaponPermissions[(Classes)(i + 6)] = bonusmalus.Equipment;
							break;
						case BonusMalusAction.ArmorAdd:
							// mod 99 used to indicate it's for promo only
							if ((byte)bonusmalus.StatMod != 99)
							{
								_armorPermissions.AddPermissionsRange(bonusmalus.Equipment.Select(x => ((Classes)i, x)).ToList());
							}
							_armorPermissions.AddPermissionsRange(bonusmalus.Equipment.Select(x => ((Classes)(i + 6), x)).ToList());
							break;
						case BonusMalusAction.ArmorRemove:
							_armorPermissions.RemovePermissionsRange(bonusmalus.Equipment.Select(x => ((Classes)i, x)).ToList());
							_armorPermissions.RemovePermissionsRange(bonusmalus.Equipment.Select(x => ((Classes)(i + 6), x)).ToList());
							break;
						case BonusMalusAction.ArmorReplace:
							// mod 99 used to indicate it's for promo only
							if ((byte)bonusmalus.StatMod != 99)
							{
								_armorPermissions[(Classes)i] = bonusmalus.Equipment;
							}
							_armorPermissions[(Classes)(i + 6)] = bonusmalus.Equipment;
							break;
						case BonusMalusAction.SpcMod:
							_classes[i].SpCStarting = (byte)Math.Max(_classes[i].SpCStarting + bonusmalus.StatMod, 0);
							_classes[i + 6].SpCStarting = (byte)Math.Max(_classes[i + 6].SpCStarting + bonusmalus.StatMod, 0);
							break;
						case BonusMalusAction.WhiteSpellcaster:
							if (_classes[i].SpCStarting < (byte)bonusmalus.StatMod)
								_classes[i].SpCStarting = (byte)bonusmalus.StatMod;
							if (_classes[i].MaxSpC < (byte)bonusmalus.StatMod2)
								_classes[i].MaxSpC = (byte)bonusmalus.StatMod2;
							if (i == (int)Classes.Thief && bonusmalus.SpcGrowth.Select(x => (int)x).ToList().Sum() == exKnightMPlist.Select(x => (int)x).ToList().Sum())
								_classes[i].SpCGrowth = exNinjaMPlist; // Edge case for thief getting Knight Sp
							else if (_classes[i].SpCGrowth.Select(x => (int)x).ToList().Sum() < bonusmalus.SpcGrowth.Select(x => (int)x).ToList().Sum())
								_classes[i].SpCGrowth = bonusmalus.SpcGrowth;

							if (_classes[i + 6].SpCStarting < (byte)bonusmalus.StatMod)
								_classes[i + 6].SpCStarting = (byte)bonusmalus.StatMod;
							if (_classes[i + 6].MaxSpC < (byte)bonusmalus.StatMod2)
								_classes[i + 6].MaxSpC = (byte)bonusmalus.StatMod2;

							_spellPermissions.AddPermissionsRange(bonusmalus.SpellList.Select(x => ((Classes)i, x)).ToList());
							_spellPermissions.AddPermissionsRange(bonusmalus.SpellList.Select(x => ((Classes)(i + 6), x)).ToList());
							break;
						case BonusMalusAction.BlackSpellcaster:
							if (_classes[i].SpCStarting < (byte)bonusmalus.StatMod)
								_classes[i].SpCStarting = (byte)bonusmalus.StatMod;
							if (_classes[i].MaxSpC < (byte)bonusmalus.StatMod2)
								_classes[i].MaxSpC = (byte)bonusmalus.StatMod2;
							if (_classes[i].SpCGrowth.Select(x => (int)x).ToList().Sum() < bonusmalus.SpcGrowth.Select(x => (int)x).ToList().Sum())
								_classes[i].SpCGrowth = bonusmalus.SpcGrowth;

							if (_classes[i + 6].SpCStarting < (byte)bonusmalus.StatMod)
								_classes[i + 6].SpCStarting = (byte)bonusmalus.StatMod;
							if (_classes[i + 6].MaxSpC < (byte)bonusmalus.StatMod2)
								_classes[i + 6].MaxSpC = (byte)bonusmalus.StatMod2;
							_spellPermissions.AddPermissionsRange(bonusmalus.SpellList.Select(x => ((Classes)i, x)).ToList());
							_spellPermissions.AddPermissionsRange(bonusmalus.SpellList.Select(x => ((Classes)(i + 6), x)).ToList());
							break;
						case BonusMalusAction.SpcMax:
							_classes[i].MaxSpC = (byte)Math.Max(_classes[i].MaxSpC + bonusmalus.StatMod, 1);
							_classes[i + 6].MaxSpC = (byte)Math.Max(_classes[i + 6].MaxSpC + bonusmalus.StatMod, 1);
							break;
						case BonusMalusAction.SpcGrowth:
							_classes[i].SpCGrowth = bonusmalus.SpcGrowth;
							_classes[i + 6].SpCGrowth = bonusmalus.SpcGrowth;
							break;
						case BonusMalusAction.PowerRW:
							// Strong blessing applies unpromoted; regular only applies promoted
							if ((byte)bonusmalus.StatMod == 1)
							{
								_spellPermissions[(Classes)i] = wmWhiteSpells.Concat(bmBlackSpells).ToList();
							}
							_spellPermissions[(Classes)(i + 6)] = wwWhiteSpells.Concat(bwBlackSpells).ToList();
							break;
						case BonusMalusAction.NoPromoMagic:
							_spellPermissions.ClearPermissions((Classes)i + 6);
							_classes[i + 6].MaxSpC = 0;
							_classes[i + 6].SpCStarting = 0;
							break;
						case BonusMalusAction.LockpickingLevel:
							int newLockPickingLevel = flags.LockpickingLevelRequirement + bonusmalus.StatMod;
							if ((bool)flags.Lockpicking)
							{
								//constrain lp level to 1-50
								newLockPickingLevel = Math.Max(1, newLockPickingLevel);
								newLockPickingLevel = Math.Min(50, newLockPickingLevel);
								rom.SetLockpickingLevel(newLockPickingLevel);
							}
							break;
						case BonusMalusAction.InnateResist:
							_classes[i].InnateResist = (byte)bonusmalus.StatMod;
							_classes[i + 6].InnateResist = (byte)bonusmalus.StatMod;
							break;
						case BonusMalusAction.BonusXp:
							double scale = bonusmalus.StatMod / 100.0;
							rom.ScaleAltExp(scale, (FF1Rom.FF1Class)i);
							break;
						case BonusMalusAction.MpGainOnMaxMpGain:
							rom.Put(lut_MpGainOnMaxMpGainClasses + i, Blob.FromHex("01"));
							rom.Put(lut_MpGainOnMaxMpGainClasses + i + 6, Blob.FromHex("01"));
							break;
						case BonusMalusAction.StartWithSpell:
							_classes[i].StartingSpell = bonusmalus.SpellSlotMod;
							_classes[i + 6].StartingSpell = bonusmalus.SpellSlotMod;
							break;
						case BonusMalusAction.CantLearnSpell:
							_spellPermissions.RemovePermission((Classes)i, (SpellSlots)bonusmalus.SpellSlotMod.BattleId);
							_spellPermissions.RemovePermission((Classes)(i + 6), (SpellSlots)bonusmalus.SpellSlotMod.BattleId);
							break;
						case BonusMalusAction.StartWithGold:
							_classes[i].StartWithGold = (BlursesStartWithGold)bonusmalus.StatMod;
							_classes[i + 6].StartWithGold = (BlursesStartWithGold)bonusmalus.StatMod;
							break;
						case BonusMalusAction.StartWithMp:
							_classes[i].StartWithMp = true;
							_classes[i + 6].StartWithMp = true;
							break;
						case BonusMalusAction.Hunter:
							_classes[i].HurtType |= (byte)bonusmalus.StatMod;
							_classes[i + 6].HurtType |= (byte)bonusmalus.StatMod;
							break;
						case BonusMalusAction.UnarmedAttack:
							_classes[i].UnarmedAttack = true;
							_classes[i + 6].UnarmedAttack = true;
							break;
						case BonusMalusAction.ThorMaster:
							_classes[i].ThorMaster = true;
							_classes[i + 6].ThorMaster = true;
							_weaponPermissions.AddPermissionsRange(new List<(Classes, Item)> { ((Classes)(i), Item.ThorHammer) });
							_weaponPermissions.AddPermissionsRange(new List<(Classes, Item)> { ((Classes)(i + 6), Item.ThorHammer) });
							break;
						case BonusMalusAction.CatClawMaster:
							_classes[i].CatClawMaster = true;
							_classes[i + 6].CatClawMaster = true;
							_weaponPermissions.AddPermissionsRange(new List<(Classes, Item)> { ((Classes)(i), Item.CatClaw) });
							_weaponPermissions.AddPermissionsRange(new List<(Classes, Item)> { ((Classes)(i + 6), Item.CatClaw) });
							break;
						case BonusMalusAction.SteelLord:
							_classes[i].SteelLord = true;
							_classes[i + 6].SteelLord = true;
							break;
						case BonusMalusAction.WoodAdept:
							_classes[i].WoodAdept = true;
							_classes[i + 6].WoodAdept = true;
							_armorPermissions.AddPermissionsRange(new List<(Classes, Item)> { ((Classes)i, Item.WoodenArmor), ((Classes)i, Item.WoodenHelm), ((Classes)i, Item.WoodenShield), ((Classes)(i + 6), Item.WoodenArmor), ((Classes)(i + 6), Item.WoodenHelm), ((Classes)(i + 6), Item.WoodenShield) });
							break;
						case BonusMalusAction.Sick:
							_classes[i].Sick = true;
							_classes[i + 6].Sick = true;
							break;
						case BonusMalusAction.Sleepy:
							_classes[i].Sleepy = true;
							_classes[i + 6].Sleepy = true;
							break;
						case BonusMalusAction.StartWithKI:
							_classes[i].StartingKeyItem = (Item)bonusmalus.StatMod;
							_classes[i + 6].StartingKeyItem = (Item)bonusmalus.StatMod;
							break;
						case BonusMalusAction.InnateSpells:
							_classes[i].InnateSpells = bonusmalus.SpellsMod.ToList();
							_classes[i + 6].InnateSpells = bonusmalus.SpellsMod.ToList();
							break;
					}
				}
			}

			return descriptionList;
		}
		//this code might be re-used without the rng aspect and using the flags instead
		public BonusMalusLeagueWIP CreateRandomResistBonusMalusLeagueWIP(MT19337 rng)
		{
			byte innateResistValue = 0x00;
			string description = "Res. ";
			List<SpellElement> elements = Enum.GetValues(typeof(SpellElement)).Cast<SpellElement>().ToList();
			elements.Remove(SpellElement.Any);
			elements.Remove(SpellElement.All);

			//3 picks but can get a none
			for (int picks = 0; picks < 3; picks++)
			{

				SpellElement pickedElement = elements.SpliceRandom(rng);
				switch (pickedElement)
				{
					case SpellElement.Any:
					case SpellElement.None:
					case SpellElement.All:
						break;
					case SpellElement.Status:
						description += "S";
						break;
					case SpellElement.Poison:
						description += "P";
						break;
					case SpellElement.Time:
						description += "T";
						break;
					case SpellElement.Death:
						description += "D";
						break;
					case SpellElement.Fire:
						description += "F";
						break;
					case SpellElement.Ice:
						description += "I";
						break;
					case SpellElement.Lightning:
						description += "L";
						break;
					case SpellElement.Earth:
						description += "E";
						break;
				}

				innateResistValue |= (byte)pickedElement;
			}

			return new BonusMalusLeagueWIP(BonusMalusAction.InnateResist, description, mod: innateResistValue);
		}

		public List<BonusMalusLeagueWIP> CreateSpellBonusesLeagueWIP(FF1Rom rom, MT19337 rng, Flags flags)  //to make this work  within the plando
																											//, we would take this list and run the if statement to find the correct spells
		{
			List<BonusMalusLeagueWIP> spellBlursings = new();

			SpellHelper spellHelper = new(rom);

			List<List<byte>> blackSpellList = new();
			List<List<byte>> whiteSpellList = new();

			blackSpellList.Add(spellHelper.FindSpells(SpellRoutine.Fast, SpellTargeting.Any).Select(x => (byte)x.Id).ToList()); // Fast
			blackSpellList.Add(spellHelper.FindSpells(SpellRoutine.Sabr, SpellTargeting.OneCharacter).Select(x => (byte)x.Id).ToList()); // Tmpr
																																		 //blackSpellList.Add(spellHelper.FindSpells(SpellRoutine.Sabr, SpellTargeting.Self).Where(s => s.Info.effect <= 18).Select(x => (byte)x.Id).ToList()); // Sabr
			blackSpellList.Add(new List<byte> { (byte)(rom.Get(FF1Rom.MagicOutOfBattleOffset + FF1Rom.MagicOutOfBattleSize * 10, 1)[0]) }); // Warp
																																			// Include LOCK/LOK2 as long as accuracy isn't too low
			if ((flags.LockMode != LockHitMode.Vanilla) && (flags.LockMode != LockHitMode.Accuracy107))
			{
				blackSpellList.Add(spellHelper.FindSpells(SpellRoutine.Lock, SpellTargeting.Any).Select(x => (byte)x.Id).ToList()); // Lock or Lok2
			}

			whiteSpellList.Add(spellHelper.FindSpells(SpellRoutine.Life, SpellTargeting.OneCharacter).Select(x => (byte)x.Id).ToList()); // Life
																																		 //whiteSpellList.Add(spellHelper.FindSpells(SpellRoutine.Ruse, SpellTargeting.Self).Select(x => (byte)x.Id).ToList()); // Ruse
			whiteSpellList.Add(spellHelper.FindSpells(SpellRoutine.Ruse, SpellTargeting.AllCharacters).Where(s => s.Info.effect <= 50).Select(x => (byte)x.Id).ToList()); // Inv2
			whiteSpellList.Add(spellHelper.FindSpells(SpellRoutine.Heal, SpellTargeting.OneCharacter).Where(s => s.Info.effect >= 70 && s.Info.effect <= 140).Select(x => (byte)x.Id).ToList()); //Cur3
			whiteSpellList.Add(spellHelper.FindSpells(SpellRoutine.Heal, SpellTargeting.AllCharacters).Where(s => s.Info.effect >= 24 && s.Info.effect <= 40 && s.Info.Level <= 4).Select(x => (byte)x.Id).ToList()); //Hel2 if Lvl 4 or Less
			whiteSpellList.Add(new List<byte> { (byte)(rom.Get(FF1Rom.MagicOutOfBattleOffset + FF1Rom.MagicOutOfBattleSize * 12, 1)[0]) }); // Exit

			foreach (var spell in blackSpellList)
			{
				if (spell.Any())
				{
					var test = SpellSlotStructure.GetSpellSlots();

					SpellSlotInfo spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == spell.PickRandom(rng));
					if (spellId != null)
					{
						spellBlursings.Add(new BonusMalusLeagueWIP(BonusMalusAction.InnateSpells, "+" + rom.ItemsText[(int)spellId.NameId], spellsmod: new List<SpellSlotInfo> { spellId, new SpellSlotInfo(), new SpellSlotInfo() }, Classes: new List<Classes> { Classes.RedMage, Classes.BlackMage }));
					}
				}
			}

			foreach (var spell in whiteSpellList)
			{
				if (spell.Any())
				{
					var test = SpellSlotStructure.GetSpellSlots();
					var pickedSpell = spell.PickRandom(rng);
					SpellSlotInfo spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == pickedSpell);
					if (spellId != null)
					{
						spellBlursings.Add(new BonusMalusLeagueWIP(BonusMalusAction.InnateSpells, "+" + rom.ItemsText[(int)spellId.NameId], spellsmod: new List<SpellSlotInfo> { spellId, new SpellSlotInfo(), new SpellSlotInfo() }, Classes: new List<Classes> { Classes.RedMage, Classes.WhiteMage }));
					}
				}
			}

			return spellBlursings;
		}
		public List<BonusMalusLeagueWIP> CreateSpellMalusesLeagueWIP(FF1Rom rom, MT19337 rng, Flags flags)
		{

			List<BonusMalusLeagueWIP> spellBlursings = new();

			SpellHelper spellHelper = new(rom);

			List<List<byte>> spellList = new();

			spellList.Add(spellHelper.FindSpells(SpellRoutine.Fast, SpellTargeting.Any).Select(x => (byte)x.Id).ToList()); // Fast
			spellList.Add(spellHelper.FindSpells(SpellRoutine.Sabr, SpellTargeting.OneCharacter).Select(x => (byte)x.Id).ToList()); // Tmpr
			spellList.Add(spellHelper.FindSpells(SpellRoutine.Damage, SpellTargeting.AllEnemies, SpellElement.None).Where(s => s.Info.effect >= 100).Select(x => (byte)x.Id).ToList()); // Nuke
			spellList.Add(spellHelper.FindSpells(SpellRoutine.Damage, SpellTargeting.AllEnemies).Where(s => s.Info.effect >= 50 && s.Info.elem != SpellElement.None).Select(x => (byte)x.Id).ToList()); // Fir3, Ice3, or Lit3
			spellList.Add(new List<byte> { (byte)(rom.Get(FF1Rom.MagicOutOfBattleOffset + (FF1Rom.MagicOutOfBattleSize * 10), 1)[0]) }); // Warp
																																		 // Include LOCK/LOK2 as long as accuracy isn't too low
			if ((flags.LockMode != LockHitMode.Vanilla) && (flags.LockMode != LockHitMode.Accuracy107))
			{
				spellList.Add(spellHelper.FindSpells(SpellRoutine.Lock, SpellTargeting.Any).Select(x => (byte)x.Id).ToList()); // Lock or Lok2
			}

			spellList.Add(spellHelper.FindSpells(SpellRoutine.Life, SpellTargeting.OneCharacter).Select(x => (byte)x.Id).ToList()); // Life
			spellList.Add(spellHelper.FindSpells(SpellRoutine.Ruse, SpellTargeting.AllCharacters).Select(x => (byte)x.Id).ToList()); // Inv2
			spellList.Add(spellHelper.FindSpells(SpellRoutine.Damage, SpellTargeting.AllEnemies, SpellElement.None).Where(s => s.Info.effect > 70 && s.Info.effect < 100).Select(x => (byte)x.Id).ToList()); // Fade
			spellList.Add(new List<byte> { (byte)(rom.Get(FF1Rom.MagicOutOfBattleOffset + (FF1Rom.MagicOutOfBattleSize * 12), 1)[0]) }); // Exit
			spellList.Add(spellHelper.FindSpells(SpellRoutine.Heal, SpellTargeting.OneCharacter).Where(s => s.Info.effect >= 70 && s.Info.effect <= 200).Select(x => (byte)x.Id).ToList()); // Cur3
			spellList.Add(spellHelper.FindSpells(SpellRoutine.Heal, SpellTargeting.AllCharacters).Where(s => s.Info.effect >= 42 && s.Info.effect <= 100).Select(x => (byte)x.Id).ToList()); // Hel3
			spellList.Add(spellHelper.FindSpells(SpellRoutine.DefElement, SpellTargeting.Any).Where(s => s.Info.status == SpellStatus.Any).Select(x => (byte)x.Id).ToList()); // Wall

			foreach (var spell in spellList)
			{
				if (spell.Any())
				{
					List<Classes> validClasses = new();
					SpellSlotInfo spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == spell.PickRandom(rng));

					if (spellId == null)
					{
						continue;
					}

					if (_spellPermissions[Classes.RedMage].Where(x => x == (SpellSlots)spellId.BattleId).Any())
					{
						validClasses.Add(Classes.RedMage);
					}

					if (_spellPermissions[Classes.BlackMage].Where(x => x == (SpellSlots)spellId.BattleId).Any())
					{
						validClasses.Add(Classes.BlackMage);
					}

					if (_spellPermissions[Classes.WhiteMage].Where(x => x == (SpellSlots)spellId.BattleId).Any())
					{
						validClasses.Add(Classes.WhiteMage);
					}

					if (validClasses.Any())
					{
						spellBlursings.Add(new BonusMalusLeagueWIP(BonusMalusAction.CantLearnSpell, "No " + rom.ItemsText[(int)spellId.NameId], spellslotmod: spellId, Classes: validClasses));
					}
				}
			}

			return spellBlursings;
		}

		public (List<BonusMalusLeagueWIP>, List<BonusMalusLeagueWIP>) CreateMagicBonusesLeagueWIP(FF1Rom rom, MT19337 rng, Flags flags) //this is for the different magic types
		{
			List<BonusMalusLeagueWIP> spellBlursingsStrong = new();
			List<BonusMalusLeagueWIP> spellBlursingsNormal = new();

			SpellHelper spellHelper = new(rom);

			List<List<byte>> blackSpellList = new();
			List<List<byte>> whiteSpellList = new();


			List<byte> spellNuke = spellHelper.FindSpells(SpellRoutine.Damage, SpellTargeting.AllEnemies).Where(s => s.Info.elem == SpellElement.None && s.Info.effect >= 100).Select(x => (byte)x.Id).ToList(); // Nuke
			List<byte> spellElem3 = spellHelper.FindSpells(SpellRoutine.Damage, SpellTargeting.AllEnemies).Where(s => s.Info.effect >= 50 && s.Info.elem != SpellElement.None).Select(x => (byte)x.Id).ToList();
			List<byte> spellElem2 = spellHelper.FindSpells(SpellRoutine.Damage, SpellTargeting.AllEnemies).Where(s => s.Info.elem != SpellElement.None && s.Info.effect >= 30 && s.Info.effect < 50).Select(x => (byte)x.Id).ToList();
			List<byte> spellFast = spellHelper.FindSpells(SpellRoutine.Fast, SpellTargeting.Any).Select(x => (byte)x.Id).ToList(); // Fast
			List<byte> spellTmpr = spellHelper.FindSpells(SpellRoutine.Sabr, SpellTargeting.OneCharacter).Select(x => (byte)x.Id).ToList(); // Tmpr
			List<byte> spellSabr = spellHelper.FindSpells(SpellRoutine.Sabr, SpellTargeting.Self).Where(s => s.Info.effect <= 18).Select(x => (byte)x.Id).ToList(); // Sabr
			List<byte> spellWarp = new List<byte> { (byte)(rom.Get(FF1Rom.MagicOutOfBattleOffset + FF1Rom.MagicOutOfBattleSize * 10, 1)[0]) }; // Warp
			List<byte> spellLife = spellHelper.FindSpells(SpellRoutine.Life, SpellTargeting.OneCharacter).Select(x => (byte)x.Id).ToList(); // Life
			List<byte> spellRuse = spellHelper.FindSpells(SpellRoutine.Ruse, SpellTargeting.Self).Select(x => (byte)x.Id).ToList(); // Ruse
			List<byte> spellInv2 = spellHelper.FindSpells(SpellRoutine.Ruse, SpellTargeting.AllCharacters).Where(s => s.Info.effect <= 50).Select(x => (byte)x.Id).ToList(); // Inv2
			List<byte> spellCur3 = spellHelper.FindSpells(SpellRoutine.Heal, SpellTargeting.OneCharacter).Where(s => s.Info.effect >= 70 && s.Info.effect <= 140).Select(x => (byte)x.Id).ToList(); //Cur3
			List<byte> spellCur4 = spellHelper.FindSpells(SpellRoutine.FullHeal, SpellTargeting.OneCharacter).Select(x => (byte)x.Id).ToList(); //Cur4
			List<byte> spellHel2 = spellHelper.FindSpells(SpellRoutine.Heal, SpellTargeting.AllCharacters).Where(s => s.Info.effect >= 24 && s.Info.effect <= 40).Select(x => (byte)x.Id).ToList(); //Hel2
			List<byte> spellHel3 = spellHelper.FindSpells(SpellRoutine.Heal, SpellTargeting.AllCharacters).Where(s => s.Info.effect > 40).Select(x => (byte)x.Id).ToList(); //Hel3
			List<byte> spellExit = new List<byte> { (byte)(rom.Get(FF1Rom.MagicOutOfBattleOffset + FF1Rom.MagicOutOfBattleSize * 12, 1)[0]) }; // Exit
			List<byte> spellCleaning = spellHelper.FindSpells(SpellRoutine.CureAilment, SpellTargeting.Any).Select(x => (byte)x.Id).ToList();
			List<byte> spellDoom = spellHelper.FindSpells(SpellRoutine.InflictStatus, SpellTargeting.Any).Where(s => s.Info.effect == (byte)SpellStatus.Death || s.Info.effect == (byte)SpellStatus.Stone).Select(x => (byte)x.Id).ToList();


			if (spellNuke.Any())
			{
				var selectedSpell = spellNuke.PickRandom(rng);
				SpellSlotInfo spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == selectedSpell);

				if (spellId != null)
				{
					spellBlursingsStrong.Add(new BonusMalusLeagueWIP(BonusMalusAction.InnateSpells, "Nuke Magic", spellsmod: new List<SpellSlotInfo> { spellId, spellId, spellId }, Classes: new List<Classes> { Classes.RedMage, Classes.WhiteMage, Classes.BlackMage }));
				}
			}

			if (spellElem3.Count >= 3)
			{
				List<SpellSlotInfo> spells = new();

				for (int i = 0; i < 3; i++)
				{
					var selectedSpell = spellElem3.SpliceRandom(rng);
					var spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == selectedSpell);

					if (spellId != null)
					{
						spells.Add(spellId);
					}
				}

				if (spells.Count == 3)
				{
					spellBlursingsNormal.Add(new BonusMalusLeagueWIP(BonusMalusAction.InnateSpells, "Elem+ Magic", spellsmod: new List<SpellSlotInfo> { spells[0], spells[1], spells[2] }, Classes: new List<Classes> { Classes.RedMage, Classes.WhiteMage, Classes.BlackMage }));

					spellBlursingsStrong.Add(new BonusMalusLeagueWIP(BonusMalusAction.InnateSpells, "Elem+ Magic", spellsmod: new List<SpellSlotInfo> { spells[0], spells[1], spells[2] }, Classes: new List<Classes> { Classes.Fighter, Classes.Thief, Classes.BlackBelt }));
				}
			}

			if (spellElem2.Count >= 3)
			{
				List<SpellSlotInfo> spells = new();

				for (int i = 0; i < 3; i++)
				{
					var selectedSpell = spellElem2.SpliceRandom(rng);
					var spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == selectedSpell);

					if (spellId != null)
					{
						spells.Add(spellId);
					}
				}

				if (spells.Count == 3)
				{
					spellBlursingsNormal.Add(new BonusMalusLeagueWIP(BonusMalusAction.InnateSpells, "Elem Magic", spellsmod: new List<SpellSlotInfo> { spells[0], spells[1], spells[2] }));
				}
			}

			if (spellCleaning.Count >= 3)
			{
				List<SpellSlotInfo> spells = new();

				for (int i = 0; i < 3; i++)
				{
					var selectedSpell = spellCleaning.SpliceRandom(rng);
					var spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == selectedSpell);

					if (spellId != null)
					{
						spells.Add(spellId);
					}
				}

				if (spells.Count == 3)
				{
					spellBlursingsNormal.Add(new BonusMalusLeagueWIP(BonusMalusAction.InnateSpells, "Clean Magic", spellsmod: new List<SpellSlotInfo> { spells[0], spells[1], spells[2] }));
				}
			}

			if (spellDoom.Count >= 3)
			{
				List<SpellSlotInfo> spells = new();

				for (int i = 0; i < 3; i++)
				{
					var selectedSpell = spellDoom.SpliceRandom(rng);
					var spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == selectedSpell);

					if (spellId != null)
					{
						spells.Add(spellId);
					}
				}
				if (spells.Count == 3)
				{
					spellBlursingsNormal.Add(new BonusMalusLeagueWIP(BonusMalusAction.InnateSpells, "Doom Magic", spellsmod: new List<SpellSlotInfo> { spells[0], spells[1], spells[2] }, Classes: new List<Classes> { Classes.RedMage, Classes.WhiteMage, Classes.BlackMage }));
				}
			}

			if (spellCur3.Any() && spellHel2.Any() && spellLife.Any())
			{
				List<SpellSlotInfo> spells = new();

				spells.Add(SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == spellCur3.PickRandom(rng)));
				spells.Add(SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == spellHel2.PickRandom(rng)));
				spells.Add(SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == spellLife.PickRandom(rng)));

				if (spells.Where(x => x != null).Count() == 3)
				{
					spellBlursingsNormal.Add(new BonusMalusLeagueWIP(BonusMalusAction.InnateSpells, "Heal Magic", spellsmod: new List<SpellSlotInfo> { spells[0], spells[1], spells[2] }));
				}
			}

			if (spellCur4.Any() && spellHel3.Any() && spellLife.Any())
			{
				List<SpellSlotInfo> spells = new();

				spells.Add(SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == spellCur4.PickRandom(rng)));
				spells.Add(SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == spellHel3.PickRandom(rng)));
				spells.Add(SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == spellLife.PickRandom(rng)));

				if (spells.Where(x => x != null).Count() == 3)
				{
					spellBlursingsNormal.Add(new BonusMalusLeagueWIP(BonusMalusAction.InnateSpells, "Heal+ Magic", spellsmod: new List<SpellSlotInfo> { spells[0], spells[1], spells[2] }, Classes: new List<Classes> { Classes.RedMage, Classes.WhiteMage, Classes.BlackMage }));

					spellBlursingsStrong.Add(new BonusMalusLeagueWIP(BonusMalusAction.InnateSpells, "Heal+ Magic", spellsmod: new List<SpellSlotInfo> { spells[0], spells[1], spells[2] }, Classes: new List<Classes> { Classes.Fighter, Classes.Thief, Classes.BlackBelt }));

				}
			}

			if (spellRuse.Any() && spellSabr.Any())
			{
				List<SpellSlotInfo> spells = new();

				spells.Add(SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == spellRuse.PickRandom(rng)));
				spells.Add(SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == spellSabr.PickRandom(rng)));
				spells.Add(new SpellSlotInfo());

				if (spells.Where(x => x != null).Count() == 3)
				{
					spellBlursingsStrong.Add(new BonusMalusLeagueWIP(BonusMalusAction.InnateSpells, "Self Magic", spellsmod: new List<SpellSlotInfo> { spells[0], spells[1], spells[2] }, Classes: new List<Classes> { Classes.Fighter, Classes.Thief, Classes.BlackBelt }));
				}
			}

			if (spellTmpr.Any() && spellFast.Any() && spellInv2.Any())
			{
				List<SpellSlotInfo> spells = new();

				spells.Add(SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == spellTmpr.PickRandom(rng)));
				spells.Add(SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == spellFast.PickRandom(rng)));
				spells.Add(SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == spellInv2.PickRandom(rng)));

				if (spells.Where(x => x != null).Count() == 3)
				{
					spellBlursingsNormal.Add(new BonusMalusLeagueWIP(BonusMalusAction.InnateSpells, "Buff Magic", spellsmod: new List<SpellSlotInfo> { spells[0], spells[1], spells[2] }, Classes: new List<Classes> { Classes.RedMage, Classes.WhiteMage, Classes.BlackMage }));

					spellBlursingsStrong.Add(new BonusMalusLeagueWIP(BonusMalusAction.InnateSpells, "Buff Magic", spellsmod: new List<SpellSlotInfo> { spells[0], spells[1], spells[2] }, Classes: new List<Classes> { Classes.Fighter, Classes.Thief, Classes.BlackBelt }));
				}
			}

			if (spellWarp.Any() && spellExit.Any())
			{
				List<SpellSlotInfo> spells = new();

				spells.Add(SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == spellWarp.PickRandom(rng)));
				spells.Add(SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == spellExit.PickRandom(rng)));
				spells.Add(new SpellSlotInfo());

				if (spells.Where(x => x != null).Count() == 3)
				{
					spellBlursingsNormal.Add(new BonusMalusLeagueWIP(BonusMalusAction.InnateSpells, "Tele Magic", spellsmod: new List<SpellSlotInfo> { spells[0], spells[1], spells[2] }));
				}
			}

			return (spellBlursingsNormal, spellBlursingsStrong);
		}
	}
}
