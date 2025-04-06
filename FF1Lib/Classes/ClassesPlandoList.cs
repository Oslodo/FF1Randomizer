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
			public BonusMalusActionPlando Action { get; set; }
			public string Description { get; set; }
			public List<byte> SpcGrowth { get; set; }
			public List<Classes> ClassList { get; set; }
			public SpellSlotInfo SpellSlotMod { get; set; }
			public List<SpellSlotInfo> SpellsMod { get; set; }
			public BonusMalusPlando(BonusMalusActionPlando action, string description, int mod = 0, int mod2 = 0, List<Item> equipment = null, List<bool> binarylist = null, List<SpellSlots> spelllist = null, List<byte> bytelist = null, SpellSlotInfo spellslotmod = null, List<SpellSlotInfo> spellsmod = null, List<Classes> Classes = null)
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
				new BonusMalusPlando(BonusMalusActionPlando.StrModUp10, "+10 Str.", mod: 10),
				new BonusMalusPlando(BonusMalusActionPlando.AgiModUp15, "+15 Agi.", mod: 15),
				new BonusMalusPlando(BonusMalusActionPlando.VitModUp10, "+10 Vit.", mod: 10),
				new BonusMalusPlando(BonusMalusActionPlando.LckModUp5, "+5 Luck", mod: 5),
				new BonusMalusPlando(BonusMalusActionPlando.HPModUp20, "+20 HP", mod: 20),
				new BonusMalusPlando(BonusMalusActionPlando.HitModUp10, "+10 Hit%", mod: 10),
				new BonusMalusPlando(BonusMalusActionPlando.MDefModUp10, "+10 MDef", mod: 10),
				new BonusMalusPlando(BonusMalusActionPlando.WeaponAddAxes, "+Equip @X", equipment: equipAxes),
				new BonusMalusPlando(BonusMalusActionPlando.ArmorAddShirts, "+Equip @T", equipment: equipShirts),
				new BonusMalusPlando(BonusMalusActionPlando.ArmorAddShields, "+Equip @s", equipment: equipShields),
				new BonusMalusPlando(BonusMalusActionPlando.ArmorAddHelmGauntlet, "+Equip @G+@h", equipment: equipGauntletsHelmets),
				new BonusMalusPlando(BonusMalusActionPlando.WeaponAddThief, "+Thief @S", equipment: equipThiefWeapon),
				new BonusMalusPlando(BonusMalusActionPlando.SpcModPlus2, "+2 Lv1 MP", mod: 2),
				new BonusMalusPlando(BonusMalusActionPlando.StrModUp20, "+20 Str.", mod: 20),
				new BonusMalusPlando(BonusMalusActionPlando.AgiModUp25, "+25 Agi.", mod: 25),
				new BonusMalusPlando(BonusMalusActionPlando.VitModUp20, "+20 Vit.", mod: 20),
				new BonusMalusPlando(BonusMalusActionPlando.LckModUp10, "+10 Luck", mod: 10),
				new BonusMalusPlando(BonusMalusActionPlando.HPModUp40, "+40 HP", mod: 40),
				new BonusMalusPlando(BonusMalusActionPlando.HitModUp20, "+20 Hit%", mod: 20),
				new BonusMalusPlando(BonusMalusActionPlando.MDefModUp20, "+20 MDef", mod: 20),
				new BonusMalusPlando(BonusMalusActionPlando.WeaponAddLegendary, "+Legendary@S", equipment: equipLegendaryWeapons),
				new BonusMalusPlando(BonusMalusActionPlando.ArmorAddRedMage, "+Red Mage @A", equipment: equipRedMageArmor),
				new BonusMalusPlando(BonusMalusActionPlando.StartWithMPLvl1, "+1 MP LvAll"),
				new BonusMalusPlando(BonusMalusActionPlando.ImprovedThor, "Improved\n Thor@H"),
				new BonusMalusPlando(BonusMalusActionPlando.HunterUndead, "Hurt Undead", mod: 0x18),
				new BonusMalusPlando(BonusMalusActionPlando.HunterDragon, "Hurt Dragon", mod: 0x02),
				new BonusMalusPlando(BonusMalusActionPlando.InnateResistMajor, "Res. PEDTS", mod: (int)(SpellElement.Poison | SpellElement.Earth | SpellElement.Death | SpellElement.Time | SpellElement.Status)),
				//start of strong tier
				new BonusMalusPlando(BonusMalusActionPlando.StrModUp40, "+40 Str.", mod: 40),
				new BonusMalusPlando(BonusMalusActionPlando.AgiModUp50, "+50 Agi.", mod: 50),
				new BonusMalusPlando(BonusMalusActionPlando.VitModUp40, "+40 Vit.", mod: 40),
				new BonusMalusPlando(BonusMalusActionPlando.LckModUp15, "+15 Luck", mod: 15),
				new BonusMalusPlando(BonusMalusActionPlando.HPModUp80, "+80 HP", mod: 80),
				new BonusMalusPlando(BonusMalusActionPlando.MDefGrowthPlus2, "+2 MDef/Lv", mod: 2),
				new BonusMalusPlando(BonusMalusActionPlando.WeaponAddFighter, "+Fighter @S", equipment: equipFighterWeapon),
				new BonusMalusPlando(BonusMalusActionPlando.ArmorAddFighter, "+Fighter @A", equipment: equipFighterArmor),
				new BonusMalusPlando(BonusMalusActionPlando.Plus1MPAll, "Improved MP", bytelist: improvedMPlist),
				new BonusMalusPlando(BonusMalusActionPlando.PowerRM, "Sage", mod: 1, spelllist: wmWhiteSpells.Concat(bmBlackSpells).Concat(wwWhiteSpells).Concat(bwBlackSpells).ToList()),
				new BonusMalusPlando(BonusMalusActionPlando.HunterHurtAll, "Hurt All", mod: 0xFF),
				new BonusMalusPlando(BonusMalusActionPlando.InnateResistAll, "Res. All", mod: 0xFF),
				//Add here the code for the resistances
				//int tier
				new BonusMalusPlando(BonusMalusActionPlando.IntModUp10, "+10 Int.", mod: 10),
				new BonusMalusPlando(BonusMalusActionPlando.IntModUp20, "+20 Int.", mod: 20),
				new BonusMalusPlando(BonusMalusActionPlando.IntModUp40, "+40 Int.", mod: 40),
				//weaponizer tier
				new BonusMalusPlando(BonusMalusActionPlando.ImprovedCatclaw, "Improved\n CatClaw", equipment: new List<Item>() { Item.CatClaw }),
				new BonusMalusPlando(BonusMalusActionPlando.DualWieldKnife, "DualWield @K"),
				//gold tier
				new BonusMalusPlando(BonusMalusActionPlando.StartWithGoldUp200, "+200 GP", mod: 2),
				new BonusMalusPlando(BonusMalusActionPlando.StartWithGoldUp1400, "+1400 GP", mod: 14),
				new BonusMalusPlando(BonusMalusActionPlando.StartWithGoldUp400, "+400 GP", mod: 4),
				new BonusMalusPlando(BonusMalusActionPlando.StartWithGoldUp2000, "+2000 GP", mod: 20),
				new BonusMalusPlando(BonusMalusActionPlando.StartWithGoldUp600, "+600 GP", mod: 6),
				new BonusMalusPlando(BonusMalusActionPlando.StartWithGoldUp3000, "+3000 GP", mod: 30),
				new BonusMalusPlando(BonusMalusActionPlando.StartWithGoldUp800, "+800 GP", mod: 8),
				new BonusMalusPlando(BonusMalusActionPlando.StartWithGoldUp400, "+4000 GP", mod: 40),
				new BonusMalusPlando(BonusMalusActionPlando.StartWithGoldUp1500, "+1500 GP", mod: 15),
				new BonusMalusPlando(BonusMalusActionPlando.StartWithGoldUp6000, "+6000 GP", mod: 60),
				new BonusMalusPlando(BonusMalusActionPlando.StartWithGoldUp5000, "+5000 GP", mod: 50),
				new BonusMalusPlando(BonusMalusActionPlando.StartWithGoldUp20000, "+20,000 GP", mod: 200),
				//Promo tier
				new BonusMalusPlando(BonusMalusActionPlando.ArmorAddFighterPromo, "Promo FI @A", mod: 99, equipment: equipFighterArmor),
				new BonusMalusPlando(BonusMalusActionPlando.PowerRMPromo, "Promo Sage", mod: 0, spelllist: wmWhiteSpells.Concat(bmBlackSpells).Concat(wwWhiteSpells).Concat(bwBlackSpells).ToList()),
				new BonusMalusPlando(BonusMalusActionPlando.MaMDef, "Promo\n +3 MDef", mod: 3, mod2: 99),
				//Armorcrafter tier
				new BonusMalusPlando(BonusMalusActionPlando.WoodAdept, "Wood@A@s@h Set\n Add Evade"),
				new BonusMalusPlando(BonusMalusActionPlando.SteelLord, "Steel@A\n Cast Fast"),
				//Add Single Spell code here
				//Lockpicking tier
				new BonusMalusPlando(BonusMalusActionPlando.EarlyLockPick, "EarlyLokpik", mod: -10),
				//XP tier removed the duplicates as they are no longer needed for balancing
				new BonusMalusPlando(BonusMalusActionPlando.BonusXPPlus50, "+50% XP", mod: 150),
				new BonusMalusPlando(BonusMalusActionPlando.BonusXPPlus100, "+100% XP", mod: 200),
				//Max MP on Gain
				new BonusMalusPlando(BonusMalusActionPlando.MPGainOnMaxMP, "Max+Mp+"),
				
			});
			maluses.AddRange(new List<BonusMalusPlando>()
			{
				new BonusMalusPlando(BonusMalusActionPlando.StrModDown10, "-10 Str.", mod: -10),
				new BonusMalusPlando(BonusMalusActionPlando.StrModDown20, "-20 Str.", mod: -20),
				new BonusMalusPlando(BonusMalusActionPlando.AgiModDown10, "-10 Agi.", mod: -10),
				new BonusMalusPlando(BonusMalusActionPlando.AgiModDown20, "-20 Agi.", mod: -20),
				new BonusMalusPlando(BonusMalusActionPlando.VitModDown10, "-10 Vit.", mod: -10),
				new BonusMalusPlando(BonusMalusActionPlando.VitModDown20, "-20 Vit.", mod: -20),
				new BonusMalusPlando(BonusMalusActionPlando.LckModDown5, "-5 Luck", mod: -5),
				new BonusMalusPlando(BonusMalusActionPlando.LckModDown10, "-10 Luck", mod: -10),
				new BonusMalusPlando(BonusMalusActionPlando.HPModDown15, "-15 HP", mod: -15),
				new BonusMalusPlando(BonusMalusActionPlando.HPModDown30, "-30 HP", mod: -30),
				new BonusMalusPlando(BonusMalusActionPlando.FiBMHP, "BlackM HP", binarylist: _classes[(int)Classes.BlackMage].HpGrowth),
				new BonusMalusPlando(BonusMalusActionPlando.HitModDown10, "-10 Hit%", mod: -10),
				new BonusMalusPlando(BonusMalusActionPlando.MDefModDown10, "-10 MDef", mod: -10),
				new BonusMalusPlando(BonusMalusActionPlando.MinusOneHit, "-1 Hit%/Lv", mod: -1),
				new BonusMalusPlando(BonusMalusActionPlando.MinusOneMdef, "-1 MDef/Lv", mod: -1),
				new BonusMalusPlando(BonusMalusActionPlando.NoBracelets, "No @B", equipment: braceletList),
				new BonusMalusPlando(BonusMalusActionPlando.ThWeaponsReplace, "Thief @S", equipment: equipThiefWeapon),
				new BonusMalusPlando(BonusMalusActionPlando.MaxMPDown4, "-4 Max MP", mod: -4),
				//Int tier
				new BonusMalusPlando(BonusMalusActionPlando.IntModDown10, "-10 Int.", mod: -10),
				new BonusMalusPlando(BonusMalusActionPlando.IntModDown20, "-20 Int.", mod: -20),
				//Gold tier
				new BonusMalusPlando(BonusMalusActionPlando.StartWithGoldDown50, "-50 GP", mod: -1),
				new BonusMalusPlando(BonusMalusActionPlando.StartWithGoldDown100, "-100 GP", mod: -1),
				new BonusMalusPlando(BonusMalusActionPlando.StartWithGoldDown150, "-150 GP", mod: -1),
				new BonusMalusPlando(BonusMalusActionPlando.StartWithGoldDown350, "-350 GP", mod: -1),
				new BonusMalusPlando(BonusMalusActionPlando.StartWithGoldDown1100, "-1100 GP", mod: -1),
				new BonusMalusPlando(BonusMalusActionPlando.StartWithGoldDown4500, "-4500 GP", mod: -1),
				//Masa Curse tier
				new BonusMalusPlando(BonusMalusActionPlando.MasaCursePoison, "Masa Curse\n Poison", mod: 0x04),
				new BonusMalusPlando(BonusMalusActionPlando.MasaCurseStun, "Masa Curse\n Stun", mod: 0x10),
				new BonusMalusPlando(BonusMalusActionPlando.MasaCurseSleep, "Masa Curse\n Sleep", mod: 0x20),
				new BonusMalusPlando(BonusMalusActionPlando.MasaCurseMute, "Masa Curse\n Mute", mod: 0x40),
				//Ribbon Curse tier
				new BonusMalusPlando(BonusMalusActionPlando.RibbonCursePosion, "Ribbon Curse\n Poison", mod: 0x04),
				new BonusMalusPlando(BonusMalusActionPlando.RibbonCurseStun, "Ribbon Curse\n Stun ", mod: 0x10),
				new BonusMalusPlando(BonusMalusActionPlando.RibbonCurseSleep, "Ribbon Curse\n Sleep", mod: 0x20),
				new BonusMalusPlando(BonusMalusActionPlando.RibbonCurseMute, "Ribbon Curse\n Mute", mod: 0x40),
				//Promo Curse tier
				new BonusMalusPlando(BonusMalusActionPlando.ArmorReplaceNoPromoFi, "No Promo @A", mod: 99, equipment: equipFighterArmorFull),
				new BonusMalusPlando(BonusMalusActionPlando.ArmorAddRedMage, "Promo RW @A", mod: 99, equipment: equipRedWizardArmorFull),
				new BonusMalusPlando(BonusMalusActionPlando.NoPromoSpellsKi, "No Promo Sp", mod: 0, mod2: 0, binarylist: nullSpells),
				new BonusMalusPlando(BonusMalusActionPlando.NoPromoSpellsNi, "No Promo Sp", mod: 0, mod2: 0, binarylist: nullSpells),
				new BonusMalusPlando(BonusMalusActionPlando.UnarmmedAttackMa, "Promo\n Unarmed", mod: 99),
				//Armorcrafter tier
				new BonusMalusPlando(BonusMalusActionPlando.ArmorRemoveNoProRing, "-" + olditemnames[(int)Item.ProRing], equipment: new List<Item> { Item.ProRing }),
				//Add Single Spell code here
				//Lockpicking tier
				new BonusMalusPlando(BonusMalusActionPlando.LateLockpicking, "LateLockpik", mod: 10),

			});
		}


		public List<BonusMalusPlando> CreateSpellBonusesPlado(FF1Rom rom, MT19337 rng, Flags flags)
		{
			List<BonusMalusPlando> spellBlursings = new();

			SpellHelper spellHelper = new(rom);

			List<List<byte>> blackSpellListfast = new();
			List<List<byte>> blackSpellListtmpr = new();
			List<List<byte>> blackSpellListwarp = new();
			List<List<byte>> blackSpellListlock = new();
			List<List<byte>> blackSpellListlok2 = new();
			List<List<byte>> whiteSpellListlife = new();
			List<List<byte>> whiteSpellListinv2 = new();
			List<List<byte>> whiteSpellListcur3 = new();
			List<List<byte>> whiteSpellListhel2 = new();
			List<List<byte>> whiteSpellListexit = new();

			blackSpellListfast.Add(spellHelper.FindSpells(SpellRoutine.Fast, SpellTargeting.Any).Select(x => (byte)x.Id).ToList()); // Fast
			blackSpellListtmpr.Add(spellHelper.FindSpells(SpellRoutine.Sabr, SpellTargeting.OneCharacter).Select(x => (byte)x.Id).ToList()); // Tmpr
			blackSpellListwarp.Add(new List<byte> { (byte)(rom.Get(FF1Rom.MagicOutOfBattleOffset + FF1Rom.MagicOutOfBattleSize * 10, 1)[0]) }); // Warp
			blackSpellListlock.Add(spellHelper.FindSpells(SpellRoutine.Lock, SpellTargeting.OneCharacter).Select(x => (byte)x.Id).ToList()); // Lock
			blackSpellListlok2.Add(spellHelper.FindSpells(SpellRoutine.Lock, SpellTargeting.AllEnemies).Select(x => (byte)x.Id).ToList()); // Lok2

			whiteSpellListlife.Add(spellHelper.FindSpells(SpellRoutine.Life, SpellTargeting.OneCharacter).Select(x => (byte)x.Id).ToList()); // Life
			whiteSpellListinv2.Add(spellHelper.FindSpells(SpellRoutine.Ruse, SpellTargeting.AllCharacters).Where(s => s.Info.effect <= 50).Select(x => (byte)x.Id).ToList()); // Inv2
			whiteSpellListcur3.Add(spellHelper.FindSpells(SpellRoutine.Heal, SpellTargeting.OneCharacter).Where(s => s.Info.effect >= 70 && s.Info.effect <= 140).Select(x => (byte)x.Id).ToList()); //Cur3
			whiteSpellListhel2.Add(spellHelper.FindSpells(SpellRoutine.Heal, SpellTargeting.AllCharacters).Where(s => s.Info.effect >= 24 && s.Info.effect <= 40).Select(x => (byte)x.Id).ToList()); //Hel2
			whiteSpellListexit.Add(new List<byte> { (byte)(rom.Get(FF1Rom.MagicOutOfBattleOffset + FF1Rom.MagicOutOfBattleSize * 12, 1)[0]) }); // Exit

			foreach (var spell in blackSpellListfast)
			{
				if (spell.Any())
				{
					var test = SpellSlotStructure.GetSpellSlots();

					SpellSlotInfo spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == spell.PickRandom(rng));
					if (spellId != null)
					{		
						spellBlursings.Add(new BonusMalusPlando(BonusMalusActionPlando.AddSpellFast, "+" + rom.ItemsText[(int)spellId.NameId], spellsmod: new List<SpellSlotInfo> { spellId, new SpellSlotInfo(), new SpellSlotInfo() }));
					}
				}
			}

			foreach (var spell in blackSpellListtmpr)
			{
				if (spell.Any())
				{
					var test = SpellSlotStructure.GetSpellSlots();
					var pickedSpell = spell.PickRandom(rng);
					SpellSlotInfo spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == pickedSpell);
					if (spellId != null)
					{
						spellBlursings.Add(new BonusMalusPlando(BonusMalusActionPlando.AddSpellTmpr, "+" + rom.ItemsText[(int)spellId.NameId], spellsmod: new List<SpellSlotInfo> { spellId, new SpellSlotInfo(), new SpellSlotInfo() }));
					}
				}
			}

			foreach (var spell in blackSpellListwarp)
			{
				if (spell.Any())
				{
					var test = SpellSlotStructure.GetSpellSlots();
					var pickedSpell = spell.PickRandom(rng);
					SpellSlotInfo spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == pickedSpell);
					if (spellId != null)
					{
						spellBlursings.Add(new BonusMalusPlando(BonusMalusActionPlando.AddSpellWarp, "+" + rom.ItemsText[(int)spellId.NameId], spellsmod: new List<SpellSlotInfo> { spellId, new SpellSlotInfo(), new SpellSlotInfo() }));
					}
				}
			}

			foreach (var spell in blackSpellListlock)
			{
				if (spell.Any())
				{
					var test = SpellSlotStructure.GetSpellSlots();
					var pickedSpell = spell.PickRandom(rng);
					SpellSlotInfo spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == pickedSpell);
					if (spellId != null)
					{
						spellBlursings.Add(new BonusMalusPlando(BonusMalusActionPlando.AddSpellLock, "+" + rom.ItemsText[(int)spellId.NameId], spellsmod: new List<SpellSlotInfo> { spellId, new SpellSlotInfo(), new SpellSlotInfo() }));
					}
				}
			}

			foreach (var spell in blackSpellListlok2)
			{
				if (spell.Any())
				{
					var test = SpellSlotStructure.GetSpellSlots();
					var pickedSpell = spell.PickRandom(rng);
					SpellSlotInfo spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == pickedSpell);
					if (spellId != null)
					{
						spellBlursings.Add(new BonusMalusPlando(BonusMalusActionPlando.AddSpellLok2, "+" + rom.ItemsText[(int)spellId.NameId], spellsmod: new List<SpellSlotInfo> { spellId, new SpellSlotInfo(), new SpellSlotInfo() }));
					}
				}
			}

			foreach (var spell in whiteSpellListlife)
			{
				if (spell.Any())
				{
					var test = SpellSlotStructure.GetSpellSlots();
					var pickedSpell = spell.PickRandom(rng);
					SpellSlotInfo spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == pickedSpell);
					if (spellId != null)
					{
						spellBlursings.Add(new BonusMalusPlando(BonusMalusActionPlando.AddSpellLife, "+" + rom.ItemsText[(int)spellId.NameId], spellsmod: new List<SpellSlotInfo> { spellId, new SpellSlotInfo(), new SpellSlotInfo() }));
					}
				}
			}
			foreach (var spell in whiteSpellListinv2)
			{
				if (spell.Any())
				{
					var test = SpellSlotStructure.GetSpellSlots();
					var pickedSpell = spell.PickRandom(rng);
					SpellSlotInfo spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == pickedSpell);
					if (spellId != null)
					{
						spellBlursings.Add(new BonusMalusPlando(BonusMalusActionPlando.AddSpellInvs2, "+" + rom.ItemsText[(int)spellId.NameId], spellsmod: new List<SpellSlotInfo> { spellId, new SpellSlotInfo(), new SpellSlotInfo() }));
					}
				}
			}

			foreach (var spell in whiteSpellListcur3)
			{
				if (spell.Any())
				{
					var test = SpellSlotStructure.GetSpellSlots();
					var pickedSpell = spell.PickRandom(rng);
					SpellSlotInfo spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == pickedSpell);
					if (spellId != null)
					{
						spellBlursings.Add(new BonusMalusPlando(BonusMalusActionPlando.AddSpellCur3, "+" + rom.ItemsText[(int)spellId.NameId], spellsmod: new List<SpellSlotInfo> { spellId, new SpellSlotInfo(), new SpellSlotInfo() }));
					}
				}
			}

			foreach (var spell in whiteSpellListhel2)
			{
				if (spell.Any())
				{
					var test = SpellSlotStructure.GetSpellSlots();
					var pickedSpell = spell.PickRandom(rng);
					SpellSlotInfo spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == pickedSpell);
					if (spellId != null)
					{
						spellBlursings.Add(new BonusMalusPlando(BonusMalusActionPlando.AddSpellHel2, "+" + rom.ItemsText[(int)spellId.NameId], spellsmod: new List<SpellSlotInfo> { spellId, new SpellSlotInfo(), new SpellSlotInfo() }));
					}
				}
			}

			foreach (var spell in whiteSpellListexit)
			{
				if (spell.Any())
				{
					var test = SpellSlotStructure.GetSpellSlots();
					var pickedSpell = spell.PickRandom(rng);
					SpellSlotInfo spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == pickedSpell);
					if (spellId != null)
					{
						spellBlursings.Add(new BonusMalusPlando(BonusMalusActionPlando.AddSpellExit, "+" + rom.ItemsText[(int)spellId.NameId], spellsmod: new List<SpellSlotInfo> { spellId, new SpellSlotInfo(), new SpellSlotInfo() }));
					}
				}
			}



			return spellBlursings;
		}
		public List<BonusMalusPlando> CreateMagicBonusesPlando(FF1Rom rom, MT19337 rng, Flags flags)
		{
			List<BonusMalusPlando> spellBlursingsPlando = new();


			SpellHelper spellHelper = new(rom);

			SpellSlotInfo emptySlot = new();

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
					spellBlursingsPlando.Add(new BonusMalusPlando(BonusMalusActionPlando.InnateSpellsNuke, "Nuke Magic", spellsmod: new List<SpellSlotInfo> { spellId, spellId, emptySlot }));
				}
			}

			if (spellElem3.Count >= 2)
			{
				List<SpellSlotInfo> spells = new();

				while (spells.Count < 2 && spellElem3.Any())
				{
					var selectedSpell = spellElem3.SpliceRandom(rng);
					if (SpellSlotStructure.GetSpellSlots().TryFind(x => x.NameId == selectedSpell, out var spellId))
					{
						spells.Add(spellId);
					}
				}

				if (spells.Count >= 2)
				{
					spellBlursingsPlando.Add(new BonusMalusPlando(BonusMalusActionPlando.InnateSpellsElemPlus, "Elem+ Magic", spellsmod: new List<SpellSlotInfo> { spells[0], spells[1], emptySlot }));

				}
			}

			if (spellElem2.Count >= 2)
			{
				List<SpellSlotInfo> spells = new();

				while (spells.Count < 2 && spellElem2.Any())
				{
					var selectedSpell = spellElem2.SpliceRandom(rng);
					if (SpellSlotStructure.GetSpellSlots().TryFind(x => x.NameId == selectedSpell, out var spellId))
					{
						spells.Add(spellId);
					}
				}

				if (spells.Count >= 2)
				{
					spellBlursingsPlando.Add(new BonusMalusPlando(BonusMalusActionPlando.InnateSpellsElem, "Elem Magic", spellsmod: new List<SpellSlotInfo> { spells[0], spells[1], emptySlot }));
				}
			}

			if (spellCleaning.Count >= 2)
			{
				List<SpellSlotInfo> spells = new();

				while (spells.Count < 2 && spellCleaning.Any())
				{
					var selectedSpell = spellCleaning.SpliceRandom(rng);
					if (SpellSlotStructure.GetSpellSlots().TryFind(x => x.NameId == selectedSpell, out var spellId))
					{
						spells.Add(spellId);
					}
				}

				if (spells.Count >= 2)
				{
					spellBlursingsPlando.Add(new BonusMalusPlando(BonusMalusActionPlando.InnateSpellsClean, "Clean Magic", spellsmod: new List<SpellSlotInfo> { spells[0], spells[1], emptySlot }));
				}
			}

			if (spellDoom.Count >= 2)
			{
				List<SpellSlotInfo> spells = new();

				while (spells.Count < 2 && spellDoom.Any())
				{
					var selectedSpell = spellDoom.SpliceRandom(rng);
					if (SpellSlotStructure.GetSpellSlots().TryFind(x => x.NameId == selectedSpell, out var spellId))
					{
						spells.Add(spellId);
					}
				}

				if (spells.Count >= 2)
				{
					spellBlursingsPlando.Add(new BonusMalusPlando(BonusMalusActionPlando.InnateSpellsDoom, "Doom Magic", spellsmod: new List<SpellSlotInfo> { spells[0], spells[1], emptySlot }));
				}
			}

			if (spellCur3.Any() && spellHel2.Any() && spellLife.Any())
			{
				List<SpellSlotInfo> spells = new();
				SpellSlotInfo spellId = new();
				SpellSlotInfo lifespell;

				SpellSlotStructure.GetSpellSlots().TryFind(x => x.NameId == spellLife.PickRandom(rng), out lifespell);

				if (SpellSlotStructure.GetSpellSlots().TryFind(x => x.NameId == spellCur3.PickRandom(rng), out spellId))
				{
					spells.Add(spellId);
				}

				if (SpellSlotStructure.GetSpellSlots().TryFind(x => x.NameId == spellHel2.PickRandom(rng), out spellId))
				{
					spells.Add(spellId);
				}

				if (spells.Count >= 2 || (lifespell != null && spells.Count >= 1))
				{
					spells = new() { spells.SpliceRandom(rng), lifespell ?? spells.SpliceRandom(rng) };
					spells.Shuffle(rng);

					spellBlursingsPlando.Add(new BonusMalusPlando(BonusMalusActionPlando.InnateSpellsHeal, "Heal Magic", spellsmod: new List<SpellSlotInfo> { spells[0], spells[1], emptySlot }));
				}
			}

			if (spellCur4.Any() && spellHel3.Any() && spellLife.Any())
			{
				List<SpellSlotInfo> spells = new();
				SpellSlotInfo spellId = new();
				SpellSlotInfo lifespell;

				SpellSlotStructure.GetSpellSlots().TryFind(x => x.NameId == spellLife.PickRandom(rng), out lifespell);

				if (SpellSlotStructure.GetSpellSlots().TryFind(x => x.NameId == spellCur4.PickRandom(rng), out spellId))
				{
					spells.Add(spellId);
				}

				if (SpellSlotStructure.GetSpellSlots().TryFind(x => x.NameId == spellHel3.PickRandom(rng), out spellId))
				{
					spells.Add(spellId);
				}

				if (spells.Count >= 2 || (lifespell != null && spells.Count >= 1))
				{
					spells = new() { spells.SpliceRandom(rng), lifespell ?? spells.SpliceRandom(rng) };
					spells.Shuffle(rng);

					spellBlursingsPlando.Add(new BonusMalusPlando(BonusMalusActionPlando.InnateSpellsHealPlus, "Heal+ Magic", spellsmod: new List<SpellSlotInfo> { spells[0], spells[1], emptySlot }));
				}
			}

			if (spellRuse.Any() && spellSabr.Any())
			{
				List<SpellSlotInfo> spells = new();
				SpellSlotInfo spellId = new();

				if (SpellSlotStructure.GetSpellSlots().TryFind(x => x.NameId == spellRuse.PickRandom(rng), out spellId))
				{
					spells.Add(spellId);
				}

				if (SpellSlotStructure.GetSpellSlots().TryFind(x => x.NameId == spellSabr.PickRandom(rng), out spellId))
				{
					spells.Add(spellId);
				}

				if (spells.Count >= 2)
				{
					spellBlursingsPlando.Add(new BonusMalusPlando(BonusMalusActionPlando.InnateSpellsSelf, "Self Magic", spellsmod: new List<SpellSlotInfo> { spells[0], spells[1], emptySlot }));
				}
			}

			if (spellTmpr.Any() && spellFast.Any())
			{
				List<SpellSlotInfo> spells = new();
				SpellSlotInfo spellId = new();

				if (SpellSlotStructure.GetSpellSlots().TryFind(x => x.NameId == spellTmpr.PickRandom(rng), out spellId))
				{
					spells.Add(spellId);
				}

				if (SpellSlotStructure.GetSpellSlots().TryFind(x => x.NameId == spellFast.PickRandom(rng), out spellId))
				{
					spells.Add(spellId);
				}

				spells.Shuffle(rng);

				if (spells.Count >= 2)
				{
					spellBlursingsPlando.Add(new BonusMalusPlando(BonusMalusActionPlando.InnateSpellsBuff, "Buff Magic", spellsmod: new List<SpellSlotInfo> { spells[0], spells[1], emptySlot }));
				}
			}

			if (spellWarp.Any() && spellExit.Any())
			{
				List<SpellSlotInfo> spells = new();
				SpellSlotInfo spellId = new();

				if (SpellSlotStructure.GetSpellSlots().TryFind(x => x.NameId == spellWarp.PickRandom(rng), out spellId))
				{
					spells.Add(spellId);
				}

				if (SpellSlotStructure.GetSpellSlots().TryFind(x => x.NameId == spellExit.PickRandom(rng), out spellId))
				{
					spells.Add(spellId);
				}

				if (spells.Count == 2)
				{
					spellBlursingsPlando.Add(new BonusMalusPlando(BonusMalusActionPlando.InnateSpellsTele, "Tele Magic", spellsmod: new List<SpellSlotInfo> { spells[0], spells[1], emptySlot }));
				}
			}

			return (spellBlursingsPlando);
		}

		public List<BonusMalusPlando> CreateSpellMalusesPlando(FF1Rom rom, MT19337 rng, Flags flags)
		{

			List<BonusMalusPlando> spellBlursings = new();

			SpellHelper spellHelper = new(rom);

			List<List<byte>> spellListfast = new();
			List<List<byte>> spellListtmpr = new();
			List<List<byte>> spellListnuke = new();
			List<List<byte>> spellListfir3 = new();
			List<List<byte>> spellListice3 = new();
			List<List<byte>> spellListlit3 = new();
			List<List<byte>> spellListwarp = new();
			List<List<byte>> spellListlock = new();
			List<List<byte>> spellListlok2 = new();
			List<List<byte>> spellListlife = new();
			List<List<byte>> spellListivs2 = new();
			List<List<byte>> spellListfade = new();
			List<List<byte>> spellListexit = new();
			List<List<byte>> spellListcur3 = new();
			List<List<byte>> spellListhel3 = new();
			List<List<byte>> spellListwall = new();

			spellListfast.Add(spellHelper.FindSpells(SpellRoutine.Fast, SpellTargeting.Any).Select(x => (byte)x.Id).ToList()); // Fast
			spellListtmpr.Add(spellHelper.FindSpells(SpellRoutine.Sabr, SpellTargeting.OneCharacter).Select(x => (byte)x.Id).ToList()); // Tmpr
			spellListnuke.Add(spellHelper.FindSpells(SpellRoutine.Damage, SpellTargeting.AllEnemies, SpellElement.None).Where(s => s.Info.effect >= 100).Select(x => (byte)x.Id).ToList()); // Nuke
			spellListfir3.Add(spellHelper.FindSpells(SpellRoutine.Damage, SpellTargeting.AllEnemies).Where(s => s.Info.effect >= 50 && s.Info.elem == SpellElement.Fire).Select(x => (byte)x.Id).ToList()); // Fir3
			spellListice3.Add(spellHelper.FindSpells(SpellRoutine.Damage, SpellTargeting.AllEnemies).Where(s => s.Info.effect >= 50 && s.Info.elem == SpellElement.Ice).Select(x => (byte)x.Id).ToList()); //Ice3
			spellListlit3.Add(spellHelper.FindSpells(SpellRoutine.Damage, SpellTargeting.AllEnemies).Where(s => s.Info.effect >= 50 && s.Info.elem == SpellElement.Lightning).Select(x => (byte)x.Id).ToList()); //Lit3
			spellListwarp.Add(new List<byte> { (byte)(rom.Get(FF1Rom.MagicOutOfBattleOffset + (FF1Rom.MagicOutOfBattleSize * 10), 1)[0]) }); // Warp
			spellListlock.Add(spellHelper.FindSpells(SpellRoutine.Lock, SpellTargeting.OneEnemy).Select(x => (byte)x.Id).ToList()); // Lock
			spellListlok2.Add(spellHelper.FindSpells(SpellRoutine.Lock, SpellTargeting.AllEnemies).Select(x => (byte)x.Id).ToList()); // Lok2

			spellListlife.Add(spellHelper.FindSpells(SpellRoutine.Life, SpellTargeting.OneCharacter).Select(x => (byte)x.Id).ToList()); // Life
			spellListivs2.Add(spellHelper.FindSpells(SpellRoutine.Ruse, SpellTargeting.AllCharacters).Select(x => (byte)x.Id).ToList()); // Inv2
			spellListfade.Add(spellHelper.FindSpells(SpellRoutine.Damage, SpellTargeting.AllEnemies, SpellElement.None).Where(s => s.Info.effect > 70 && s.Info.effect < 100).Select(x => (byte)x.Id).ToList()); // Fade
			spellListexit.Add(new List<byte> { (byte)(rom.Get(FF1Rom.MagicOutOfBattleOffset + (FF1Rom.MagicOutOfBattleSize * 12), 1)[0]) }); // Exit
			spellListcur3.Add(spellHelper.FindSpells(SpellRoutine.Heal, SpellTargeting.OneCharacter).Where(s => s.Info.effect >= 70 && s.Info.effect <= 200).Select(x => (byte)x.Id).ToList()); // Cur3
			spellListhel3.Add(spellHelper.FindSpells(SpellRoutine.Heal, SpellTargeting.AllCharacters).Where(s => s.Info.effect >= 42 && s.Info.effect <= 100).Select(x => (byte)x.Id).ToList()); // Hel3
			spellListwall.Add(spellHelper.FindSpells(SpellRoutine.DefElement, SpellTargeting.Any).Where(s => s.Info.status == SpellStatus.Any).Select(x => (byte)x.Id).ToList()); // Wall

			foreach (var spell in spellListfast)
			{
				if (spell.Any())
				{
					List<Classes> validClasses = new();
					SpellSlotInfo spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == spell.PickRandom(rng));

					if (spellId == null)
					{
						continue;
					}

					if (validClasses.Any())
					{
						spellBlursings.Add(new BonusMalusPlando(BonusMalusActionPlando.RemoveSpellFast, "No " + rom.ItemsText[(int)spellId.NameId], spellslotmod: spellId, Classes: validClasses));
					}
				}
			}
			foreach (var spell in spellListtmpr)
			{
				if (spell.Any())
				{
					List<Classes> validClasses = new();
					SpellSlotInfo spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == spell.PickRandom(rng));

					if (spellId == null)
					{
						continue;
					}

					if (validClasses.Any())
					{
						spellBlursings.Add(new BonusMalusPlando(BonusMalusActionPlando.RemoveSpellTmpr, "No " + rom.ItemsText[(int)spellId.NameId], spellslotmod: spellId, Classes: validClasses));
					}
				}
			}

			foreach (var spell in spellListnuke)
			{
				if (spell.Any())
				{
					List<Classes> validClasses = new();
					SpellSlotInfo spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == spell.PickRandom(rng));

					if (spellId == null)
					{
						continue;
					}

					if (validClasses.Any())
					{
						spellBlursings.Add(new BonusMalusPlando(BonusMalusActionPlando.RemoveSpellNuke, "No " + rom.ItemsText[(int)spellId.NameId], spellslotmod: spellId, Classes: validClasses));
					}
				}
			}

			foreach (var spell in spellListfir3)
			{
				if (spell.Any())
				{
					List<Classes> validClasses = new();
					SpellSlotInfo spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == spell.PickRandom(rng));

					if (spellId == null)
					{
						continue;
					}

					if (validClasses.Any())
					{
						spellBlursings.Add(new BonusMalusPlando(BonusMalusActionPlando.RemoveSpellFir3, "No " + rom.ItemsText[(int)spellId.NameId], spellslotmod: spellId, Classes: validClasses));
					}
				}
			}

			foreach (var spell in spellListice3)
			{
				if (spell.Any())
				{
					List<Classes> validClasses = new();
					SpellSlotInfo spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == spell.PickRandom(rng));

					if (spellId == null)
					{
						continue;
					}

					if (validClasses.Any())
					{
						spellBlursings.Add(new BonusMalusPlando(BonusMalusActionPlando.RemoveSpellIce3, "No " + rom.ItemsText[(int)spellId.NameId], spellslotmod: spellId, Classes: validClasses));
					}
				}
			}

			foreach (var spell in spellListlit3)
			{
				if (spell.Any())
				{
					List<Classes> validClasses = new();
					SpellSlotInfo spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == spell.PickRandom(rng));

					if (spellId == null)
					{
						continue;
					}

					if (validClasses.Any())
					{
						spellBlursings.Add(new BonusMalusPlando(BonusMalusActionPlando.RemoveSpellLit3, "No " + rom.ItemsText[(int)spellId.NameId], spellslotmod: spellId, Classes: validClasses));
					}
				}
			}

			foreach (var spell in spellListwarp)
			{
				if (spell.Any())
				{
					List<Classes> validClasses = new();
					SpellSlotInfo spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == spell.PickRandom(rng));

					if (spellId == null)
					{
						continue;
					}

					if (validClasses.Any())
					{
						spellBlursings.Add(new BonusMalusPlando(BonusMalusActionPlando.RemoveSpellWarp, "No " + rom.ItemsText[(int)spellId.NameId], spellslotmod: spellId, Classes: validClasses));
					}
				}
			}

			foreach (var spell in spellListlock)
			{
				if (spell.Any())
				{
					List<Classes> validClasses = new();
					SpellSlotInfo spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == spell.PickRandom(rng));

					if (spellId == null)
					{
						continue;
					}

					if (validClasses.Any())
					{
						spellBlursings.Add(new BonusMalusPlando(BonusMalusActionPlando.RemoveSpellLock, "No " + rom.ItemsText[(int)spellId.NameId], spellslotmod: spellId, Classes: validClasses));
					}
				}
			}

			foreach (var spell in spellListlok2)
			{
				if (spell.Any())
				{
					List<Classes> validClasses = new();
					SpellSlotInfo spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == spell.PickRandom(rng));

					if (spellId == null)
					{
						continue;
					}

					if (validClasses.Any())
					{
						spellBlursings.Add(new BonusMalusPlando(BonusMalusActionPlando.RemoveSpellLok2, "No " + rom.ItemsText[(int)spellId.NameId], spellslotmod: spellId, Classes: validClasses));
					}
				}
			}

			foreach (var spell in spellListlife)
			{
				if (spell.Any())
				{
					List<Classes> validClasses = new();
					SpellSlotInfo spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == spell.PickRandom(rng));

					if (spellId == null)
					{
						continue;
					}

					if (validClasses.Any())
					{
						spellBlursings.Add(new BonusMalusPlando(BonusMalusActionPlando.RemoveSpellLife, "No " + rom.ItemsText[(int)spellId.NameId], spellslotmod: spellId, Classes: validClasses));
					}
				}
			}

			foreach (var spell in spellListivs2)
			{
				if (spell.Any())
				{
					List<Classes> validClasses = new();
					SpellSlotInfo spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == spell.PickRandom(rng));

					if (spellId == null)
					{
						continue;
					}

					if (validClasses.Any())
					{
						spellBlursings.Add(new BonusMalusPlando(BonusMalusActionPlando.RemoveSpellInv2, "No " + rom.ItemsText[(int)spellId.NameId], spellslotmod: spellId, Classes: validClasses));
					}
				}
			}

			foreach (var spell in spellListfade)
			{
				if (spell.Any())
				{
					List<Classes> validClasses = new();
					SpellSlotInfo spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == spell.PickRandom(rng));

					if (spellId == null)
					{
						continue;
					}

					if (validClasses.Any())
					{
						spellBlursings.Add(new BonusMalusPlando(BonusMalusActionPlando.RemoveSpellFade, "No " + rom.ItemsText[(int)spellId.NameId], spellslotmod: spellId, Classes: validClasses));
					}
				}
			}

			foreach (var spell in spellListexit)
			{
				if (spell.Any())
				{
					List<Classes> validClasses = new();
					SpellSlotInfo spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == spell.PickRandom(rng));

					if (spellId == null)
					{
						continue;
					}

					if (validClasses.Any())
					{
						spellBlursings.Add(new BonusMalusPlando(BonusMalusActionPlando.RemoveSpellExit, "No " + rom.ItemsText[(int)spellId.NameId], spellslotmod: spellId, Classes: validClasses));
					}
				}
			}

			foreach (var spell in spellListcur3)
			{
				if (spell.Any())
				{
					List<Classes> validClasses = new();
					SpellSlotInfo spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == spell.PickRandom(rng));

					if (spellId == null)
					{
						continue;
					}

					if (validClasses.Any())
					{
						spellBlursings.Add(new BonusMalusPlando(BonusMalusActionPlando.RemoveSpellCur3, "No " + rom.ItemsText[(int)spellId.NameId], spellslotmod: spellId, Classes: validClasses));
					}
				}
			}

			foreach (var spell in spellListhel3)
			{
				if (spell.Any())
				{
					List<Classes> validClasses = new();
					SpellSlotInfo spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == spell.PickRandom(rng));

					if (spellId == null)
					{
						continue;
					}

					if (validClasses.Any())
					{
						spellBlursings.Add(new BonusMalusPlando(BonusMalusActionPlando.RemoveSpellHel3, "No " + rom.ItemsText[(int)spellId.NameId], spellslotmod: spellId, Classes: validClasses));
					}
				}
			}

			foreach (var spell in spellListwall)
			{
				if (spell.Any())
				{
					List<Classes> validClasses = new();
					SpellSlotInfo spellId = SpellSlotStructure.GetSpellSlots().Find(x => x.NameId == spell.PickRandom(rng));

					if (spellId == null)
					{
						continue;
					}

					if (validClasses.Any())
					{
						spellBlursings.Add(new BonusMalusPlando(BonusMalusActionPlando.RemoveSpellWall, "No " + rom.ItemsText[(int)spellId.NameId], spellslotmod: spellId, Classes: validClasses));
					}
				}
			}


			return spellBlursings;
		}




		private void BuildSpellIdDictPlando(FF1Rom rom)
		{
			SpellHelper spellHelper = new(rom);
			List<(Spell spell, byte id)> spellsFound = new();

			// Lamp
			var lampCandidates = spellHelper.FindSpells(SpellRoutine.CureAilment, SpellTargeting.Any).Where(s => (s.Info.effect & 0x08) > 0).Select(x => (byte)x.Id).ToList();
			spellsFound.Add((Spell.LAMP, lampCandidates.Any() ? (byte)(lampCandidates.First() - 0xB0 + 1) : (byte)0xFF));

			// A-Spells
			var aSpellsCandidates = spellHelper.FindSpells(SpellRoutine.DefElement, SpellTargeting.AllCharacters).ToList();
			spellsFound.Add((Spell.AFIR, aSpellsCandidates.TryFind(s => (s.Info.effect & 0x10) > 0, out var afirespell) ? (byte)(afirespell.Id - 0xB0 + 1) : (byte)0xFF));
			spellsFound.Add((Spell.AICE, aSpellsCandidates.TryFind(s => (s.Info.effect & 0x20) > 0, out var aicespell) ? (byte)(aicespell.Id - 0xB0 + 1) : (byte)0xFF));
			spellsFound.Add((Spell.ALIT, aSpellsCandidates.TryFind(s => (s.Info.effect & 0x40) > 0, out var alitspell) ? (byte)(alitspell.Id - 0xB0 + 1) : (byte)0xFF));
			spellsFound.Add((Spell.ARUB, aSpellsCandidates.TryFind(s => (s.Info.effect & 0x80) > 0, out var arubspell) ? (byte)(arubspell.Id - 0xB0 + 1) : (byte)0xFF));

			var aMuteCandidates = spellHelper.FindSpells(SpellRoutine.CureAilment, SpellTargeting.Any).Where(s => (s.Info.effect & 0x40) > 0).Select(x => (byte)x.Id).ToList();
			spellsFound.Add((Spell.AMUT, aMuteCandidates.Any() ? (byte)(aMuteCandidates.First() - 0xB0 + 1) : (byte)0xFF));

			// Dark
			var darkCandidates = spellHelper.FindSpells(SpellRoutine.InflictStatus, SpellTargeting.Any).ToList();
			spellsFound.Add((Spell.DARK, darkCandidates.TryFind(s => (s.Info.effect & 0x08) > 0, out var darkspell) ? (byte)(darkspell.Id - 0xB0 + 1) : (byte)0xFF));

			// Sleeps
			var sleepCandidates = spellHelper.FindSpells(SpellRoutine.InflictStatus, SpellTargeting.Any).ToList();
			spellsFound.Add((Spell.SLEP, darkCandidates.TryFind(s => (s.Info.effect & 0x20) > 0 && s.Info.targeting == SpellTargeting.AllEnemies, out var slepspell) ? (byte)(slepspell.Id - 0xB0 + 1) : (byte)0xFF));
			spellsFound.Add((Spell.SLP2, darkCandidates.TryFind(s => (s.Info.effect & 0x20) > 0 && s.Info.targeting == SpellTargeting.OneEnemy, out var slp2spell) ? (byte)(slp2spell.Id - 0xB0 + 1) : (byte)0xFF));

			// Slows
			var slowCandidates = spellHelper.FindSpells(SpellRoutine.Slow, SpellTargeting.Any).ToList();
			spellsFound.Add((Spell.SLOW, slowCandidates.TryFind(s => s.Info.targeting == SpellTargeting.AllEnemies, out var slowspell) ? (byte)(slowspell.Id - 0xB0 + 1) : (byte)0xFF));
			spellsFound.Add((Spell.SLO2, slowCandidates.TryFind(s => s.Info.targeting == SpellTargeting.OneEnemy, out var slo2spell) ? (byte)(slo2spell.Id - 0xB0 + 1) : (byte)0xFF));
		}

			private List<BonusMalusPlando> CreateSpellLearningBlessingsPlando(FF1Rom rom)
			{
				BuildSpellIdDict(rom);

				List<BonusMalusPlando> bonusListLearn = new();
			bonusListLearn.Add(new BonusMalusPlando(BonusMalusActionPlando.LearnLampRibbon, "Learn LAMP\n Resist All"));
			bonusListLearn.Add(new BonusMalusPlando(BonusMalusActionPlando.LearnDarkEvade, "Learn DARK\n +Evade"));
			bonusListLearn.Add(new BonusMalusPlando(BonusMalusActionPlando.LearnSleepMDef, "Learn SLEEP\n +MDef"));
			bonusListLearn.Add(new BonusMalusPlando(BonusMalusActionPlando.LearnSlowAbsorb, "Learn SLOW\n +Absorb"));
			bonusListLearn.Add(new BonusMalusPlando(BonusMalusActionPlando.LearnAspellAuto, "A-Spells\n Autocast"));
				
			
				return bonusListLearn;

			}
		
	}
}

