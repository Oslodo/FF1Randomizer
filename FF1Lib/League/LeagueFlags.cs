using System.Numerics;
using System.Reflection;
using Newtonsoft.Json;
using System.IO.Compression;
using static FF1Lib.FF1Rom;
using FF1Lib.Sanity;
using System.Diagnostics.SymbolStore;

namespace FF1Lib
{
	public class LeagueFlags

		{

#region League
	#region LeagueBonus
		#region FighterBonus
			public bool FiAdd10Str { get; set; } = false;
			public bool FiAdd20Str { get; set; } = false;
			public bool FiAdd15Agi { get; set; } = false;
			public bool FiAdd20Agi { get; set; } = false;
			public bool FiAdd25Agi { get; set; } = false;
			public bool FiAdd10Vit { get; set; } = false;
			public bool FiAdd20Vit { get; set; } = false;
			public bool FiAdd5Luck { get; set; } = false;
			public bool FiAdd10Luck { get; set; } = false;
			public bool FiAdd20HP { get; set; } = false;
			public bool FiAdd40HP { get; set; } = false;
			public bool FiAdd10PerHit { get; set; } = false;
			public bool FiAdd20PerHit { get; set; } = false;
			public bool FiEquipShirt { get; set; } = false;
			public bool FiLegSwords { get; set; } = false;
			public bool FiWoodArmor { get; set; } = false;
			public bool FiTelemagic { get; set; } = false;
			public bool FiBuffmagic { get; set; } = false;
			public bool FiSelfmagic { get; set; } = false;
			public bool FiHealmagic {  get; set; } = false;
			public bool FiHealplusmagic { get; set; } = false;
			public bool FiElemmagic { get; set; } = false;
			public bool FiElemplusmagic { get; set; } = false; 
			public bool FiCleanmagic { get; set; } = false;
			public bool FiImpCatclaw { get; set; } = false;
			public bool FiImpThor { get; set; } = false;
			public bool FiHurtundead { get; set; } = false;
			public bool FiHurtdragon { get; set; } = false;
			public bool FiHurtall { get; set; } = false;
			public bool FiXP50percent { get; set; } = false;
			public bool FiResistPosion { get; set; } = false;
			public bool FiResistEarth { get; set; } = false;
			public bool FiResistDeath { get; set; } = false;
			public bool FiResistTime { get; set; } = false;
			public bool FiResistStatus { get; set; } = false;
			public bool FiResistIce { get; set; } = false;
			public bool FiResistLit { get; set; } = false;
			public bool FiResistFire { get; set; } = false;
			public bool FiStartgold200 { get; set; } = false;
			public bool FiStartgold400 { get; set; } = false;
			public bool FiStartgold600 { get; set; } = false;
			public bool FiStartgold800 { get; set; } = false;
			public bool FiStartgold1500 { get; set; } = false;
			public bool FiStartgold5000 { get; set; } = false;
			public bool FiStartgold20000 { get; set; } = false;
			public bool FiAdd40Str { get; set; } = false;
			public bool FiAdd50Agi { get; set; } = false;
			public bool FiAdd40Vit { get; set; } = false;
			public bool FiAdd15Luck { get; set; } = false;
			public bool FiAdd80HP { get; set; } = false;
			public bool FiMdef2lvl { get; set; } = false;
			public bool FiSteelfast { get; set; } = false;
			public bool Fi50XPFiBB { get; set; } = false;
		#endregion
		#region ThiefBonus
			public bool ThAdd10Str { get; set; } = false;
			public bool ThAdd20Str { get; set; } = false;
			public bool ThAdd15Agi { get; set; } = false;
			public bool ThAdd20Agi { get; set; } = false;
			public bool ThAdd25Agi { get; set; } = false;
			public bool ThAdd10Vit { get; set; } = false;
			public bool ThAdd20Vit { get; set; } = false;
			public bool ThAdd5Luck { get; set; } = false;
			public bool ThAdd10Luck { get; set; } = false;
			public bool ThAdd20HP { get; set; } = false;
			public bool ThAdd40HP { get; set; } = false;
			public bool ThAdd10PerHit { get; set; } = false;
			public bool ThAdd20PerHit { get; set; } = false;
			public bool ThEquipAxe { get; set; } = false;
			public bool ThEquipShirt { get; set; } = false;
			public bool ThEquipShields { get; set; } = false;
			public bool ThEquipBonkHelm { get; set; } = false;
			public bool ThRMArmor { get; set; } = false;
			public bool ThLegSwords { get; set; } = false;
			public bool ThWoodArmor { get; set; } = false;
			public bool ThTelemagic { get; set; } = false;
			public bool ThBuffmagic { get; set; } = false;
			public bool ThSelfmagic { get; set; } = false;
			public bool ThHealmagic { get; set; } = false;
			public bool ThHealplusmagic { get; set; } = false;
			public bool ThElemmagic { get; set; } = false;
			public bool ThElemplusmagic { get; set; } = false;
			public bool ThCleanmagic { get; set; } = false;
			public bool ThImpCatclaw { get; set; } = false;
			public bool ThImpThor { get; set; } = false;
			public bool ThHurtundead { get; set; } = false;
			public bool ThHurtdragon { get; set; } = false;
			public bool ThHurtall { get; set; } = false;
			public bool ThXP50percent { get; set; } = false;
			public bool ThEarlylockpick { get; set; } = false;
			public bool ThResistPosion { get; set; } = false;
			public bool ThResistEarth { get; set; } = false;
			public bool ThResistDeath { get; set; } = false;
			public bool ThResistTime { get; set; } = false;
			public bool ThResistStatus { get; set; } = false;
			public bool ThResistIce { get; set; } = false;
			public bool ThResistLit { get; set; } = false;
			public bool ThResistFire { get; set; } = false;
			public bool ThStartgold200 { get; set; } = false;
			public bool ThStartgold400 { get; set; } = false;
			public bool ThStartgold600 { get; set; } = false;
			public bool ThStartgold800 { get; set; } = false;
			public bool ThStartgold1500 { get; set; } = false;
			public bool ThStartgold5000 { get; set; } = false;
			public bool ThStartgold20000 { get; set; } = false;
			public bool ThAdd40Str { get; set; } = false;
			public bool ThAdd50Agi { get; set; } = false;
			public bool ThAdd40Vit { get; set; } = false;
			public bool ThAdd80HP { get; set; } = false;
			public bool ThMdef2lvl { get; set; } = false;
			public bool ThFiWeapons { get; set; } = false;
			public bool ThFiArmor { get; set; } = false;
			public bool ThXP100Percent { get; set; } = false;

