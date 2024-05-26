using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Diagnostics.SymbolStore;
using System.Runtime.CompilerServices;
using System.Security;
using static FF1Lib.FF1Rom;

namespace FF1Lib.League
{
	public class LeaugeFlagsViewModel : INotifyPropertyChanged
	{

		//is this needed? Need to Check later....
		/*public LeagueFlagsViewModel()
		{
			Leagueflags = new LeagueFlags();

		}*/

		public string Encoded => LeagueFlags.EncodeFlagsText(Leagueflags);

		public event PropertyChangedEventHandler PropertyChanged;

		private void RaisePropertyChanged([CallerMemberName] string property = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
		}

		public (string name, LeagueFlags Leagueflags, IEnumerable<string> log) FromJson(string json) => LeagueFlags.FromJson(json);
		private LeagueFlags _Leagueflags;

		public LeagueFlags Leagueflags
		{
			get => _Leagueflags;
			set
			{
				_Leagueflags = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Flags"));
			}
		}
		#region League
		#region Fighter

		#endregion
		public bool Add10Str
		{
			get => Leagueflags.Add10Str;
			set
			{
				Leagueflags.Add10Str = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Add10Str"));
			}

		}
		public bool Add20Str
		{
			get => Leagueflags.Add20Str;
			set
			{
				Leagueflags.Add20Str = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Add20Str"));
			}
		}
		public bool Add15Agi
		{
			get => Leagueflags.Add15Agi;
			set
			{
				Leagueflags.Add15Agi = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Add15Agi"));
			}
		}

		public bool Add20Agi
		{
			get => Leagueflags.Add20Agi;
			set
			{
				Leagueflags.Add20Agi = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Add20Agi"));
			}
		}

		public bool Add25Agi
		{
			get => Leagueflags.Add25Agi;
			set
			{
				Leagueflags.Add25Agi = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Add25Agi"));
			}
		}

		public bool Add10Vit
		{
			get => Leagueflags.Add10Vit;
			set
			{
				Leagueflags.Add10Vit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Add10Vit"));
			}

		}
		public bool Add20Vit
		{
			get => Leagueflags.Add20Vit;
			set
			{
				Leagueflags.Add20Vit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Add20Vit"));
			}
		}
		public bool Add5Luck
		{
			get => Leagueflags.Add5Luck;
			set
			{
				Leagueflags.Add5Luck = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Add5Luck"));
			}
		}
		public bool Add10Luck
		{
			get => Leagueflags.Add10Luck;
			set
			{
				Leagueflags.Add10Luck = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Add10Luck"));
			}
		}

