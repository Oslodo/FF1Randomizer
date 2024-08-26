using FF1Lib.Helpers;
using RomUtilities;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
			#region FigherStats
			if (flags.Fighterstr != FiStrpool.FiStrpoolnone)
			{
				int i = 0;
				switch (flags.Fighterstr)
				{
					case FiStrpool.Fiadd10Str:
						_classes[i].StrStarting = (byte)Math.Max(_classes[i].StrStarting + 10, 0);
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
			if (flags.Fightergold != FiGoldpool.FiGoldpoolNone) //unsure if this code will function, will write it and test it later
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

			#region ThiefStats
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