		#endregion
		#region BlackBeltBonus
			public bool BBAdd10Str { get; set; } = false;
			public bool BBAdd20Str { get; set; } = false;
			public bool BBAdd15Agi { get; set; } = false;
			public bool BBAdd20Agi { get; set; } = false;
			public bool BBAdd25Agi { get; set; } = false;
			public bool BBAdd10Vit { get; set; } = false;
			public bool BBAdd20Vit { get; set; } = false;
			public bool BBAdd5Luck { get; set; } = false;
			public bool BBAdd10Luck { get; set; } = false;
			public bool BBAdd20HP { get; set; } = false;
			public bool BBAdd40HP { get; set; } = false;
			public bool BBAdd10PerHit { get; set; } = false;
			public bool BBAdd20PerHit { get; set; } = false;
			public bool BBEquipAxe { get; set; } = false;
			public bool BBEquipShirt { get; set; } = false;
			public bool BBEquipShields { get; set; } = false;
			public bool BBEquipBonkHelm { get; set; } = false;
			public bool BBThiefWeaponsBonus { get; set; } = false;
			public bool BBRMArmor { get; set; } = false;
			public bool BBLegSwords { get; set; } = false;
			public bool BBWoodArmor { get; set; } = false;
			public bool BBTelemagic { get; set; } = false;
			public bool BBBuffmagic { get; set; } = false;
			public bool BBSelfmagic { get; set; } = false;
			public bool BBHealmagic { get; set; } = false;
			public bool BBHealplusmagic { get; set; } = false;
			public bool BBElemmagic { get; set; } = false;
			public bool BBElemplusmagic { get; set; } = false;
			public bool BBCleanmagic { get; set; } = false;
			public bool BBHurtundead { get; set; } = false;
			public bool BBHurtdragon { get; set; } = false;
			public bool BBHurtall { get; set; } = false;
			public bool BBPromoFiweapons { get; set; } = false;
			public bool BBPromoFiarmor { get; set; } = false;
			public bool BBResistPosion { get; set; } = false;
			public bool BBResistEarth { get; set; } = false;
			public bool BBResistDeath { get; set; } = false;
			public bool BBResistTime { get; set; } = false;
			public bool BBResistStatus { get; set; } = false;
			public bool BBResistIce { get; set; } = false;
			public bool BBResistLit { get; set; } = false;
			public bool BBResistFire { get; set; } = false;
			public bool BBStartgold200 { get; set; } = false;
			public bool BBStartgold400 { get; set; } = false;
			public bool BBStartgold600 { get; set; } = false;
			public bool BBStartgold800 { get; set; } = false;
			public bool BBStartgold1500 { get; set; } = false;
			public bool BBStartgold5000 { get; set; } = false;
			public bool BBStartgold20000 { get; set; } = false;
			public bool BBAdd40Str { get; set; } = false;
			public bool BBAdd50Agi { get; set; } = false;
			public bool BBAdd40Vit { get; set; } = false;
			public bool BBAdd15Luck { get; set; } = false;
			public bool BBAdd80HP { get; set; } = false;
			public bool BBFiWeapons { get; set; } = false;
			public bool BBFiArmor { get; set; } = false;
			public bool BB50XPFiBB { get; set; } = false;
		#endregion
		#region RMBonus
			public bool RmAdd10Str { get; set; } = false;
			public bool RmAdd20Str { get; set; } = false;
			public bool RmAdd15Agi { get; set; } = false;
			public bool RmAdd20Agi { get; set; } = false;
			public bool RmAdd25Agi { get; set; } = false;
			public bool RmAdd10Vit { get; set; } = false;
			public bool RmAdd20Vit { get; set; } = false;
			public bool RmAdd5Luck { get; set; } = false;
			public bool RmAdd10Luck { get; set; } = false;
			public bool RmAdd20HP { get; set; } = false;
			public bool RmAdd40HP { get; set; } = false;
			public bool RmAdd10PerHit { get; set; } = false;
			public bool RmAdd20PerHit { get; set; } = false;
			public bool RmEquipAxe { get; set; } = false;
			public bool RMEquipShirt { get; set; } = false;
			public bool RmEquipShields { get; set; } = false;
			public bool RmEquipBonkHelm { get; set; } = false;
			public bool RmLegSwords { get; set; } = false;
			public bool RmWoodArmor { get; set; } = false;
			public bool RmLvl1MP2 { get; set; } = false;
			public bool RmMP1All { get; set; } = false;
			public bool RmAddSpell { get; set; } = false; // will need extra work to get the spell list
			public bool RmTelemagic { get; set; } = false;
			public bool RmBuffmagic { get; set; } = false;
			public bool RmSelfmagic { get; set; } = false;
			public bool RmHealmagic { get; set; } = false;
			public bool RmHealplusmagic { get; set; } = false;
			public bool RmElemmagic { get; set; } = false;
			public bool RmElemplusmagic { get; set; } = false;
			public bool RmNukemagic { get; set; } = false;
			public bool RmDoommagic { get; set; } = false;
			public bool RmCleanmagic { get; set; } = false;
			public bool RmHurtundead { get; set; } = false;
			public bool RmHurtdragon { get; set; } = false;
			public bool RmHurtall { get; set; } = false;
			public bool RmPromoFiweapons { get; set; } = false;
			public bool RmPromoFiArmor { get; set; } = false;
			public bool RmPromoSage { get; set; } = false;
			public bool RmXP50percent { get; set; } = false;
			public bool RmResistPosion { get; set; } = false;
			public bool RmResistEarth { get; set; } = false;
			public bool RmResistDeath { get; set; } = false;
			public bool RmResistTime { get; set; } = false;
			public bool RmResistStatus { get; set; } = false;
			public bool RmResistIce { get; set; } = false;
			public bool RmResistLit { get; set; } = false;
			public bool RmResistFire { get; set; } = false;
			public bool RmStartgold200 { get; set; } = false;
			public bool RmStartgold400 { get; set; } = false;
			public bool RmStartgold600 { get; set; } = false;
			public bool RmStartgold800 { get; set; } = false;
			public bool RmStartgold1500 { get; set; } = false;
			public bool RmStartgold5000 { get; set; } = false;
			public bool RmStartgold20000 { get; set; } = false;
			public bool RmAdd40Str { get; set; } = false;
			public bool RmAdd50Agi { get; set; } = false;
			public bool RmAdd40Vit { get; set; } = false;
			public bool RmAdd15Luck { get; set; } = false;
			public bool RmAdd80HP { get; set; } = false;
			public bool RmMdef2lvl { get; set; } = false;
			public bool RmFiWeapons { get; set; } = false;
			public bool RmFiArmor { get; set; } = false;
			public bool RmImprovedMP { get; set; } = false;
			public bool RmSage { get; set; } = false;
			public bool RmXP100Percent { get; set; } = false;

