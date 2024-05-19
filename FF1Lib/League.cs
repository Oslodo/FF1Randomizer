using FF1Lib.Helpers;
using RomUtilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Compression;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static FF1Lib.GameClasses;

/* This is a work in progress needed the following
 1) Will need to get the league page working
 2) Get the code set up to pull out the blursing as needed
 3) Create a Plando code to take a randomized rom and add in blursings without changing the basic randomization and the hash
 4) Test to make sure that it works*/

namespace FF1Lib
{
	public partial class GameClasses
	{

		public class LeagueBonusMalus
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

			public LeagueBonusMalus(BonusMalusAction action, string description, int mod = 0, int mod2 = 0, List<Item> equipment = null, List<bool> binarylist = null, List<SpellSlots> spelllist = null, List<byte> bytelist = null, SpellSlotInfo spellslotmod = null, List<SpellSlotInfo> spellsmod = null, List<Classes> Classes = null)
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
			private List<BonusMalus> LeagueKI(Flags flags, List<string> olditemnames)
			{
				List<BonusMalus> kiBlursingsLeague = new()
				{
					new BonusMalus(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Crown], mod: (int)Item.Crown),
					new BonusMalus(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Crystal], mod: (int)Item.Crystal),
					new BonusMalus(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Herb], mod: (int)Item.Herb),
					new BonusMalus(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Tnt], mod: (int)Item.Tnt),
					new BonusMalus(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Adamant], mod: (int)Item.Adamant),
					new BonusMalus(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Slab], mod: (int)Item.Slab),
					new BonusMalus(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Ruby], mod: (int)Item.Ruby),
					new BonusMalus(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Rod], mod: (int)Item.Rod),
					new BonusMalus(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Chime], mod: (int)Item.Chime),
					new BonusMalus(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Cube], mod: (int)Item.Cube),
					new BonusMalus(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Bottle], mod: (int)Item.Bottle),
					new BonusMalus(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Oxyale], mod: (int)Item.Oxyale),
					new BonusMalus(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Lute], mod: (int)Item.Lute),
					new BonusMalus(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Tail], mod: (int)Item.Tail),
					new BonusMalus(BonusMalusAction.StartWithKI, "+" + olditemnames[(int)Item.Key], mod: (int)Item.Key),
				};
				return kiBlursingsLeague;
			}
			public void StartCrown(Flags flags)
			{
				if (!(bool)flags.Startcrown)
				{
					return;

				}
				BonusMalusAction.StartWithKI.Equals(Item.Crown);
			}
			
			}
			}
		}


