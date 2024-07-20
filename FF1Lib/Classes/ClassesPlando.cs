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
		[Description("+10 Hit%")]
		Fiadd10hit,
		[Description("+20 Hit%")]
		Fiadd20hit,
		[Description("-10 Hit%")]
		Fiminus10hit,
	}

	public enum FiMdefpool
	{
		[Description("+10 MDef")]
		Fiadd10mdef,
		[Description("+20 MDef")]
		Fiadd20mdef,
		[Description("-10 MDef")]
		Fiminus10mdef,
	}

	public enum FiIntpool
	{
		[Description("+10 Int")]
		Fiadd10int,
		[Description("+20 Int")]
		Fiadd20int,
		[Description("+40 Int")]
		Fiadd40int,
	}

	public enum FiGoldpool
	{
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

	public enum ThStrpool
	{
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
		[Description("+10 Hit%")]
		Thadd10hit,
		[Description("+20 Hit%")]
		Thadd20hit,
		[Description("-10 Hit%")]
		Thminus10hit,
	}

	public enum ThMdefpool
	{
		[Description("+10 MDef")]
		Thadd10mdef,
		[Description("+20 MDef")]
		Thadd20mdef,
		[Description("-10 MDef")]
		Thminus10mdef,
	}
	public enum ThIntpool
	{
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
		[Description("+10 Hit%")]
		BBadd10hit,
		[Description("+20 Hit%")]
		BBadd20hit,
		[Description("-10 Hit%")]
		BBminus10hit,
	}
	public enum BBMdefpool
	{
		[Description("+10 MDef")]
		BBadd10mdef,
		[Description("+20 MDef")]
		BBadd20mdef,
		[Description("-10 MDef")]
		BBminus10mdef,
	}


	internal class Class1
	{
	}
}