		#endregion
		#region WmBonus
			public bool WmAdd10Str { get; set; } = false;
			public bool WmAdd20Str { get; set; } = false;
			public bool WmAdd15Agi { get; set; } = false;
			public bool WmAdd20Agi { get; set; } = false;
			public bool WmAdd25Agi { get; set; } = false;
			public bool WmAdd10Vit { get; set; } = false;
			public bool WmAdd20Vit { get; set; } = false;
			public bool WmAdd5Luck { get; set; } = false;
			public bool WmAdd10Luck { get; set; } = false;
			public bool WmAdd20HP { get; set; } = false;
			public bool WmAdd40HP { get; set; } = false;
			public bool WmAdd10PerHit { get; set; } = false;
			public bool WmAdd20PerHit { get; set; } = false;
			public bool WmEquipAxe { get; set; } = false;
			public bool WmEquipShirt { get; set; } = false;
			public bool WmEquipShields { get; set; } = false;
			public bool WmEquipBonkHelm { get; set; } = false;
			public bool WmThiefWeaponsBonus { get; set; } = false;
			public bool WmRMArmor { get; set; } = false;
			public bool WmLegSwords { get; set; } = false;
			public bool WmWoodArmor { get; set; } = false;
			public bool WmLvl1MP2 { get; set; } = false;
			public bool WmMP1All { get; set; } = false;
			public bool WmAddSpell { get; set; } = false; // will need extra work to get the spell list
			public bool WmTelemagic { get; set; } = false;
			public bool WmBuffmagic { get; set; } = false;
			public bool WmSelfmagic { get; set; } = false;
			public bool WmHealmagic { get; set; } = false;
			public bool WmHealplusmagic { get; set; } = false;
			public bool WmElemmagic { get; set; } = false;
			public bool WmElemplusmagic { get; set; } = false;
			public bool WmNukemagic { get; set; } = false;
			public bool WmDoommagic { get; set; } = false;
			public bool WmCleanmagic { get; set; } = false;
			public bool WmImpThor { get; set; } = false;
			public bool WmHurtundead { get; set; } = false;
			public bool WmHurtdragon { get; set; } = false;
			public bool WmHurtall { get; set; } = false;
			public bool WmPromoFiweapons { get; set; } = false;
			public bool WmPromoFiArmor { get; set; } = false;
			public bool WmXP50percent { get; set; } = false;
			public bool WmResistPosion { get; set; } = false;
			public bool WmResistEarth { get; set; } = false;
			public bool WmResistDeath { get; set; } = false;
			public bool WmResistTime { get; set; } = false;
			public bool WmResistStatus { get; set; } = false;
			public bool WmResistIce { get; set; } = false;
			public bool WmResistLit { get; set; } = false;
			public bool WmResistFire { get; set; } = false;
			public bool WmStartgold200 { get; set; } = false;
			public bool WmStartgold400 { get; set; } = false;
			public bool WmStartgold600 { get; set; } = false;
			public bool WmStartgold800 { get; set; } = false;
			public bool WmStartgold1500 { get; set; } = false;
			public bool WmStartgold5000 { get; set; } = false;
			public bool WmStartgold20000 { get; set; } = false;
			public bool WmAdd40Str { get; set; } = false;
			public bool WmAdd50Agi { get; set; } = false;
			public bool WmAdd40Vit { get; set; } = false;
			public bool WmAdd15Luck { get; set; } = false;
			public bool WmAdd80HP { get; set; } = false;
			public bool WmMdef2lvl { get; set; } = false;
			public bool WmFiWeapons { get; set; } = false;
			public bool WmFiArmor { get; set; } = false;
			public bool WmImprovedMP { get; set; } = false;
			public bool WmXP100Percent { get; set; } = false;
		#endregion
		#region BmBonus
			public bool BmAdd10Str { get; set; } = false;
			public bool BmAdd20Str { get; set; } = false;
			public bool BmAdd15Agi { get; set; } = false;
			public bool BmAdd20Agi { get; set; } = false;
			public bool BmAdd25Agi { get; set; } = false;
			public bool BmAdd10Vit { get; set; } = false;
			public bool BmAdd20Vit { get; set; } = false;
			public bool BmAdd5Luck { get; set; } = false;
			public bool BmAdd10Luck { get; set; } = false;
			public bool BmAdd20HP { get; set; } = false;
			public bool BMAdd40HP { get; set; } = false;
			public bool BmAdd10PerHit { get; set; } = false;
			public bool BmAdd20PerHit { get; set; } = false;
			public bool BmEquipAxe { get; set; } = false;
			public bool BmEquipShirt { get; set; } = false;
			public bool BmEquipShields { get; set; } = false;
			public bool BmEquipBonkHelm { get; set; } = false;
			public bool BmThiefWeaponsBonus { get; set; } = false;
			public bool BmRMArmor { get; set; } = false;
			public bool BmLegSwords { get; set; } = false;
			public bool BmWoodArmor { get; set; } = false;
			public bool BmLvl1MP2 { get; set; } = false;
			public bool BmMP1All { get; set; } = false;
			public bool BmAddSpell { get; set; } = false; // will need extra work to get the spell list
			public bool BmTelemagic { get; set; } = false;
			public bool BmBuffmagic { get; set; } = false;
			public bool BmSelfmagic { get; set; } = false;
			public bool BmHealmagic { get; set; } = false;
			public bool BmHealplusmagic { get; set; } = false;
			public bool BmElemmagic { get; set; } = false;
			public bool BmElemplusmagic { get; set; } = false;
			public bool BmNukemagic { get; set; } = false;
			public bool BmDoommagic { get; set; } = false;
			public bool BmCleanmagic { get; set; } = false;
			public bool BmImpCatclaw { get; set; } = false;
			public bool BmHurtundead { get; set; } = false;
			public bool BmHurtdragon { get; set; } = false;
			public bool BmHurtall { get; set; } = false;
			public bool BmPromoFiweapons { get; set; } = false;
			public bool BmPromoFiArmor { get; set; } = false;
			public bool BmXP50percent { get; set; } = false;
			public bool BmResistPosion { get; set; } = false;
			public bool BmResistEarth { get; set; } = false;
			public bool BmResistDeath { get; set; } = false;
			public bool BmResistTime { get; set; } = false;
			public bool BmResistStatus { get; set; } = false;
			public bool BmResistIce { get; set; } = false;
			public bool BmResistLit { get; set; } = false;
			public bool BmResistFire { get; set; } = false;
			public bool BmStartgold200 { get; set; } = false;
			public bool BmStartgold400 { get; set; } = false;
			public bool BmStartgold600 { get; set; } = false;
			public bool BmStartgold800 { get; set; } = false;
			public bool BmStartgold1500 { get; set; } = false;
			public bool BmStartgold5000 { get; set; } = false;
			public bool BmStartgold20000 { get; set; } = false;
			public bool BmAdd40Str { get; set; } = false;
			public bool BmAdd50Agi { get; set; } = false;
			public bool BmAdd40Vit { get; set; } = false;
			public bool BmAdd15Luck { get; set; } = false;
			public bool BmAdd80HP { get; set; } = false;
			public bool BmMdef2lvl { get; set; } = false;
			public bool BmFiWeapons { get; set; } = false;
			public bool BmFiArmor { get; set; } = false;
			public bool BmImprovedMP { get; set; } = false;
			public bool BmXP100Percent { get; set; } = false;
		#endregion
		#endregion
		#region LeagueMalus
		#region FighterMalus
		public bool FiDown10Str { get; set; } = false;
			public bool FiDown20Str { get; set; } = false;
			public bool FiDown10Agi { get; set; } = false;
			public bool FiDown10Vit { get; set; } = false;
			public bool FiDown5Luck { get; set; } = false;
			public bool FiDown15HP { get; set; } = false;
			public bool FiDown30HP { get; set; } = false;
			public bool FiBMHP { get; set; } = false;
			public bool FiDown1Hitpercent { get; set; } = false;
			public bool FiDown1Mdef { get; set; } = false;
			public bool FiNobrace { get; set; } = false;
			public bool FiNoMasa { get; set; } = false;
			public bool FiNoRibbon { get; set; } = false;
			public bool FiNoProring { get; set; } = false;
			public bool FiThiefweaponsMalus { get; set; } = false;
			public bool FiNoFiPromoArmor { get; set; } = false;
			public bool FiNoPromoSpells { get; set; } = false;
			public bool FiDown50GP { get; set; } = false;
			public bool FiDown100GP { get; set; } = false;
			public bool FiDown150GP { get; set; } = false;
			public bool FiDown350GP { get; set; } = false;
			public bool FiDown1100GP { get; set; } = false;
			public bool FiDown4500gp { get; set; } = false;
		#endregion
		#region TheifMalus
			public bool ThDown10Str { get; set; } = false;
			public bool ThDown20Str { get; set; } = false;
			public bool ThDown10Agi { get; set; } = false;
			public bool ThDown20Agi { get; set; } = false;
			public bool ThDown10Vit { get; set; } = false;
			public bool ThDown5Luck { get; set; } = false;
			public bool ThDown10Luck { get; set; } = false;
			public bool ThDown15HP { get; set; } = false;
			public bool ThDown30HP { get; set; } = false;
			public bool ThDown1Hitpercent { get; set; } = false;
			public bool ThDown1Mdef { get; set; } = false;
			public bool ThNobrace { get; set; } = false;
			public bool ThNoMasa { get; set; } = false;
			public bool ThNoRibbon { get; set; } = false;
			public bool ThNoProring { get; set; } = false;
			public bool ThPromoRMArmor { get; set; } = false;
			public bool ThNoPromoSpells { get; set; } = false;
			public bool ThLateLockpick { get; set; } = false;
			public bool ThDown50GP { get; set; } = false;
			public bool ThDown100GP { get; set; } = false;
			public bool ThDown150GP { get; set; } = false;
			public bool ThDown350GP { get; set; } = false;
			public bool ThDown1100GP { get; set; } = false;
			public bool ThDown4500gp { get; set; } = false;

