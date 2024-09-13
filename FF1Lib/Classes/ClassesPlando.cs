using DotNetAsm;
using FF1Lib.Helpers;
using FF1Lib.Sanity;
using RomUtilities;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static FF1Lib.GameClasses;

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
			//var PlandoBonusList = GenerateListsPlando(bonuslist, maluses, olditemnames, itemnames, flags, rom);

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

			if (flags.BBKeyItems != BBKeyItems.BBKeyItemsNone)
			{
				switch (flags.BBKeyItems)
				{
					case BBKeyItems.BBKeyItemsCrown:
						assignedBlessings[Classes.BlackBelt].Add(StartwithKIPlando[(int)Item.Crown]);
						break;

					case BBKeyItems.BBKeyItemsCrystal:
						assignedBlessings[Classes.BlackBelt].Add(StartwithKIPlando[(int)Item.Crystal]);
						break;

					case BBKeyItems.BBKeyItemsHerb:
						assignedBlessings[Classes.BlackBelt].Add(StartwithKIPlando[(int)Item.Herb]);
						break;

					case BBKeyItems.BBKeyItemsTNT:
						assignedBlessings[Classes.BlackBelt].Add(StartwithKIPlando[(int)Item.Tnt]);
						break;

					case BBKeyItems.BBKeyItemsAdamant:
						assignedBlessings[Classes.BlackBelt].Add(StartwithKIPlando[(int)Item.Adamant]);
						break;

					case BBKeyItems.BBKeyItemsSlab:
						assignedBlessings[Classes.BlackBelt].Add(StartwithKIPlando[(int)Item.Slab]);
						break;

					case BBKeyItems.BBKeyItemsRuby:
						assignedBlessings[Classes.BlackBelt].Add(StartwithKIPlando[(int)Item.Ruby]);
						break;

					case BBKeyItems.BBKeyItemsRod:
						assignedBlessings[Classes.BlackBelt].Add(StartwithKIPlando[(int)Item.Rod]);
						break;

					case BBKeyItems.BBKeyItemsChime:
						assignedBlessings[Classes.BlackBelt].Add(StartwithKIPlando[(int)Item.Chime]);
						break;

					case BBKeyItems.BBKeyItemsCube:
						assignedBlessings[Classes.BlackBelt].Add(StartwithKIPlando[(int)Item.Cube]);
						break;

					case BBKeyItems.BBKeyItemsBottle:
						assignedBlessings[Classes.BlackBelt].Add(StartwithKIPlando[(int)Item.Bottle]);
						break;

					case BBKeyItems.BBKeyItemsOxyale:
						assignedBlessings[Classes.BlackBelt].Add(StartwithKIPlando[(int)Item.Oxyale]);
						break;

					case BBKeyItems.BBKeyItemsLute:
						assignedBlessings[Classes.BlackBelt].Add(StartwithKIPlando[(int)Item.Lute]);
						break;

					case BBKeyItems.BBKeyItemsTail:
						assignedBlessings[Classes.BlackBelt].Add(StartwithKIPlando[(int)Item.Tail]);
						break;

					case BBKeyItems.BBKeyItemsKey:
						assignedBlessings[Classes.BlackBelt].Add(StartwithKIPlando[(int)Item.Key]);
						break;
				}
			};

			if (flags.RmKeyItems != RmKeyItems.RmKeyItemsNone)

			{
				switch (flags.RmKeyItems)
				{
					case RmKeyItems.RmKeyItemsCrown:
						assignedBlessings[Classes.RedMage].Add(StartwithKIPlando[(int)Item.Crown]);
						break;

					case RmKeyItems.RmKeyItemsCrystal:
						assignedBlessings[Classes.RedMage].Add(StartwithKIPlando[(int)Item.Crystal]);
						break;

					case RmKeyItems.RmKeyItemsHerb:
						assignedBlessings[Classes.RedMage].Add(StartwithKIPlando[(int)Item.Herb]);
						break;

					case RmKeyItems.RmKeyItemsTNT:
						assignedBlessings[Classes.RedMage].Add(StartwithKIPlando[(int)Item.Tnt]);
						break;

					case RmKeyItems.RmKeyItemsAdamant:
						assignedBlessings[Classes.RedMage].Add(StartwithKIPlando[(int)Item.Adamant]);
						break;

					case RmKeyItems.RmKeyItemsSlab:
						assignedBlessings[Classes.RedMage].Add(StartwithKIPlando[(int)Item.Slab]);
						break;

					case RmKeyItems.RmKeyItemsRuby:
						assignedBlessings[Classes.RedMage].Add(StartwithKIPlando[(int)Item.Ruby]);
						break;

					case RmKeyItems.RmKeyItemsRod:
						assignedBlessings[Classes.RedMage].Add(StartwithKIPlando[(int)Item.Rod]);
						break;

					case RmKeyItems.RmKeyItemsChime:
						assignedBlessings[Classes.RedMage].Add(StartwithKIPlando[(int)Item.Chime]);
						break;

					case RmKeyItems.RmKeyItemsCube:
						assignedBlessings[Classes.RedMage].Add(StartwithKIPlando[(int)Item.Cube]);
						break;

					case RmKeyItems.RmKeyItemsBottle:
						assignedBlessings[Classes.RedMage].Add(StartwithKIPlando[(int)Item.Bottle]);
						break;

					case RmKeyItems.RmKeyItemsOxyale:
						assignedBlessings[Classes.RedMage].Add(StartwithKIPlando[(int)Item.Oxyale]);
						break;

					case RmKeyItems.RmKeyItemsLute:
						assignedBlessings[Classes.RedMage].Add(StartwithKIPlando[(int)Item.Lute]);
						break;

					case RmKeyItems.RmKeyItemsTail:
						assignedBlessings[Classes.RedMage].Add(StartwithKIPlando[(int)Item.Tail]);
						break;

					case RmKeyItems.RmKeyItemsKey:
						assignedBlessings[Classes.RedMage].Add(StartwithKIPlando[(int)Item.Key]);
						break;
				}
			};

			if (flags.WMKeyItems != WMKeyItems.WMKeyItemsNone)

			{
				switch (flags.WMKeyItems)
				{
					case WMKeyItems.WMKeyItemsCrown:
						assignedBlessings[Classes.WhiteMage].Add(StartwithKIPlando[(int)Item.Crown]);
						break;

					case WMKeyItems.WMKeyItemsCrystal:
						assignedBlessings[Classes.WhiteMage].Add(StartwithKIPlando[(int)Item.Crystal]);
						break;

					case WMKeyItems.WMKeyItemsHerb:
						assignedBlessings[Classes.WhiteMage].Add(StartwithKIPlando[(int)Item.Herb]);
						break;

					case WMKeyItems.WMKeyItemsTNT:
						assignedBlessings[Classes.WhiteMage].Add(StartwithKIPlando[(int)Item.Tnt]);
						break;

					case WMKeyItems.WMKeyItemsAdamant:
						assignedBlessings[Classes.WhiteMage].Add(StartwithKIPlando[(int)Item.Adamant]);
						break;

					case WMKeyItems.WMKeyItemsSlab:
						assignedBlessings[Classes.WhiteMage].Add(StartwithKIPlando[(int)Item.Slab]);
						break;

					case WMKeyItems.WMKeyItemsRuby:
						assignedBlessings[Classes.WhiteMage].Add(StartwithKIPlando[(int)Item.Ruby]);
						break;

					case WMKeyItems.WMKeyItemsRod:
						assignedBlessings[Classes.WhiteMage].Add(StartwithKIPlando[(int)Item.Rod]);
						break;

					case WMKeyItems.WMKeyItemsChime:
						assignedBlessings[Classes.WhiteMage].Add(StartwithKIPlando[(int)Item.Chime]);
						break;

					case WMKeyItems.WMKeyItemsCube:
						assignedBlessings[Classes.WhiteMage].Add(StartwithKIPlando[(int)Item.Cube]);
						break;

					case WMKeyItems.WMKeyItemsBottle:
						assignedBlessings[Classes.WhiteMage].Add(StartwithKIPlando[(int)Item.Bottle]);
						break;

					case WMKeyItems.WMKeyItemsOxyale:
						assignedBlessings[Classes.WhiteMage].Add(StartwithKIPlando[(int)Item.Oxyale]);
						break;

					case WMKeyItems.WMKeyItemsLute:
						assignedBlessings[Classes.WhiteMage].Add(StartwithKIPlando[(int)Item.Lute]);
						break;

					case WMKeyItems.WMKeyItemsTail:
						assignedBlessings[Classes.WhiteMage].Add(StartwithKIPlando[(int)Item.Tail]);
						break;

					case WMKeyItems.WMKeyItemsKey:
						assignedBlessings[Classes.WhiteMage].Add(StartwithKIPlando[(int)Item.Key]);
						break;
				}
			};

			if (flags.BMKeyItems != BMKeyItems.BMKeyItemsNone)
			{
				switch (flags.BMKeyItems)
				{
					case BMKeyItems.BMKeyItemsCrown:
						assignedBlessings[Classes.BlackMage].Add(StartwithKIPlando[(int)Item.Crown]);
						break;

					case BMKeyItems.BMKeyItemsCrystal:
						assignedBlessings[Classes.BlackMage].Add(StartwithKIPlando[(int)Item.Crystal]);
						break;

					case BMKeyItems.BMKeyItemsHerb:
						assignedBlessings[Classes.BlackMage].Add(StartwithKIPlando[(int)Item.Herb]);
						break;

					case BMKeyItems.BMKeyItemsTNT:
						assignedBlessings[Classes.BlackMage].Add(StartwithKIPlando[(int)Item.Tnt]);
						break;

					case BMKeyItems.BMKeyItemsAdamant:
						assignedBlessings[Classes.BlackMage].Add(StartwithKIPlando[(int)Item.Adamant]);
						break;

					case BMKeyItems.BMKeyItemsSlab:
						assignedBlessings[Classes.BlackMage].Add(StartwithKIPlando[(int)Item.Slab]);
						break;

					case BMKeyItems.BMKeyItemsRuby:
						assignedBlessings[Classes.BlackMage].Add(StartwithKIPlando[(int)Item.Ruby]);
						break;

					case BMKeyItems.BMKeyItemsRod:
						assignedBlessings[Classes.BlackMage].Add(StartwithKIPlando[(int)Item.Rod]);
						break;

					case BMKeyItems.BMKeyItemsChime:
						assignedBlessings[Classes.BlackMage].Add(StartwithKIPlando[(int)Item.Chime]);
						break;

					case BMKeyItems.BMKeyItemsCube:
						assignedBlessings[Classes.BlackMage].Add(StartwithKIPlando[(int)Item.Cube]);
						break;

					case BMKeyItems.BMKeyItemsBottle:
						assignedBlessings[Classes.BlackMage].Add(StartwithKIPlando[(int)Item.Bottle]);
						break;

					case BMKeyItems.BMKeyItemsOxyale:
						assignedBlessings[Classes.BlackMage].Add(StartwithKIPlando[(int)Item.Oxyale]);
						break;

					case BMKeyItems.BMKeyItemsLute:
						assignedBlessings[Classes.BlackMage].Add(StartwithKIPlando[(int)Item.Lute]);
						break;

					case BMKeyItems.BMKeyItemsTail:
						assignedBlessings[Classes.BlackMage].Add(StartwithKIPlando[(int)Item.Tail]);
						break;

					case BMKeyItems.BMKeyItemsKey:
						assignedBlessings[Classes.BlackMage].Add(StartwithKIPlando[(int)Item.Key]);
						break;
				}
			};

			//Do the Stat and gold changes first
			//Gold function unknown at this time, may need a re-write
			#region FigherStatsGold
			if (flags.Fighterstr != FiStrpool.FiStrpoolnone)
			{
				int i = 0;
				switch (flags.Fighterstr)
				{
					case FiStrpool.Fiadd10Str:
						_classes[i].StrStarting = (byte)Math.Max(_classes[i].StrStarting + 10, 0);
						//assignedBlessings[Classes.Fighter].Add(bonuslist(BonusMalusAction.));
							break;

					case FiStrpool.Fiadd20Str:
						_classes[i].StrStarting = (byte)Math.Max(_classes[i].StrStarting + 20, 0);
						break;

					case FiStrpool.Fiadd40Str:
						_classes[i].StrStarting = (byte)Math.Max(_classes[i].StrStarting + 40, 0);
						break;

					case FiStrpool.Fiminus10Str:
						_classes[i].StrStarting = (byte)Math.Max(_classes[i].StrStarting - 10, 0);
						break;

					case FiStrpool.Fiminus20Str:
						_classes[i].StrStarting = (byte)Math.Max(_classes[i].StrStarting - 20, 0);
						break;
				}

			};
			if (flags.Fighteragi != FiAgipool.FiAgpoolinone)
			{
				int i = 0;
				switch(flags.Fighteragi)
				{
					case FiAgipool.Fiadd15Agi:
						_classes[i].AgiStarting = (byte)Math.Max(_classes[i].AgiStarting + 15, 0);
						break;

					case FiAgipool.Fiadd25Agi:
						_classes[i].AgiStarting = (byte)Math.Max(_classes[i].AgiStarting + 25, 0);
						break;

					case FiAgipool.Fiadd50Agi:
						_classes[i].AgiStarting = (byte)Math.Max(_classes[i].AgiStarting + 50, 0);
						break;

					case FiAgipool.Fiminus10Agi:
						_classes[i].AgiStarting = (byte)Math.Max(_classes[i].AgiStarting - 10, 0);
						break;

				}

			};
			if (flags.Fightervit != FiVitpool.FiVitpoolNone)
			{
				int i = 0;
				switch (flags.Fightervit)
				{
					case FiVitpool.Fiadd10Vit:
						_classes[i].VitStarting = (byte)Math.Max(_classes[i].VitStarting + 10, 0);
						break;

					case FiVitpool.Fiadd20Vit:
						_classes[i].VitStarting = (byte)Math.Max(_classes[i].VitStarting + 20, 0);
						break;

					case FiVitpool.Fiadd40Vit:
						_classes[i].VitStarting = (byte)Math.Max(_classes[i].VitStarting + 40, 0);
						break;

					case FiVitpool.Fiminus10Vit:
						_classes[i].VitStarting = (byte)Math.Max(_classes[i].VitStarting - 10, 0);
						break;

				}
			};
			if (flags.Fighterluck != FiLuckpool.FiLuckpoolNone)
			{
				int  i = 0;
				switch (flags.Fighterluck)
				{
					case FiLuckpool.Fiadd5Luck:
						_classes[i].LckStarting = (byte)Math.Max(_classes[i].LckStarting + 5, 0);
						break;

					case FiLuckpool.Fiadd10Luck:
						_classes[i].LckStarting = (byte)Math.Max(_classes[i].LckStarting + 10, 0);
						break;

					case FiLuckpool.Fiadd20Luck:
						_classes[i].LckStarting = (byte)Math.Max(_classes[i].LckStarting + 20, 0);
						break;

					case FiLuckpool.Fiminus5Luck:
						_classes[i].LckStarting = (byte)Math.Max(_classes[i].LckStarting - 10, 0);
						break;
				}
			};
			if (flags.FighterHP != FiHPPool.FiHPPoolNone)
			{
				int i = 0;
				switch (flags.FighterHP)
				{
					case FiHPPool.Fiadd20HP:
						_classes[i].HpStarting = (byte)Math.Max(_classes[i].HpStarting + 20, 1);
						break;

					case FiHPPool.Fiadd40HP:
						_classes[i].HpStarting = (byte)Math.Max(_classes[i].HpStarting + 40, 1);
						break;

					case FiHPPool.Fiadd80HP:
						_classes[i].HpStarting = (byte)Math.Max(_classes[i].HpStarting + 80, 1);
						break;

					case FiHPPool.Fiminus15HP:
						_classes[i].HpStarting = (byte)Math.Max(_classes[i].HpStarting - 15, 1);
						break;

					case FiHPPool.Fiminus30HP:
						_classes[i].HpStarting = (byte)Math.Max(_classes[i].HpStarting - 30, 1);
						break;
				}
			};
			if (flags.FighterHit != FiHitPercentpool.FiHitPercentpoolNone)
			{
				int i = 0;
				switch (flags.FighterHit)
				{
					case FiHitPercentpool.Fiadd10hit:
						_classes[i].HitStarting = (byte)Math.Max(_classes[i].HitStarting + 10, 0);
					break;

					case FiHitPercentpool.Fiadd20hit:
						_classes[i].HitStarting = (byte)Math.Max(_classes[i].HitStarting + 20, 0);
						break;

					case FiHitPercentpool.Fiminus10hit:
						_classes[i].HitStarting = (byte)Math.Max(_classes[i].HitStarting - 10, 0);
						break;
				}
			};
			if (flags.FighterMdef != FiMdefpool.FiMdefpoolNone)
			{
				int i = 0;
				switch (flags.FighterMdef)
				{
					case FiMdefpool.Fiadd10mdef:
						_classes[i].MDefStarting = (byte)Math.Max(_classes[i].MDefStarting + 10, 0);
						break;

					case FiMdefpool.Fiadd20mdef:
						_classes[i].MDefStarting = (byte)Math.Max(_classes[i].MDefStarting + 20, 0);
						break;

					case FiMdefpool.Fiminus10mdef:
						_classes[i].MDefStarting = (byte)Math.Max(_classes[i].MDefStarting - 10, 0);
						break;
				}
			};
			if (flags.FighterInt != FiIntpool.FiIntpoolNone)
			{
				int i = 0;
				switch (flags.FighterInt)
				{
					case FiIntpool.Fiadd10int:
						_classes[i].IntStarting = (byte)Math.Max(_classes[i].IntStarting + 10, 0);
						break;

					case FiIntpool.Fiadd20int:
						_classes[i].IntStarting = (byte)Math.Max(_classes[i].IntStarting + 20, 0);
						break;

					case FiIntpool.Fiadd40int:
						_classes[i].IntStarting = (byte)Math.Max(_classes[i].IntStarting + 40, 0);
						break;
				}

			};
			if (flags.Fightergold != FiGoldpool.FiGoldpoolNone) 
			{
				int i = 0;
				 
				switch (flags.Fightergold)
				{
					case FiGoldpool.Fiadd200gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(2, 0); 
						break;

					case FiGoldpool.Fiadd400gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(4, 0);
						break;

					case FiGoldpool.Fiadd600gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(6, 0);
						break;

					case FiGoldpool.Fiadd800gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(8, 0);
						break;

					case FiGoldpool.FIadd1500gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(15, 0);
						break;

					case FiGoldpool.Fiadd5000gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(50, 0);
						break;

					case FiGoldpool.Fiadd20000gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(200, 0);
						break;



				}

			};
			#endregion

			#region ThiefStatsGold
			if (flags.Thiefstr != ThStrpool.ThStrpoolNone)
			{
				int i = 1;
				switch (flags.Thiefstr)
				{
					case ThStrpool.Thadd10Str:
						_classes[i].StrStarting = (byte)Math.Max(_classes[i].StrStarting + 10, 0);
						break;

					case ThStrpool.Thadd20Str:
						_classes[i].StrStarting = (byte)Math.Max(_classes[i].StrStarting + 20, 0);
						break;

					case ThStrpool.Thadd40Str:
						_classes[i].StrStarting = (byte)Math.Max(_classes[i].StrStarting + 40, 0);
						break;

					case ThStrpool.Thminus10Str:
						_classes[i].StrStarting = (byte)Math.Max(_classes[i].StrStarting - 10, 0);
						break;

				}

			};
			if (flags.Thiefagi != ThAgipool.ThAgipoolNone)
			{
				int i = 1;
				switch (flags.Thiefagi)
				{
					case ThAgipool.Thadd15Agi:
						_classes[i].AgiStarting = (byte)Math.Max(_classes[i].AgiStarting + 15, 0);
						break;

					case ThAgipool.Thadd25Agi:
						_classes[i].AgiStarting = (byte)Math.Max(_classes[i].AgiStarting + 25, 0);
						break;

					case ThAgipool.Thadd50Agi:
						_classes[i].AgiStarting = (byte)Math.Max(_classes[i].AgiStarting + 50, 0);
						break;

					case ThAgipool.Thminus10Agi:
						_classes[i].AgiStarting = (byte)Math.Max(_classes[i].AgiStarting - 10, 0);
						break;

					case ThAgipool.Thminus20Agi:
						_classes[i].AgiStarting = (byte)Math.Max(_classes[i].AgiStarting - 20, 0);
						break;
				}
			};
			if (flags.Thiefvit != ThVitpool.ThVitpoolNone)
			{
				int i = 1;
				switch (flags.Thiefvit)
				{
					case ThVitpool.Thadd10Vit:
						_classes[i].VitStarting = (byte)Math.Max(_classes[i].VitStarting + 10, 0);
						break;

					case ThVitpool.Thadd20Vit:
						_classes[i].VitStarting = (byte)Math.Max(_classes[i].VitStarting + 20, 0);
						break;

					case ThVitpool.Thadd40Vit:
						_classes[i].VitStarting = (byte)Math.Max(_classes[i].VitStarting + 40, 0);
						break;

					case ThVitpool.Thminus10Vit:
						_classes[i].VitStarting = (byte)Math.Max(_classes[i].VitStarting - 10, 0);
						break;
				}
			};
			if (flags.Thiefluck != ThLuckpool.ThLuckpoolNone)
			{
				int i = 1;
				switch (flags.Thiefluck)
				{
					case ThLuckpool.Thadd5Luck:
						_classes[i].LckStarting = (byte)Math.Max(_classes[i].LckStarting + 5, 0);
						break;

					case ThLuckpool.Thadd10Luck:
						_classes[i].LckStarting = (byte)Math.Max(_classes[i].LckStarting + 10, 0);
						break;

					case ThLuckpool.Thminus5luck:
						_classes[i].LckStarting = (byte)Math.Max(_classes[i].LckStarting - 5, 0);
						break;

					case ThLuckpool.Thminus10Luck:
						_classes[i].LckStarting = (byte)Math.Max(_classes[i].LckStarting - 10, 0);
						break;
				}	

			};
			if (flags.ThiefHP != ThHPPool.ThHPPoolNone)
			{
				int i = 1;
				switch (flags.ThiefHP)
				{
					case ThHPPool.Thadd20HP:
						_classes[i].HpStarting = (byte)Math.Max(_classes[i].HpStarting + 20, 0);
						break;

					case ThHPPool.Thadd40HP:
						_classes[i].HpStarting = (byte)Math.Max(_classes[i].HpStarting + 40, 0);
						break;

					case ThHPPool.Thadd80HP:
						_classes[i].HpStarting = (byte)Math.Max(_classes[i].HpStarting + 80, 0);
						break;

					case ThHPPool.Thminus15HP:
						_classes[i].HpStarting = (byte)Math.Max(_classes[i].HpStarting - 15, 0);
						break;

					case ThHPPool.Thminus30HP:
						_classes[i].HpStarting = (byte)Math.Max(_classes[i].HpStarting - 30, 0);
						break;

					}
			};
			if (flags.ThiefHit != ThHitPercentpool.ThHitPercentpoolNone)
			{
				int i = 1;
				switch (flags.ThiefHit)
				{
					case ThHitPercentpool.Thadd10hit:
						_classes[i].HitStarting = (byte)Math.Max(_classes[i].HitStarting + 10, 0);
						break;

					case ThHitPercentpool.Thadd20hit:
						_classes[i].HitStarting = (byte)Math.Max(_classes[i].HitStarting + 20, 0);
						break;

					case ThHitPercentpool.Thminus10hit:
						_classes[i].HitStarting = (byte)Math.Max(_classes[i].HitStarting - 10, 0);
						break;

				}

			};
			if (flags.ThiefMdef != ThMdefpool.ThMdefpoolNone)
			{
				int i = 1;
				switch (flags.ThiefMdef)
				{
					case ThMdefpool.Thadd10mdef:
						_classes[i].MDefStarting = (byte)Math.Max(_classes[i].MDefStarting + 10, 0);
						break;

					case ThMdefpool.Thadd20mdef:
						_classes[i].MDefStarting = (byte)Math.Max(_classes[i].MDefStarting + 20, 0);
						break;

					case ThMdefpool.Thminus10mdef:
						_classes[i].MDefStarting = (byte)Math.Max(_classes[i].MDefStarting - 10, 0);
						break;
				}
			};
			if (flags.ThiefInt != ThIntpool.ThIntpoolNone)
			{
				int i = 1;
				switch (flags.ThiefInt)
				{
					case ThIntpool.Thadd10int:
						_classes[i].IntStarting = (byte)Math.Max(_classes[i].IntStarting +  10, 0);
						break;

					case ThIntpool.Thadd20int:
						_classes[i].IntStarting = (byte)Math.Max(_classes[i].IntStarting + 20, 0);
						break;

					case ThIntpool.Thminus10int:
						_classes[i].IntStarting = (byte)Math.Max(_classes[i].IntStarting - 10, 0);
						break;

				}

			};
			if (flags.Thiefgold != ThGoldpool.ThGoldpoolNone)
			{
				int i = 1;
				switch (flags.Thiefgold)
				{
					case ThGoldpool.Thadd200gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(2, 0);
						break;

					case ThGoldpool.Thadd400gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(4, 0);
						break;

					case ThGoldpool.Thadd600gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(6, 0);
						break;

					case ThGoldpool.Thadd800gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(8, 0);
						break;

					case ThGoldpool.Thadd1400gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(14, 0);
						break;

					case ThGoldpool.Thadd1500gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(15, 0);
						break;

					case ThGoldpool.Thadd2000gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(20, 0);
						break;

					case ThGoldpool.Thadd3000gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(30, 0);
						break;

					case ThGoldpool.Thadd4000gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(40, 0);
						break;

					case ThGoldpool.Thadd6000gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(60, 0);
						break;

					case ThGoldpool.Thadd20000gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(200, 0);
						break;

					case ThGoldpool.Thminus50gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(-5, 0);
						break;

					case ThGoldpool.Thminus100gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(-10, 0);
						break;

					case ThGoldpool.Thminus150gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(-15, 0);
						break;

					case ThGoldpool.Thminus350gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(-35, 0);
						break;

					case ThGoldpool.Thminus1100gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(-110, 0);
						break;
				}

			};
			#endregion

			#region BBStatsGold
			if (flags.BBStr != BBStrpool.BBStrpoolNone)
			{
				int i = 2;
				switch (flags.BBStr)
				{
					case BBStrpool.BBadd10Str:
						_classes[i].StrStarting = (byte)Math.Max(_classes[i].StrStarting + 10, 0);
						break;

					case BBStrpool.BBadd20Str:
						_classes[i].StrStarting = (byte)Math.Max(_classes[i].StrStarting + 20, 0);
						break;

					case BBStrpool.BBadd40Str:
						_classes[i].StrStarting = (byte)Math.Max(_classes[i].StrStarting + 40, 0);
						break;
				}
			};
			if (flags.BBAgi != BBAgipool.BBAgipoolNone)
			{
				int i = 2;
				switch (flags.BBAgi)
				{
					case BBAgipool.BBadd15Agi:
						_classes[i].AgiStarting = (byte)Math.Max(_classes[i].AgiStarting + 15, 0);
						break;

					case BBAgipool.BBadd25Agi:
						_classes[i].AgiStarting = (byte)Math.Max(_classes[i].AgiStarting + 25, 0);
						break;

					case BBAgipool.BBadd50Agi:
						_classes[i].AgiStarting = (byte)Math.Max(_classes[i].AgiStarting + 50, 0);
						break;

					case BBAgipool.BBminus10Agi:
						_classes[i].AgiStarting = (byte)Math.Max(_classes[i].AgiStarting - 10, 0);
						break;
				}
			};
			if (flags.BBVit != BBVitpool.BBVitpoolNone)
			{
				int i = 2;
				switch (flags.BBVit)
				{
					case BBVitpool.BBadd10Vit:
						_classes[i].VitStarting = (byte)Math.Max(_classes[i].VitStarting + 10, 0);
						break;

					case BBVitpool.BBadd20Vit:
						_classes[i].VitStarting = (byte)Math.Max(_classes[i].VitStarting + 20, 0);
						break;

					case BBVitpool.BBadd40Vit:
						_classes[i].VitStarting = (byte)Math.Max(_classes[i].VitStarting + 40, 4);
						break;

					case BBVitpool.BBminus10Vit:
						_classes[i].VitStarting = (byte)Math.Max(_classes[i].VitStarting - 10, 0);
						break;

					case BBVitpool.BBminus20Vit:
						_classes[i].VitStarting = (byte)Math.Max(_classes[i].VitStarting - 20, 0);
						break;

				}
			};
			if (flags.BBLuck != BBLuckpool.BBBLuckpoolNone)
			{
				int i = 2;
				switch (flags.BBLuck)
				{
					case BBLuckpool.BBadd5Luck:
						_classes[i].LckStarting = (byte)Math.Max(_classes[i].LckStarting + 5, 0);
						break;

					case BBLuckpool.BBadd10Luck:
						_classes[i].LckStarting = (byte)Math.Max(_classes[i].LckStarting + 10, 0);
						break;

					case BBLuckpool.BBadd15Luck:
						_classes[i].LckStarting = (byte)Math.Max(_classes[i].LckStarting + 15, 0);
						break;

					case BBLuckpool.BBminus5luck:
						_classes[i].LckStarting = (byte)Math.Max(_classes[i].LckStarting - 5, 0);
						break;
				}
			};
			if (flags.BBHP != BBHPPool.BBHPPoolNone)
			{
				int i = 2;
				switch (flags.BBHP)
				{
					case BBHPPool.BBadd20HP:
						_classes[i].HpStarting = (byte)Math.Max(_classes[i].HpStarting + 20, 0);
						break;

					case BBHPPool.BBadd40HP:
						_classes[i].HpStarting = (byte)Math.Max(_classes[i].HpStarting + 40, 0);
						break;

					case BBHPPool.BBadd80HP:
						_classes[i].HpStarting = (byte)Math.Max(_classes[i].HpStarting + 80, 0);
						break;

					case BBHPPool.BBminus15HP:
						_classes[i].HpStarting = (byte)Math.Max(_classes[i].HpStarting - 15, 0);
						break;

					case BBHPPool.BBminus30HP:
						_classes[i].HpStarting = (byte)Math.Max(_classes[i].HpStarting - 30, 0);
						break;
				}
			};
			if (flags.BBHit != BBHitPercentpool.BBHitPercentpoolNone)
			{
				int i = 2;
				switch (flags.BBHit)
				{
					case BBHitPercentpool.BBadd10hit:
						_classes[i].HitStarting = (byte)Math.Max(_classes[i].HitStarting + 10, 0);
						break;

					case BBHitPercentpool.BBadd20hit:
						_classes[i].HitStarting = (byte)Math.Max(_classes[i].HitStarting + 20, 0);
						break;

					case BBHitPercentpool.BBminus10hit:
						_classes[i].HitStarting = (byte)Math.Max(_classes[i].HitStarting - 10, 0);
						break;
				}
			};
			if (flags.BBMdef != BBMdefpool.BBBMdefpoolNone)
			{
				int i = 2;
				switch (flags.BBMdef)
				{
					case BBMdefpool.BBadd10mdef:
						_classes[i].MDefStarting = (byte)Math.Max(_classes[i].MDefStarting + 10, 0);
						break;

					case BBMdefpool.BBadd20mdef:
						_classes[i].MDefStarting = (byte)Math.Max(_classes[i].MDefStarting + 20, 0);
						break;

					case BBMdefpool.BBminus10mdef:
						_classes[i].MDefStarting = (byte)Math.Max(_classes[i].MDefStarting - 10, 0);
						break;
				}
			};
			if (flags.BBGold != BBGoldpool.BBGoldpoolNone)
			{
				int i = 2;
				switch (flags.BBGold)
				{
					case BBGoldpool.BBadd200gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(2, 0);
						break;

					case BBGoldpool.BBadd400gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(4, 0);
						break;

					case BBGoldpool.BBadd600gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(6, 0);
						break;

					case BBGoldpool.BBadd800gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(8, 0);
						break;

					case BBGoldpool.BBadd1500gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(15, 0);
						break;

					case BBGoldpool.BBadd5000gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(50, 0);
						break;

					case BBGoldpool.BBadd20000gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(200, 0);
						break;

					case BBGoldpool.BBminus50gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(-5, 0);
						break;

					case BBGoldpool.BBminus100gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(-10, 0);
						break;

					case BBGoldpool.BBminus150gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(-15, 0);
						break;

					case BBGoldpool.BBminus350gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(-35, 0);
						break;

					case BBGoldpool.BBminus1100gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(-110, 0);
						break;
				}

			};
			#endregion

			#region RedMageStatsGold
			if (flags.Rmstr != RMStrpool.RMStrpoolNone)
			{
				int i = 3;
				switch (flags.Rmstr)
				{
					case RMStrpool.RMadd10Str:
						_classes[i].StrStarting = (byte)Math.Max(_classes[i].StrStarting + 10, 0);
						break;

					case RMStrpool.RMadd20Str:
						_classes[i].StrStarting = (byte)Math.Max(_classes[i].StrStarting + 20, 0);
						break;

					case RMStrpool.RMadd40Str:
						_classes[i].StrStarting = (byte)Math.Max(_classes[i].StrStarting + 40, 0);
						break;

					case RMStrpool.RMminus10Str:
						_classes[i].StrStarting = (byte)Math.Max(_classes[i].StrStarting - 10, 0);
						break;
				}
			};
			if (flags.Rmagi != RMAgipool.RMAgipoolNone)
			{
				int i = 3;
				switch (flags.Rmagi)
				{
					case RMAgipool.RMadd15Agi:
						_classes[i].AgiStarting = (byte)Math.Max(_classes[i].AgiStarting + 15, 0);
						break;

					case RMAgipool.RMadd25Agi:
						_classes[i].AgiStarting = (byte)Math.Max(_classes[i].AgiStarting + 25, 0);
						break;

					case RMAgipool.RMadd50Agi:
						_classes[i].AgiStarting = (byte)Math.Max(_classes[i].AgiStarting + 50, 0);
						break;

					case RMAgipool.RMminus10Agi:
						_classes[i].AgiStarting = (byte)Math.Max(_classes[i].AgiStarting + 10, 0);
						break;
				}
			};
			if (flags.Rmvit != RMVitpool.RMmVitpoolNone)
			{
				int i = 3;
				switch(flags.Rmvit)
				{
					case RMVitpool.RMadd10Vit:
						_classes[i].VitStarting = (byte)Math.Max(_classes[i].VitStarting + 10, 0);
						break;

					case RMVitpool.RMadd20Vit:
						_classes[i].VitStarting = (byte)Math.Max(_classes[i].VitStarting + 20, 0);
						break;

					case RMVitpool.RMadd40Vit:
						_classes[i].VitStarting = (byte)Math.Max(_classes[i].VitStarting + 40, 0);
						break;

					case RMVitpool.RMminus10Vit:
						_classes[i].VitStarting = (byte)Math.Max(_classes[i].VitStarting - 10, 0);
						break;
				}
			};
			if (flags.Rmluck != RMLuckpool.RMmLuckpoolNone)
			{
				int i = 3;
				switch (flags.Rmluck)
				{
					case RMLuckpool.RMadd5Luck:
						_classes[i].LckStarting = (byte)Math.Max(_classes[i].LckStarting + 5, 0);
						break;

					case RMLuckpool.RMadd10Luck:
						_classes[i].LckStarting = (byte)Math.Max(_classes[i].LckStarting + 10, 0);
						break;

					case RMLuckpool.RMadd15Luck:
						_classes[i].LckStarting = (byte)Math.Max(_classes[i].LckStarting + 15, 0);
						break;

					case RMLuckpool.RMminus5luck:
						_classes[i].LckStarting = (byte)Math.Max(_classes[i].LckStarting - 5, 0);
						break;
				}
			};
			if (flags.RmHP != RMHPPool.RMHPPoolNone)
			{
				int i = 3;
				switch (flags.RmHP)
				{
					case RMHPPool.RMadd20HP:
						_classes[i].HpStarting = (byte)Math.Max(_classes[i].HpStarting + 20, 0);
						break;

					case RMHPPool.RMadd40HP:
						_classes[i].HpStarting = (byte)Math.Max(_classes[i].HpStarting + 40, 0);
						break;

					case RMHPPool.RMadd80HP:
						_classes[i].HpStarting = (byte)Math.Max(_classes[i].HpStarting + 80, 0);
						break;

					case RMHPPool.RMminus15HP:
						_classes[i].HpStarting = (byte)Math.Max(_classes[i].HpStarting - 15, 0);
						break;

					case RMHPPool.RMminus30HP:
						_classes[i].HpStarting = (byte)Math.Max(_classes[i].HpStarting - 30, 0);
						break;
				}
			};
			if (flags.Rmhit != RMHitPercentpool.RMHitPercentpoolNone)
			{
				int i = 3;
				switch (flags.Rmhit)
				{
					case RMHitPercentpool.RMadd10hit:
						_classes[i].HitStarting = (byte)Math.Max(_classes[i].HitStarting + 10, 0);
						break;

					case RMHitPercentpool.RMadd20hit:
						_classes[i].HitStarting = (byte)Math.Max(_classes[i].HitStarting + 20, 0);
						break;

					case RMHitPercentpool.RMminus10hit:
						_classes[i].HitStarting = (byte)Math.Max(_classes[i].HitStarting - 10, 0);
						break;
				}
			};
			if (flags.Rmmdef != RMMdefpool.RMdefpoolNone)
			{
				int i = 3;
				switch (flags.Rmmdef)
				{
					case RMMdefpool.RMadd10mdef:
						_classes[i].MDefStarting = (byte)Math.Max(_classes[i].MDefStarting + 10, 0);
						break;

					case RMMdefpool.RMadd20mdef:
						_classes[i].MDefStarting = (byte)Math.Max(_classes[i].MDefStarting + 20, 0);
						break;

					case RMMdefpool.RMminus10mdef:
						_classes[i].MDefStarting = (byte)Math.Max(_classes[i].MDefStarting - 10, 0);
						break;

				}
			};
			if (flags.Rmint != RMIntpool.RMIntpoolNone)
			{
				int i = 3;
				switch (flags.Rmint)
				{
					case RMIntpool.RMadd10int:
						_classes[i].IntStarting = (byte)Math.Max(_classes[i].IntStarting + 10, 0);
						break;

					case RMIntpool.RMadd20int:
						_classes[i].IntStarting = (byte)Math.Max(_classes[i].IntStarting + 20, 0);
						break;

					case RMIntpool.RMadd40int:
						_classes[i].IntStarting = (byte)Math.Max(_classes[i].IntStarting + 40, 0);
						break;

					case RMIntpool.RMminus10int:
						_classes[i].IntStarting = (byte)Math.Max(_classes[i].IntStarting - 10, 0);
						break;

					case RMIntpool.RMminus20int:
						_classes[i].IntStarting = (byte)Math.Max(_classes[i].IntStarting - 20, 0);
						break;
				}
			};
			if (flags.Rmgold != RMGoldpool.RMGoldpoolNone)
			{
				int i = 3;
				switch (flags.Rmgold)
				{
					case RMGoldpool.RMadd200gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(2, 0);
						break;

					case RMGoldpool.RMadd400gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(4, 0);
						break;

					case RMGoldpool.RMadd600gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(6, 0);
						break;

					case RMGoldpool.RMadd800gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(8, 0);
						break;

					case RMGoldpool.RMadd1500gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(15, 0);
						break;

					case RMGoldpool.RMadd5000gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(50, 0);
						break;

					case RMGoldpool.RMadd20000gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(200, 0);
						break;

					case RMGoldpool.RMminus50gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(-5, 0);
						break;

					case RMGoldpool.RMminus100gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(-10, 0);
						break;

					case RMGoldpool.RMminus150gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(-15, 0);
						break;

					case RMGoldpool.RMminus350gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(-35, 0);
						break;

					case RMGoldpool.RMminus1100gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(-110, 0);
						break;
				}

			};
			#endregion

			#region WhiteMageStatsGold
			if (flags.Wmstr != WMStrpool.WMStrpoolNone)
			{
				int i = 4;
				switch (flags.Wmstr)
				{
					case WMStrpool.WMadd10Str:
						_classes[i].StrStarting = (byte)Math.Max(_classes[i].StrStarting + 10, 0);
						break;

					case WMStrpool.WMadd20Str:
						_classes[i].StrStarting = (byte)Math.Max(_classes[i].StrStarting + 20, 0);
						break;

					case WMStrpool.WMadd40Str:
						_classes[i].StrStarting = (byte)Math.Max(_classes[i].StrStarting + 40, 0);
						break;

					case WMStrpool.WMminus10Str:
						_classes[i].StrStarting = (byte)Math.Max(_classes[i].StrStarting - 10, 0);
						break;
				}
			};
			if (flags.Wmagi != WMAgipool.WMAgipoolNone)
			{
				int i = 4;
				switch (flags.Wmagi)
				{
					case WMAgipool.WMadd15Agi:
						_classes[i].AgiStarting = (byte)Math.Max(_classes[i].AgiStarting + 15, 0);
						break;

					case WMAgipool.WMadd25Agi:
						_classes[i].AgiStarting = (byte)Math.Max(_classes[i].AgiStarting + 25, 0);
						break;

					case WMAgipool.WMadd50Agi:
						_classes[i].AgiStarting = (byte)Math.Max(_classes[i].AgiStarting + 50, 0);
						break;

					case WMAgipool.WMminus10Agi:
						_classes[i].AgiStarting = (byte)Math.Max(_classes[i].AgiStarting - 10, 0);
						break;
				}
			};
			if (flags.Wmvit != WMVitpool.WMVitpoolNone)
			{
				int i = 4;
				switch (flags.Wmvit)
				{
					case WMVitpool.WMadd10Vit:
						_classes[i].VitStarting = (byte)Math.Max(_classes[i].VitStarting + 10, 0);
						break;

					case WMVitpool.WMadd20Vit:
						_classes[i].VitStarting = (byte)Math.Max(_classes[i].VitStarting + 20, 0);
						break;

					case WMVitpool.WMadd40Vit:
						_classes[i].VitStarting = (byte)Math.Max(_classes[i].VitStarting + 40, 0);
						break;

					case WMVitpool.WMminus10Vit:
						_classes[i].VitStarting = (byte)Math.Max(_classes[i].VitStarting - 10, 0);
						break;
				}
			};
			if (flags.Wmluck != WMLuckpool.WMLuckpoolNone)
			{
				int i = 4;
				switch (flags.Wmluck)
				{
					case WMLuckpool.WMadd5Luck:
						_classes[i].LckStarting = (byte)Math.Max(_classes[i].LckStarting + 5, 0);
						break;

					case WMLuckpool.WMadd10Luck:
						_classes[i].LckStarting = (byte)Math.Max(_classes[i].LckStarting + 10, 0);
						break;

					case WMLuckpool.WMadd15Luck:
						_classes[i].LckStarting = (byte)Math.Max(_classes[i].LckStarting + 15, 0);
						break;

					case WMLuckpool.WMminus5luck:
						_classes[i].LckStarting = (byte)Math.Max(_classes[i].LckStarting - 5, 0);
						break;
				}
			};
			if (flags.WmHP != WMHPPool.WMHPPoolNone)
			{
				int i = 4;
				switch (flags.WmHP)
				{
					case WMHPPool.WMadd20HP:
						_classes[i].HpStarting = (byte)Math.Max(_classes[i].HpStarting + 20, 0);
						break;

					case WMHPPool.WMadd40HP:
						_classes[i].HpStarting = (byte)Math.Max(_classes[i].HpStarting + 40, 0);
						break;

					case WMHPPool.WMadd80HP:
						_classes[i].HpStarting = (byte)Math.Max(_classes[i].HpStarting + 80, 0);
						break;

					case WMHPPool.WMminus15HP:
						_classes[i].HpStarting = (byte)Math.Max(_classes[i].HpStarting - 15, 0);
						break;

					case WMHPPool.WMminus30HP:
						_classes[i].HpStarting = (byte)Math.Max(_classes[i].HpStarting - 30, 0);
						break;
				}
			};
			if (flags.Wmhit != WMHitPercentpool.WMHitPercentpoolNone)
			{
				int i = 4;
				switch (flags.Wmhit)
				{
					case WMHitPercentpool.WMadd10hit:
						_classes[i].HitStarting = (byte)Math.Max(_classes[i].HitStarting + 10, 0);
						break;

					case WMHitPercentpool.WMadd20hit:
						_classes[i].HitStarting = (byte)Math.Max(_classes[i].HitStarting + 20, 0);
						break;

					case WMHitPercentpool.WMminus10hit:
						_classes[i].HitStarting = (byte)Math.Max(_classes[i].HitStarting - 10, 0);
						break;
				}
			};
			if (flags.Wmmdef != WMMdefpool.WMMdefpoolNone)
			{
				int i = 4;
				switch (flags.Wmmdef)
				{
					case WMMdefpool.WMadd10mdef:
						_classes[i].MDefStarting = (byte)Math.Max(_classes[i].MDefStarting + 10, 0);
						break;

					case WMMdefpool.WMadd20mdef:
						_classes[i].MDefStarting = (byte)Math.Max(_classes[i].MDefStarting + 20, 0);
						break;

					case WMMdefpool.WMminus10mdef:
						_classes[i].MDefStarting = (byte)Math.Max(_classes[i].MDefStarting - 10, 0);
						break;
				}
			};
			if (flags.Wmint != WMIntpool.WMIntpoolNone)
			{
				int i = 4;
				switch (flags.Wmint)
				{
					case WMIntpool.WMadd10int:
						_classes[i].IntStarting = (byte)Math.Max(_classes[i].IntStarting + 10, 0);
						break;

					case WMIntpool.WMadd20int:
						_classes[i].IntStarting = (byte)Math.Max(_classes[i].IntStarting + 20, 0);
						break;

					case WMIntpool.WMadd40int:
						_classes[i].IntStarting = (byte)Math.Max(_classes[i].IntStarting + 40, 0);
						break;

					case WMIntpool.WMminus10int:
						_classes[i].IntStarting = (byte)Math.Max(_classes[i].IntStarting - 10, 0);
						break;

					case WMIntpool.WMminus20int:
						_classes[i].IntStarting = (byte)Math.Max(_classes[i].IntStarting - 20, 0);
						break;
				}
			};
			if (flags.Wmgold != WMGoldpool.WMGoldpoolNone)
			{
				int i = 4;
				switch (flags.Wmgold)
				{
					case WMGoldpool.WMadd200gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(2, 0);
						break;

					case WMGoldpool.WMadd400gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(4, 0);
						break;

					case WMGoldpool.WMadd600gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(6, 0);
						break;

					case WMGoldpool.WMadd800gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(8, 0);
						break;

					case WMGoldpool.WMadd1500gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(15, 0);
						break;

					case WMGoldpool.WMadd5000gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(50, 0);
						break;

					case WMGoldpool.WMadd20000gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(200, 0);
						break;

					case WMGoldpool.WMminus50gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(-5, 0);
						break;

					case WMGoldpool.WMminus100gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(-10, 0);
						break;

					case WMGoldpool.WMminus150gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(-15, 0);
						break;

					case WMGoldpool.WMminus350gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(-35, 0);
						break;

					case WMGoldpool.WMminus1100gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(-110, 0);
						break;

				}
			};
			#endregion

			#region BlackMageStatsGold
			if (flags.Bmstr != BMStrpool.BMStrpoolnone)
			{
				int i = 5;
				switch(flags.Bmstr)
				{
					case BMStrpool.BMadd10Str:
						_classes[i].StrStarting = (byte)Math.Max(_classes[i].StrStarting + 10, 0);
						break;

					case BMStrpool.BMadd20Str:
						_classes[i].StrStarting = (byte)Math.Max(_classes[i].StrStarting + 20, 0);
						break;

					case BMStrpool.BMadd40Str:
						_classes[i].StrStarting = (byte)Math.Max(_classes[i].StrStarting + 40, 0);
						break;

					case BMStrpool.BMminus10Str:
						_classes[i].StrStarting = (byte)Math.Max(_classes[i].StrStarting - 10, 0);
						break;
				}
			};
			if (flags.Bmagi != BMAgipool.BMAgipoolnone)
			{
				int i = 5;
				switch (flags.Bmagi)
				{
					case BMAgipool.BMadd15Agi:
						_classes[i].AgiStarting = (byte)Math.Max(_classes[i].AgiStarting + 15, 0);
						break;

					case BMAgipool.BMadd25Agi:
						_classes[i].AgiStarting = (byte)Math.Max(_classes[i].AgiStarting + 25, 0);
						break;

					case BMAgipool.BMadd50Agi:
						_classes[i].AgiStarting = (byte)Math.Max(_classes[i].AgiStarting + 50, 0);
						break;

					case BMAgipool.BMminus10Agi:
						_classes[i].AgiStarting = (byte)Math.Max(_classes[i].AgiStarting - 10, 0);
						break;
				}
			};
			if (flags.Bmvit != BMVitpool.BMVitpoolnone)
			{
				int i = 5;
				switch (flags.Bmvit)
				{
					case BMVitpool.BMadd10Vit:
						_classes[i].VitStarting = (byte)Math.Max(_classes[i].VitStarting + 10, 0);
						break;

					case BMVitpool.BMadd20Vit:
						_classes[i].VitStarting = (byte)Math.Max(_classes[i].VitStarting + 20, 0);
						break;

					case BMVitpool.BMadd40Vit:
						_classes[i].VitStarting = (byte)Math.Max(_classes[i].VitStarting + 40, 0);
						break;

					case BMVitpool.BMminus10Vit:
						_classes[i].VitStarting = (byte)Math.Max(_classes[i].VitStarting - 10, 0);
						break;
				}
			};
			if (flags.Bmluck != BMLuckpool.BMLuckpoolnone)
			{
				int i = 5;
				switch (flags.Bmluck)
				{
					case BMLuckpool.BMadd5Luck:
						_classes[i].LckStarting = (byte)Math.Max(_classes[i].LckStarting + 5, 0);
						break;

					case BMLuckpool.BMadd10Luck:
						_classes[i].LckStarting = (byte)Math.Max(_classes[i].LckStarting + 10, 0);
						break;

					case BMLuckpool.BMadd15Luck:
						_classes[i].LckStarting = (byte)Math.Max(_classes[i].LckStarting + 15, 0);
						break;

					case BMLuckpool.BMminus10Luck:
						_classes[i].LckStarting = (byte)Math.Max(_classes[i].LckStarting  - 10, 0);
						break;


				}
			};
			if (flags.BmHP != BMHPPool.BMHPPoolnone)
			{
				int i = 5;
				switch (flags.BmHP)
				{
					case BMHPPool.BMadd20HP:
						_classes[i].HpStarting = (byte)Math.Max(_classes[i].HpStarting + 20, 0);
						break;

					case BMHPPool.BMadd40HP:
						_classes[i].HpStarting = (byte)Math.Max(_classes[i].HpStarting + 40, 0);
						break;

					case BMHPPool.BMadd80HP:
						_classes[i].HpStarting = (byte)Math.Max(_classes[i].HpStarting + 80, 0);
						break;

					case BMHPPool.BMminus15HP:
						_classes[i].HpStarting = (byte)Math.Max(_classes[i].HpStarting - 15, 0);
						break;

					case BMHPPool.BMminus30HP:
						_classes[i].HpStarting = (byte)Math.Max(_classes[i].HpStarting - 30, 0);
						break;
				}
			};
			if (flags.Bmmdef != BMMdefpool.BMMdefpoolnone)
			{
				int i = 5;
				switch (flags.Bmmdef)
				{
					case BMMdefpool.BMadd10mdef:
						_classes[i].MDefStarting = (byte)Math.Max(_classes[i].MDefStarting + 10, 0);
						break;

					case BMMdefpool.BMadd20mdef:
						_classes[i].MDefStarting = (byte)Math.Max(_classes[i].MDefStarting + 20, 0);
						break;

					case BMMdefpool.BMminus10mdef:
						_classes[i].MDefStarting = (byte)Math.Max(_classes[i].MDefStarting - 10, 0);
						break;
				}
			};
			if (flags.Bmint != BMIntpool.BMIntpoolNone)
			{
				int i = 5;
				switch (flags.Bmint)
				{
					case BMIntpool.BMadd10int:
						_classes[i].IntStarting = (byte)Math.Max(_classes[i].IntStarting + 10, 0);
						break;

					case BMIntpool.BMadd20int:
						_classes[i].IntStarting = (byte)Math.Max(_classes[i].IntStarting + 20, 0);
						break;

					case BMIntpool.BMadd40int:
						_classes[i].IntStarting = (byte)Math.Max(_classes[i].IntStarting + 40, 0);
						break;

					case BMIntpool.BMminus10int:
						_classes[i].IntStarting = (byte)Math.Max(_classes[i].IntStarting - 10, 0);
						break;

					case BMIntpool.BMmins20int:
						_classes[i].IntStarting = (byte)Math.Max(_classes[i].IntStarting - 20, 0);
						break;
				}
			};
			if (flags.Bmgold != BMGoldpool.BMGoldpoolnone)
			{
				int i = 5;
				switch (flags.Bmgold)
				{

					case BMGoldpool.BMadd200gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(2, 0);
						break;

					case BMGoldpool.BMadd400gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(4, 0);
						break;

					case BMGoldpool.BMadd600gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(6, 0);
						break;

					case BMGoldpool.BMadd800gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(8, 0);
						break;

					case BMGoldpool.BMadd1500gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(15, 0);
						break;

					case BMGoldpool.BMadd5000gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(50, 0);
						break;

					case BMGoldpool.BMadd20000gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(200, 0);
						break;

					case BMGoldpool.BMminus50gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(-5, 0);
						break;

					case BMGoldpool.BMminus100gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(-10, 0);
						break;

					case BMGoldpool.BMminus150gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(-15, 0);
						break;

					case BMGoldpool.BMminus350gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(-35, 0);
						break;

					case BMGoldpool.BMminus1100gold:
						_classes[i].StartWithGold = (BlursesStartWithGold)Math.Max(-110, 0);
						break;
				}
			};
			#endregion


			validClasses = new() { Classes.Fighter, Classes.Thief, Classes.BlackBelt, Classes.RedMage, Classes.WhiteMage, Classes.BlackMage };

			foreach (var gameclass in validClasses)
			{

				var blessingstring = string.Join("\n\n", assignedBlessings[gameclass].Select(b => b.Description.ToList()));
				var malusesstring = string.Join("\n\n", assignedMaluses[gameclass].Select(b => b.Description.ToList()));

				descriptionList.Add(blessingstring + "\n\n\nMALUS\n\n" + malusesstring);
			}


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

