using System.ComponentModel;
using FF1Lib.Helpers;
using RomUtilities;

namespace FF1Lib
{

	public class GameClassesLeague
	{
		private List<ClassData> _classes;
		private GearPermissions _weaponPermissions;
		private GearPermissions _armorPermissions;
		private SpellPermissions _spellPermissions;

		const int lut_LvlUpHitRateBonus = 0x6CA59;
		const int lut_LvlUpMagDefBonus = 0x6CA65;
		const int lut_InnateResist = 0x6D400;
		const int lut_MaxMP = 0x6C902;
		const int lut_MpGainOnMaxMpGainClasses = 0x6D830;
		const int NewLevelUpDataOffset = 0x6CDA9;
		const int old_lut_LvlUpHitRateBonus = 0x2CA59;
		const int old_lut_LvlUpMagDefBonus = 0x2CA65;
		const int old_lut_InnateResist = 0x2D400;
		const int old_lut_MaxMP = 0x2C902;
		const int old_lut_MpGainOnMaxMpGainClasses = 0x2D830;
		const int old_NewLevelUpDataOffset = 0x2CDA9;
		const int StartingStatsOffset = 0x3040;


		public enum BonusMalusAction
		{
			None = 0,
			StrMod = 1,
			AgiMod = 2,
			IntMod = 3,
			VitMod = 4,
			LckMod = 5,
			HpMod = 6,
			HitMod = 7,
			MDefMod = 8,
			StrGrowth = 9,
			AgiGrowth = 10,
			IntGrowth = 11,
			VitGrowth = 12,
			LckGrowth = 13,
			HpGrowth = 14,
			HitGrowth = 15,
			MDefGrowth = 16,
			SpcMod = 17,
			SpcGrowth = 18,
			WeaponAdd = 19,
			WeaponRemove = 20,
			WeaponReplace = 21,
			ArmorAdd = 22,
			ArmorRemove = 23,
			ArmorReplace = 24,
			WhiteSpellcaster = 25,
			BlackSpellcaster = 27,
			SpcMax = 29,
			PowerRW = 30,
			NoPromoMagic = 31,
			LockpickingLevel = 32,
			InnateResist = 33,
			BonusXp = 34,
			MpGainOnMaxMpGain = 35,
			StartWithSpell,
			CantLearnSpell,
			StartWithGold,
			StartWithMp,
			UnarmedAttack,
			CatClawMaster,
			ThorMaster,
			SteelLord,
			WoodAdept,
			Hunter,
			Sleepy,
			Sick,
			StartWithKI,
			InnateSpells
		}
		public class BonusMalus
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
			public BonusMalus(BonusMalusAction action, string description, int mod = 0, int mod2 = 0, List<Item> equipment = null, List<bool> binarylist = null, List<SpellSlots> spelllist = null, List<byte> bytelist = null, SpellSlotInfo spellslotmod = null, List<SpellSlotInfo> spellsmod = null, List<Classes> Classes = null)
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
	}
}