		#endregion
		#region BlackBeltMalus
			public bool BBDown10Str { get; set; } = false;
			public bool BBDown10Agi { get; set; } = false;
			public bool BBDown10Vit { get; set; } = false;
			public bool BBDown20Vit { get; set; } = false;
			public bool BBDown5Luck { get; set; } = false;
			public bool BBDown10Luck { get; set; } = false;
			public bool BBDown15HP { get; set; } = false;
			public bool BBDown30HP { get; set; } = false;
			public bool BBDown1Hitpercent { get; set; } = false;
			public bool BBDown1Mdef { get; set; } = false;
			public bool BBNobrace { get; set; } = false;
			public bool BBNoMasa { get; set; } = false;
			public bool BBNoRibbon { get; set; } = false;
			public bool BBNoProring { get; set; } = false;
			public bool BBDown50GP { get; set; } = false;
			public bool BBDown100GP { get; set; } = false;
			public bool BBDown150GP { get; set; } = false;
			public bool BBDown350GP { get; set; } = false;
			public bool BBDown1100GP { get; set; } = false;
			public bool BBDown4500gp { get; set; } = false;

		#endregion
		#region RMMalus
			public bool RmDown10Str { get; set; } = false;
			public bool RmDown10Agi { get; set; } = false;
			public bool RmDown10Vit { get; set; } = false;
			public bool RmDown5Luck { get; set; } = false;
			public bool RmDown15HP { get; set; } = false;
			public bool RmDown30HP { get; set; } = false;
			public bool RmDown1Hitpercent { get; set; } = false;
			public bool RmDown1Mdef { get; set; } = false;
			public bool RmNobrace { get; set; } = false;
			public bool RmNoMasa { get; set; } = false;
			public bool RmNoRibbon { get; set; } = false;
			public bool RmNoProring { get; set; } = false;
			public bool RmThiefweaponsMalus { get; set; } = false;
			public bool RmDown4MaxMP { get; set; } = false;
			public bool RmNoSpell { get; set; } = false; //this one might need some added items to get the spell
			public bool RmDown50GP { get; set; } = false;
			public bool RmDown100GP { get; set; } = false;
			public bool RmDown150GP { get; set; } = false;
			public bool RmDown350GP { get; set; } = false;
			public bool RmDown1100GP { get; set; } = false;
			public bool RmDown4500gp { get; set; } = false;
		#endregion
		#region WmMalus
			public bool WmDown10Str { get; set; } = false;
			public bool WmDown10Agi { get; set; } = false;
			public bool WmDown10Vit { get; set; } = false;
			public bool WmDown5Luck { get; set; } = false;
			public bool WmDown15HP { get; set; } = false;
			public bool WmDown30HP { get; set; } = false;
			public bool WmDown1Hitpercent { get; set; } = false;
			public bool WmDown1Mdef { get; set; } = false;
			public bool WmNobrace { get; set; } = false;
			public bool WmNoMasa { get; set; } = false;
			public bool WmNoRibbon { get; set; } = false;
			public bool WmNoProring { get; set; } = false;
			public bool WmDown4MaxMP { get; set; } = false;
			public bool WmNoSpell { get; set; } = false; //this one might need some added items to get the spell
			public bool WmDown50GP { get; set; } = false;
			public bool WmDown100GP { get; set; } = false;
			public bool WmDown150GP { get; set; } = false;
			public bool WmDown350GP { get; set; } = false;
			public bool WmDown1100GP { get; set; } = false;
			public bool WmDown4500gp { get; set; } = false;
		#endregion
		#region BmMalus