		public bool Add20HP
		{
			get => Leagueflags.Add20HP;
			set
			{
				Leagueflags.Add20HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Add20HP"));
			}
		}
		public bool Add40HP
		{
			get => Leagueflags.Add40HP;
			set
			{
				Leagueflags.Add40HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Add40HP"));
			}
		}
		public bool Add10PerHit
		{
			get => Leagueflags.Add10PerHit;
			set
			{
				Leagueflags.Add10PerHit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Add10PerHit"));
			}
		}
		public bool Add20PerHit
		{
			get => Leagueflags.Add20PerHit;
			set
			{
				Leagueflags.Add20PerHit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Add20PerHit"));
			}
		}
		public bool EquipAxe
		{
			get => Leagueflags.EquipAxe;
			set
			{
				Leagueflags.EquipAxe = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EquipAxe"));
			}
		}
		public bool EquipShirt
		{
			get => Leagueflags.EquipShirt;
			set
			{
				Leagueflags.EquipShirt = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EquipShirt"));
			}
		}
		public bool EquipShields
		{
			get => Leagueflags.EquipShields;
			set
			{
				Leagueflags.EquipShields = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EquipShields"));
			}
		}
		public bool EquipBonkHelm
		{
			get => Leagueflags.EquipBonkHelm;
			set
			{
				Leagueflags.EquipBonkHelm = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EquipBonkHelm"));
			}
		}
		public bool ThiefWeaponsBonus
		{
			get => Leagueflags.ThiefWeaponsBonus;
			set
			{
				Leagueflags.ThiefWeaponsBonus = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThiefWeaponsBonus"));
			}
		}
		public bool RMArmor
		{
			get => Leagueflags.RMArmor;
			set
			{
				Leagueflags.RMArmor = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RMArmor"));
			}
		}
		public bool LegSwords
		{
			get => Leagueflags.LegSwords;
			set
			{
				Leagueflags.LegSwords = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LegSwords"));
			}
		}
		public bool WoodArmor
		{
			get => Leagueflags.WoodArmor;
			set
			{
				Leagueflags.WoodArmor = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WoodArmor"));
			}
		}
		public bool Lvl1MP2
		{
			get => Leagueflags.Lvl1MP2;
			set
			{
				Leagueflags.Lvl1MP2 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Lvl1MP2"));
			}
		}
		public bool MP1All
		{
			get => Leagueflags.MP1All;
			set
			{
				Leagueflags.MP1All = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MP1All"));
			}
		}
		public bool AddSpell
		{
			get => Leagueflags.AddSpell;
			set
			{
				Leagueflags.AddSpell = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AddSpell"));
			}
		}
		public bool Telemagic
		{
			get => Leagueflags.Telemagic;
			set
			{
				Leagueflags.Telemagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Telemagic"));
			}
		}
		public bool BuffMagic
		{
			get => Leagueflags.Buffmagic;
			set
			{
				Leagueflags.Buffmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BuffMagic"));
			}
		}
		public bool SelfMagic
		{
			get => Leagueflags.Selfmagic;
			set
			{
				Leagueflags.Selfmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelfMagic"));
			}
		}
		public bool HealMagic
		{
			get => Leagueflags.Healmagic;
			set
			{
				Leagueflags.Healmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HealMagic"));
			}
		}
		public bool HealMagicPlus
		{
			get => Leagueflags.Healplusmagic;
			set
			{
				Leagueflags.Healplusmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HealMagicPlus"));
			}
		}
		public bool ElemMagic
		{
			get => Leagueflags.Elemmagic;
			set
			{
				Leagueflags.Elemmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ElemMagic"));
			}
		}
		public bool ElemplusMagic
		{
			get => Leagueflags.Elemplusmagic;
			set
			{
				Leagueflags.Elemplusmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ElemPlusMagic"));
			}
		}
		public bool NukeMagic
		{
			get => Leagueflags.Nukemagic;
			set
			{
				Leagueflags.Nukemagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NukeMagic"));
			}
		}
		public bool DoomMagic
		{
			get => Leagueflags.Doommagic;
			set
			{
				Leagueflags.Doommagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DoomMagic"));
			}
		}
		public bool CleanMagic
		{
			get => Leagueflags.Cleanmagic;
			set
			{
				Leagueflags.Cleanmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CleanMagic"));
			}

		}
		public bool MaxplusMPplus
		{
			get => Leagueflags.MaxplusMPplus;
			set
			{
				Leagueflags.MaxplusMPplus = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaxPlusMPplus"));
			}
		}
		public bool ImpCatclaw
		{
			get => Leagueflags.ImpCatclaw;
			set
			{
				Leagueflags.ImpCatclaw = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ImpCatclaw"));
			}
		}
		public bool ImpThor
		{
			get => Leagueflags.ImpThor;
			set
			{
				Leagueflags.ImpThor = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ImpThor"));
			}
		}
		public bool HurtUndead
		{
			get => Leagueflags.Hurtundead;
			set
			{
				Leagueflags.Hurtundead = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HurtUndead"));
			}
		}
		public bool HurtDragon
		{
			get => Leagueflags.Hurtdragon;
			set
			{
				Leagueflags.Hurtdragon = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HurtDragon"));
			}
		}
		public bool HurtAll
		{
			get => Leagueflags.Hurtall;
			set
			{
				Leagueflags.Hurtall = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HurtAll"));
			}
		}
		public bool PromoFiWeapons
		{
			get => Leagueflags.PromoFiweapons;
			set
			{
				Leagueflags.PromoFiweapons = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PromoFiWeapons"));
			}

		}
		public bool PromoSage
		{
			get => Leagueflags.PromoSage;
			set
			{
				Leagueflags.PromoSage = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PromoSage"));
			}
		}
		public bool XP50Percent
		{
			get => Leagueflags.XP50percent;
			set
			{
				Leagueflags.XP50percent = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("XP50Percent"));
			}
		}
		public bool EarlyLockpick
		{
			get => Leagueflags.Earlylockpick;
			set
			{
				Leagueflags.Earlylockpick = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EarlyLockpick"));
			}
		}
		public bool ResistPoison
		{
			get => Leagueflags.ResistPosion;
			set
			{
				Leagueflags.ResistPosion = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ResistPoison"));
			}
		}
		public bool ResistEarth
		{
			get => Leagueflags.ResistEarth;
			set
			{
				Leagueflags.ResistEarth = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ResistEarth"));
			}
		}
		public bool ResistDeath
		{
			get => Leagueflags.ResistDeath;
			set
			{
				Leagueflags.ResistDeath = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ResistDeath"));
			}
		}
		public bool ResistTime
		{
			get => Leagueflags.ResistTime;
			set
			{
				Leagueflags.ResistTime = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ResistTime"));
			}
		}
		public bool ResistStatus
		{
			get => Leagueflags.ResistStatus;
			set
			{
				Leagueflags.ResistStatus = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ResistStatus"));
			}
		}
		public bool ResistIce
		{
			get => Leagueflags.ResistIce;
			set
			{
				Leagueflags.ResistIce = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ResistIce"));
			}
		}
		public bool ResistLit
		{
			get => Leagueflags.ResistLit;
			set
			{
				Leagueflags.ResistLit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ResistLit"));
			}
		}
		public bool ResistFire
		{
			get => Leagueflags.ResistFire;
			set
			{
				Leagueflags.ResistFire = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ResistFire"));
			}
		}
		public bool StartGold200
		{
			get => Leagueflags.Startgold200;
			set
			{
				Leagueflags.Startgold200 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StartGold200"));
			}
		}
		public bool StartGold400
		{
			get => Leagueflags.Startgold400;
			set
			{
				Leagueflags.Startgold400 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StartGold400"));
			}
		}
		public bool StartGold600
		{
			get => Leagueflags.Startgold600;
			set
			{
				Leagueflags.Startgold600 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StartGold600"));
			}
		}
		public bool StartGold800
		{
			get => Leagueflags.Startgold800;
			set
			{
				Leagueflags.Startgold800 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StartGold800"));
			}
		}
		public bool StartGold1500
		{
			get => Leagueflags.Startgold1500;
			set
			{
				Leagueflags.Startgold1500 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StartGold1500"));
			}
		}
		public bool StartGold5000
		{
			get => Leagueflags.Startgold5000;
			set
			{
				Leagueflags.Startgold5000 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StartGold5000"));
			}
		}
		public bool StartGold20000
		{
			get => Leagueflags.Startgold20000;
			set
			{
				Leagueflags.Startgold20000 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StartGold20000"));
			}
		}
		public bool Add40Str
		{
			get => Leagueflags.Add40Str;
			set
			{
				Leagueflags.Add40Str = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Add40Str"));
			}
		}
		public bool Add50Agi
		{
			get => Leagueflags.Add50Agi;
			set
			{
				Leagueflags.Add50Agi = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Add50Agi"));
			}
		}
		public bool Add40Vit
		{
			get => Leagueflags.Add40Vit;
			set
			{
				Leagueflags.Add40Vit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Add40Vit"));
			}
		}
		public bool Add15Luck
		{
			get => Leagueflags.Add15Luck;
			set
			{
				Leagueflags.Add15Luck = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Add15Luck"));
			}
		}
		public bool Add80HP
		{
			get => Leagueflags.Add80HP;
			set
			{
				Leagueflags.Add80HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Add80HP"));
			}
		}
		public bool Mdef2Lvl
		{
			get => Leagueflags.Mdef2lvl;
			set
			{
				Leagueflags.Mdef2lvl = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Mdef2Lvl"));
			}
		}
		public bool FiWeapons
		{
			get => Leagueflags.FiWeapons;
			set
			{
				Leagueflags.FiWeapons = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiWeapons"));
			}
		}
		public bool FiArmor
		{
			get => Leagueflags.FiArmor;
			set
			{
				Leagueflags.FiArmor = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiArmor"));
			}
		}
		public bool ImprovedMP
		{
			get => Leagueflags.ImprovedMP;
			set
			{
				Leagueflags.ImprovedMP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ImprovedMP"));
			}
		}
		public bool Sage
		{
			get => Leagueflags.Sage;
			set
			{
				Leagueflags.Sage = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Sage"));
			}
		}
		public bool SteelFast
		{
			get => Leagueflags.Steelfast;
			set
			{
				Leagueflags.Steelfast = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SteelFast"));
			}
		}
		public bool FiBB50XP
		{
			get => Leagueflags.FiBB50XP;
			set
			{
				Leagueflags.FiBB50XP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiBB50XP"));
			}
		}
		public bool XP100Percent
		{
			get => Leagueflags.XP100Percent;
			set
			{
				Leagueflags.XP100Percent = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("XP100Percent"));
			}
		}
		public bool Down10Str
		{
			get => Leagueflags.Down10Str;
			set
			{
				Leagueflags.Down10Str = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Down10Str"));
			}
		}
		public bool Down20Str
		{
			get => Leagueflags.Down20Str;
			set
			{
				Leagueflags.Down20Str = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Down20Str"));
			}
		}
		public bool Down10Agi
		{
			get => Leagueflags.Down10Agi;
			set
			{
				Leagueflags.Down10Agi = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Down10Agi"));
			}
		}
		public bool Down20Agi
		{
			get => Leagueflags.Down20Agi;
			set
			{
				Leagueflags.Down20Agi = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Down20Agi"));
			}
		}
		public bool Down10Vit
		{
			get => Leagueflags.Down10Vit;
			set
			{
				Leagueflags.Down10Vit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Down10Vit"));
			}
		}
		public bool Down20Vit
		{
			get => Leagueflags.Down20Vit;
			set
			{
				Leagueflags.Down20Vit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Down20Vit"));
			}
		}
		public bool Down5Luck
		{
			get => Leagueflags.Down5Luck;
			set
			{
				Leagueflags.Down5Luck = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Down5Luck"));
			}
		}
		public bool Down10Luck
		{
			get => Leagueflags.Down10Luck;
			set
			{
				Leagueflags.Down10Luck = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Down10Luck"));
			}
		}
		public bool Down15HP
		{
			get => Leagueflags.Down15HP;
			set
			{
				Leagueflags.Down15HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Down15HP"));
			}
		}
		public bool Down30HP
		{
			get => Leagueflags.Down30HP;
			set
			{
				Leagueflags.Down30HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Down15HP"));
			}
		}
		public bool BMHP
		{
			get => Leagueflags.BMHP;
			set
			{
				Leagueflags.BMHP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BMHP"));
			}
		}
		public bool Down1HitPercent
		{
			get => Leagueflags.Down1Hitpercent;
			set
			{
				Leagueflags.Down1Hitpercent = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Down1HitPercent"));
			}
		}
		public bool Down1MDef
		{
			get => Leagueflags.Down1Mdef;
			set
			{
				Leagueflags.Down1Mdef = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Down1MDef"));
			}
		}
		public bool NoBracelets
		{
			get => Leagueflags.Nobrace;
			set
			{
				Leagueflags.Nobrace = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NoBracelets"));
			}
		}
		public bool NoMasa
		{
			get => Leagueflags.NoMasa;
			set
			{
				Leagueflags.NoMasa = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NoMasa"));
			}
		}
		public bool NoRibbon
		{
			get => Leagueflags.NoRibbon;
			set
			{
				Leagueflags.NoRibbon = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NoRibbon"));
			}
		}
		public bool NoProRing
		{
			get => Leagueflags.NoProring;
			set
			{
				Leagueflags.NoProring = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NoProRing"));
			}
		}
		public bool LateLockPicking
		{
			get => Leagueflags.LateLockpick;
			set
			{
				Leagueflags.LateLockpick = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LateLockpick"));
			}
		}
		public bool ThWeaponMal
		{
			get => Leagueflags.ThiefweaponsMalus;
			set
			{
				Leagueflags.ThiefweaponsMalus = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThWeaponMal"));
			}
		}
		public bool Down4MaxMP
		{
			get => Leagueflags.Down4MaxMP;
			set
			{
				Leagueflags.Down4MaxMP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Down4MaxMP"));
			}
		}

		public bool NoSpell
		{
			get => Leagueflags.NoSpell;
			set
			{
				Leagueflags.NoSpell = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NoSpell"));
			}
		}
		public bool NoFiPromoArmor
		{
			get => Leagueflags.NoFiPromoArmor;
			set
			{
				Leagueflags.NoFiPromoArmor = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NoFiPromoArmor"));
			}
		}
		public bool PromoRmArmor
		{
			get => Leagueflags.PromoRMArmor;
			set
			{
				Leagueflags.PromoRMArmor = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PromoRMArmor"));
			}
		}
		public bool NoPromoSpells
		{
			get => Leagueflags.NoPromoSpells;
			set
			{
				Leagueflags.NoPromoSpells = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NoPromoSpells"));
			}
		}
		public bool Down50GP
		{
			get => Leagueflags.Down50GP;
			set
			{
				Leagueflags.Down50GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Down50GP"));
			}
		}
		public bool Down100GP
		{
			get => Leagueflags.Down100GP;
			set
			{
				Leagueflags.Down100GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Down100GP"));
			}
		}
		public bool Down150GP
		{
			get => Leagueflags.Down150GP;
			set
			{
				Leagueflags.Down150GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Down150GP"));
			}
		}
		public bool Down350GP
		{
			get => Leagueflags.Down350GP;
			set
			{
				Leagueflags.Down350GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Down350GP"));
			}
		}
		public bool Down1100GP
		{
			get => Leagueflags.Down1100GP;
			set
			{
				Leagueflags.Down1100GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Down1100GP"));
			}
		}
		public bool Down4500GP
		{
			get => Leagueflags.Down4500gp;
			set
			{
				Leagueflags.Down4500gp = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Down4500GP"));
			}
		}
		public bool StartCrown
		{
			get => Leagueflags.Startcrown;
			set
			{
				Leagueflags.Startcrown = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StartCrown"));
			}
		}
		#endregion

	}
}
