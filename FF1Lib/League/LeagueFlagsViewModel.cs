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

		public LeaugeFlagsViewModel()
		{
			Leagueflags = new LeagueFlags();
		}
		
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
		#region Bonus
		#region FighterBonus
		public bool FiAdd10Str
		{
			get => Leagueflags.FiAdd10Str;
			set
			{
				Leagueflags.FiAdd10Str = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiAdd10Str"));
			}

		}
		public bool FiAdd20Str
		{
			get => Leagueflags.FiAdd20Str;
			set
			{
				Leagueflags.FiAdd20Str = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiAdd20Str"));
			}
		}
		public bool FiAdd15Agi
		{
			get => Leagueflags.FiAdd15Agi;
			set
			{
				Leagueflags.FiAdd15Agi = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiAdd15Agi"));
			}
		}

		public bool FiAdd25Agi
		{
			get => Leagueflags.FiAdd25Agi;
			set
			{
				Leagueflags.FiAdd25Agi = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiAdd25Agi"));
			}
		}

		public bool FiAdd10Vit
		{
			get => Leagueflags.FiAdd10Vit;
			set
			{
				Leagueflags.FiAdd10Vit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Add10Vit"));
			}

		}
		public bool FiAdd20Vit
		{
			get => Leagueflags.FiAdd20Vit;
			set
			{
				Leagueflags.FiAdd20Vit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiAdd20Vit"));
			}
		}
		public bool FiAdd5Luck
		{
			get => Leagueflags.FiAdd5Luck;
			set
			{
				Leagueflags.FiAdd5Luck = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiAdd5Luck"));
			}
		}
		public bool FiAdd10Luck
		{
			get => Leagueflags.FiAdd10Luck;
			set
			{
				Leagueflags.FiAdd10Luck = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Add10Luck"));
			}
		}

		public bool FiAdd20HP
		{
			get => Leagueflags.FiAdd20HP;
			set
			{
				Leagueflags.FiAdd20HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiAdd20HP"));
			}
		}
		public bool FiAdd40HP
		{
			get => Leagueflags.FiAdd40HP;
			set
			{
				Leagueflags.FiAdd40HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiAdd40HP"));
			}
		}
		public bool FiAdd10PerHit
		{
			get => Leagueflags.FiAdd10PerHit;
			set
			{
				Leagueflags.FiAdd10PerHit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiAdd10PerHit"));
			}
		}
		public bool FiAdd20PerHit
		{
			get => Leagueflags.FiAdd20PerHit;
			set
			{
				Leagueflags.FiAdd20PerHit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiAdd20PerHit"));
			}
		}
		public bool FiAdd10Mdef
		{
			get => Leagueflags.FiAdd10Mdef;
			set
			{
				Leagueflags.FiAdd10Mdef = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiAdd10Mdef"));
			}
		}
		public bool FiAdd20Mdef
		{
			get => Leagueflags.FiAdd20Mdef;
			set
			{
				Leagueflags.FiAdd20Mdef = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiAdd20Mdef"));
			}
		}
		public bool FiEquipShirt
		{
			get => Leagueflags.FiEquipShirt;
			set
			{
				Leagueflags.FiEquipShirt = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiEquipShirt"));
			}
		}
		public bool FiLegSwords
		{
			get => Leagueflags.FiLegSwords;
			set
			{
				Leagueflags.FiLegSwords = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiLegSwords"));
			}
		}
		public bool FiWoodArmor
		{
			get => Leagueflags.FiWoodArmor;
			set
			{
				Leagueflags.FiWoodArmor = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiWoodArmor"));
			}
		}
		public bool FiTelemagic
		{
			get => Leagueflags.FiTelemagic;
			set
			{
				Leagueflags.FiTelemagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiTelemagic"));
			}
		}
		public bool FiBuffMagic
		{
			get => Leagueflags.FiBuffmagic;
			set
			{
				Leagueflags.FiBuffmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiBuffMagic"));
			}
		}
		public bool FiSelfMagic
		{
			get => Leagueflags.FiSelfmagic;
			set
			{
				Leagueflags.FiSelfmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiSelfMagic"));
			}
		}
		public bool FiHealMagic
		{
			get => Leagueflags.FiHealmagic;
			set
			{
				Leagueflags.FiHealmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiHealMagic"));
			}
		}
		public bool FiHealMagicPlus
		{
			get => Leagueflags.FiHealplusmagic;
			set
			{
				Leagueflags.FiHealplusmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiHealMagicPlus"));
			}
		}
		public bool FiElemMagic
		{
			get => Leagueflags.FiElemmagic;
			set
			{
				Leagueflags.FiElemmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiElemMagic"));
			}
		}
		public bool FiElemplusMagic
		{
			get => Leagueflags.FiElemplusmagic;
			set
			{
				Leagueflags.FiElemplusmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiElemPlusMagic"));
			}
		}
		public bool FiCleanMagic
		{
			get => Leagueflags.FiCleanmagic;
			set
			{
				Leagueflags.FiCleanmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiCleanMagic"));
			}

		}
		public bool FiImpCatclaw
		{
			get => Leagueflags.FiImpCatclaw;
			set
			{
				Leagueflags.FiImpCatclaw = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiImpCatclaw"));
			}
		}
		public bool FiImpThor
		{
			get => Leagueflags.FiImpThor;
			set
			{
				Leagueflags.FiImpThor = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiImpThor"));
			}
		}
		public bool FiHurtUndead
		{
			get => Leagueflags.FiHurtundead;
			set
			{
				Leagueflags.FiHurtundead = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiHurtUndead"));
			}
		}
		public bool FiHurtDragon
		{
			get => Leagueflags.FiHurtdragon;
			set
			{
				Leagueflags.FiHurtdragon = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiHurtDragon"));
			}
		}
		public bool FiHurtAll
		{
			get => Leagueflags.FiHurtall;
			set
			{
				Leagueflags.FiHurtall = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiHurtAll"));
			}
		}

		public bool FiXP50Percent
		{
			get => Leagueflags.FiXP50percent;
			set
			{
				Leagueflags.FiXP50percent = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiXP50Percent"));
			}
		}
		public bool FiResistPoison
		{
			get => Leagueflags.FiResistPoison;
			set
			{
				Leagueflags.FiResistPoison = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiResistPoison"));
			}
		}
		public bool FiResistEarth
		{
			get => Leagueflags.FiResistEarth;
			set
			{
				Leagueflags.FiResistEarth = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiResistEarth"));
			}
		}
		public bool FiResistDeath
		{
			get => Leagueflags.FiResistDeath;
			set
			{
				Leagueflags.FiResistDeath = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiResistDeath"));
			}
		}
		public bool FiResistTime
		{
			get => Leagueflags.FiResistTime;
			set
			{
				Leagueflags.FiResistTime = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiResistTime"));
			}
		}
		public bool FiResistStatus
		{
			get => Leagueflags.FiResistStatus;
			set
			{
				Leagueflags.FiResistStatus = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiResistStatus"));
			}
		}
		public bool FiResistIce
		{
			get => Leagueflags.FiResistIce;
			set
			{
				Leagueflags.FiResistIce = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiResistIce"));
			}
		}
		public bool FiResistLit
		{
			get => Leagueflags.FiResistLit;
			set
			{
				Leagueflags.FiResistLit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiResistLit"));
			}
		}
		public bool FiResistFire
		{
			get => Leagueflags.FiResistFire;
			set
			{
				Leagueflags.FiResistFire = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiResistFire"));
			}
		}
		public bool FiStartGold200
		{
			get => Leagueflags.FiStartgold200;
			set
			{
				Leagueflags.FiStartgold200 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiStartGold200"));
			}
		}
		public bool FiStartGold400
		{
			get => Leagueflags.FiStartgold400;
			set
			{
				Leagueflags.FiStartgold400 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiStartGold400"));
			}
		}
		public bool FiStartGold600
		{
			get => Leagueflags.FiStartgold600;
			set
			{
				Leagueflags.FiStartgold600 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiStartGold600"));
			}
		}
		public bool FiStartGold800
		{
			get => Leagueflags.FiStartgold800;
			set
			{
				Leagueflags.FiStartgold800 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiStartGold800"));
			}
		}
		public bool FiStartGold1500
		{
			get => Leagueflags.FiStartgold1500;
			set
			{
				Leagueflags.FiStartgold1500 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiStartGold1500"));
			}
		}
		public bool FiStartGold5000
		{
			get => Leagueflags.FiStartgold5000;
			set
			{
				Leagueflags.FiStartgold5000 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiStartGold5000"));
			}
		}
		public bool FiStartGold20000
		{
			get => Leagueflags.FiStartgold20000;
			set
			{
				Leagueflags.FiStartgold20000 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiStartGold20000"));
			}
		}
		public bool FiAdd40Str
		{
			get => Leagueflags.FiAdd40Str;
			set
			{
				Leagueflags.FiAdd40Str = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiAdd40Str"));
			}
		}
		public bool FiAdd50Agi
		{
			get => Leagueflags.FiAdd50Agi;
			set
			{
				Leagueflags.FiAdd50Agi = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiAdd50Agi"));
			}
		}
		public bool FiAdd40Vit
		{
			get => Leagueflags.FiAdd40Vit;
			set
			{
				Leagueflags.FiAdd40Vit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiAdd40Vit"));
			}
		}
		public bool FiAdd15Luck
		{
			get => Leagueflags.FiAdd15Luck;
			set
			{
				Leagueflags.FiAdd15Luck = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiAdd15Luck"));
			}
		}
		public bool FiAdd80HP
		{
			get => Leagueflags.FiAdd80HP;
			set
			{
				Leagueflags.FiAdd80HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiAdd80HP"));
			}
		}
		public bool FiMdef2Lvl
		{
			get => Leagueflags.FiMdef2lvl;
			set
			{
				Leagueflags.FiMdef2lvl = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiMdef2Lvl"));
			}
		}
		public bool FiSteelFast
		{
			get => Leagueflags.FiSteelfast;
			set
			{
				Leagueflags.FiSteelfast = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiSteelFast"));
			}
		}
		public bool Fi50XPFiBB
		{
			get => Leagueflags.Fi50XPFiBB;
			set
			{
				Leagueflags.Fi50XPFiBB = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Fi50XPFiBB"));
			}
		}
		public bool FiResistAll
		{
			get => Leagueflags.FiResistAll;
			set
			{
				Leagueflags.FiResistAll = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiResistAll"));
			}
		}
		public bool FiResistPEDTS
		{
			get => Leagueflags.FiResistPEDTS;
			set
			{
				Leagueflags.FiResistPEDTS = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiResistPEDTS"));
			}
		}
		#endregion
		#region ThiefBonus
		public bool ThAdd10Str
		{
			get => Leagueflags.ThAdd10Str;
			set
			{
				Leagueflags.ThAdd10Str = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThAdd10Str"));
			}

		}
		public bool ThAdd20Str
		{
			get => Leagueflags.ThAdd20Str;
			set
			{
				Leagueflags.ThAdd20Str = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThAdd20Str"));
			}
		}
		public bool ThAdd15Agi
		{
			get => Leagueflags.ThAdd15Agi;
			set
			{
				Leagueflags.ThAdd15Agi = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThAdd15Agi"));
			}
		}

		public bool ThAdd25Agi
		{
			get => Leagueflags.ThAdd25Agi;
			set
			{
				Leagueflags.ThAdd25Agi = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThAdd25Agi"));
			}
		}

		public bool ThAdd10Vit
		{
			get => Leagueflags.ThAdd10Vit;
			set
			{
				Leagueflags.ThAdd10Vit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThAdd10Vit"));
			}

		}
		public bool ThAdd20Vit
		{
			get => Leagueflags.ThAdd20Vit;
			set
			{
				Leagueflags.ThAdd20Vit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThAdd20Vit"));
			}
		}
		public bool ThAdd5Luck
		{
			get => Leagueflags.ThAdd5Luck;
			set
			{
				Leagueflags.ThAdd5Luck = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThAdd5Luck"));
			}
		}
		public bool ThAdd10Luck
		{
			get => Leagueflags.ThAdd10Luck;
			set
			{
				Leagueflags.ThAdd10Luck = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThAdd10Luck"));
			}
		}

		public bool ThAdd20HP
		{
			get => Leagueflags.ThAdd20HP;
			set
			{
				Leagueflags.ThAdd20HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThAdd20HP"));
			}
		}
		public bool ThAdd40HP
		{
			get => Leagueflags.ThAdd40HP;
			set
			{
				Leagueflags.ThAdd40HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThAdd40HP"));
			}
		}
		public bool ThAdd10PerHit
		{
			get => Leagueflags.ThAdd10PerHit;
			set
			{
				Leagueflags.ThAdd10PerHit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThAdd10PerHit"));
			}
		}
		public bool ThAdd20PerHit
		{
			get => Leagueflags.ThAdd20PerHit;
			set
			{
				Leagueflags.ThAdd20PerHit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThAdd20PerHit"));
			}
		}
		public bool ThAdd10Mdef
		{
			get => Leagueflags.ThAdd10Mdef;
			set
			{
				Leagueflags.ThAdd10Mdef = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThAdd10Mdef"));
			}
		}
		public bool ThAdd20Mdef
		{
			get => Leagueflags.ThAdd20Mdef;
			set
			{
				Leagueflags.ThAdd20Mdef = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThAdd20Mdef"));
			}
		}
		public bool ThEquipAxe
		{
			get => Leagueflags.ThEquipAxe;
			set
			{
				Leagueflags.ThEquipAxe = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThEquipAxe"));
			}
		}
		public bool ThEquipShirt
		{
			get => Leagueflags.ThEquipShirt;
			set
			{
				Leagueflags.ThEquipShirt = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThEquipShirt"));
			}
		}
		public bool ThEquipShields
		{
			get => Leagueflags.ThEquipShields;
			set
			{
				Leagueflags.ThEquipShields = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThEquipShields"));
			}
		}
		public bool ThEquipBonkHelm
		{
			get => Leagueflags.ThEquipBonkHelm;
			set
			{
				Leagueflags.ThEquipBonkHelm = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThEquipBonkHelm"));
			}
		}
		public bool ThRMArmor
		{
			get => Leagueflags.ThRMArmor;
			set
			{
				Leagueflags.ThRMArmor = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThRMArmor"));
			}
		}
		public bool ThLegSwords
		{
			get => Leagueflags.ThLegSwords;
			set
			{
				Leagueflags.ThLegSwords = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThLegSwords"));
			}
		}
		public bool ThWoodArmor
		{
			get => Leagueflags.ThWoodArmor;
			set
			{
				Leagueflags.ThWoodArmor = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThWoodArmor"));
			}
		}
		public bool ThTelemagic
		{
			get => Leagueflags.ThTelemagic;
			set
			{
				Leagueflags.ThTelemagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Telemagic"));
			}
		}
		public bool ThBuffMagic
		{
			get => Leagueflags.ThBuffmagic;
			set
			{
				Leagueflags.ThBuffmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThBuffMagic"));
			}
		}
		public bool ThSelfMagic
		{
			get => Leagueflags.ThSelfmagic;
			set
			{
				Leagueflags.ThSelfmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThSelfMagic"));
			}
		}
		public bool ThHealMagic
		{
			get => Leagueflags.ThHealmagic;
			set
			{
				Leagueflags.ThHealmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThHealMagic"));
			}
		}
		public bool ThHealMagicPlus
		{
			get => Leagueflags.ThHealplusmagic;
			set
			{
				Leagueflags.ThHealplusmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThHealMagicPlus"));
			}
		}
		public bool ThElemMagic
		{
			get => Leagueflags.ThElemmagic;
			set
			{
				Leagueflags.ThElemmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThElemMagic"));
			}
		}
		public bool ThElemplusMagic
		{
			get => Leagueflags.ThElemplusmagic;
			set
			{
				Leagueflags.ThElemplusmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThElemPlusMagic"));
			}
		}
		public bool ThCleanMagic
		{
			get => Leagueflags.ThCleanmagic;
			set
			{
				Leagueflags.ThCleanmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThCleanMagic"));
			}

		}
		public bool ThImpCatclaw
		{
			get => Leagueflags.ThImpCatclaw;
			set
			{
				Leagueflags.ThImpCatclaw = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThImpCatclaw"));
			}
		}
		public bool ThImpThor
		{
			get => Leagueflags.ThImpThor;
			set
			{
				Leagueflags.ThImpThor = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThImpThor"));
			}
		}
		public bool ThHurtUndead
		{
			get => Leagueflags.ThHurtundead;
			set
			{
				Leagueflags.ThHurtundead = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThHurtUndead"));
			}
		}
		public bool ThHurtDragon
		{
			get => Leagueflags.ThHurtdragon;
			set
			{
				Leagueflags.ThHurtdragon = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThHurtDragon"));
			}
		}
		public bool ThHurtAll
		{
			get => Leagueflags.ThHurtall;
			set
			{
				Leagueflags.ThHurtall = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThHurtAll"));
			}
		}
		public bool ThXP50Percent
		{
			get => Leagueflags.ThXP50percent;
			set
			{
				Leagueflags.ThXP50percent = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThXP50Percent"));
			}
		}
		public bool ThEarlyLockpick
		{
			get => Leagueflags.ThEarlylockpick;
			set
			{
				Leagueflags.ThEarlylockpick = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThEarlyLockpick"));
			}
		}
		public bool ThResistPoison
		{
			get => Leagueflags.ThResistPosion;
			set
			{
				Leagueflags.ThResistPosion = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThResistPoison"));
			}
		}
		public bool ThResistEarth
		{
			get => Leagueflags.ThResistEarth;
			set
			{
				Leagueflags.ThResistEarth = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThResistEarth"));
			}
		}
		public bool ThResistDeath
		{
			get => Leagueflags.ThResistDeath;
			set
			{
				Leagueflags.ThResistDeath = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThResistDeath"));
			}
		}
		public bool ThResistTime
		{
			get => Leagueflags.ThResistTime;
			set
			{
				Leagueflags.ThResistTime = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThResistTime"));
			}
		}
		public bool ThResistStatus
		{
			get => Leagueflags.ThResistStatus;
			set
			{
				Leagueflags.ThResistStatus = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThResistStatus"));
			}
		}
		public bool ThResistIce
		{
			get => Leagueflags.ThResistIce;
			set
			{
				Leagueflags.ThResistIce = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThResistIce"));
			}
		}
		public bool ThResistLit
		{
			get => Leagueflags.ThResistLit;
			set
			{
				Leagueflags.ThResistLit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThResistLit"));
			}
		}
		public bool ThResistFire
		{
			get => Leagueflags.ThResistFire;
			set
			{
				Leagueflags.ThResistFire = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThResistFire"));
			}
		}
		public bool ThStartGold200
		{
			get => Leagueflags.ThStartgold200;
			set
			{
				Leagueflags.ThStartgold200 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThStartGold200"));
			}
		}
		public bool ThStartGold400
		{
			get => Leagueflags.ThStartgold400;
			set
			{
				Leagueflags.ThStartgold400 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThStartGold400"));
			}
		}
		public bool ThStartGold600
		{
			get => Leagueflags.ThStartgold600;
			set
			{
				Leagueflags.ThStartgold600 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThStartGold600"));
			}
		}
		public bool ThStartGold800
		{
			get => Leagueflags.ThStartgold800;
			set
			{
				Leagueflags.ThStartgold800 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThStartGold800"));
			}
		}
		public bool ThStartGold1500
		{
			get => Leagueflags.ThStartgold1500;
			set
			{
				Leagueflags.ThStartgold1500 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThStartGold1500"));
			}
		}
		public bool ThStartGold5000
		{
			get => Leagueflags.ThStartgold5000;
			set
			{
				Leagueflags.ThStartgold5000 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThStartGold5000"));
			}
		}
		public bool ThStartGold20000
		{
			get => Leagueflags.ThStartgold20000;
			set
			{
				Leagueflags.ThStartgold20000 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThStartGold20000"));
			}
		}
		public bool ThAdd40Str
		{
			get => Leagueflags.ThAdd40Str;
			set
			{
				Leagueflags.ThAdd40Str = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThAdd40Str"));
			}
		}
		public bool ThAdd50Agi
		{
			get => Leagueflags.ThAdd50Agi;
			set
			{
				Leagueflags.ThAdd50Agi = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThAdd50Agi"));
			}
		}
		public bool ThAdd40Vit
		{
			get => Leagueflags.ThAdd40Vit;
			set
			{
				Leagueflags.ThAdd40Vit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThAdd40Vit"));
			}
		}
		public bool ThAdd80HP
		{
			get => Leagueflags.ThAdd80HP;
			set
			{
				Leagueflags.ThAdd80HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThAdd80HP"));
			}
		}
		public bool ThMdef2Lvl
		{
			get => Leagueflags.ThMdef2lvl;
			set
			{
				Leagueflags.ThMdef2lvl = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThMdef2Lvl"));
			}
		}
		public bool ThFiWeapons
		{
			get => Leagueflags.ThFiWeapons;
			set
			{
				Leagueflags.ThFiWeapons = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThFiWeapons"));
			}
		}
		public bool ThFiArmor
		{
			get => Leagueflags.ThFiArmor;
			set
			{
				Leagueflags.ThFiArmor = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThFiArmor"));
			}
		}
		public bool ThXP100Percent
		{
			get => Leagueflags.ThXP100Percent;
			set
			{
				Leagueflags.ThXP100Percent = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThXP100Percent"));
			}
		}
		public bool ThResistAll
		{
			get => Leagueflags.ThResistAll;
			set
			{
				Leagueflags.ThResistAll = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThResistAll"));
			}
		}
		public bool ThResistPEDTS
		{
			get => Leagueflags.ThResistPEDTS;
			set
			{
				Leagueflags.ThResistPEDTS = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThResistPEDTS"));
			}
		}
		public bool ThStartgold1400
		{
			get => Leagueflags.ThStartgold1400;
			set
			{
				Leagueflags.ThStartgold1400 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThStartgold1400"));
			}
		}
		public bool ThStartgold2000
		{
			get => Leagueflags.ThStartgold2000;
			set
			{
				Leagueflags.ThStartgold2000 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThStartgold2000"));
			}
		}
		public bool ThStartgold3000
		{
			get => Leagueflags.ThStartgold3000;
			set
			{
				Leagueflags.ThStartgold3000 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThStartgold3000"));
			}
		}
		public bool ThStartgold4000
		{
			get => Leagueflags.ThStartgold4000;
			set
			{
				Leagueflags.ThStartgold4000 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThStartgold4000"));
			}
		}
		public bool ThStartgold6000
		{
			get => Leagueflags.ThStartgold6000;
			set
			{
				Leagueflags.ThStartgold6000 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThStartgold6000"));
			}
		}
		public bool ThStartgold20000St
		{
			get => Leagueflags.ThStartgold20000St;
			set
			{
				Leagueflags.ThStartgold20000St = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThStartgold20000St"));
			}
		}
		#endregion
		#region BlackBeltBonus
		public bool BBAdd10Str
		{
			get => Leagueflags.BBAdd10Str;
			set
			{
				Leagueflags.BBAdd10Str = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBAdd10Str"));
			}

		}
		public bool BBAdd20Str
		{
			get => Leagueflags.BBAdd20Str;
			set
			{
				Leagueflags.BBAdd20Str = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBAdd20Str"));
			}
		}
		public bool BBAdd15Agi
		{
			get => Leagueflags.BBAdd15Agi;
			set
			{
				Leagueflags.BBAdd15Agi = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBAdd15Agi"));
			}
		}

		public bool BBAdd25Agi
		{
			get => Leagueflags.BBAdd25Agi;
			set
			{
				Leagueflags.BBAdd25Agi = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBAdd25Agi"));
			}
		}

		public bool BBAdd10Vit
		{
			get => Leagueflags.BBAdd10Vit;
			set
			{
				Leagueflags.BBAdd10Vit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBAdd10Vit"));
			}

		}
		public bool BBAdd20Vit
		{
			get => Leagueflags.BBAdd20Vit;
			set
			{
				Leagueflags.BBAdd20Vit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBAdd20Vit"));
			}
		}
		public bool BBAdd5Luck
		{
			get => Leagueflags.BBAdd5Luck;
			set
			{
				Leagueflags.BBAdd5Luck = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBAdd5Luck"));
			}
		}
		public bool BBAdd10Luck
		{
			get => Leagueflags.BBAdd10Luck;
			set
			{
				Leagueflags.BBAdd10Luck = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBAdd10Luck"));
			}
		}

		public bool BBAdd20HP
		{
			get => Leagueflags.BBAdd20HP;
			set
			{
				Leagueflags.BBAdd20HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBAdd20HP"));
			}
		}
		public bool BBAdd40HP
		{
			get => Leagueflags.BBAdd40HP;
			set
			{
				Leagueflags.BBAdd40HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBAdd40HP"));
			}
		}
		public bool BBAdd10PerHit
		{
			get => Leagueflags.BBAdd10PerHit;
			set
			{
				Leagueflags.BBAdd10PerHit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBAdd10PerHit"));
			}
		}
		public bool BBAdd20PerHit
		{
			get => Leagueflags.BBAdd20PerHit;
			set
			{
				Leagueflags.BBAdd20PerHit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBAdd20PerHit"));
			}
		}
		public bool BBAdd10Mdef
		{
			get => Leagueflags.BBAdd10Mdef;
			set
			{
				Leagueflags.BBAdd10Mdef = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBAdd10Mdef"));
			}
		}
		public bool BBAdd20Mdef
		{
			get => Leagueflags.BBAdd20Mdef;
			set
			{
				Leagueflags.BBAdd20Mdef = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBAdd20Mdef"));
			}
		}
		public bool BBEquipAxe
		{
			get => Leagueflags.BBEquipAxe;
			set
			{
				Leagueflags.BBEquipAxe = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBEquipAxe"));
			}
		}
		public bool BBEquipShirt
		{
			get => Leagueflags.BBEquipShirt;
			set
			{
				Leagueflags.BBEquipShirt = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBEquipShirt"));
			}
		}
		public bool BBEquipShields
		{
			get => Leagueflags.BBEquipShields;
			set
			{
				Leagueflags.BBEquipShields = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBEquipShields"));
			}
		}
		public bool BBEquipBonkHelm
		{
			get => Leagueflags.BBEquipBonkHelm;
			set
			{
				Leagueflags.BBEquipBonkHelm = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBEquipBonkHelm"));
			}
		}
		public bool BBThiefWeaponsBonus
		{
			get => Leagueflags.BBThiefWeaponsBonus;
			set
			{
				Leagueflags.BBThiefWeaponsBonus = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBThiefWeaponsBonus"));
			}
		}
		public bool BBRMArmor
		{
			get => Leagueflags.BBRMArmor;
			set
			{
				Leagueflags.BBRMArmor = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBRMArmor"));
			}
		}
		public bool BBLegSwords
		{
			get => Leagueflags.BBLegSwords;
			set
			{
				Leagueflags.BBLegSwords = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBLegSwords"));
			}
		}
		public bool BBWoodArmor
		{
			get => Leagueflags.BBWoodArmor;
			set
			{
				Leagueflags.BBWoodArmor = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBWoodArmor"));
			}
		}
		public bool BBTelemagic
		{
			get => Leagueflags.BBTelemagic;
			set
			{
				Leagueflags.BBTelemagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBTelemagic"));
			}
		}
		public bool BBBuffMagic
		{
			get => Leagueflags.BBBuffmagic;
			set
			{
				Leagueflags.BBBuffmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBBuffMagic"));
			}
		}
		public bool BBSelfMagic
		{
			get => Leagueflags.BBSelfmagic;
			set
			{
				Leagueflags.BBSelfmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBSelfMagic"));
			}
		}
		public bool BBHealMagic
		{
			get => Leagueflags.BBHealmagic;
			set
			{
				Leagueflags.BBHealmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBHealMagic"));
			}
		}
		public bool BBHealMagicPlus
		{
			get => Leagueflags.BBHealplusmagic;
			set
			{
				Leagueflags.BBHealplusmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBHealMagicPlus"));
			}
		}
		public bool BBElemMagic
		{
			get => Leagueflags.BBElemmagic;
			set
			{
				Leagueflags.BBElemmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBElemMagic"));
			}
		}
		public bool BBElemplusMagic
		{
			get => Leagueflags.BBElemplusmagic;
			set
			{
				Leagueflags.BBElemplusmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBElemPlusMagic"));
			}
		}
		public bool BBCleanMagic
		{
			get => Leagueflags.BBCleanmagic;
			set
			{
				Leagueflags.BBCleanmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBCleanMagic"));
			}

		}
		public bool BBHurtUndead
		{
			get => Leagueflags.BBHurtundead;
			set
			{
				Leagueflags.BBHurtundead = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBHurtUndead"));
			}
		}
		public bool BBHurtDragon
		{
			get => Leagueflags.BBHurtdragon;
			set
			{
				Leagueflags.BBHurtdragon = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBHurtDragon"));
			}
		}
		public bool BBHurtAll
		{
			get => Leagueflags.BBHurtall;
			set
			{
				Leagueflags.BBHurtall = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBHurtAll"));
			}
		}
		public bool BBPromoFiWeapons
		{
			get => Leagueflags.BBPromoFiweapons;
			set
			{
				Leagueflags.BBPromoFiweapons = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBPromoFiWeapons"));
			}

		}
		public bool BBPromoFiarmor
		{
			get => Leagueflags.BBPromoFiarmor;
			set
			{
				Leagueflags.BBPromoFiarmor = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBPromoFiarmor"));
			}

		}
		public bool BBResistPoison
		{
			get => Leagueflags.BBResistPosion;
			set
			{
				Leagueflags.BBResistPosion = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBResistPoison"));
			}
		}
		public bool BBResistEarth
		{
			get => Leagueflags.BBResistEarth;
			set
			{
				Leagueflags.BBResistEarth = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBResistEarth"));
			}
		}
		public bool BBResistDeath
		{
			get => Leagueflags.BBResistDeath;
			set
			{
				Leagueflags.BBResistDeath = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBResistDeath"));
			}
		}
		public bool BBResistTime
		{
			get => Leagueflags.BBResistTime;
			set
			{
				Leagueflags.BBResistTime = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBResistTime"));
			}
		}
		public bool BBResistStatus
		{
			get => Leagueflags.BBResistStatus;
			set
			{
				Leagueflags.BBResistStatus = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBResistStatus"));
			}
		}
		public bool BBResistIce
		{
			get => Leagueflags.BBResistIce;
			set
			{
				Leagueflags.BBResistIce = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBResistIce"));
			}
		}
		public bool BBResistLit
		{
			get => Leagueflags.BBResistLit;
			set
			{
				Leagueflags.BBResistLit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBResistLit"));
			}
		}
		public bool BBResistFire
		{
			get => Leagueflags.BBResistFire;
			set
			{
				Leagueflags.BBResistFire = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBResistFire"));
			}
		}
		public bool BBResistAll
		{
			get => Leagueflags.BBResistAll;
			set
			{
				Leagueflags.BBResistAll = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBResistAll"));
			}
		}
		public bool BBResistPEDTS
		{
			get => Leagueflags.BBResistPEDTS;
			set
			{
				Leagueflags.BBResistPEDTS = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBResistPEDTS"));
			}
		}
		public bool BBStartGold200
		{
			get => Leagueflags.BBStartgold200;
			set
			{
				Leagueflags.BBStartgold200 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBStartGold200"));
			}
		}
		public bool BBStartGold400
		{
			get => Leagueflags.BBStartgold400;
			set
			{
				Leagueflags.BBStartgold400 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBStartGold400"));
			}
		}
		public bool BBStartGold600
		{
			get => Leagueflags.BBStartgold600;
			set
			{
				Leagueflags.BBStartgold600 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBStartGold600"));
			}
		}
		public bool BBStartGold800
		{
			get => Leagueflags.BBStartgold800;
			set
			{
				Leagueflags.BBStartgold800 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBStartGold800"));
			}
		}
		public bool BBStartGold1500
		{
			get => Leagueflags.BBStartgold1500;
			set
			{
				Leagueflags.BBStartgold1500 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBStartGold1500"));
			}
		}
		public bool BBStartGold5000
		{
			get => Leagueflags.BBStartgold5000;
			set
			{
				Leagueflags.BBStartgold5000 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBStartGold5000"));
			}
		}
		public bool BBStartGold20000
		{
			get => Leagueflags.BBStartgold20000;
			set
			{
				Leagueflags.BBStartgold20000 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBStartGold20000"));
			}
		}
		public bool BBAdd40Str
		{
			get => Leagueflags.BBAdd40Str;
			set
			{
				Leagueflags.BBAdd40Str = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBAdd40Str"));
			}
		}
		public bool BBAdd50Agi
		{
			get => Leagueflags.BBAdd50Agi;
			set
			{
				Leagueflags.BBAdd50Agi = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBAdd50Agi"));
			}
		}
		public bool BBAdd40Vit
		{
			get => Leagueflags.BBAdd40Vit;
			set
			{
				Leagueflags.BBAdd40Vit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBAdd40Vit"));
			}
		}
		public bool BBAdd15Luck
		{
			get => Leagueflags.BBAdd15Luck;
			set
			{
				Leagueflags.BBAdd15Luck = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBAdd15Luck"));
			}
		}
		public bool BBAdd80HP
		{
			get => Leagueflags.BBAdd80HP;
			set
			{
				Leagueflags.BBAdd80HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBAdd80HP"));
			}
		}
		public bool BBFiWeapons
		{
			get => Leagueflags.BBFiWeapons;
			set
			{
				Leagueflags.BBFiWeapons = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBFiWeapons"));
			}
		}
		public bool BBFiArmor
		{
			get => Leagueflags.BBFiArmor;
			set
			{
				Leagueflags.BBFiArmor = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBFiArmor"));
			}
		}
		public bool BB50XPFiBB
		{
			get => Leagueflags.BB50XPFiBB;
			set
			{
				Leagueflags.BB50XPFiBB = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BB50XPFiBB"));
			}
		}
		#endregion
		#region RedMageBonus
		public bool RmAdd10Str
		{
			get => Leagueflags.RmAdd10Str;
			set
			{
				Leagueflags.RmAdd10Str = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmAdd10Str"));
			}

		}
		public bool RmAdd20Str
		{
			get => Leagueflags.RmAdd20Str;
			set
			{
				Leagueflags.RmAdd20Str = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmAdd20Str"));
			}
		}
		public bool RmAdd15Agi
		{
			get => Leagueflags.RmAdd15Agi;
			set
			{
				Leagueflags.RmAdd15Agi = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmAdd15Agi"));
			}
		}


		public bool RmAdd25Agi
		{
			get => Leagueflags.RmAdd25Agi;
			set
			{
				Leagueflags.RmAdd25Agi = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmAdd25Agi"));
			}
		}

		public bool RmAdd10Vit
		{
			get => Leagueflags.RmAdd10Vit;
			set
			{
				Leagueflags.RmAdd10Vit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmAdd10Vit"));
			}

		}
		public bool RmAdd20Vit
		{
			get => Leagueflags.RmAdd20Vit;
			set
			{
				Leagueflags.RmAdd20Vit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmAdd20Vit"));
			}
		}
		public bool RmAdd5Luck
		{
			get => Leagueflags.RmAdd5Luck;
			set
			{
				Leagueflags.RmAdd5Luck = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmAdd5Luck"));
			}
		}
		public bool RmAdd10Luck
		{
			get => Leagueflags.RmAdd10Luck;
			set
			{
				Leagueflags.RmAdd10Luck = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmAdd10Luck"));
			}
		}

		public bool RmAdd20HP
		{
			get => Leagueflags.RmAdd20HP;
			set
			{
				Leagueflags.RmAdd20HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmAdd20HP"));
			}
		}
		public bool RmAdd40HP
		{
			get => Leagueflags.RmAdd40HP;
			set
			{
				Leagueflags.RmAdd40HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmAdd40HP"));
			}
		}
		public bool RmAdd10PerHit
		{
			get => Leagueflags.RmAdd10PerHit;
			set
			{
				Leagueflags.RmAdd10PerHit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmAdd10PerHit"));
			}
		}
		public bool RmAdd20PerHit
		{
			get => Leagueflags.RmAdd20PerHit;
			set
			{
				Leagueflags.RmAdd20PerHit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmAdd20PerHit"));
			}
		}
		public bool RmEquipAxe
		{
			get => Leagueflags.RmEquipAxe;
			set
			{
				Leagueflags.RmEquipAxe = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmEquipAxe"));
			}
		}
		public bool RmEquipShields
		{
			get => Leagueflags.RmEquipShields;
			set
			{
				Leagueflags.RmEquipShields = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmEquipShields"));
			}
		}
		public bool RmEquipBonkHelm
		{
			get => Leagueflags.RmEquipBonkHelm;
			set
			{
				Leagueflags.RmEquipBonkHelm = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmEquipBonkHelm"));
			}
		}
		public bool RmLegSwords
		{
			get => Leagueflags.RmLegSwords;
			set
			{
				Leagueflags.RmLegSwords = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmLegSwords"));
			}
		}
		public bool RmWoodArmor
		{
			get => Leagueflags.RmWoodArmor;
			set
			{
				Leagueflags.RmWoodArmor = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmWoodArmor"));
			}
		}
		public bool RmLvl1MP2
		{
			get => Leagueflags.RmLvl1MP2;
			set
			{
				Leagueflags.RmLvl1MP2 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmLvl1MP2"));
			}
		}
		public bool RmMP1All
		{
			get => Leagueflags.RmMP1All;
			set
			{
				Leagueflags.RmMP1All = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MP1All"));
			}
		}
		public bool RmAddSpell
		{
			get => Leagueflags.RmAddSpell;
			set
			{
				Leagueflags.RmAddSpell = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmAddSpell"));
			}
		}
		public bool RmTelemagic
		{
			get => Leagueflags.RmTelemagic;
			set
			{
				Leagueflags.RmTelemagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmTelemagic"));
			}
		}
		public bool RmBuffMagic
		{
			get => Leagueflags.RmBuffmagic;
			set
			{
				Leagueflags.RmBuffmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmBuffMagic"));
			}
		}
		public bool RmSelfMagic
		{
			get => Leagueflags.RmSelfmagic;
			set
			{
				Leagueflags.RmSelfmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmSelfMagic"));
			}
		}
		public bool RmHealMagic
		{
			get => Leagueflags.RmHealmagic;
			set
			{
				Leagueflags.RmHealmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmHealMagic"));
			}
		}
		public bool RmHealMagicPlus
		{
			get => Leagueflags.RmHealplusmagic;
			set
			{
				Leagueflags.RmHealplusmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmHealMagicPlus"));
			}
		}
		public bool RmElemMagic
		{
			get => Leagueflags.RmElemmagic;
			set
			{
				Leagueflags.RmElemmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmElemMagic"));
			}
		}
		public bool RmElemplusMagic
		{
			get => Leagueflags.RmElemplusmagic;
			set
			{
				Leagueflags.RmElemplusmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmElemPlusMagic"));
			}
		}
		public bool RmNukeMagic
		{
			get => Leagueflags.RmNukemagic;
			set
			{
				Leagueflags.RmNukemagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmNukeMagic"));
			}
		}
		public bool RmDoomMagic
		{
			get => Leagueflags.RmDoommagic;
			set
			{
				Leagueflags.RmDoommagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmDoomMagic"));
			}
		}
		public bool RmCleanMagic
		{
			get => Leagueflags.RmCleanmagic;
			set
			{
				Leagueflags.RmCleanmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmCleanMagic"));
			}

		}
		public bool RmHurtUndead
		{
			get => Leagueflags.RmHurtundead;
			set
			{
				Leagueflags.RmHurtundead = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmHurtUndead"));
			}
		}
		public bool RmHurtDragon
		{
			get => Leagueflags.RmHurtdragon;
			set
			{
				Leagueflags.RmHurtdragon = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmHurtDragon"));
			}
		}
		public bool RmHurtAll
		{
			get => Leagueflags.RmHurtall;
			set
			{
				Leagueflags.RmHurtall = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmHurtAll"));
			}
		}
		public bool RmPromoFiWeapons
		{
			get => Leagueflags.RmPromoFiweapons;
			set
			{
				Leagueflags.RmPromoFiweapons = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmPromoFiWeapons"));
			}

		}
		public bool RmPromoSage
		{
			get => Leagueflags.RmPromoSage;
			set
			{
				Leagueflags.RmPromoSage = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmPromoSage"));
			}
		}
		public bool RmXP50Percent
		{
			get => Leagueflags.RmXP50percent;
			set
			{
				Leagueflags.RmXP50percent = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmXP50Percent"));
			}
		}
		public bool RmResistPoison
		{
			get => Leagueflags.RmResistPosion;
			set
			{
				Leagueflags.RmResistPosion = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmResistPoison"));
			}
		}
		public bool RmResistEarth
		{
			get => Leagueflags.RmResistEarth;
			set
			{
				Leagueflags.RmResistEarth = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmResistEarth"));
			}
		}
		public bool RmResistDeath
		{
			get => Leagueflags.RmResistDeath;
			set
			{
				Leagueflags.RmResistDeath = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmResistDeath"));
			}
		}
		public bool RmResistTime
		{
			get => Leagueflags.RmResistTime;
			set
			{
				Leagueflags.RmResistTime = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmResistTime"));
			}
		}
		public bool RmResistStatus
		{
			get => Leagueflags.RmResistStatus;
			set
			{
				Leagueflags.RmResistStatus = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmResistStatus"));
			}
		}
		public bool RmResistIce
		{
			get => Leagueflags.RmResistIce;
			set
			{
				Leagueflags.RmResistIce = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmResistIce"));
			}
		}
		public bool RmResistLit
		{
			get => Leagueflags.RmResistLit;
			set
			{
				Leagueflags.RmResistLit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmResistLit"));
			}
		}
		public bool RmResistFire
		{
			get => Leagueflags.RmResistFire;
			set
			{
				Leagueflags.RmResistFire = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmResistFire"));
			}
		}
		public bool RmStartGold200
		{
			get => Leagueflags.RmStartgold200;
			set
			{
				Leagueflags.RmStartgold200 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmStartGold200"));
			}
		}
		public bool RmStartGold400
		{
			get => Leagueflags.RmStartgold400;
			set
			{
				Leagueflags.RmStartgold400 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmStartGold400"));
			}
		}
		public bool RmStartGold600
		{
			get => Leagueflags.RmStartgold600;
			set
			{
				Leagueflags.RmStartgold600 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmStartGold600"));
			}
		}
		public bool RmStartGold800
		{
			get => Leagueflags.RmStartgold800;
			set
			{
				Leagueflags.RmStartgold800 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmStartGold800"));
			}
		}
		public bool RmStartGold1500
		{
			get => Leagueflags.RmStartgold1500;
			set
			{
				Leagueflags.RmStartgold1500 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmStartGold1500"));
			}
		}
		public bool RmStartGold5000
		{
			get => Leagueflags.RmStartgold5000;
			set
			{
				Leagueflags.RmStartgold5000 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmStartGold5000"));
			}
		}
		public bool RmStartGold20000
		{
			get => Leagueflags.RmStartgold20000;
			set
			{
				Leagueflags.RmStartgold20000 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmStartGold20000"));
			}
		}
		public bool RmAdd40Str
		{
			get => Leagueflags.RmAdd40Str;
			set
			{
				Leagueflags.RmAdd40Str = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmAdd40Str"));
			}
		}
		public bool RmAdd50Agi
		{
			get => Leagueflags.RmAdd50Agi;
			set
			{
				Leagueflags.RmAdd50Agi = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmAdd50Agi"));
			}
		}
		public bool RmAdd40Vit
		{
			get => Leagueflags.RmAdd40Vit;
			set
			{
				Leagueflags.RmAdd40Vit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmAdd40Vit"));
			}
		}
		public bool RmAdd15Luck
		{
			get => Leagueflags.RmAdd15Luck;
			set
			{
				Leagueflags.RmAdd15Luck = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmAdd15Luck"));
			}
		}
		public bool RmAdd80HP
		{
			get => Leagueflags.RmAdd80HP;
			set
			{
				Leagueflags.RmAdd80HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmAdd80HP"));
			}
		}
		public bool RmMdef2Lvl
		{
			get => Leagueflags.RmMdef2lvl;
			set
			{
				Leagueflags.RmMdef2lvl = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmMdef2Lvl"));
			}
		}
		public bool RmFiWeapons
		{
			get => Leagueflags.RmFiWeapons;
			set
			{
				Leagueflags.RmFiWeapons = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmFiWeapons"));
			}
		}
		public bool RmFiArmor
		{
			get => Leagueflags.RmFiArmor;
			set
			{
				Leagueflags.RmFiArmor = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmFiArmor"));
			}
		}
		public bool RmImprovedMP
		{
			get => Leagueflags.RmImprovedMP;
			set
			{
				Leagueflags.RmImprovedMP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ImprovedMP"));
			}
		}
		public bool RmSage
		{
			get => Leagueflags.RmSage;
			set
			{
				Leagueflags.RmSage = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmSage"));
			}
		}
		public bool RmXP100Percent
		{
			get => Leagueflags.RmXP100Percent;
			set
			{
				Leagueflags.RmXP100Percent = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmXP100Percent"));
			}
		}
		#endregion
		#region WhiteMageBonus
		public bool WmAdd10Str
		{
			get => Leagueflags.WmAdd10Str;
			set
			{
				Leagueflags.WmAdd10Str = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmAdd10Str"));
			}

		}
		public bool WmAdd20Str
		{
			get => Leagueflags.WmAdd20Str;
			set
			{
				Leagueflags.WmAdd20Str = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmAdd20Str"));
			}
		}
		public bool WmAdd15Agi
		{
			get => Leagueflags.WmAdd15Agi;
			set
			{
				Leagueflags.WmAdd15Agi = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmAdd15Agi"));
			}
		}


		public bool WmAdd25Agi
		{
			get => Leagueflags.WmAdd25Agi;
			set
			{
				Leagueflags.WmAdd25Agi = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmAdd25Agi"));
			}
		}

		public bool WmAdd10Vit
		{
			get => Leagueflags.WmAdd10Vit;
			set
			{
				Leagueflags.WmAdd10Vit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmAdd10Vit"));
			}

		}
		public bool WmAdd20Vit
		{
			get => Leagueflags.WmAdd20Vit;
			set
			{
				Leagueflags.WmAdd20Vit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmAdd20Vit"));
			}
		}
		public bool WmAdd5Luck
		{
			get => Leagueflags.WmAdd5Luck;
			set
			{
				Leagueflags.WmAdd5Luck = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmAdd5Luck"));
			}
		}
		public bool WmAdd10Luck
		{
			get => Leagueflags.WmAdd10Luck;
			set
			{
				Leagueflags.WmAdd10Luck = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmAdd10Luck"));
			}
		}

		public bool WmAdd20HP
		{
			get => Leagueflags.WmAdd20HP;
			set
			{
				Leagueflags.WmAdd20HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmAdd20HP"));
			}
		}
		public bool WmAdd40HP
		{
			get => Leagueflags.WmAdd40HP;
			set
			{
				Leagueflags.WmAdd40HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmAdd40HP"));
			}
		}
		public bool WmAdd10PerHit
		{
			get => Leagueflags.WmAdd10PerHit;
			set
			{
				Leagueflags.WmAdd10PerHit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmAdd10PerHit"));
			}
		}
		public bool WmAdd20PerHit
		{
			get => Leagueflags.WmAdd20PerHit;
			set
			{
				Leagueflags.WmAdd20PerHit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmAdd20PerHit"));
			}
		}
		public bool WmEquipAxe
		{
			get => Leagueflags.WmEquipAxe;
			set
			{
				Leagueflags.WmEquipAxe = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmEquipAxe"));
			}
		}
		public bool WmEquipShirt
		{
			get => Leagueflags.WmEquipShirt;
			set
			{
				Leagueflags.WmEquipShirt = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmEquipShirt"));
			}
		}
		public bool WmEquipShields
		{
			get => Leagueflags.WmEquipShields;
			set
			{
				Leagueflags.WmEquipShields = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmEquipShields"));
			}
		}
		public bool WmEquipBonkHelm
		{
			get => Leagueflags.WmEquipBonkHelm;
			set
			{
				Leagueflags.WmEquipBonkHelm = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmEquipBonkHelm"));
			}
		}
		public bool WmThiefWeaponsBonus
		{
			get => Leagueflags.WmThiefWeaponsBonus;
			set
			{
				Leagueflags.WmThiefWeaponsBonus = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmThiefWeaponsBonus"));
			}
		}
		public bool WmRMArmor
		{
			get => Leagueflags.WmRMArmor;
			set
			{
				Leagueflags.WmRMArmor = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmRMArmor"));
			}
		}
		public bool WmLegSwords
		{
			get => Leagueflags.WmLegSwords;
			set
			{
				Leagueflags.WmLegSwords = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmLegSwords"));
			}
		}
		public bool WmWoodArmor
		{
			get => Leagueflags.WmWoodArmor;
			set
			{
				Leagueflags.WmWoodArmor = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmWoodArmor"));
			}
		}
		public bool WmLvl1MP2
		{
			get => Leagueflags.WmLvl1MP2;
			set
			{
				Leagueflags.WmLvl1MP2 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmLvl1MP2"));
			}
		}
		public bool WmMP1All
		{
			get => Leagueflags.WmMP1All;
			set
			{
				Leagueflags.WmMP1All = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmMP1All"));
			}
		}
		public bool WmAddSpell
		{
			get => Leagueflags.WmAddSpell;
			set
			{
				Leagueflags.WmAddSpell = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmAddSpell"));
			}
		}
		public bool WmTelemagic
		{
			get => Leagueflags.WmTelemagic;
			set
			{
				Leagueflags.WmTelemagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmTelemagic"));
			}
		}
		public bool WmBuffMagic
		{
			get => Leagueflags.WmBuffmagic;
			set
			{
				Leagueflags.WmBuffmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmBuffMagic"));
			}
		}
		public bool WmSelfMagic
		{
			get => Leagueflags.WmSelfmagic;
			set
			{
				Leagueflags.WmSelfmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmSelfMagic"));
			}
		}
		public bool WmHealMagic
		{
			get => Leagueflags.WmHealmagic;
			set
			{
				Leagueflags.WmHealmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmHealMagic"));
			}
		}
		public bool WmHealMagicPlus
		{
			get => Leagueflags.WmHealplusmagic;
			set
			{
				Leagueflags.WmHealplusmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmHealMagicPlus"));
			}
		}
		public bool WmElemMagic
		{
			get => Leagueflags.WmElemmagic;
			set
			{
				Leagueflags.WmElemmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmElemMagic"));
			}
		}
		public bool WmElemplusMagic
		{
			get => Leagueflags.WmElemplusmagic;
			set
			{
				Leagueflags.WmElemplusmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmElemPlusMagic"));
			}
		}
		public bool WmNukeMagic
		{
			get => Leagueflags.WmNukemagic;
			set
			{
				Leagueflags.WmNukemagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmNukeMagic"));
			}
		}
		public bool DoomMagic
		{
			get => Leagueflags.WmDoommagic;
			set
			{
				Leagueflags.WmDoommagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmDoomMagic"));
			}
		}
		public bool WmCleanMagic
		{
			get => Leagueflags.WmCleanmagic;
			set
			{
				Leagueflags.WmCleanmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmCleanMagic"));
			}

		}
		public bool WmImpThor
		{
			get => Leagueflags.WmImpThor;
			set
			{
				Leagueflags.WmImpThor = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmImpThor"));
			}
		}
		public bool WmHurtUndead
		{
			get => Leagueflags.WmHurtundead;
			set
			{
				Leagueflags.WmHurtundead = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmHurtUndead"));
			}
		}
		public bool WmHurtDragon
		{
			get => Leagueflags.WmHurtdragon;
			set
			{
				Leagueflags.WmHurtdragon = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmHurtDragon"));
			}
		}
		public bool WmHurtAll
		{
			get => Leagueflags.WmHurtall;
			set
			{
				Leagueflags.WmHurtall = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmHurtAll"));
			}
		}
		public bool WmPromoFiWeapons
		{
			get => Leagueflags.WmPromoFiweapons;
			set
			{
				Leagueflags.WmPromoFiweapons = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmPromoFiWeapons"));
			}

		}
		public bool WmXP50Percent
		{
			get => Leagueflags.WmXP50percent;
			set
			{
				Leagueflags.WmXP50percent = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmXP50Percent"));
			}
		}
		public bool WmResistPoison
		{
			get => Leagueflags.WmResistPosion;
			set
			{
				Leagueflags.WmResistPosion = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmResistPoison"));
			}
		}
		public bool WmResistEarth
		{
			get => Leagueflags.WmResistEarth;
			set
			{
				Leagueflags.WmResistEarth = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmResistEarth"));
			}
		}
		public bool WmResistDeath
		{
			get => Leagueflags.WmResistDeath;
			set
			{
				Leagueflags.WmResistDeath = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmResistDeath"));
			}
		}
		public bool WmResistTime
		{
			get => Leagueflags.WmResistTime;
			set
			{
				Leagueflags.WmResistTime = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmResistTime"));
			}
		}
		public bool WmResistStatus
		{
			get => Leagueflags.WmResistStatus;
			set
			{
				Leagueflags.WmResistStatus = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmResistStatus"));
			}
		}
		public bool WmResistIce
		{
			get => Leagueflags.WmResistIce;
			set
			{
				Leagueflags.WmResistIce = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmResistIce"));
			}
		}
		public bool WmResistLit
		{
			get => Leagueflags.WmResistLit;
			set
			{
				Leagueflags.WmResistLit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmResistLit"));
			}
		}
		public bool WmResistFire
		{
			get => Leagueflags.WmResistFire;
			set
			{
				Leagueflags.WmResistFire = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmResistFire"));
			}
		}
		public bool WmStartGold200
		{
			get => Leagueflags.WmStartgold200;
			set
			{
				Leagueflags.WmStartgold200 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmStartGold200"));
			}
		}
		public bool WmStartGold400
		{
			get => Leagueflags.WmStartgold400;
			set
			{
				Leagueflags.WmStartgold400 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmStartGold400"));
			}
		}
		public bool WmStartGold600
		{
			get => Leagueflags.WmStartgold600;
			set
			{
				Leagueflags.WmStartgold600 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmStartGold600"));
			}
		}
		public bool WmStartGold800
		{
			get => Leagueflags.WmStartgold800;
			set
			{
				Leagueflags.WmStartgold800 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmStartGold800"));
			}
		}
		public bool WmStartGold1500
		{
			get => Leagueflags.WmStartgold1500;
			set
			{
				Leagueflags.WmStartgold1500 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmStartGold1500"));
			}
		}
		public bool WmStartGold5000
		{
			get => Leagueflags.WmStartgold5000;
			set
			{
				Leagueflags.WmStartgold5000 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmStartGold5000"));
			}
		}
		public bool WmStartGold20000
		{
			get => Leagueflags.WmStartgold20000;
			set
			{
				Leagueflags.WmStartgold20000 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmStartGold20000"));
			}
		}
		public bool WmAdd40Str
		{
			get => Leagueflags.WmAdd40Str;
			set
			{
				Leagueflags.WmAdd40Str = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmAdd40Str"));
			}
		}
		public bool WmAdd50Agi
		{
			get => Leagueflags.WmAdd50Agi;
			set
			{
				Leagueflags.WmAdd50Agi = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmAdd50Agi"));
			}
		}
		public bool WmAdd40Vit
		{
			get => Leagueflags.WmAdd40Vit;
			set
			{
				Leagueflags.WmAdd40Vit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmAdd40Vit"));
			}
		}
		public bool WmAdd15Luck
		{
			get => Leagueflags.WmAdd15Luck;
			set
			{
				Leagueflags.WmAdd15Luck = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmAdd15Luck"));
			}
		}
		public bool WmAdd80HP
		{
			get => Leagueflags.WmAdd80HP;
			set
			{
				Leagueflags.WmAdd80HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmAdd80HP"));
			}
		}
		public bool WmMdef2Lvl
		{
			get => Leagueflags.WmMdef2lvl;
			set
			{
				Leagueflags.WmMdef2lvl = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmMdef2Lvl"));
			}
		}
		public bool WmFiWeapons
		{
			get => Leagueflags.WmFiWeapons;
			set
			{
				Leagueflags.WmFiWeapons = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmFiWeapons"));
			}
		}
		public bool WmFiArmor
		{
			get => Leagueflags.WmFiArmor;
			set
			{
				Leagueflags.WmFiArmor = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmFiArmor"));
			}
		}
		public bool WmImprovedMP
		{
			get => Leagueflags.WmImprovedMP;
			set
			{
				Leagueflags.WmImprovedMP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmImprovedMP"));
			}
		}
		public bool WmXP100Percent
		{
			get => Leagueflags.WmXP100Percent;
			set
			{
				Leagueflags.WmXP100Percent = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmXP100Percent"));
			}
		}
		#endregion
		#region BlackMageBonus
		public bool BmAdd10Str
		{
			get => Leagueflags.BmAdd10Str;
			set
			{
				Leagueflags.BmAdd10Str = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmAdd10Str"));
			}

		}
		public bool BmAdd20Str
		{
			get => Leagueflags.BmAdd20Str;
			set
			{
				Leagueflags.BmAdd20Str = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmAdd20Str"));
			}
		}
		public bool BmAdd15Agi
		{
			get => Leagueflags.BmAdd15Agi;
			set
			{
				Leagueflags.BmAdd15Agi = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmAdd15Agi"));
			}
		}

		public bool BmAdd25Agi
		{
			get => Leagueflags.BmAdd25Agi;
			set
			{
				Leagueflags.BmAdd25Agi = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmAdd25Agi"));
			}
		}

		public bool BmAdd10Vit
		{
			get => Leagueflags.BmAdd10Vit;
			set
			{
				Leagueflags.BmAdd10Vit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmAdd10Vit"));
			}

		}
		public bool BmAdd20Vit
		{
			get => Leagueflags.BmAdd20Vit;
			set
			{
				Leagueflags.BmAdd20Vit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmAdd20Vit"));
			}
		}
		public bool BmAdd5Luck
		{
			get => Leagueflags.BmAdd5Luck;
			set
			{
				Leagueflags.BmAdd5Luck = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Add5Luck"));
			}
		}
		public bool BmAdd10Luck
		{
			get => Leagueflags.BmAdd10Luck;
			set
			{
				Leagueflags.BmAdd10Luck = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmAdd10Luck"));
			}
		}

		public bool BmAdd20HP
		{
			get => Leagueflags.BmAdd20HP;
			set
			{
				Leagueflags.BmAdd20HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmAdd20HP"));
			}
		}
		public bool BmAdd40HP
		{
			get => Leagueflags.BmAdd80HP;
			set
			{
				Leagueflags.BmAdd80HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmAdd40HP"));
			}
		}
		public bool BmAdd10PerHit
		{
			get => Leagueflags.BmAdd10PerHit;
			set
			{
				Leagueflags.BmAdd10PerHit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmAdd10PerHit"));
			}
		}
		public bool BmAdd20PerHit
		{
			get => Leagueflags.BmAdd20PerHit;
			set
			{
				Leagueflags.BmAdd20PerHit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmAdd20PerHit"));
			}
		}
		public bool BmEquipAxe
		{
			get => Leagueflags.BmEquipAxe;
			set
			{
				Leagueflags.BmEquipAxe = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmEquipAxe"));
			}
		}
		public bool BmEquipShirt
		{
			get => Leagueflags.BmEquipShirt;
			set
			{
				Leagueflags.BmEquipShirt = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmEquipShirt"));
			}
		}
		public bool BmEquipShields
		{
			get => Leagueflags.BmEquipShields;
			set
			{
				Leagueflags.BmEquipShields = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmEquipShields"));
			}
		}
		public bool BmEquipBonkHelm
		{
			get => Leagueflags.BmEquipBonkHelm;
			set
			{
				Leagueflags.BmEquipBonkHelm = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmEquipBonkHelm"));
			}
		}
		public bool BmThiefWeaponsBonus
		{
			get => Leagueflags.BmThiefWeaponsBonus;
			set
			{
				Leagueflags.BmThiefWeaponsBonus = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmThiefWeaponsBonus"));
			}
		}
		public bool BmRMArmor
		{
			get => Leagueflags.BmRMArmor;
			set
			{
				Leagueflags.BmRMArmor = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmRMArmor"));
			}
		}
		public bool BmLegSwords
		{
			get => Leagueflags.BmLegSwords;
			set
			{
				Leagueflags.BmLegSwords = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmLegSwords"));
			}
		}
		public bool BmWoodArmor
		{
			get => Leagueflags.BmWoodArmor;
			set
			{
				Leagueflags.BmWoodArmor = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmWoodArmor"));
			}
		}
		public bool BmLvl1MP2
		{
			get => Leagueflags.BmLvl1MP2;
			set
			{
				Leagueflags.BmLvl1MP2 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmLvl1MP2"));
			}
		}
		public bool BmMP1All
		{
			get => Leagueflags.BmMP1All;
			set
			{
				Leagueflags.BmMP1All = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmMP1All"));
			}
		}
		public bool BmAddSpell
		{
			get => Leagueflags.BmAddSpell;
			set
			{
				Leagueflags.BmAddSpell = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmAddSpell"));
			}
		}
		public bool BmTelemagic
		{
			get => Leagueflags.BmTelemagic;
			set
			{
				Leagueflags.BmTelemagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmTelemagic"));
			}
		}
		public bool BmBuffMagic
		{
			get => Leagueflags.BmBuffmagic;
			set
			{
				Leagueflags.BmBuffmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmBuffMagic"));
			}
		}
		public bool BmSelfMagic
		{
			get => Leagueflags.BmSelfmagic;
			set
			{
				Leagueflags.BmSelfmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmSelfMagic"));
			}
		}
		public bool BmHealMagic
		{
			get => Leagueflags.BmHealmagic;
			set
			{
				Leagueflags.BmHealmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmHealMagic"));
			}
		}
		public bool BmHealMagicPlus
		{
			get => Leagueflags.BmHealplusmagic;
			set
			{
				Leagueflags.BmHealplusmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmHealMagicPlus"));
			}
		}
		public bool BmElemMagic
		{
			get => Leagueflags.BmElemmagic;
			set
			{
				Leagueflags.BmElemmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmElemMagic"));
			}
		}
		public bool BmElemplusMagic
		{
			get => Leagueflags.BmElemplusmagic;
			set
			{
				Leagueflags.BmElemplusmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmElemPlusMagic"));
			}
		}
		public bool BmNukeMagic
		{
			get => Leagueflags.BmNukemagic;
			set
			{
				Leagueflags.BmNukemagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmNukeMagic"));
			}
		}
		public bool BmDoomMagic
		{
			get => Leagueflags.BmDoommagic;
			set
			{
				Leagueflags.BmDoommagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmDoomMagic"));
			}
		}
		public bool BmCleanMagic
		{
			get => Leagueflags.BmCleanmagic;
			set
			{
				Leagueflags.BmCleanmagic = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmCleanMagic"));
			}

		}
		public bool BmImpCatclaw
		{
			get => Leagueflags.BmImpCatclaw;
			set
			{
				Leagueflags.BmImpCatclaw = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmImpCatclaw"));
			}
		}
		public bool BmHurtUndead
		{
			get => Leagueflags.BmHurtundead;
			set
			{
				Leagueflags.BmHurtundead = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmHurtUndead"));
			}
		}
		public bool BmHurtDragon
		{
			get => Leagueflags.BmHurtdragon;
			set
			{
				Leagueflags.BmHurtdragon = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmHurtDragon"));
			}
		}
		public bool BmHurtAll
		{
			get => Leagueflags.BmHurtall;
			set
			{
				Leagueflags.BmHurtall = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmHurtAll"));
			}
		}
		public bool BmPromoFiWeapons
		{
			get => Leagueflags.BmPromoFiweapons;
			set
			{
				Leagueflags.BmPromoFiweapons = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmPromoFiWeapons"));
			}

		}
		public bool BmXP50Percent
		{
			get => Leagueflags.BmXP50percent;
			set
			{
				Leagueflags.BmXP50percent = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmXP50Percent"));
			}
		}
		public bool BmResistPoison
		{
			get => Leagueflags.BmResistPosion;
			set
			{
				Leagueflags.BmResistPosion = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmResistPoison"));
			}
		}
		public bool BmResistEarth
		{
			get => Leagueflags.BmResistEarth;
			set
			{
				Leagueflags.BmResistEarth = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmResistEarth"));
			}
		}
		public bool BmResistDeath
		{
			get => Leagueflags.BmResistDeath;
			set
			{
				Leagueflags.BmResistDeath = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmResistDeath"));
			}
		}
		public bool BmResistTime
		{
			get => Leagueflags.BmResistTime;
			set
			{
				Leagueflags.BmResistTime = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmResistTime"));
			}
		}
		public bool BmResistStatus
		{
			get => Leagueflags.BmResistStatus;
			set
			{
				Leagueflags.BmResistStatus = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmResistStatus"));
			}
		}
		public bool BmResistIce
		{
			get => Leagueflags.BmResistIce;
			set
			{
				Leagueflags.BmResistIce = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmResistIce"));
			}
		}
		public bool BmResistLit
		{
			get => Leagueflags.BmResistLit;
			set
			{
				Leagueflags.BmResistLit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmResistLit"));
			}
		}
		public bool BmResistFire
		{
			get => Leagueflags.BmResistFire;
			set
			{
				Leagueflags.BmResistFire = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmResistFire"));
			}
		}
		public bool BmStartGold200
		{
			get => Leagueflags.BmStartgold200;
			set
			{
				Leagueflags.BmStartgold200 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmStartGold200"));
			}
		}
		public bool BmStartGold400
		{
			get => Leagueflags.BmStartgold400;
			set
			{
				Leagueflags.BmStartgold400 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmStartGold400"));
			}
		}
		public bool BmStartGold600
		{
			get => Leagueflags.BmStartgold600;
			set
			{
				Leagueflags.BmStartgold600 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmStartGold600"));
			}
		}
		public bool BmStartGold800
		{
			get => Leagueflags.BmStartgold800;
			set
			{
				Leagueflags.BmStartgold800 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmStartGold800"));
			}
		}
		public bool BmStartGold1500
		{
			get => Leagueflags.BmStartgold1500;
			set
			{
				Leagueflags.BmStartgold1500 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmStartGold1500"));
			}
		}
		public bool BmStartGold5000
		{
			get => Leagueflags.BmStartgold5000;
			set
			{
				Leagueflags.BmStartgold5000 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmStartGold5000"));
			}
		}
		public bool BmStartGold20000
		{
			get => Leagueflags.BmStartgold20000;
			set
			{
				Leagueflags.BmStartgold20000 = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmStartGold20000"));
			}
		}
		public bool BmAdd40Str
		{
			get => Leagueflags.BmAdd40Str;
			set
			{
				Leagueflags.BmAdd40Str = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmAdd40Str"));
			}
		}
		public bool BmAdd50Agi
		{
			get => Leagueflags.BmAdd50Agi;
			set
			{
				Leagueflags.BmAdd50Agi = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmAdd50Agi"));
			}
		}
		public bool BmAdd40Vit
		{
			get => Leagueflags.BmAdd40Vit;
			set
			{
				Leagueflags.BmAdd40Vit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmAdd40Vit"));
			}
		}
		public bool BmAdd15Luck
		{
			get => Leagueflags.BmAdd15Luck;
			set
			{
				Leagueflags.BmAdd15Luck = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmAdd15Luck"));
			}
		}
		public bool BmAdd80HP
		{
			get => Leagueflags.BmAdd80HP;
			set
			{
				Leagueflags.BmAdd80HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmAdd80HP"));
			}
		}
		public bool BmMdef2Lvl
		{
			get => Leagueflags.BmMdef2lvl;
			set
			{
				Leagueflags.BmMdef2lvl = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmMdef2Lvl"));
			}
		}
		public bool BmFiWeapons
		{
			get => Leagueflags.BmFiWeapons;
			set
			{
				Leagueflags.BmFiWeapons = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiWeapons"));
			}
		}
		public bool BmFiArmor
		{
			get => Leagueflags.BmFiArmor;
			set
			{
				Leagueflags.BmFiArmor = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmFiArmor"));
			}
		}
		public bool BmImprovedMP
		{
			get => Leagueflags.BmImprovedMP;
			set
			{
				Leagueflags.BmImprovedMP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmImprovedMP"));
			}
		}
		public bool BmXP100Percent
		{
			get => Leagueflags.BmXP100Percent;
			set
			{
				Leagueflags.BmXP100Percent = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmXP100Percent"));
			}
		}

		#endregion
		#endregion
		#region Malus
		#region FighterMalus
		public bool FiDown10Str
		{
			get => Leagueflags.FiDown10Str;
			set
			{
				Leagueflags.FiDown10Str = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiDown10Str"));
			}
		}
		public bool FiDown20Str
		{
			get => Leagueflags.FiDown20Str;
			set
			{
				Leagueflags.FiDown20Str = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiDown20Str"));
			}
		}
		public bool FiDown10Agi
		{
			get => Leagueflags.FiDown10Agi;
			set
			{
				Leagueflags.FiDown10Agi = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiDown10Agi"));
			}
		}
		public bool FiDown10Vit
		{
			get => Leagueflags.FiDown10Vit;
			set
			{
				Leagueflags.FiDown10Vit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiDown10Vit"));
			}
		}

		public bool FiDown5Luck
		{
			get => Leagueflags.FiDown5Luck;
			set
			{
				Leagueflags.FiDown5Luck = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiDown5Luck"));
			}
		}
		public bool FiDown15HP
		{
			get => Leagueflags.FiDown15HP;
			set
			{
				Leagueflags.FiDown15HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiDown15HP"));
			}
		}
		public bool FiDown30HP
		{
			get => Leagueflags.FiDown30HP;
			set
			{
				Leagueflags.FiDown30HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiDown15HP"));
			}
		}
		public bool FiBMHP
		{
			get => Leagueflags.FiBMHP;
			set
			{
				Leagueflags.FiBMHP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiBMHP"));
			}
		}
		public bool FiDown1HitPercent
		{
			get => Leagueflags.FiDown1Hitpercent;
			set
			{
				Leagueflags.FiDown1Hitpercent = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiDown1HitPercent"));
			}
		}
		public bool FiDown1MDef
		{
			get => Leagueflags.FiDown1Mdef;
			set
			{
				Leagueflags.FiDown1Mdef = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiDown1MDef"));
			}
		}
		public bool FiNoBracelets
		{
			get => Leagueflags.FiNobrace;
			set
			{
				Leagueflags.FiNobrace = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiNoBracelets"));
			}
		}
		public bool FiNoMasa
		{
			get => Leagueflags.FiNoMasa;
			set
			{
				Leagueflags.FiNoMasa = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiNoMasa"));
			}
		}
		public bool FiNoRibbon
		{
			get => Leagueflags.FiNoRibbon;
			set
			{
				Leagueflags.FiNoRibbon = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiNoRibbon"));
			}
		}
		public bool FiNoProRing
		{
			get => Leagueflags.FiNoProring;
			set
			{
				Leagueflags.FiNoProring = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiNoProRing"));
			}
		}

		public bool FiThWeaponMal
		{
			get => Leagueflags.FiThiefweaponsMalus;
			set
			{
				Leagueflags.FiThiefweaponsMalus = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiThWeaponMal"));
			}
		}
		public bool FiNoFiPromoArmor
		{
			get => Leagueflags.FiNoFiPromoArmor;
			set
			{
				Leagueflags.FiNoFiPromoArmor = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiNoFiPromoArmor"));
			}
		}
		public bool FiNoPromoSpells
		{
			get => Leagueflags.FiNoPromoSpells;
			set
			{
				Leagueflags.FiNoPromoSpells = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiNoPromoSpells"));
			}
		}
		public bool FiDown50GP
		{
			get => Leagueflags.FiDown50GP;
			set
			{
				Leagueflags.FiDown50GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiDown50GP"));
			}
		}
		public bool FiDown100GP
		{
			get => Leagueflags.FiDown100GP;
			set
			{
				Leagueflags.FiDown100GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiDown100GP"));
			}
		}
		public bool FiDown150GP
		{
			get => Leagueflags.FiDown150GP;
			set
			{
				Leagueflags.FiDown150GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiDown150GP"));
			}
		}
		public bool FiDown350GP
		{
			get => Leagueflags.FiDown350GP;
			set
			{
				Leagueflags.FiDown350GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiDown350GP"));
			}
		}
		public bool FiDown1100GP
		{
			get => Leagueflags.FiDown1100GP;
			set
			{
				Leagueflags.FiDown1100GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiDown1100GP"));
			}
		}
		public bool FiDown4500GP
		{
			get => Leagueflags.FiDown4500gp;
			set
			{
				Leagueflags.FiDown4500gp = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiDown4500GP"));
			}
		}
		#endregion
		#region ThiefMalus
		public bool ThDown10Str
		{
			get => Leagueflags.ThDown10Str;
			set
			{
				Leagueflags.ThDown10Str = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThDown10Str"));
			}
		}
		public bool ThDown10Agi
		{
			get => Leagueflags.ThDown10Agi;
			set
			{
				Leagueflags.ThDown10Agi = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThDown10Agi"));
			}
		}
		public bool ThDown20Agi
		{
			get => Leagueflags.ThDown20Agi;
			set
			{
				Leagueflags.ThDown20Agi = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThDown20Agi"));
			}
		}
		public bool ThDown10Vit
		{
			get => Leagueflags.ThDown10Vit;
			set
			{
				Leagueflags.ThDown10Vit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThDown10Vit"));
			}
		}
		public bool ThDown5Luck
		{
			get => Leagueflags.ThDown5Luck;
			set
			{
				Leagueflags.ThDown5Luck = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThDown5Luck"));
			}
		}
		public bool ThDown10Luck
		{
			get => Leagueflags.ThDown10Luck;
			set
			{
				Leagueflags.ThDown10Luck = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThDown10Luck"));
			}
		}
		public bool ThDown15HP
		{
			get => Leagueflags.ThDown15HP;
			set
			{
				Leagueflags.ThDown15HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThDown15HP"));
			}
		}
		public bool ThDown30HP
		{
			get => Leagueflags.ThDown30HP;
			set
			{
				Leagueflags.ThDown30HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThDown15HP"));
			}
		}
		public bool ThDown1HitPercent
		{
			get => Leagueflags.ThDown1Hitpercent;
			set
			{
				Leagueflags.ThDown1Hitpercent = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThDown1HitPercent"));
			}
		}
		public bool ThDown1MDef
		{
			get => Leagueflags.ThDown1Mdef;
			set
			{
				Leagueflags.ThDown1Mdef = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThDown1MDef"));
			}
		}
		public bool ThNoBracelets
		{
			get => Leagueflags.ThNobrace;
			set
			{
				Leagueflags.ThNobrace = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThNoBracelets"));
			}
		}
		public bool ThNoMasa
		{
			get => Leagueflags.ThNoMasa;
			set
			{
				Leagueflags.ThNoMasa = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThNoMasa"));
			}
		}
		public bool ThNoRibbon
		{
			get => Leagueflags.ThNoRibbon;
			set
			{
				Leagueflags.ThNoRibbon = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThNoRibbon"));
			}
		}
		public bool ThNoProRing
		{
			get => Leagueflags.ThNoProring;
			set
			{
				Leagueflags.ThNoProring = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThNoProRing"));
			}
		}
		public bool ThLateLockPicking
		{
			get => Leagueflags.ThLateLockpick;
			set
			{
				Leagueflags.ThLateLockpick = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThLateLockpick"));
			}
		}
		public bool ThPromoRmArmor
		{
			get => Leagueflags.ThPromoRMArmor;
			set
			{
				Leagueflags.ThPromoRMArmor = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThPromoRMArmor"));
			}
		}
		public bool ThNoPromoSpells
		{
			get => Leagueflags.ThNoPromoSpells;
			set
			{
				Leagueflags.ThNoPromoSpells = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThNoPromoSpells"));
			}
		}
		public bool Down50GP
		{
			get => Leagueflags.ThDown50GP;
			set
			{
				Leagueflags.ThDown50GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThDown50GP"));
			}
		}
		public bool ThDown100GP
		{
			get => Leagueflags.ThDown100GP;
			set
			{
				Leagueflags.ThDown100GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThDown100GP"));
			}
		}
		public bool ThDown150GP
		{
			get => Leagueflags.ThDown150GP;
			set
			{
				Leagueflags.ThDown150GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThDown150GP"));
			}
		}
		public bool ThDown350GP
		{
			get => Leagueflags.ThDown350GP;
			set
			{
				Leagueflags.ThDown350GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThDown350GP"));
			}
		}
		public bool ThDown1100GP
		{
			get => Leagueflags.ThDown1100GP;
			set
			{
				Leagueflags.ThDown1100GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Down1100GP"));
			}
		}
		public bool ThDown4500GP
		{
			get => Leagueflags.ThDown4500gp;
			set
			{
				Leagueflags.ThDown4500gp = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThDown4500GP"));
			}
		}
		#endregion
		#region BlackBeltMalus
		public bool BBDown10Str
		{
			get => Leagueflags.BBDown10Str;
			set
			{
				Leagueflags.BBDown10Str = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBDown10Str"));
			}
		}
		public bool BBDown10Agi
		{
			get => Leagueflags.BBDown10Agi;
			set
			{
				Leagueflags.BBDown10Agi = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBDown10Agi"));
			}
		}
		public bool BBDown10Vit
		{
			get => Leagueflags.BBDown10Vit;
			set
			{
				Leagueflags.BBDown10Vit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBDown10Vit"));
			}
		}
		public bool BBDown20Vit
		{
			get => Leagueflags.BBDown20Vit;
			set
			{
				Leagueflags.BBDown20Vit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBDown20Vit"));
			}
		}
		public bool BBDown5Luck
		{
			get => Leagueflags.BBDown5Luck;
			set
			{
				Leagueflags.BBDown5Luck = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBDown5Luck"));
			}
		}
		public bool BBDown10Luck
		{
			get => Leagueflags.BBDown10Luck;
			set
			{
				Leagueflags.BBDown10Luck = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBDown10Luck"));
			}
		}
		public bool BBDown15HP
		{
			get => Leagueflags.BBDown15HP;
			set
			{
				Leagueflags.BBDown15HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBDown15HP"));
			}
		}
		public bool BBDown30HP
		{
			get => Leagueflags.BBDown30HP;
			set
			{
				Leagueflags.BBDown30HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBDown15HP"));
			}
		}
		public bool BBDown1HitPercent
		{
			get => Leagueflags.BBDown1Hitpercent;
			set
			{
				Leagueflags.BBDown1Hitpercent = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBDown1HitPercent"));
			}
		}
		public bool BBDown1MDef
		{
			get => Leagueflags.BBDown1Mdef;
			set
			{
				Leagueflags.BBDown1Mdef = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBDown1MDef"));
			}
		}
		public bool BBNoBracelets
		{
			get => Leagueflags.BBNobrace;
			set
			{
				Leagueflags.BBNobrace = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBNoBracelets"));
			}
		}
		public bool BBNoMasa
		{
			get => Leagueflags.BBNoMasa;
			set
			{
				Leagueflags.BBNoMasa = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBNoMasa"));
			}
		}
		public bool BBNoRibbon
		{
			get => Leagueflags.BBNoRibbon;
			set
			{
				Leagueflags.BBNoRibbon = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBNoRibbon"));
			}
		}
		public bool BBNoProRing
		{
			get => Leagueflags.BBNoProring;
			set
			{
				Leagueflags.BBNoProring = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBNoProRing"));
			}
		}
		public bool BBDown50GP
		{
			get => Leagueflags.BBDown50GP;
			set
			{
				Leagueflags.BBDown50GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBDown50GP"));
			}
		}
		public bool BBDown100GP
		{
			get => Leagueflags.BBDown100GP;
			set
			{
				Leagueflags.BBDown100GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBDown100GP"));
			}
		}
		public bool BBDown150GP
		{
			get => Leagueflags.BBDown150GP;
			set
			{
				Leagueflags.BBDown150GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBDown150GP"));
			}
		}
		public bool BBDown350GP
		{
			get => Leagueflags.BBDown350GP;
			set
			{
				Leagueflags.BBDown350GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBDown350GP"));
			}
		}
		public bool BBDown1100GP
		{
			get => Leagueflags.BBDown1100GP;
			set
			{
				Leagueflags.BBDown1100GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBDown1100GP"));
			}
		}
		public bool BBDown4500GP
		{
			get => Leagueflags.BBDown4500gp;
			set
			{
				Leagueflags.BBDown4500gp = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBDown4500GP"));
			}
		}
		#endregion
		#region RedMageMalus
		public bool RmDown10Str
		{
			get => Leagueflags.RmDown10Str;
			set
			{
				Leagueflags.RmDown10Str = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmDown10Str"));
			}
		}
		public bool RmDown10Agi
		{
			get => Leagueflags.RmDown10Agi;
			set
			{
				Leagueflags.RmDown10Agi = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmDown10Agi"));
			}
		}
		public bool RmDown10Vit
		{
			get => Leagueflags.RmDown10Vit;
			set
			{
				Leagueflags.RmDown10Vit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmDown10Vit"));
			}
		}
		public bool RmDown5Luck
		{
			get => Leagueflags.RmDown5Luck;
			set
			{
				Leagueflags.RmDown5Luck = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmDown5Luck"));
			}
		}
		public bool RmDown15HP
		{
			get => Leagueflags.RmDown15HP;
			set
			{
				Leagueflags.RmDown15HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmDown15HP"));
			}
		}
		public bool RmDown30HP
		{
			get => Leagueflags.RmDown30HP;
			set
			{
				Leagueflags.RmDown30HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmDown15HP"));
			}
		}
		public bool RmDown1HitPercent
		{
			get => Leagueflags.RmDown1Hitpercent;
			set
			{
				Leagueflags.RmDown1Hitpercent = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmDown1HitPercent"));
			}
		}
		public bool RmDown1MDef
		{
			get => Leagueflags.RmDown1Mdef;
			set
			{
				Leagueflags.RmDown1Mdef = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmDown1MDef"));
			}
		}
		public bool RmNoBracelets
		{
			get => Leagueflags.RmNobrace;
			set
			{
				Leagueflags.RmNobrace = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmNoBracelets"));
			}
		}
		public bool RmNoMasa
		{
			get => Leagueflags.RmNoMasa;
			set
			{
				Leagueflags.RmNoMasa = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmNoMasa"));
			}
		}
		public bool RmNoRibbon
		{
			get => Leagueflags.RmNoRibbon;
			set
			{
				Leagueflags.RmNoRibbon = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmNoRibbon"));
			}
		}
		public bool RmNoProRing
		{
			get => Leagueflags.RmNoProring;
			set
			{
				Leagueflags.RmNoProring = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmNoProRing"));
			}
		}
		public bool RmThWeaponMal
		{
			get => Leagueflags.RmThiefweaponsMalus;
			set
			{
				Leagueflags.RmThiefweaponsMalus = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmThWeaponMal"));
			}
		}
		public bool RmDown4MaxMP
		{
			get => Leagueflags.RmDown4MaxMP;
			set
			{
				Leagueflags.RmDown4MaxMP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmDown4MaxMP"));
			}
		}

		public bool RmNoSpell
		{
			get => Leagueflags.RmNoSpell;
			set
			{
				Leagueflags.RmNoSpell = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmNoSpell"));
			}
		}
		public bool RmDown50GP
		{
			get => Leagueflags.RmDown50GP;
			set
			{
				Leagueflags.RmDown50GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmDown50GP"));
			}
		}
		public bool Down100GP
		{
			get => Leagueflags.RmDown100GP;
			set
			{
				Leagueflags.RmDown100GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmDown100GP"));
			}
		}
		public bool RmDown150GP
		{
			get => Leagueflags.RmDown150GP;
			set
			{
				Leagueflags.RmDown150GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmDown150GP"));
			}
		}
		public bool RmDown350GP
		{
			get => Leagueflags.RmDown350GP;
			set
			{
				Leagueflags.RmDown350GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmDown350GP"));
			}
		}
		public bool RmDown1100GP
		{
			get => Leagueflags.RmDown1100GP;
			set
			{
				Leagueflags.RmDown1100GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmDown1100GP"));
			}
		}
		public bool RmDown4500GP
		{
			get => Leagueflags.RmDown4500gp;
			set
			{
				Leagueflags.RmDown4500gp = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmDown4500GP"));
			}
		}


		#endregion
		#region WhiteMageMalus
		public bool WmDown10Str
		{
			get => Leagueflags.WmDown10Str;
			set
			{
				Leagueflags.WmDown10Str = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmDown10Str"));
			}
		}
		public bool WmDown10Agi
		{
			get => Leagueflags.WmDown10Agi;
			set
			{
				Leagueflags.WmDown10Agi = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmDown10Agi"));
			}
		}
		public bool WmDown10Vit
		{
			get => Leagueflags.WmDown10Vit;
			set
			{
				Leagueflags.WmDown10Vit = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmDown10Vit"));
			}
		}
		public bool WmDown5Luck
		{
			get => Leagueflags.WmDown5Luck;
			set
			{
				Leagueflags.WmDown5Luck = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmDown5Luck"));
			}
		}
		public bool WmDown15HP
		{
			get => Leagueflags.WmDown15HP;
			set
			{
				Leagueflags.WmDown15HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmDown15HP"));
			}
		}
		public bool WmDown30HP
		{
			get => Leagueflags.WmDown30HP;
			set
			{
				Leagueflags.WmDown30HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmDown15HP"));
			}
		}
		public bool WmDown1HitPercent
		{
			get => Leagueflags.WmDown1Hitpercent;
			set
			{
				Leagueflags.WmDown1Hitpercent = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmDown1HitPercent"));
			}
		}
		public bool WmDown1MDef
		{
			get => Leagueflags.WmDown1Mdef;
			set
			{
				Leagueflags.WmDown1Mdef = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmDown1MDef"));
			}
		}
		public bool WmNoBracelets
		{
			get => Leagueflags.WmNobrace;
			set
			{
				Leagueflags.WmNobrace = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmNoBracelets"));
			}
		}
		public bool WmNoMasa
		{
			get => Leagueflags.WmNoMasa;
			set
			{
				Leagueflags.WmNoMasa = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmNoMasa"));
			}
		}
		public bool WmNoRibbon
		{
			get => Leagueflags.WmNoRibbon;
			set
			{
				Leagueflags.WmNoRibbon = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmNoRibbon"));
			}
		}
		public bool WmNoProRing
		{
			get => Leagueflags.WmNoProring;
			set
			{
				Leagueflags.WmNoProring = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmNoProRing"));
			}
		}
		public bool WmDown4MaxMP
		{
			get => Leagueflags.WmDown4MaxMP;
			set
			{
				Leagueflags.WmDown4MaxMP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmDown4MaxMP"));
			}
		}
		public bool WmNoSpell
		{
			get => Leagueflags.WmNoSpell;
			set
			{
				Leagueflags.WmNoSpell = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmNoSpell"));
			}
		}
		public bool WmDown50GP
		{
			get => Leagueflags.WmDown50GP;
			set
			{
				Leagueflags.WmDown50GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmDown50GP"));
			}
		}
		public bool WmDown100GP
		{
			get => Leagueflags.WmDown100GP;
			set
			{
				Leagueflags.WmDown100GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmDown100GP"));
			}
		}
		public bool WmDown150GP
		{
			get => Leagueflags.WmDown150GP;
			set
			{
				Leagueflags.WmDown150GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmDown150GP"));
			}
		}
		public bool WmDown350GP
		{
			get => Leagueflags.WmDown350GP;
			set
			{
				Leagueflags.WmDown350GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmDown350GP"));
			}
		}
		public bool WmDown1100GP
		{
			get => Leagueflags.WmDown1100GP;
			set
			{
				Leagueflags.WmDown1100GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmDown1100GP"));
			}
		}
		public bool WmDown4500GP
		{
			get => Leagueflags.WmDown4500gp;
			set
			{
				Leagueflags.WmDown4500gp = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmDown4500GP"));
			}
		}
		#endregion
		#region BlackMageMalus
		public bool BmDown10Agi
		{
			get => Leagueflags.BmDown10Agi;
			set
			{
				Leagueflags.BmDown10Agi = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmDown10Agi"));
			}
		}
		public bool BmDown5Luck
		{
			get => Leagueflags.BmDown5Luck;
			set
			{
				Leagueflags.BmDown5Luck = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmDown5Luck"));
			}
		}
		public bool BmDown10Luck
		{
			get => Leagueflags.BmDown10Luck;
			set
			{
				Leagueflags.BmDown10Luck = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmDown10Luck"));
			}
		}
		public bool BmDown15HP
		{
			get => Leagueflags.BmDown15HP;
			set
			{
				Leagueflags.BmDown15HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmDown15HP"));
			}
		}
		public bool BmDown30HP
		{
			get => Leagueflags.BmDown30HP;
			set
			{
				Leagueflags.BmDown30HP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmDown15HP"));
			}
		}
		public bool BmDown1HitPercent
		{
			get => Leagueflags.BmDown1Hitpercent;
			set
			{
				Leagueflags.BmDown1Hitpercent = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmDown1HitPercent"));
			}
		}
		public bool BmDown1MDef
		{
			get => Leagueflags.BmDown1Mdef;
			set
			{
				Leagueflags.BmDown1Mdef = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmDown1MDef"));
			}
		}
		public bool BmNoBracelets
		{
			get => Leagueflags.BmNobrace;
			set
			{
				Leagueflags.BmNobrace = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmNoBracelets"));
			}
		}
		public bool BmNoMasa
		{
			get => Leagueflags.BmNoMasa;
			set
			{
				Leagueflags.BmNoMasa = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmNoMasa"));
			}
		}
		public bool BmNoRibbon
		{
			get => Leagueflags.BmNoRibbon;
			set
			{
				Leagueflags.BmNoRibbon = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmNoRibbon"));
			}
		}
		public bool BmNoProRing
		{
			get => Leagueflags.BmNoProring;
			set
			{
				Leagueflags.BmNoProring = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmNoProRing"));
			}
		}
		public bool BmDown4MaxMP
		{
			get => Leagueflags.BmDown4MaxMP;
			set
			{
				Leagueflags.BmDown4MaxMP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmDown4MaxMP"));
			}
		}

		public bool BmNoSpell
		{
			get => Leagueflags.BmNoSpell;
			set
			{
				Leagueflags.BmNoSpell = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmNoSpell"));
			}
		}
		public bool BmDown50GP
		{
			get => Leagueflags.BmDown50GP;
			set
			{
				Leagueflags.BmDown50GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmDown50GP"));
			}
		}
		public bool BmDown100GP
		{
			get => Leagueflags.BmDown100GP;
			set
			{
				Leagueflags.BmDown100GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmDown100GP"));
			}
		}
		public bool BmDown150GP
		{
			get => Leagueflags.BmDown150GP;
			set
			{
				Leagueflags.BmDown150GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmDown150GP"));
			}
		}
		public bool BmDown350GP
		{
			get => Leagueflags.BmDown350GP;
			set
			{
				Leagueflags.BmDown350GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmDown350GP"));
			}
		}
		public bool BmDown1100GP
		{
			get => Leagueflags.BmDown1100GP;
			set
			{
				Leagueflags.BmDown1100GP = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmDown1100GP"));
			}
		}
		public bool BmDown4500GP
		{
			get => Leagueflags.BmDown4500gp;
			set
			{
				Leagueflags.BmDown4500gp = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmDown4500GP"));
			}
		}
		#endregion
		#endregion
		#region KeyItems
		#region FighterKeyItems
		public bool FiStartCrown
		{
			get => Leagueflags.FiStartCrown;
			set
			{
				Leagueflags.FiStartCrown = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiStartCrown"));
			}
		}
		public bool FiStartCrystal
		{
			get => Leagueflags.FiStartCrystal;
			set
			{
				Leagueflags.FiStartCrystal = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiStartCrystal"));
			}
		}
		public bool FiStartHerb
		{
			get => Leagueflags.FiStartHerb;
			set
			{
				Leagueflags.FiStartHerb = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiStartHerb"));
			}
		}
		public bool FiStartTNT
		{
			get => Leagueflags.FiStartTNT;
			set
			{
				Leagueflags.FiStartTNT = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiStartTNT"));
			}
		}
		public bool FiStartAdamant
		{
			get => Leagueflags.FiStartAdamant;
			set
			{
				Leagueflags.FiStartAdamant = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiStartAdamant"));
			}
		}
		public bool FiStartSlab
		{
			get => Leagueflags.FiStartSlab;
			set
			{
				Leagueflags.FiStartSlab = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiStartSlab"));
			}
		}
		public bool FiStartRuby
		{
			get => Leagueflags.FiStartRuby;
			set
			{
				Leagueflags.FiStartRuby = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiStartRuby"));
			}
		}
		public bool FiStartRod
		{
			get => Leagueflags.FiStartRod;
			set
			{
				Leagueflags.FiStartRod = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiStartRod"));
			}
		}
		public bool FiStartChime
		{
			get => Leagueflags.FiStartChime;
			set
			{
				Leagueflags.FiStartChime = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiStartChime"));
			}
		}
		public bool FiStartCube
		{
			get => Leagueflags.FiStartCube;
			set
			{
				Leagueflags.FiStartCube = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiStartCube"));
			}
		}
		public bool FiStartBottle
		{
			get => Leagueflags.FiStartBottle;
			set
			{
				Leagueflags.FiStartBottle = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiStartBottle"));
			}
		}
		public bool FiStartOxyale
		{
			get => Leagueflags.FiStartOxyale;
			set
			{
				Leagueflags.FiStartOxyale = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiStartOxyale"));
			}
		}
		public bool FiStartLute
		{
			get => Leagueflags.FiStartLute;
			set
			{
				Leagueflags.FiStartLute = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiStartLute"));
			}
		}
		public bool FiStartTail
		{
			get => Leagueflags.FiStartTail;
			set
			{
				Leagueflags.FiStartTail = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiStartTail"));
			}
		}
		public bool FiStartKey
		{
			get => Leagueflags.FiStartKey;
			set
			{
				Leagueflags.FiStartKey = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiStartCrystal"));
			}
		}
		#endregion
		#region ThiefKeyItems
		public bool ThStartCrown
		{
			get => Leagueflags.ThStartCrown;
			set
			{
				Leagueflags.ThStartCrown = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThStartCrown"));
			}
		}
		public bool ThStartCrystal
		{
			get => Leagueflags.ThStartCrystal;
			set
			{
				Leagueflags.ThStartCrystal = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThStartCrystal"));
			}
		}
		public bool ThStartHerb
		{
			get => Leagueflags.ThStartHerb;
			set
			{
				Leagueflags.ThStartHerb = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThStartHerb"));
			}
		}
		public bool ThStartTNT
		{
			get => Leagueflags.ThStartTNT;
			set
			{
				Leagueflags.ThStartTNT = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThStartTNT"));
			}
		}
		public bool ThStartAdamant
		{
			get => Leagueflags.ThStartAdamant;
			set
			{
				Leagueflags.ThStartAdamant = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThStartAdamant"));
			}
		}
		public bool ThStartSlab
		{
			get => Leagueflags.ThStartSlab;
			set
			{
				Leagueflags.ThStartSlab = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThStartSlab"));
			}
		}
		public bool ThStartRuby
		{
			get => Leagueflags.ThStartRuby;
			set
			{
				Leagueflags.ThStartRuby = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThStartRuby"));
			}
		}
		public bool ThStartRod
		{
			get => Leagueflags.ThStartRod;
			set
			{
				Leagueflags.ThStartRod = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThStartRod"));
			}
		}
		public bool ThStartChime
		{
			get => Leagueflags.ThStartChime;
			set
			{
				Leagueflags.ThStartChime = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThStartChime"));
			}
		}
		public bool ThStartCube
		{
			get => Leagueflags.ThStartCube;
			set
			{
				Leagueflags.ThStartCube = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThStartCube"));
			}
		}
		public bool ThStartBottle
		{
			get => Leagueflags.ThStartBottle;
			set
			{
				Leagueflags.ThStartBottle = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThStartBottle"));
			}
		}
		public bool ThStartOxyale
		{
			get => Leagueflags.ThStartOxyale;
			set
			{
				Leagueflags.ThStartOxyale = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThStartOxyale"));
			}
		}
		public bool ThStartLute
		{
			get => Leagueflags.ThStartLute;
			set
			{
				Leagueflags.ThStartLute = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThStartLute"));
			}
		}
		public bool ThStartTail
		{
			get => Leagueflags.ThStartTail;
			set
			{
				Leagueflags.ThStartTail = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThStartTail"));
			}
		}
		public bool ThStartKey
		{
			get => Leagueflags.ThStartKey;
			set
			{
				Leagueflags.ThStartKey = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThStartCrystal"));
			}
		}
		#endregion
		#region BlackBeltItems
		public bool BBStartCrown
		{
			get => Leagueflags.BBStartCrown;
			set
			{
				Leagueflags.BBStartCrown = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBStartCrown"));
			}
		}
		public bool BBStartCrystal
		{
			get => Leagueflags.BBStartCrystal;
			set
			{
				Leagueflags.BBStartCrystal = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBStartCrystal"));
			}
		}
		public bool BBStartHerb
		{
			get => Leagueflags.BBStartHerb;
			set
			{
				Leagueflags.BBStartHerb = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBStartHerb"));
			}
		}
		public bool BBStartTNT
		{
			get => Leagueflags.BBStartTNT;
			set
			{
				Leagueflags.BBStartTNT = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBStartTNT"));
			}
		}
		public bool BBStartAdamant
		{
			get => Leagueflags.BBStartAdamant;
			set
			{
				Leagueflags.BBStartAdamant = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBStartAdamant"));
			}
		}
		public bool BBStartSlab
		{
			get => Leagueflags.BBStartSlab;
			set
			{
				Leagueflags.BBStartSlab = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBStartSlab"));
			}
		}
		public bool BBStartRuby
		{
			get => Leagueflags.BBStartRuby;
			set
			{
				Leagueflags.BBStartRuby = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBStartRuby"));
			}
		}
		public bool BBStartRod
		{
			get => Leagueflags.BBStartRod;
			set
			{
				Leagueflags.BBStartRod = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBStartRod"));
			}
		}
		public bool BBStartChime
		{
			get => Leagueflags.BBStartChime;
			set
			{
				Leagueflags.BBStartChime = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBStartChime"));
			}
		}
		public bool BBStartCube
		{
			get => Leagueflags.BBStartCube;
			set
			{
				Leagueflags.BBStartCube = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBStartCube"));
			}
		}
		public bool BBStartBottle
		{
			get => Leagueflags.BBStartBottle;
			set
			{
				Leagueflags.BBStartBottle = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBStartBottle"));
			}
		}
		public bool BBStartOxyale
		{
			get => Leagueflags.BBStartOxyale;
			set
			{
				Leagueflags.BBStartOxyale = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBStartOxyale"));
			}
		}
		public bool BBStartLute
		{
			get => Leagueflags.BBStartLute;
			set
			{
				Leagueflags.BBStartLute = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBStartLute"));
			}
		}
		public bool BBStartTail
		{
			get => Leagueflags.BBStartTail;
			set
			{
				Leagueflags.BBStartTail = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBStartTail"));
			}
		}
		public bool BBStartKey
		{
			get => Leagueflags.BBStartKey;
			set
			{
				Leagueflags.BBStartKey = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BBStartCrystal"));
			}
		}
		#endregion
		#region RedMageKeyItems
		public bool RmStartCrown
		{
			get => Leagueflags.RmStartCrown;
			set
			{
				Leagueflags.RmStartCrown = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmStartCrown"));
			}
		}
		public bool RmStartCrystal
		{
			get => Leagueflags.RmStartCrystal;
			set
			{
				Leagueflags.RmStartCrystal = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmStartCrystal"));
			}
		}
		public bool RmStartHerb
		{
			get => Leagueflags.RmStartHerb;
			set
			{
				Leagueflags.RmStartHerb = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmStartHerb"));
			}
		}
		public bool RmStartTNT
		{
			get => Leagueflags.RmStartTNT;
			set
			{
				Leagueflags.RmStartTNT = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmStartTNT"));
			}
		}
		public bool RmStartAdamant
		{
			get => Leagueflags.RmStartAdamant;
			set
			{
				Leagueflags.RmStartAdamant = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmStartAdamant"));
			}
		}
		public bool RmStartSlab
		{
			get => Leagueflags.RmStartSlab;
			set
			{
				Leagueflags.RmStartSlab = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmStartSlab"));
			}
		}
		public bool RmStartRuby
		{
			get => Leagueflags.RmStartRuby;
			set
			{
				Leagueflags.RmStartRuby = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmStartRuby"));
			}
		}
		public bool RmStartRod
		{
			get => Leagueflags.RmStartRod;
			set
			{
				Leagueflags.RmStartRod = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmStartRod"));
			}
		}
		public bool RmStartChime
		{
			get => Leagueflags.RmStartChime;
			set
			{
				Leagueflags.RmStartChime = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmStartChime"));
			}
		}
		public bool RmStartCube
		{
			get => Leagueflags.RmStartCube;
			set
			{
				Leagueflags.RmStartCube = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmStartCube"));
			}
		}
		public bool RmStartBottle
		{
			get => Leagueflags.RmStartBottle;
			set
			{
				Leagueflags.RmStartBottle = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmStartBottle"));
			}
		}
		public bool RmStartOxyale
		{
			get => Leagueflags.RmStartOxyale;
			set
			{
				Leagueflags.RmStartOxyale = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmStartOxyale"));
			}
		}
		public bool RmStartLute
		{
			get => Leagueflags.RmStartLute;
			set
			{
				Leagueflags.RmStartLute = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmStartLute"));
			}
		}
		public bool RmStartTail
		{
			get => Leagueflags.RmStartTail;
			set
			{
				Leagueflags.RmStartTail = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmStartTail"));
			}
		}
		public bool RmStartKey
		{
			get => Leagueflags.RmStartKey;
			set
			{
				Leagueflags.RmStartKey = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RmStartCrystal"));
			}
		}
		#endregion
		#region WhiteMageItems
		public bool WmStartCrown
		{
			get => Leagueflags.WmStartCrown;
			set
			{
				Leagueflags.WmStartCrown = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmStartCrown"));
			}
		}
		public bool WmStartCrystal
		{
			get => Leagueflags.WmStartCrystal;
			set
			{
				Leagueflags.WmStartCrystal = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmStartCrystal"));
			}
		}
		public bool WmStartHerb
		{
			get => Leagueflags.WmStartHerb;
			set
			{
				Leagueflags.WmStartHerb = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmStartHerb"));
			}
		}
		public bool WmStartTNT
		{
			get => Leagueflags.WmStartTNT;
			set
			{
				Leagueflags.WmStartTNT = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmStartTNT"));
			}
		}
		public bool WmStartAdamant
		{
			get => Leagueflags.WmStartAdamant;
			set
			{
				Leagueflags.WmStartAdamant = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmStartAdamant"));
			}
		}
		public bool WmStartSlab
		{
			get => Leagueflags.WmStartSlab;
			set
			{
				Leagueflags.WmStartSlab = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmStartSlab"));
			}
		}
		public bool WmStartRuby
		{
			get => Leagueflags.WmStartRuby;
			set
			{
				Leagueflags.WmStartRuby = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmStartRuby"));
			}
		}
		public bool WmStartRod
		{
			get => Leagueflags.WmStartRod;
			set
			{
				Leagueflags.WmStartRod = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmStartRod"));
			}
		}
		public bool WmStartChime
		{
			get => Leagueflags.WmStartChime;
			set
			{
				Leagueflags.WmStartChime = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmStartChime"));
			}
		}
		public bool WmStartCube
		{
			get => Leagueflags.WmStartCube;
			set
			{
				Leagueflags.WmStartCube = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmStartCube"));
			}
		}
		public bool WmStartBottle
		{
			get => Leagueflags.WmStartBottle;
			set
			{
				Leagueflags.WmStartBottle = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmStartBottle"));
			}
		}
		public bool WmStartOxyale
		{
			get => Leagueflags.WmStartOxyale;
			set
			{
				Leagueflags.WmStartOxyale = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmStartOxyale"));
			}
		}
		public bool WmStartLute
		{
			get => Leagueflags.WmStartLute;
			set
			{
				Leagueflags.WmStartLute = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmStartLute"));
			}
		}
		public bool WmStartTail
		{
			get => Leagueflags.WmStartTail;
			set
			{
				Leagueflags.WmStartTail = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmStartTail"));
			}
		}
		public bool WmStartKey
		{
			get => Leagueflags.WmStartKey;
			set
			{
				Leagueflags.WmStartKey = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WmStartCrystal"));
			}
		}
		#endregion
		#region BlackMageItems
		public bool BmStartCrown
		{
			get => Leagueflags.BmStartCrown;
			set
			{
				Leagueflags.BmStartCrown = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmStartCrown"));
			}
		}
		public bool BmStartCrystal
		{
			get => Leagueflags.BmStartCrystal;
			set
			{
				Leagueflags.BmStartCrystal = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmStartCrystal"));
			}
		}
		public bool BmStartHerb
		{
			get => Leagueflags.BmStartHerb;
			set
			{
				Leagueflags.BmStartHerb = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmStartHerb"));
			}
		}
		public bool BmStartTNT
		{
			get => Leagueflags.BmStartTNT;
			set
			{
				Leagueflags.BmStartTNT = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmStartTNT"));
			}
		}
		public bool BmStartAdamant
		{
			get => Leagueflags.BmStartAdamant;
			set
			{
				Leagueflags.BmStartAdamant = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmStartAdamant"));
			}
		}
		public bool BmStartSlab
		{
			get => Leagueflags.BmStartSlab;
			set
			{
				Leagueflags.BmStartSlab = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmStartSlab"));
			}
		}
		public bool BmStartRuby
		{
			get => Leagueflags.BmStartRuby;
			set
			{
				Leagueflags.BmStartRuby = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmStartRuby"));
			}
		}
		public bool BmStartRod
		{
			get => Leagueflags.BmStartRod;
			set
			{
				Leagueflags.BmStartRod = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmStartRod"));
			}
		}
		public bool BmStartChime
		{
			get => Leagueflags.BmStartChime;
			set
			{
				Leagueflags.BmStartChime = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmStartChime"));
			}
		}
		public bool BmStartCube
		{
			get => Leagueflags.BmStartCube;
			set
			{
				Leagueflags.BmStartCube = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmStartCube"));
			}
		}
		public bool BmStartBottle
		{
			get => Leagueflags.BmStartBottle;
			set
			{
				Leagueflags.BmStartBottle = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmStartBottle"));
			}
		}
		public bool BmStartOxyale
		{
			get => Leagueflags.BmStartOxyale;
			set
			{
				Leagueflags.BmStartOxyale = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmStartOxyale"));
			}
		}
		public bool BmStartLute
		{
			get => Leagueflags.BmStartLute;
			set
			{
				Leagueflags.BmStartLute = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmStartLute"));
			}
		}
		public bool BmStartTail
		{
			get => Leagueflags.BmStartTail;
			set
			{
				Leagueflags.BmStartTail = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmStartTail"));
			}
		}
		public bool BmStartKey
		{
			get => Leagueflags.BmStartKey;
			set
			{
				Leagueflags.BmStartKey = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BmStartCrystal"));
			}
		}
		#endregion

		#endregion
		#endregion


	}
}