			public bool BmDown10Agi { get; set; } = false;
			public bool BmDown5Luck { get; set; } = false;
			public bool BmDown10Luck { get; set; } = false;
			public bool BmDown15HP { get; set; } = false;
			public bool BmDown30HP { get; set; } = false;
			public bool BmDown1Hitpercent { get; set; } = false;
			public bool BmDown1Mdef { get; set; } = false;
			public bool BmNobrace { get; set; } = false;
			public bool BmNoMasa { get; set; } = false;
			public bool BmNoRibbon { get; set; } = false;
			public bool BmNoProring { get; set; } = false;
			public bool BmDown4MaxMP { get; set; } = false;
			public bool BmNoSpell { get; set; } = false; //this one might need some added items to get the spell
			public bool BmDown50GP { get; set; } = false;
			public bool BmDown100GP { get; set; } = false;
			public bool BmDown150GP { get; set; } = false;
			public bool BmDown350GP { get; set; } = false;
			public bool BmDown1100GP { get; set; } = false;
			public bool BmDown4500gp { get; set; } = false;

		#endregion
		#endregion
		#region League KI
		#region	FighterKI	
				public bool FiStartCrown { get; set; } = false;
				public bool FiStartCrystal { get; set; } = false;
				public bool FiStartHerb { get; set; } = false;
				public bool FiStartTNT { get; set; } = false;
				public bool FiStartAdamant { get; set; } = false;
				public bool FiStartSlab { get; set; } = false;
				public bool FiStartRuby { get; set; } = false;
				public bool FiStartRod {  get; set; } = false;
				public bool FiStartChime { get; set; } = false;
				public bool FiStartCube { get; set; } = false;
				public bool FiStartBottle { get; set; } = false;
				public bool FiStartOxyale { get; set; } = false;
				public bool FiStartLute { get; set; } = false;
				public bool FiStartTail { get; set; } = false;
				public bool FiStartKey { get; set; } = false;
		#endregion
		#region ThiefKI
				public bool ThStartCrown { get; set; } = false;
				public bool ThStartCrystal { get; set; } = false;
				public bool ThStartHerb { get; set; } = false;
				public bool ThStartTNT { get; set; } = false;
				public bool ThStartAdamant { get; set; } = false;
				public bool ThStartSlab { get; set; } = false;
				public bool ThStartRuby { get; set; } = false;
				public bool ThStartRod { get; set; } = false;
				public bool ThStartChime { get; set; } = false;
				public bool ThStartCube { get; set; } = false;
				public bool ThStartBottle { get; set; } = false;
				public bool ThStartOxyale { get; set; } = false;
				public bool ThStartLute { get; set; } = false;
				public bool ThStartTail { get; set; } = false;
				public bool ThStartKey { get; set; } = false;

