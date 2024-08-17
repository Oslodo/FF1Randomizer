using FF1Lib.Helpers;
using RomUtilities;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Created this new list due to the old one having conditional statements that are not needed for the plando code as
any bonus or malus that is not functional will not be selectable, as well there is no need for randomization or class
based blusrings */

namespace FF1Lib
{
	public partial class GameClasses
	{
		public class BonusMalusPlando
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
			public BonusMalusPlando(BonusMalusAction action, string description, int mod = 0, int mod2 = 0, List<Item> equipment = null, List<bool> binarylist = null, List<SpellSlots> spelllist = null, List<byte> bytelist = null, SpellSlotInfo spellslotmod = null, List<SpellSlotInfo> spellsmod = null, List<Classes> Classes = null)
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
		public void GenerateListsPlando(List<BonusMalusPlando> bonusList, List<BonusMalusPlando> maluses, List<string> olditemnames, ItemNames itemnames, Flags flags, FF1Rom rom)
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

			//Masa and Ribbon Curse Setup
			List<(string name, byte value)> ailments = new()
			{
				("Poison", 0x04),
				("Stun", 0x10),
				("Sleep", 0x20),
				("Mute", 0x40),
			};

			//Master Bonus List

			bonusList.AddRange(new List<BonusMalusPlando>()
			{
				new BonusMalusPlando(BonusMalusAction.StrMod, "+10 Str.", mod: 10),
				new BonusMalusPlando(BonusMalusAction.AgiMod, "+15 Agi.", mod: 15),
				new BonusMalusPlando(BonusMalusAction.VitMod, "+10 Vit.", mod: 10),
				new BonusMalusPlando(BonusMalusAction.LckMod, "+5 Luck", mod: 5),
				new BonusMalusPlando(BonusMalusAction.HpMod, "+20 HP", mod: 20),
				new BonusMalusPlando(BonusMalusAction.HitMod, "+10 Hit%", mod: 10),
				new BonusMalusPlando(BonusMalusAction.MDefMod, "+10 MDef", mod: 10),
				new BonusMalusPlando(BonusMalusAction.WeaponAdd, "+Equip @X", equipment: equipAxes),
				new BonusMalusPlando(BonusMalusAction.ArmorAdd, "+Equip @T", equipment: equipShirts),
				new BonusMalusPlando(BonusMalusAction.ArmorAdd, "+Equip @s", equipment: equipShields),
				new BonusMalusPlando(BonusMalusAction.ArmorAdd, "+Equip @G+@h", equipment: equipGauntletsHelmets),
				new BonusMalusPlando(BonusMalusAction.WeaponAdd, "+Thief @S", equipment: equipThiefWeapon),
				new BonusMalusPlando(BonusMalusAction.SpcMod, "+2 Lv1 MP", mod: 2),
				new BonusMalusPlando(BonusMalusAction.StrMod, "+20 Str.", mod: 20),
				new BonusMalusPlando(BonusMalusAction.AgiMod, "+25 Agi.", mod: 25),
				new BonusMalusPlando(BonusMalusAction.VitMod, "+20 Vit.", mod: 20),
				new BonusMalusPlando(BonusMalusAction.LckMod, "+10 Luck", mod: 10),
				new BonusMalusPlando(BonusMalusAction.HpMod, "+40 HP", mod: 40),
				new BonusMalusPlando(BonusMalusAction.HitMod, "+20 Hit%", mod: 20),
				new BonusMalusPlando(BonusMalusAction.MDefMod, "+20 MDef", mod: 20),
				new BonusMalusPlando(BonusMalusAction.WeaponAdd, "+Legendary@S", equipment: equipLegendaryWeapons),
				new BonusMalusPlando(BonusMalusAction.ArmorAdd, "+Red Mage @A", equipment: equipRedMageArmor),
				new BonusMalusPlando(BonusMalusAction.StartWithMp, "+1 MP LvAll"),
				new BonusMalusPlando(BonusMalusAction.ThorMaster, "Improved\n Thor@H"),
				new BonusMalusPlando(BonusMalusAction.Hunter, "Hurt Undead", mod: 0x18),
				new BonusMalusPlando(BonusMalusAction.Hunter, "Hurt Dragon", mod: 0x02),
				new BonusMalusPlando(BonusMalusAction.InnateResist, "Res. PEDTS", mod: (int)(SpellElement.Poison | SpellElement.Earth | SpellElement.Death | SpellElement.Time | SpellElement.Status)),
				//start of strong tier
				new BonusMalusPlando(BonusMalusAction.StrMod, "+40 Str.", mod: 40),
				new     (BonusMalusAction.AgiMod, "+50 Agi.", mod: 50),
				new BonusMalusPlando(BonusMalusAction.VitMod, "+40 Vit.", mod: 40),
				new BonusMalusPlando(BonusMalusAction.LckMod, "+15 Luck", mod: 15),
				new BonusMalusPlando(BonusMalusAction.HpMod, "+80 HP", mod: 80),
				new BonusMalusPlando(BonusMalusAction.MDefGrowth, "+2 MDef/Lv", mod: 2),
				new BonusMalusPlando(BonusMalusAction.WeaponAdd, "+Fighter @S", equipment: equipFighterWeapon),
				new BonusMalusPlando(BonusMalusAction.ArmorAdd, "+Fighter @A", equipment: equipFighterArmor),
				new BonusMalusPlando(BonusMalusAction.SpcGrowth, "Improved MP", bytelist: improvedMPlist),
				new BonusMalusPlando(BonusMalusAction.PowerRW, "Sage", mod: 1, spelllist: wmWhiteSpells.Concat(bmBlackSpells).Concat(wwWhiteSpells).Concat(bwBlackSpells).ToList()),
				new BonusMalusPlando(BonusMalusAction.Hunter, "Hurt All", mod: 0xFF),
				new BonusMalusPlando(BonusMalusAction.InnateResist, "Res. All", mod: 0xFF),
				//Add here the code for the resistances
				//int tier
				new BonusMalusPlando(BonusMalusAction.IntMod, "+10 Int.", mod: 10),
				new BonusMalusPlando(BonusMalusAction.IntMod, "+20 Int.", mod: 20),
				new BonusMalusPlando(BonusMalusAction.IntMod, "+40 Int.", mod: 40),
				//weaponizer tier
				new BonusMalusPlando(BonusMalusAction.CatClawMaster, "Improved\n CatClaw", equipment: new List<Item>() { Item.CatClaw }),
				new BonusMalusPlando(BonusMalusAction.DualWieldKnife, "DualWield @K"),
				//gold tier
				new BonusMalusPlando(BonusMalusAction.StartWithGold, "+200 GP", mod: 2),
				new BonusMalusPlando(BonusMalusAction.StartWithGold, "+1400 GP", mod: 14),
				new BonusMalusPlando(BonusMalusAction.StartWithGold, "+400 GP", mod: 4),
				new BonusMalusPlando(BonusMalusAction.StartWithGold, "+2000 GP", mod: 20),
				new BonusMalusPlando(BonusMalusAction.StartWithGold, "+600 GP", mod: 6),
				new BonusMalusPlando(BonusMalusAction.StartWithGold, "+3000 GP", mod: 30),
				new BonusMalusPlando(BonusMalusAction.StartWithGold, "+800 GP", mod: 8),
				new BonusMalusPlando(BonusMalusAction.StartWithGold, "+4000 GP", mod: 40),
				new BonusMalusPlando(BonusMalusAction.StartWithGold, "+1500 GP", mod: 15),
				new BonusMalusPlando(BonusMalusAction.StartWithGold, "+6000 GP", mod: 60),
				new BonusMalusPlando(BonusMalusAction.StartWithGold, "+5000 GP", mod: 50),
				new BonusMalusPlando(BonusMalusAction.StartWithGold, "+20,000 GP", mod: 200),
				new BonusMalusPlando(BonusMalusAction.StartWithGold, "+20,000 GP", mod: 200),
				//Promo tier
				new BonusMalusPlando(BonusMalusAction.ArmorAdd, "Promo FI @A", mod: 99, equipment: equipFighterArmor),
				new BonusMalusPlando(BonusMalusAction.PowerRW, "Promo Sage", mod: 0, spelllist: wmWhiteSpells.Concat(bmBlackSpells).Concat(wwWhiteSpells).Concat(bwBlackSpells).ToList()),
				new BonusMalusPlando(BonusMalusAction.MDefGrowth, "Promo\n +3 MDef", mod: 3, mod2: 99),
				//Armorcrafter tier
				new BonusMalusPlando(BonusMalusAction.WoodAdept, "Wood@A@s@h Set\n Add Evade"),
				new BonusMalusPlando(BonusMalusAction.SteelLord, "Steel@A\n Cast Fast"),
				//Add Single Spell code here
				//Lockpicking tier
				new BonusMalusPlando(BonusMalusAction.LockpickingLevel, "EarlyLokpik", mod: -10),
				//XP tier removed the duplicates as they are no longer needed for balancing
				new BonusMalusPlando(BonusMalusAction.BonusXp, "+50% XP", mod: 150),
				new BonusMalusPlando(BonusMalusAction.BonusXp, "+100% XP", mod: 200),
				//Max MP on Gain
				new BonusMalusPlando(BonusMalusAction.MpGainOnMaxMpGain, "Max+Mp+"),
			});
			maluses.AddRange(new List<BonusMalusPlando>()
			{
				new BonusMalusPlando(BonusMalusAction.StrMod, "-10 Str.", mod: -10),
				new BonusMalusPlando(BonusMalusAction.StrMod, "-20 Str.", mod: -20),
				new BonusMalusPlando(BonusMalusAction.AgiMod, "-10 Agi.", mod: -10),
				new BonusMalusPlando(BonusMalusAction.AgiMod, "-20 Agi.", mod: -20),
				new BonusMalusPlando(BonusMalusAction.VitMod, "-10 Vit.", mod: -10),
				new BonusMalusPlando(BonusMalusAction.VitMod, "-20 Vit.", mod: -20),
				new         (BonusMalusAction.LckMod, "-5 Luck", mod: -5),
				new BonusMalusPlando(BonusMalusAction.LckMod, "-10 Luck", mod: -10),
				new BonusMalusPlando(BonusMalusAction.HpMod, "-15 HP", mod: -15),
				new BonusMalusPlando(BonusMalusAction.HpMod, "-30 HP", mod: -30),
				new BonusMalusPlando(BonusMalusAction.HpGrowth, "BlackM HP", binarylist: _classes[(int)Classes.BlackMage].HpGrowth),
				new BonusMalusPlando(BonusMalusAction.HitMod, "-10 Hit%", mod: -10),
				new BonusMalusPlando(BonusMalusAction.MDefMod, "-10 MDef", mod: -10),
				new BonusMalusPlando(BonusMalusAction.HitGrowth, "-1 Hit%/Lv", mod: -1),
				new BonusMalusPlando(BonusMalusAction.MDefGrowth, "-1 MDef/Lv", mod: -1),
				new BonusMalusPlando(BonusMalusAction.ArmorRemove, "No @B", equipment: braceletList),
				new BonusMalusPlando(BonusMalusAction.WeaponReplace, "Thief @S", equipment: equipThiefWeapon),
				new BonusMalusPlando(BonusMalusAction.SpcMax, "-4 Max MP", mod: -4),
				//Int tier
				new BonusMalusPlando(BonusMalusAction.IntMod, "-10 Int.", mod: -10),
				new BonusMalusPlando(BonusMalusAction.IntMod, "-20 Int.", mod: -20),
				//Gold tier
				new BonusMalusPlando(BonusMalusAction.StartWithGold, "-50 GP", mod: -1),
				new BonusMalusPlando(BonusMalusAction.StartWithGold, "-100 GP", mod: -1),
				new BonusMalusPlando(BonusMalusAction.StartWithGold, "-150 GP", mod: -1),
				new BonusMalusPlando(BonusMalusAction.StartWithGold, "-350 GP", mod: -1),
				new BonusMalusPlando(BonusMalusAction.StartWithGold, "-1100 GP", mod: -1),
				new BonusMalusPlando(BonusMalusAction.StartWithGold, "-4500 GP", mod: -1),
				//Masa Curse tier
				new BonusMalusPlando(BonusMalusAction.MasaCurse, "Masa Curse\n Poison", mod: 0x04),
				new BonusMalusPlando(BonusMalusAction.MasaCurse, "Masa Curse\n Stun", mod: 0x10),
				new BonusMalusPlando(BonusMalusAction.MasaCurse, "Masa Curse\n Sleep", mod: 0x20),
				new BonusMalusPlando(BonusMalusAction.MasaCurse, "Masa Curse\n Mute", mod: 0x40),
				//Ribbon Curse tier
				new BonusMalusPlando(BonusMalusAction.RibbonCurse, "Ribbon Curse\n Poison", mod: 0x04),
				new BonusMalusPlando(BonusMalusAction.RibbonCurse, "Ribbon Curse\n Stun ", mod: 0x10),
				new BonusMalusPlando(BonusMalusAction.RibbonCurse, "Ribbon Curse\n Sleep", mod: 0x20),
				new BonusMalusPlando(BonusMalusAction.RibbonCurse, "Ribbon Curse\n Mute", mod: 0x40),
				//Promo Curse tier
				new BonusMalusPlando(BonusMalusAction.ArmorReplace, "No Promo @A", mod: 99, equipment: equipFighterArmorFull),
				new BonusMalusPlando(BonusMalusAction.ArmorReplace, "Promo RW @A", mod: 99, equipment: equipRedWizardArmorFull),
				new BonusMalusPlando(BonusMalusAction.NoPromoMagic, "No Promo Sp", mod: 0, mod2: 0, binarylist: nullSpells),
				new BonusMalusPlando(BonusMalusAction.UnarmedAttack, "Promo\n Unarmed", mod: 99),
				//Armorcrafter tier
				new BonusMalusPlando(BonusMalusAction.ArmorRemove, "-" + olditemnames[(int)Item.ProRing], equipment: new List<Item> { Item.ProRing }),
				//Add Single Spell code here
				//Lockpicking tier
				new BonusMalusPlando(BonusMalusAction.LockpickingLevel, "LateLockpik", mod: 10),
			});
		}
		public void KeyItemList(List<BonusMalusPlando> StartwithKIPlando, Flags flags, List<string> olditemnames)
		{
			StartwithKIPlando.AddRange(new List<BonusMalusPlando>()
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

			});
		}

		public List<BonusMalus> CreateSpellBonusesPlado(FF1Rom rom, MT19337 rng, Flags flags)
		{
			List<BonusMalus> spellBlursings = new();

			SpellHelper spellHelper = new(rom);

			List<List<byte>> blackSpellList = new();
			List<List<byte>> whiteSpellList = new();

			blackSpellList.Add(spellHelper.FindSpells(SpellRoutine.Fast, SpellTargeting.Any).Select(x => (byte)x.Id).ToList()); // Fast
			blackSpellList.Add(spellHelper.FindSpells(SpellRoutine.Sabr, SpellTargeting.OneCharacter).Select(x => (byte)x.Id).ToList()); // Tmpr
			blackSpellList.Add(new List<byte> { (byte)(rom.Get(FF1Rom.MagicOutOfBattleOffset + FF1Rom.MagicOutOfBattleSize * 10, 1)[0]) }); // Warp
			blackSpellList.Add(spellHelper.FindSpells(SpellRoutine.Lock, SpellTargeting.Any).Select(x => (byte)x.Id).ToList()); // Lock or Lok2

			whiteSpellList.Add(spellHelper.FindSpells(SpellRoutine.Life, SpellTargeting.OneCharacter).Select(x => (byte)x.Id).ToList()); // Life
			whiteSpellList.Add(spellHelper.FindSpells(SpellRoutine.Ruse, SpellTargeting.AllCharacters).Where(s => s.Info.effect <= 50).Select(x => (byte)x.Id).ToList()); // Inv2
			whiteSpellList.Add(spellHelper.FindSpells(SpellRoutine.Heal, SpellTargeting.OneCharacter).Where(s => s.Info.effect >= 70 && s.Info.effect <= 140).Select(x => (byte)x.Id).ToList()); //Cur3
			whiteSpellList.Add(spellHelper.FindSpells(SpellRoutine.Heal, SpellTargeting.AllCharacters).Where(s => s.Info.effect >= 24 && s.Info.effect <= 40).Select(x => (byte)x.Id).ToList()); //Hel2
			whiteSpellList.Add(new List<byte> { (byte)(rom.Get(FF1Rom.MagicOutOfBattleOffset + FF1Rom.MagicOutOfBattleSize * 12, 1)[0]) }); // Exit

			foreach (var spell in blackSpellList)
			{
				if (spell.Any())
				{
					var test = SpellSlotStructure.GetSpellSlots();

					SpellSlotInfo spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == spell.PickRandom(rng));
					if (spellId != null)
					{
						spellBlursings.Add(new BonusMalus(BonusMalusAction.InnateSpells, "+" + rom.ItemsText[(int)spellId.NameId], spellsmod: new List<SpellSlotInfo> { spellId, new SpellSlotInfo(), new SpellSlotInfo()}));
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
						spellBlursings.Add(new BonusMalus(BonusMalusAction.InnateSpells, "+" + rom.ItemsText[(int)spellId.NameId], spellsmod: new List<SpellSlotInfo> { spellId, new SpellSlotInfo(), new SpellSlotInfo()}));
					}
				}
			}

			return spellBlursings;
		}
	}
}
