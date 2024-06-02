
using System.ComponentModel;

namespace FF1Lib.League
{
	public enum LeagueMagicPool
	{
		[Description("None")]
		None = 0,
		[Description("FAST")]
		FAST = 1,
		[Description("TMPR")]
		TMPR = 2,
		[Description("WARP")]
		WARP = 3,
		[Description("LOCK")]
		LOCK = 4,
		[Description("LOK2")]
		LOK2 = 5,
		[Description("LIFE")]
		LIFE = 6,
		[Description("RUSE")]
		RUSE = 7,
		[Description("INV2")]
		INV2 = 8,
		[Description("CUR3")]
		CURE3 = 9,
		[Description("EXIT")]
		EXIT = 10,
		[Description("HEL2")]
		HEL2 = 11,
		[Description("NUKE")]
		NUKE = 12,
		[Description("FIR3")]
		FIR3 = 13,
		[Description("ICE3")]
		ICE3 = 14,
		[Description("LIT3")]
		LIT3 = 15,
		[Description("FADE")]
		FADE = 16,
		[Description("HEL3")]
		HEL3 = 17,
		[Description("WALL")]
		WALL = 18,
	}
/*
	[AttributeUsage(AttributeTargets.Property)]
	public class MagicList : Attribute
	{

		public int Magic { get; set; }

		public IntflagmagicAttribute(int magicnum)
		{
			Magic = magicnum;
		}
	}*/
}