		#endregion
		#region BBKI
			public bool BBStartCrown { get; set; } = false;
			public bool BBStartCrystal { get; set; } = false;
			public bool BBStartHerb { get; set; } = false;
			public bool BBStartTNT { get; set; } = false;
			public bool BBStartAdamant { get; set; } = false;
			public bool BBStartSlab { get; set; } = false;
			public bool BBStartRuby { get; set; } = false;
			public bool BBStartRod { get; set; } = false;
			public bool BBStartChime { get; set; } = false;
			public bool BBStartCube { get; set; } = false;
			public bool BBStartBottle { get; set; } = false;
			public bool BBStartOxyale { get; set; } = false;
			public bool BBStartLute { get; set; } = false;
			public bool BBStartTail { get; set; } = false;
			public bool BBStartKey { get; set; } = false;
		#endregion
		#region RmKi
			public bool RmStartCrown { get; set; } = false;
			public bool RmStartCrystal { get; set; } = false;
			public bool RmStartHerb { get; set; } = false;
			public bool RmStartTNT { get; set; } = false;
			public bool RmStartAdamant { get; set; } = false;
			public bool RmStartSlab { get; set; } = false;
			public bool RmStartRuby { get; set; } = false;
			public bool RmStartRod { get; set; } = false;
			public bool RmStartChime { get; set; } = false;
			public bool RmStartCube { get; set; } = false;
			public bool RmStartBottle { get; set; } = false;
			public bool RmStartOxyale { get; set; } = false;
			public bool RmStartLute { get; set; } = false;
			public bool RmStartTail { get; set; } = false;
			public bool RmStartKey { get; set; } = false;

		#endregion
		#region WmKI
			public bool WmStartCrown { get; set; } = false;
			public bool WmStartCrystal { get; set; } = false;
			public bool WmStartHerb { get; set; } = false;
			public bool WmStartTNT { get; set; } = false;
			public bool WmStartAdamant { get; set; } = false;
			public bool WmStartSlab { get; set; } = false;
			public bool WmStartRuby { get; set; } = false;
			public bool WmStartRod { get; set; } = false;
			public bool WmStartChime { get; set; } = false;
			public bool WmStartCube { get; set; } = false;
			public bool WmStartBottle { get; set; } = false;
			public bool WmStartOxyale { get; set; } = false;
			public bool WmStartLute { get; set; } = false;
			public bool WmStartTail { get; set; } = false;
			public bool WmStartKey { get; set; } = false;
		#endregion
		#region BmKI
			public bool BmStartCrown { get; set; } = false;
			public bool BmStartCrystal { get; set; } = false;
			public bool BmStartHerb { get; set; } = false;
			public bool BmStartTNT { get; set; } = false;
			public bool BmStartAdamant { get; set; } = false;
			public bool BmStartSlab { get; set; } = false;
			public bool BmStartRuby { get; set; } = false;
			public bool BmStartRod { get; set; } = false;
			public bool BmStartChime { get; set; } = false;
			public bool BmStartCube { get; set; } = false;
			public bool BMStartBottle { get; set; } = false;
			public bool BmStartOxyale { get; set; } = false;
			public bool BmStartLute { get; set; } = false;
			public bool BmStartTail { get; set; } = false;
			public bool BmStartKey { get; set; } = false;

		#endregion
		#endregion

