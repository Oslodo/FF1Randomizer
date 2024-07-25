using FF1Lib.Helpers;
using RomUtilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FF1Lib
{

	public enum FiStrpool
	{
		[Description("None")]
		FiStrpoolnone,
		[Description("+10 Str")]
		Fiadd10Str,
		[Description("+20 Str")]
		Fiadd20Str,
		[Description("+40 Str")]
		FIadd40Str,
		[Description("-10 Str")]
		FIminus10Str,
		[Description("-20 Str")]
		Fiminus20Str,

	}
	public enum FiAgipool
	{
		[Description("None")]
		FiAgpoolinone,
		[Description("+15 Agi")]
		Fiadd15Agi,
		[Description("+25 Agi")]
		Fiadd25Agi,
		[Description("+50 Agi")]
		Fiadd50Agi,
		[Description("-10 Agi")]
		Fiminus10Agi,
	}
	public enum FiVitpool
	{
		[Description("None")]
		FiVitpoolNone,
		[Description("+10 Vit")]
		Fiadd10Vit,
		[Description("+20 Vit")]
		Fiadd20Vit,
		[Description("+40 Vit")]
		Fiadd40Vit,
		[Description("-10 Vit")]
		Fiminus10Vit,
	}
	public enum FiLuckpool
	{
		[Description("None")]
		FiLuckpoolNone,
		[Description("+5 Luck")]
		Fiadd5Luck,
		[Description("+10 Luck")]
		Fiadd10Luck,
		[Description("+20 Luck")]
		Fiadd20Luck,
		[Description("-5 Luck")]
		Fiminus5Luck,

	}
	public enum FiHPPool
	{
		[Description("None")]
		FiHPPoolNone,
		[Description("+20 HP")]
		Fiadd20HP,
		[Description("+40 HP")]
		Fiadd40HP,
		[Description("+80 HP")]
		Fiadd80HP,
		[Description("-15 HP")]
		Fiminus15HP,
		[Description("-30 HP")]
		Fiminus30HP,
	}
	public enum FiHitPercentpool
	{
		[Description("None")]
		FiHitPercentpoolNone,
		[Description("+10 Hit%")]
		Fiadd10hit,
		[Description("+20 Hit%")]
		Fiadd20hit,
		[Description("-10 Hit%")]
		Fiminus10hit,
	}
	public enum FiMdefpool
	{
		[Description("None")]
		FiMdefpoolNone,
		[Description("+10 MDef")]
		Fiadd10mdef,
		[Description("+20 MDef")]
		Fiadd20mdef,
		[Description("-10 MDef")]
		Fiminus10mdef,
	}
	public enum FiIntpool
	{
		[Description("None")]
		FiIntpoolNone,
		[Description("+10 Int")]
		Fiadd10int,
		[Description("+20 Int")]
		Fiadd20int,
		[Description("+40 Int")]
		Fiadd40int,
	}
	public enum FiGoldpool
	{
		[Description("None")]
		FiGoldpoolNone,
		[Description("+200 Gold")]
		Fiadd200gold,
		[Description("+400 Gold")]
		Fiadd400gold,
		[Description("+600 Gold")]
		Fiadd600gold,
		[Description("+800 Gold")]
		Fiadd800gold,
		[Description("+1500 Gold")]
		FIadd1500gold,
		[Description("+5000 Gold")]
		Fiadd5000gold,
		[Description("+20,000 Gold")]
		Fiadd20000gold,
		[Description("-50 Gold")]
		Fiminus50gold,
		[Description("-100 Gold")]
		Fiminus100gold,
		[Description("-150 Gold")]
		Fiminus150gold,
		[Description("-350 Gold")]
		Fiminus350gold,
		[Description("-1100 Gold")]
		Fiminus1100gold,
	}
	public enum FiMasaCurse
	{
		[Description("None")]
		FiMasaCurseNone,
		[Description("Poison")]
		FIMasaPoison,
		[Description("Stun")]
		FiMasaStun,
		[Description("Sleep")]
		FiMasaSleep,
		[Description("Mute")]
		FiMasaMute,
	}
	public enum FiRibbonCurse
	{
		[Description("None")]
		FiRibbonCurseNone,
		[Description("Poison")]
		FiRibbonCursePoison,
		[Description("Stun")]
		FiRibbonCurseStun,
		[Description("Sleep")]
		FiRibbonCurseSleep,
		[Description("Mute")]
		FiRibbonCurseMute,
	}
	public enum FiMagicBonus
	{
		[Description("None")]
		FiMagicBonusNone,
		[Description("Elem Magic")]
		FiMagicBonusElem,
		[Description("Elem+ Magic")]
		FiMagicBonusElemPlus,
		[Description("Clean Magic")]
		FiMagicBonusClean,
		[Description("Heal Magic")]
		FiMagicBonusHeal,
		[Description("Heal+ Magic")]
		FiMagicBonusHealPlus,
		[Description("Self Magic")]
		FiMagicBonusSelf,
		[Description("Buff Magic")]
		FiMagicBonusBuff,
		[Description("Tele Magic")]
		FiMagicBonusTele,
	}
	public enum FiKeyItems
	{
		[Description("None")]
		FiKeyItemsNone,
		[Description("Crown")]
		FiKeyItemsCrown,
		[Description("Crystal")]
		FiKeyItemsCrystal,
		[Description("Herb")]
		FiKeyItemsHerb,
		[Description("TNT")]
		FiKeyItemsTNT,
		[Description("Adamant")]
		FiKeyItemsAdamant,
		[Description("Slab")]
		FiKeyItemsSlab,
		[Description("Ruby")]
		FiKeyItemsRuby,
		[Description("Rod")]
		FiKeyItemsRod,
		[Description("Chime")]
		FiKeyItemsChime,
		[Description("Cube")]
		FiKeyItemsCube,
		[Description("Bottle")]
		FiKeyItemsBottle,
		[Description("Oxyale")]
		FiKeyItemsOxyale,
		[Description("Lute")]
		FiKeyItemsLute,
		[Description("Tail")]
		FiKeyItemsTail,
		[Description("Key")]
		FiKeyItemsKey,
	}
	public enum ThStrpool
	{
		[Description("None")]
		ThStrpoolNone,
		[Description("+10 Str")]
		Thadd10Str,
		[Description("+20 Str")]
		Thadd20Str,
		[Description("+40 Str")]
		Thadd40Str,
		[Description("-10 Str")]
		Thminus10Str,
	}
	public enum ThAgipool
	{
		[Description("None")]
		ThAgipoolNone,
		[Description("+15 Agi")]
		Thadd15Agi,
		[Description("+25 Agi")]
		Thadd25Agi,
		[Description("+50 Agi")]
		Thadd50Agi,
		[Description("-10 Agi")]
		Thminus10Agi,
		[Description("-20 Agi")]
		Thminus20Agi
	}
	public enum ThVitpool
	{
		[Description("None")]
		ThVitpoolNone,
		[Description("+10 Vit")]
		Thadd10Vit,
		[Description("+20 Vit")]
		Thadd20Vit,
		[Description("+40 Vit")]
		Thadd40Vit,
		[Description("-10 Vit")]
		Thminus10Vit,
	}
	public enum ThLuckpool
	{
		[Description ("None")]
		ThLuckpoolNone,
		[Description("+5 Luck")]
		Thadd5Luck,
		[Description("+10 Luck")]
		Thadd10Luck,
		[Description("-5 Luck")]
		Thminus5luck,
		[Description("-10 Luck")]
		Thminus10Luck,
	}
	public enum ThHPPool
	{
		[Description("None")]
		ThHPPoolNone,
		[Description("+20 HP")]
		Thadd20HP,
		[Description("+40 HP")]
		Thadd40HP,
		[Description("+80 HP")]
		Thadd80HP,
		[Description("-15 HP")]
		Thminus15HP,
		[Description("-30 HP")]
		Thminus30HP,
	}
	public enum ThHitPercentpool
	{
		[Description("None")]
		ThHitPercentpoolNone,
		[Description("+10 Hit%")]
		Thadd10hit,
		[Description("+20 Hit%")]
		Thadd20hit,
		[Description("-10 Hit%")]
		Thminus10hit,
	}
	public enum ThMdefpool
	{
		[Description("None")]
		ThMdefpoolNone,
		[Description("+10 MDef")]
		Thadd10mdef,
		[Description("+20 MDef")]
		Thadd20mdef,
		[Description("-10 MDef")]
		Thminus10mdef,
	}
	public enum ThIntpool
	{
		[Description("None")]
		ThIntpoolNone,
		[Description("+10 Int")]
		Thadd10int,
		[Description("+20 Int")]
		Thadd20int,
		[Description("+40 Int")]
		Thadd40int,
		[Description("-10 Int")]
		Thminus10int,
	}
	public enum ThGoldpool
	{
		[Description("None")]
		ThGoldpoolNone,
		[Description("+200 Gold")]
		Thadd200gold,
		[Description("+400 Gold")]
		Thadd400gold,
		[Description("+600 Gold")]
		Thadd600gold,
		[Description("+800 Gold")]
		Thadd800gold,
		[Description("+1400 Gold")]
		Thadd1400gold,
		[Description("+1500 Gold")]
		Thadd1500gold,
		[Description("+2000 Gold")]
		Thadd2000gold,
		[Description("+3000 Gold")]
		Thadd3000gold,
		[Description("+4000 Gold")]
		Thadd4000gold,
		[Description("+5000 Gold")]
		Thadd5000gold,
		[Description("+6000 Gold")]
		Thadd6000gold,
		[Description("+20,000 Gold")]
		Thadd20000gold,
		[Description("-50 Gold")]
		Thminus50gold,
		[Description("-100 Gold")]
		Thminus100gold,
		[Description("-150 Gold")]
		Thminus150gold,
		[Description("-350 Gold")]
		Thminus350gold,
		[Description("-1100 Gold")]
		Thminus1100gold,
	}
	public enum BBStrpool
	{
		[Description("None")]
		BBStrpoolNone,
		[Description("+10 Str")]
		BBadd10Str,
		[Description("+20 Str")]
		BBadd20Str,
		[Description("+40 Str")]
		BBadd40Str,
		[Description("-10 Str")]
		BBminus10Str,
	}
	public enum BBAgipool
	{
		[Description("None")]
		BBAgipoolNone,
		[Description("+15 Agi")]
		BBadd15Agi,
		[Description("+25 Agi")]
		BBadd25Agi,
		[Description("+50 Agi")]
		BBadd50Agi,
		[Description("-10 Agi")]
		BBminus10Agi,
	}
	public enum BBVitpool
	{
		[Description("None")]
		BBVitpoolNone,
		[Description("+10 Vit")]
		BBadd10Vit,
		[Description("+20 Vit")]
		BBadd20Vit,
		[Description("+40 Vit")]
		BBadd40Vit,
		[Description("-10 Vit")]
		BBminus10Vit,
		[Description("-20 Vit")]
		BBminus20Vit,
	}
	public enum BBLuckpool
	{
		[Description("None")]
		BBBLuckpoolNone,
		[Description("+5 Luck")]
		BBadd5Luck,
		[Description("+10 Luck")]
		BBadd10Luck,
		[Description("+15 Luck")]
		BBadd15Luck,
		[Description("-5 Luck")]
		BBminus5luck,
	}
	public enum BBHPPool
	{
		[Description("None")]
		BBHPPoolNone,
		[Description("+20 HP")]
		BBadd20HP,
		[Description("+40 HP")]
		BBadd40HP,
		[Description("+80 HP")]
		BBadd80HP,
		[Description("-15 HP")]
		BBminus15HP,
		[Description("-30 HP")]
		BBminus30HP,
	}
	public enum BBHitPercentpool
	{
		[Description("None")]
		BBHitPercentpoolNone,
		[Description("+10 Hit%")]
		BBadd10hit,
		[Description("+20 Hit%")]
		BBadd20hit,
		[Description("-10 Hit%")]
		BBminus10hit,
	}
	public enum BBMdefpool
	{
		[Description("None")]
		BBBMdefpoolNone,
		[Description("+10 MDef")]
		BBadd10mdef,
		[Description("+20 MDef")]
		BBadd20mdef,
		[Description("-10 MDef")]
		BBminus10mdef,
	}
	public enum BBGoldpool
	{
		[Description("None")]
		BBGoldpoolNone,
		[Description("+200 Gold")]
		BBadd200gold,
		[Description("+400 Gold")]
		BBadd400gold,
		[Description("+600 Gold")]
		BBadd600gold,
		[Description("+800 Gold")]
		BBadd800gold,
		[Description("+1500 Gold")]
		BBadd1500gold,
		[Description("+5000 Gold")]
		BBadd5000gold,
		[Description("+20,000 Gold")]
		BBadd20000gold,
		[Description("-50 Gold")]
		BBminus50gold,
		[Description("-100 Gold")]
		BBminus100gold,
		[Description("-150 Gold")]
		BBminus150gold,
		[Description("-350 Gold")]
		BBminus350gold,
		[Description("-1100 Gold")]
		BBminus1100gold,
	}
	public enum BBMasaCruse
	{
		[Description("None")]
		BBMasaCurseNone,
		[Description("Poison")]
		BBMasaPoison,
		[Description("Stun")]
		BBMasaStun,
		[Description("Sleep")]
		BBMasaSleep,
		[Description("Mute")]
		BBMasaMute,
	}
	public enum BBRibbonCurse
	{
		[Description("None")]
		BBRibbonCurseNone,
		[Description("Poison")]
		BBRibbonCursePoison,
		[Description("Stun")]
		BBRibbonCurseStun,
		[Description("Sleep")]
		BBRibbonCurseSleep,
		[Description("Mute")]
		BBRibbonCurseMute,
	}
	public enum BBMagicBonus
	{
	
		[Description("None")]
		BBMagicBonusNone,
		[Description("Elem Magic")]
		BBMagicBonusElem,
		[Description("Elem+ Magic")]
		BBMagicBonusElemPlus,
		[Description("Clean Magic")]
		BBMagicBonusClean,
		[Description("Heal Magic")]
		BBMagicBonusHeal,
		[Description("Heal+ Magic")]
		BBMagicBonusHealPlus,
		[Description("Self Magic")]
		BBMagicBonusSelf,
		[Description("Buff Magic")]
		BBMagicBonusBuff,
		[Description("Tele Magic")]
		BBMagicBonusTele,
	}
	public enum BBKeyItems
	{
		[Description("None")]
		BBKeyItemsNone,
		[Description("Crown")]
		BBKeyItemsCrown,
		[Description("Crystal")]
		BBKeyItemsCrystal,
		[Description("Herb")]
		BBKeyItemsHerb,
		[Description("TNT")]
		BBKeyItemsTNT,
		[Description("Adamant")]
		BBKeyItemsAdamant,
		[Description("Slab")]
		BBKeyItemsSlab,
		[Description("Ruby")]
		BBKeyItemsRuby,
		[Description("Rod")]
		BBKeyItemsRod,
		[Description("Chime")]
		BBKeyItemsChime,
		[Description("Cube")]
		BBKeyItemsCube,
		[Description("Bottle")]
		BBKeyItemsBottle,
		[Description("Oxyale")]
		BBKeyItemsOxyale,
		[Description("Lute")]
		BBKeyItemsLute,
		[Description("Tail")]
		BBKeyItemsTail,
		[Description("Key")]
		BBKeyItemsKey,
	}
	public enum RMStrpool
	{
		[Description("None")]
		RMStrpoolNone,
		[Description("+10 Str")]
		RMadd10Str,
		[Description("+20 Str")]
		RMadd20Str,
		[Description("+40 Str")]
		RMadd40Str,
		[Description("-10 Str")]
		RMminus10Str,
	}
	public enum RMAgipool
	{
		[Description("None")]
		RMAgipoolNone,
		[Description("+15 Agi")]
		RMadd15Agi,
		[Description("+25 Agi")]
		RMadd25Agi,
		[Description("+50 Agi")]
		RMadd50Agi,
		[Description("-10 Agi")]
		RMminus10Agi,
	}
	public enum RMVitpool
	{
		[Description("None")]
		RMmVitpoolNone,
		[Description("+10 Vit")]
		RMadd10Vit,
		[Description("+20 Vit")]
		RMadd20Vit,
		[Description("+40 Vit")]
		RMadd40Vit,
		[Description("-10 Vit")]
		RMminus10Vit,
	}
	public enum RMLuckpool
	{
		[Description ("None")]
		RMmLuckpoolNone,
		[Description("+5 Luck")]
		RMadd5Luck,
		[Description("+10 Luck")]
		RMadd10Luck,
		[Description("+15 Luck")]
		RMadd15Luck,
		[Description("-5 Luck")]
		RMminus5luck,
	}
	public enum RMHPPool
	{
		[Description("None")]
		RMHPPoolNone,
		[Description("+20 HP")]
		RMadd20HP,
		[Description("+40 HP")]
		RMadd40HP,
		[Description("+80 HP")]
		RMadd80HP,
		[Description("-15 HP")]
		RMminus15HP,
		[Description("-30 HP")]
		RMminus30HP,
	}
	public enum RMHitPercentpool
	{
		[Description("None")]
		RMHitPercentpoolNone,
		[Description("+10 Hit%")]
		RMadd10hit,
		[Description("+20 Hit%")]
		RMadd20hit,
		[Description("-10 Hit%")]
		RMminus10hit,
	}
	public enum RMMdefpool
	{
		[Description("None")]
		RMdefpoolNone,
		[Description("+10 MDef")]
		RMadd10mdef,
		[Description("+20 MDef")]
		RMadd20mdef,
		[Description("-10 MDef")]
		RMminus10mdef,
	}
	public enum RMIntpool
	{
		[Description("None")]
		RMIntpoolNone,
		[Description("+10 Int")]
		RMadd10int,
		[Description("+20 Int")]
		RMadd20int,
		[Description("+40 Int")]
		RMadd40int,
		[Description("-10 Int")]
		RMminus10int,
		[Description("-20 Int")]
		RMmins20int,
	}
	public enum RMGoldpool
	{
		[Description("None")]
		RMGoldpoolNone,
		[Description("+200 Gold")]
		RMadd200gold,
		[Description("+400 Gold")]
		RMadd400gold,
		[Description("+600 Gold")]
		RMadd600gold,
		[Description("+800 Gold")]
		RMadd800gold,
		[Description("+1500 Gold")]
		RMadd1500gold,
		[Description("+5000 Gold")]
		RMadd5000gold,
		[Description("+20,000 Gold")]
		RMadd20000gold,
		[Description("-50 Gold")]
		RMminus50gold,
		[Description("-100 Gold")]
		RMminus100gold,
		[Description("-150 Gold")]
		RMminus150gold,
		[Description("-350 Gold")]
		RMminus350gold,
		[Description("-1100 Gold")]
		RMminus1100gold,
	}
	public enum WMStrpool
	{
		[Description("None")]
		WMStrpoolNone,
		[Description("+10 Str")]
		WMadd10Str,
		[Description("+20 Str")]
		WMadd20Str,
		[Description("+40 Str")]
		WMadd40Str,
		[Description("-10 Str")]
		WMminus10Str,
	}
	public enum WMAgipool
	{
		[Description("None")]
		WMAgipoolNone,
		[Description("+15 Agi")]
		WMadd15Agi,
		[Description("+25 Agi")]
		WMadd25Agi,
		[Description("+50 Agi")]
		WMadd50Agi,
		[Description("-10 Agi")]
		WMminus10Agi,
	}
	public enum WMVitpool
	{
		[Description("None")]
		WMVitpoolNone,
		[Description("+10 Vit")]
		WMadd10Vit,
		[Description("+20 Vit")]
		WMadd20Vit,
		[Description("+40 Vit")]
		WMadd40Vit,
		[Description("-10 Vit")]
		WMminus10Vit,
	}
	public enum WMLuckpool
	{
		[Description("None")]
		WMLuckpoolNone,
		[Description("+5 Luck")]
		WMadd5Luck,
		[Description("+10 Luck")]
		WMadd10Luck,
		[Description("+15 Luck")]
		WMadd15Luck,
		[Description("-5 Luck")]
		WMminus5luck,
	}
	public enum WMHPPool
	{
		[Description("None")]
		WMHPPoolNone,
		[Description("+20 HP")]
		WMadd20HP,
		[Description("+40 HP")]
		WMadd40HP,
		[Description("+80 HP")]
		WMadd80HP,
		[Description("-15 HP")]
		WMminus15HP,
		[Description("-30 HP")]
		WMminus30HP,
	}
	public enum WMHitPercentpool
	{
		[Description("None")]
		WMHitPercentpoolNone,
		[Description("+10 Hit%")]
		WMadd10hit,
		[Description("+20 Hit%")]
		WMadd20hit,
		[Description("-10 Hit%")]
		WMminus10hit,
	}
	public enum WMMdefpool
	{
		[Description("None")]
		WMMdefpoolNone,
		[Description("+10 MDef")]
		WMadd10mdef,
		[Description("+20 MDef")]
		WMadd20mdef,
		[Description("-10 MDef")]
		WMminus10mdef,
	}
	public enum WMIntpool
	{
		[Description("None")]
		WMIntpoolNone,
		[Description("+10 Int")]
		WMadd10int,
		[Description("+20 Int")]
		WMadd20int,
		[Description("+40 Int")]
		WMadd40int,
		[Description("-10 Int")]
		WMminus10int,
		[Description("-20 Int")]
		WMmins20int,
	}
	public enum WMGoldpool
	{
		[Description("None")]
		WMGoldpoolNone,
		[Description("+200 Gold")]
		WMadd200gold,
		[Description("+400 Gold")]
		WMadd400gold,
		[Description("+600 Gold")]
		WMadd600gold,
		[Description("+800 Gold")]
		WMadd800gold,
		[Description("+1500 Gold")]
		WMadd1500gold,
		[Description("+5000 Gold")]
		WMadd5000gold,
		[Description("+20,000 Gold")]
		WMadd20000gold,
		[Description("-50 Gold")]
		WMminus50gold,
		[Description("-100 Gold")]
		WMminus100gold,
		[Description("-150 Gold")]
		WMminus150gold,
		[Description("-350 Gold")]
		WMminus350gold,
		[Description("-1100 Gold")]
		WMminus1100gold,
	}
	public enum BMStrpool
	{
		[Description("None")]
		BMStrpoolnone,
		[Description("+10 Str")]
		BMadd10Str,
		[Description("+20 Str")]
		BMadd20Str,
		[Description("+40 Str")]
		BMadd40Str,
		[Description("-10 Str")]
		BMminus10Str,
	}
	public enum BMAgipool
	{
		[Description("None")]
		BMAgipoolnone,
		[Description("+15 Agi")]
		BMadd15Agi,
		[Description("+25 Agi")]
		BMadd25Agi,
		[Description("+50 Agi")]
		BMadd50Agi,
		[Description("-10 Agi")]
		BMminus10Agi,
	}
	public enum BMVitpool
	{
		[Description("None")]
		BMVitpoolnone,
		[Description("+10 Vit")]
		BMadd10Vit,
		[Description("+20 Vit")]
		BMadd20Vit,
		[Description("+40 Vit")]
		BMadd40Vit,
		[Description("-10 Vit")]
		BMminus10Vit,
	}
	public enum BMLuckpool
	{
		[Description("None")]
		BMLuckpoolnone,
		[Description("+5 Luck")]
		BMadd5Luck,
		[Description("+10 Luck")]
		BMadd10Luck,
		[Description("+15 Luck")]
		BMadd15Luck,
		[Description("-5 Luck")]
		BMminus5luck,
		[Description("-10 Luck")]
		BMminus10Luck,
	}
	public enum BMHPPool
	{
		[Description("None")]
		BMHPPoolnone,
		[Description("+20 HP")]
		BMadd20HP,
		[Description("+40 HP")]
		BMadd40HP,
		[Description("+80 HP")]
		BMadd80HP,
		[Description("-15 HP")]
		BMminus15HP,
		[Description("-30 HP")]
		BMminus30HP,
	}
	public enum BMHitPercentpool
	{
		[Description("None")]
		BMHitPercentpoolnone,
		[Description("+10 Hit%")]
		BMadd10hit,
		[Description("+20 Hit%")]
		BMadd20hit,
		[Description("-10 Hit%")]
		BMminus10hit,
	}
	public enum BMMdefpool
	{
		[Description("None")]
		BMMdefpoolnone,
		[Description("+10 MDef")]
		BMadd10mdef,
		[Description("+20 MDef")]
		BMadd20mdef,
		[Description("-10 MDef")]
		BMminus10mdef,
	}
	public enum BMIntpool
	{
		[Description("None")]
		BMIntpoolNone,
		[Description("+10 Int")]
		BMadd10int,
		[Description("+20 Int")]
		BMadd20int,
		[Description("+40 Int")]
		BMadd40int,
		[Description("-10 Int")]
		BMminus10int,
		[Description("-20 Int")]
		BMmins20int,
	}
	public enum BMGoldpool
	{
		[Description("None")]
		BMGoldpoolnone,
		[Description("+200 Gold")]
		BMadd200gold,
		[Description("+400 Gold")]
		BMadd400gold,
		[Description("+600 Gold")]
		BMadd600gold,
		[Description("+800 Gold")]
		BMadd800gold,
		[Description("+1500 Gold")]
		BMadd1500gold,
		[Description("+5000 Gold")]
		BMadd5000gold,
		[Description("+20,000 Gold")]
		BMadd20000gold,
		[Description("-50 Gold")]
		BMminus50gold,
		[Description("-100 Gold")]
		BMminus100gold,
		[Description("-150 Gold")]
		BMminus150gold,
		[Description("-350 Gold")]
		BMminus350gold,
		[Description("-1100 Gold")]
		BMminus1100gold,
	}

}