		#endregion
		public static string EncodeFlagsText(LeagueFlags flags)
		{
			var properties = typeof(LeagueFlags).GetProperties(BindingFlags.Instance | BindingFlags.Public);
			var flagproperties = properties.Where(p => p.CanWrite).OrderBy(p => p.Name).ToList();

			BigInteger sum = 0;
			sum = AddString(sum, 7, (FFRVersion.Sha.Length >= 7) ? FFRVersion.Sha.Substring(0, 7) : FFRVersion.Sha.PadRight(7, 'X'));

			foreach (var p in flagproperties)
			{
				if (Nullable.GetUnderlyingType(p.PropertyType) == typeof(bool))
				{
					sum = AddTriState(sum, (bool?)p.GetValue(flags));
				}
				else if (p.PropertyType == typeof(bool))
				{
					sum = AddBoolean(sum, (bool)p.GetValue(flags));
				}
				else if (p.PropertyType.IsEnum)
				{
					sum = AddNumeric(sum, Enum.GetValues(p.PropertyType).Cast<int>().Max() + 1, (int)p.GetValue(flags));
				}
				else if (p.PropertyType == typeof(int))
				{
					IntegerFlagAttribute ia = p.GetCustomAttribute<IntegerFlagAttribute>();
					var radix = (ia.Max - ia.Min) / ia.Step + 1;
					var val = (int)p.GetValue(flags);
					var raw_val = (val - ia.Min) / ia.Step;
					sum = AddNumeric(sum, radix, raw_val);
				}
				else if (p.PropertyType == typeof(double))
				{
					DoubleFlagAttribute ia = p.GetCustomAttribute<DoubleFlagAttribute>();
					var radix = (int)Math.Ceiling((ia.Max - ia.Min) / ia.Step) + 1;
					var val = (double)p.GetValue(flags);
					var raw_val = (int)Math.Round((val - ia.Min) / ia.Step);
					sum = AddNumeric(sum, radix, raw_val);
				}
			}

			return BigIntegerToString(sum);
		}

		public static LeagueFlags DecodeFlagsText(string text)
		{
			var properties = typeof(LeagueFlags).GetProperties(BindingFlags.Instance | BindingFlags.Public);
			var flagproperties = properties.Where(p => p.CanWrite).OrderBy(p => p.Name).Reverse().ToList();

			var sum = StringToBigInteger(text);
			var flags = new LeagueFlags();

			foreach (var p in flagproperties)
			{
				if (Nullable.GetUnderlyingType(p.PropertyType) == typeof(bool))
				{
					p.SetValue(flags, GetTriState(ref sum));
				}
				else if (p.PropertyType == typeof(bool))
				{
					p.SetValue(flags, GetBoolean(ref sum));
				}
				else if (p.PropertyType.IsEnum)
				{
					p.SetValue(flags, GetNumeric(ref sum, Enum.GetValues(p.PropertyType).Cast<int>().Max() + 1));
				}
				else if (p.PropertyType == typeof(int))
				{
					IntegerFlagAttribute ia = p.GetCustomAttribute<IntegerFlagAttribute>();
					var radix = (ia.Max - ia.Min) / ia.Step + 1;
					var raw_val = GetNumeric(ref sum, radix);
					var val = raw_val * ia.Step + ia.Min;
					p.SetValue(flags, val);
				}
				else if (p.PropertyType == typeof(double))
				{
					DoubleFlagAttribute ia = p.GetCustomAttribute<DoubleFlagAttribute>();
					var radix = (int)Math.Ceiling((ia.Max - ia.Min) / ia.Step) + 1;
					var raw_val = GetNumeric(ref sum, radix);
					var val = Math.Min(Math.Max(raw_val * ia.Step + ia.Min, ia.Min), ia.Max);
					p.SetValue(flags, val);
				}
			}

			string EncodedSha = GetString(ref sum, 7);
			if (((FFRVersion.Sha.Length >= 7) ? FFRVersion.Sha.Substring(0, 7) : FFRVersion.Sha.PadRight(7, 'X')) != EncodedSha)
			{
				throw new Exception("The encoded version does not match the expected version");
			}

			return flags;
		}

		private static BigInteger AddEnum<T>(BigInteger sum, T value) => AddNumeric(sum, Enum.GetValues(typeof(T)).Cast<int>().Max() + 1, Convert.ToInt32(value));

		private static BigInteger AddNumeric(BigInteger sum, int radix, int value) => sum * radix + value;
		private static BigInteger AddString(BigInteger sum, int length, string str)
		{
			Encoding AsciiEncoding = Encoding.ASCII;
			byte[] bytes = AsciiEncoding.GetBytes(str);
			BigInteger StringAsBigInt = new BigInteger(bytes);
			BigInteger LargestInt = new BigInteger(Math.Pow(0xFF, bytes.Length) - 1);


			return sum * LargestInt + StringAsBigInt;
		}
		private static BigInteger AddBoolean(BigInteger sum, bool value) => AddNumeric(sum, 2, value ? 1 : 0);
		private static int TriStateValue(bool? value) => value.HasValue ? (value.Value ? 1 : 0) : 2;
		private static BigInteger AddTriState(BigInteger sum, bool? value) => AddNumeric(sum, 3, TriStateValue(value));

		private static T GetEnum<T>(ref BigInteger sum) where T : Enum => (T)(object)GetNumeric(ref sum, Enum.GetValues(typeof(T)).Cast<int>().Max() + 1);

		private static int GetNumeric(ref BigInteger sum, int radix)
		{
			sum = BigInteger.DivRem(sum, radix, out var value);

			return (int)value;
		}
		private static string GetString(ref BigInteger sum, int length)
		{
			BigInteger LargestInt = new BigInteger(Math.Pow(0xFF, length) - 1);
			sum = BigInteger.DivRem(sum, LargestInt, out BigInteger value);
			Encoding AsciiEncoding = Encoding.ASCII;
			byte[] bytes = value.ToByteArray();
			string str = AsciiEncoding.GetString(bytes);

			return str;
		}
		private static bool GetBoolean(ref BigInteger sum) => GetNumeric(ref sum, 2) != 0;
		private static bool? ValueTriState(int value) => value == 0 ? (bool?)false : value == 1 ? (bool?)true : null;
		private static bool? GetTriState(ref BigInteger sum) => ValueTriState(GetNumeric(ref sum, 3));

		private const string Base64Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789.-";

		private static string BigIntegerToString(BigInteger sum)
		{
			var s = "";

			while (sum > 0)
			{
				var digit = GetNumeric(ref sum, 64);
				s += Base64Chars[digit];
			}

			return s;
		}

		private static BigInteger StringToBigInteger(string s)
		{
			var sum = new BigInteger(0);

			foreach (char c in s.Reverse())
			{
				int index = Base64Chars.IndexOf(c);
				if (index < 0) throw new IndexOutOfRangeException($"{c} is not valid FFR-style Base64.");

				sum = AddNumeric(sum, 64, index);
			}

			return sum;
		}


		public class Preset
		{
			public string Name { get; set; }
			public Flags Flags { get; set; }
		}

		//public static Flags FromJson(string json) => JsonConvert.DeserializeObject<Preset>(json).Flags;

		public class Preset2
		{
			public string Name { get; set; }
			public Dictionary<string, object> Flags { get; set; }
		}

		public static (string name, LeagueFlags flags, IEnumerable<string> log) FromJson(string json)
		{
		    var flags = new LeagueFlags();
		    string name;
		    IEnumerable<string> log;
		    (name, log) = flags.LoadFromJson(json);
		    return (name, flags, log);
		}

		public  (string name, IEnumerable<string> log) LoadFromJson(string json) {
			var w = new System.Diagnostics.Stopwatch();
			w.Restart();

			var preset = JsonConvert.DeserializeObject<Preset2>(json);
			var preset_dic = preset.Flags.ToDictionary(kv => kv.Key.ToLower());

			var properties = typeof(LeagueFlags).GetProperties(BindingFlags.Instance | BindingFlags.Public);
			var flagproperties = properties.Where(p => p.CanWrite).OrderBy(p => p.Name).Reverse().ToList();

			List<string> warnings = new List<string>();

			foreach (var pi in flagproperties)
			{
				if (preset_dic.TryGetValue(pi.Name.ToLower(), out var obj))
				{
					var result = SetValue(pi, this, obj.Value);

					if (result != null) warnings.Add(result);

					preset.Flags.Remove(obj.Key);
				}
				else
				{
					//warnings.Add($"\"{pi.Name}\" was missing in preset and set to default \"{pi.GetValue(flags)}\".");
				}
			}

			foreach (var flag in preset.Flags)
			{
				warnings.Add($"\"{flag.Key}\" with value \"{flag.Value}\" does not exist and has been discarded.");
			}

			warnings.Sort();

			w.Stop();
			return (preset.Name, warnings);
		}


		private static string SetValue(PropertyInfo p, LeagueFlags flags, object obj)
		{
			try
			{
				if (Nullable.GetUnderlyingType(p.PropertyType) == typeof(bool))
				{
					var t = obj == null ? (bool?)null : (bool?)(bool)obj;
					p.SetValue(flags, t);
				}
				else if (p.PropertyType == typeof(bool))
				{
					if (obj == null) throw new ArgumentNullException();
					p.SetValue(flags, obj);
				}
				else if (p.PropertyType.IsEnum)
				{
					if (obj == null) throw new ArgumentNullException();

					var values = Enum.GetValues(p.PropertyType);

					if (obj is string v)
					{
						foreach (var e in values)
						{
							if (v.ToLower() == e.ToString().ToLower())
							{
								p.SetValue(flags, e);
								return null;
							}
						}
					}
					else if (obj is IConvertible)
					{
						int v2 = Convert.ToInt32(obj);

						foreach (var e in values)
						{
							if (v2 == Convert.ToInt32(e))
							{
								p.SetValue(flags, e);
								return null;
							}
						}
					}

					throw new ArgumentException();
				}
				else if (p.PropertyType == typeof(int))
				{
					IntegerFlagAttribute ia = p.GetCustomAttribute<IntegerFlagAttribute>();
					var v3 = Convert.ToInt32(obj);

					p.SetValue(flags, v3);

					if (v3 > ia.Max)
					{
						return $"\"{p.Name}\" with value \"{obj}\" exceeds the maximum but will be kept.";
					}
					else if (v3 < ia.Min)
					{
						return $"\"{p.Name}\" with value \"{obj}\" deceedes the minimum but will be kept.";
					}
				}
				else if (p.PropertyType == typeof(double))
				{
					DoubleFlagAttribute da = p.GetCustomAttribute<DoubleFlagAttribute>();
					var v3 = Convert.ToDouble(obj);

					p.SetValue(flags, v3);

					if (v3 > da.Max)
					{
						return $"\"{p.Name}\" with value \"{obj}\" exceeds the maximum but will be kept.";
					}
					else if (v3 < da.Min)
					{
						return $"\"{p.Name}\" with value \"{obj}\" deceedes the minimum but will be kept.";
					}
				}
			}
			catch
			{
				return $"\"{p.Name}\" with value \"{obj}\" was invalid and set to default \"{p.GetValue(flags)}\".";
			}

			return null;
		}
	}
}
