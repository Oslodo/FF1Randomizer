﻿using RomUtilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF1Lib
{
	public enum AltFiendPool
	{
		[Description("All Fiends in Pool")]
		Random,
		[Description("Final Fantasy 2 Fiends")]
		FinalFantasy2,
		[Description("Final Fantasy 3 Fiends")]
		FinalFantasy3,
		[Description("Final Fantasy 4 Fiends")]
		FinalFantasy4,
		[Description("Final Fantasy 5 Fiends")]
		FinalFantasy5

	}
	public enum FiendPool
	{
		All,
		FinalFantasy2,
		FinalFantasy3,
		FinalFantasy4,
		FinalFantasy5,
	}
	public partial class FF1Rom
	{
		public struct AlternateFiends
		{
			public string Name;
			public List<byte> Spells1;
			public List<byte> Skills1;
			public byte SpellChance1;
			public byte SkillChance1;
			public List<byte> Spells2;
			public List<byte> Skills2;
			public byte SpellChance2;
			public byte SkillChance2;
			public MonsterType MonsterType;
			public SpellElement ElementalWeakness;
			public FormationSpriteSheet SpriteSheet;
			public FormationPattern FormationPattern;
			public int Palette1;
			public int Palette2;
			public FormationGFX GFXOffset;
			public FiendPool FiendPool;
		}
		public void AlternativeFiends(EnemyScripts enemyScripts, MT19337 rng, Flags flags)
		{
			if (!(bool)flags.AlternateFiends || flags.SpookyFlag)
			{
				return;
			}

			const int FiendsIndex = 0x77;
			const int FiendsScriptIndex = 0x22;
			var fiendsFormationOrder = new List<int> { 0x7A, 0x73, 0x79, 0x74, 0x78, 0x75, 0x77, 0x76 };

			var FF1MasterFiendList = new List<AlternateFiends>
			{
					new AlternateFiends {
					Name = "LICH",
					SpriteSheet = FormationSpriteSheet.KaryLich,
					FormationPattern = FormationPattern.Fiends,
					GFXOffset = FormationGFX.Sprite3,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.Fire,
					MonsterType = MonsterType.UNDEAD,
					FiendPool = FiendPool.FinalFantasy2,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.ICE2, (byte)SpellByte.SLP2, (byte)SpellByte.FAST, (byte)SpellByte.LIT2, (byte)SpellByte.HOLD, (byte)SpellByte.FIR2, (byte)SpellByte.SLOW, (byte)SpellByte.SLEP },
					SkillChance1 = 0x00,
					Skills1 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.NUKE, (byte)SpellByte.STOP, (byte)SpellByte.ZAP, (byte)SpellByte.XXXX, (byte)SpellByte.NUKE, (byte)SpellByte.STOP, (byte)SpellByte.ZAP, (byte)SpellByte.XXXX },
					SkillChance2 = 0x00,
					Skills2 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
					},

					new AlternateFiends {
					Name = "KARY",
					SpriteSheet = FormationSpriteSheet.KrakenTiamat,
					FormationPattern = FormationPattern.Fiends,
					GFXOffset = FormationGFX.Sprite1,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.Status,
					MonsterType = MonsterType.MAGE,
					FiendPool = FiendPool.FinalFantasy2,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.FIR2, (byte)SpellByte.DARK, (byte)SpellByte.FIR2, (byte)SpellByte.DARK, (byte)SpellByte.FIR2, (byte)SpellByte.HOLD, (byte)SpellByte.FIR2, (byte)SpellByte.HOLD },
					SkillChance1 = 0x00,
					Skills1 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.FIR3, (byte)SpellByte.RUB, (byte)SpellByte.FIR3, (byte)SpellByte.RUB, (byte)SpellByte.FIR3, (byte)SpellByte.STUN, (byte)SpellByte.FIR3, (byte)SpellByte.STUN },
					SkillChance2 = 0x00,
					Skills2 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
					},

					new AlternateFiends {
					Name = "KRAKEN",
					SpriteSheet = FormationSpriteSheet.KaryLich,
					FormationPattern = FormationPattern.Fiends,
					GFXOffset = FormationGFX.Sprite2,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.Lightning,
					MonsterType = MonsterType.AQUATIC,
					FiendPool = FiendPool.FinalFantasy2,
					SpellChance1 = 0x00,
					Spells1 = new List<byte> { (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Ink, (byte)EnemySkills.Ink, (byte)EnemySkills.Ink, (byte)EnemySkills.Ink },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.LIT2, (byte)SpellByte.LIT2, (byte)SpellByte.LIT2, (byte)SpellByte.LIT2, (byte)SpellByte.LIT2, (byte)SpellByte.LIT2, (byte)SpellByte.LIT2, (byte)SpellByte.LIT2 },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Ink, (byte)EnemySkills.Ink, (byte)EnemySkills.Ink, (byte)EnemySkills.Ink },
					},

					new AlternateFiends {
					Name = "TIAMAT",
					SpriteSheet = FormationSpriteSheet.KrakenTiamat,
					FormationPattern = FormationPattern.Fiends,
					GFXOffset = FormationGFX.Sprite4,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.Poison,
					MonsterType = MonsterType.DRAGON,
					FiendPool = FiendPool.FinalFantasy2,
					SpellChance1 = 0x00,
					Spells1 = new List<byte> { (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Thunder, (byte)EnemySkills.Poison_Damage, (byte)EnemySkills.Blizzard, (byte)EnemySkills.Blaze },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.BANE, (byte)SpellByte.ICE2, (byte)SpellByte.LIT2, (byte)SpellByte.FIR2, (byte)SpellByte.BANE, (byte)SpellByte.ICE2, (byte)SpellByte.LIT2, (byte)SpellByte.FIR2 },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Thunder, (byte)EnemySkills.Poison_Damage, (byte)EnemySkills.Blizzard, (byte)EnemySkills.Blaze },
					},

			};
			var FF2AltFiendslist = new List<AlternateFiends> 
			{
					new AlternateFiends {
					Name = "ADMNTOSE",
					SpriteSheet = FormationSpriteSheet.AspLobsterBullTroll,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite4,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.Fire,
					MonsterType = MonsterType.DRAGON,
					FiendPool = FiendPool.FinalFantasy2,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.FAST, (byte)SpellByte.FOG, (byte)SpellByte.AFIR, (byte)SpellByte.AICE, (byte)SpellByte.TMPR, (byte)SpellByte.FOG, (byte)SpellByte.INVS, (byte)SpellByte.CUR2 },
					SkillChance1 = 0x00,
					Skills1 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.FAST, (byte)SpellByte.SABR, (byte)SpellByte.RUSE, (byte)SpellByte.LOCK, (byte)SpellByte.FAST, (byte)SpellByte.SABR, (byte)SpellByte.RUSE, (byte)SpellByte.CUR4 },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Ink, (byte)EnemySkills.Ink, (byte)EnemySkills.Ink, (byte)EnemySkills.Ink },
					},

					new AlternateFiends {
					Name = "ASTAROTH",
					SpriteSheet = FormationSpriteSheet.BadmanAstosMadponyWarmech,
					FormationPattern = FormationPattern.Mixed,
					GFXOffset = FormationGFX.Sprite2,
					Palette1 = 0x39,
					Palette2 = 0x39,
					ElementalWeakness = SpellElement.Fire,
					MonsterType = MonsterType.MAGE,
					FiendPool = FiendPool.FinalFantasy2,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.FIRE, (byte)SpellByte.FIRE, (byte)SpellByte.BRAK, (byte)SpellByte.FIRE, (byte)SpellByte.FIRE, (byte)SpellByte.FIRE, (byte)SpellByte.BRAK, (byte)SpellByte.FIRE },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Heat, (byte)EnemySkills.Heat, (byte)EnemySkills.Heat, (byte)EnemySkills.Poison_Stone },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.FIR2, (byte)SpellByte.FIR3, (byte)SpellByte.FIR2, (byte)SpellByte.BRAK, (byte)SpellByte.FIR2, (byte)SpellByte.FIR3, (byte)SpellByte.FIR2, (byte)SpellByte.BANE },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Scorch, (byte)EnemySkills.Poison_Damage, (byte)EnemySkills.Blaze, (byte)EnemySkills.Poison_Stone },
					},

				new AlternateFiends {
					Name = "BELZEBUB",
					SpriteSheet = FormationSpriteSheet.SlimeSpiderManticorAnkylo,
					FormationPattern = FormationPattern.Mixed,
					GFXOffset = FormationGFX.Sprite2,
					Palette1 = 0x30,
					Palette2 = 0x30,
					ElementalWeakness = SpellElement.Lightning,
					MonsterType = MonsterType.UNDEAD,
					FiendPool = FiendPool.FinalFantasy2,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.FIRE, (byte)SpellByte.FAST, (byte)SpellByte.FIRE, (byte)SpellByte.FOG, (byte)SpellByte.FIRE, (byte)SpellByte.SLOW, (byte)SpellByte.FIRE, (byte)SpellByte.RUB },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Flash, (byte)EnemySkills.Stinger, (byte)EnemySkills.Flash, (byte)EnemySkills.Dazzle },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.FIR2, (byte)SpellByte.FAST, (byte)SpellByte.FIR3, (byte)SpellByte.FOG, (byte)SpellByte.FIR2, (byte)SpellByte.SLO2, (byte)SpellByte.FIR3, (byte)SpellByte.BANE },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Nuclear, (byte)EnemySkills.Flash, (byte)EnemySkills.Dazzle, (byte)EnemySkills.Inferno },
				},

				new AlternateFiends {
					Name = "BORGEN",
					SpriteSheet = FormationSpriteSheet.MedusaCatmanPedeTiger,
					FormationPattern = FormationPattern.Small9,
					GFXOffset = FormationGFX.Sprite2,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.Fire,
					MonsterType = MonsterType.GIANT,
					FiendPool = FiendPool.FinalFantasy2,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.CUR2, (byte)SpellByte.CURE, (byte)SpellByte.FIRE, (byte)SpellByte.AFIR, (byte)SpellByte.FIR2, (byte)SpellByte.HEAL, (byte)SpellByte.HEL2, (byte)SpellByte.CURE },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Stinger, (byte)EnemySkills.Snorting, (byte)EnemySkills.Dazzle, (byte)EnemySkills.Trance },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.NUKE, (byte)SpellByte.FIR3, (byte)SpellByte.HOLD, (byte)SpellByte.XFER, (byte)SpellByte.BANE, (byte)SpellByte.ZAP, (byte)SpellByte.MUTE, (byte)SpellByte.STOP },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Gaze, (byte)EnemySkills.Trance, (byte)EnemySkills.Gaze, (byte)EnemySkills.Blaze },
				},

				new AlternateFiends {
					Name = "BEHEMOTH",
					SpriteSheet = FormationSpriteSheet.BoneCreepHyenaOgre,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite3,
					Palette1 = 0x1D, // Yellow/Orange
					Palette2 = 0x1D,
					ElementalWeakness = SpellElement.Ice,
					MonsterType = MonsterType.UNDEAD,
					FiendPool = FiendPool.FinalFantasy2,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.FIR2, (byte)SpellByte.STUN, (byte)SpellByte.FIR2, (byte)SpellByte.FAST, (byte)SpellByte.FIR2, (byte)SpellByte.STUN, (byte)SpellByte.FIR2, (byte)SpellByte.FAST },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Snorting, (byte)EnemySkills.Snorting, (byte)EnemySkills.Snorting, (byte)EnemySkills.Snorting },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.FIR3, (byte)SpellByte.STOP, (byte)SpellByte.FIR3, (byte)SpellByte.FAST, (byte)SpellByte.FIR3, (byte)SpellByte.SLO2, (byte)SpellByte.FIR3, (byte)SpellByte.NUKE },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Snorting, (byte)EnemySkills.Snorting, (byte)EnemySkills.Snorting, (byte)EnemySkills.Blaze },
				},

				new AlternateFiends {
					Name = "B.KNIGHT",
					SpriteSheet = FormationSpriteSheet.BadmanAstosMadponyWarmech,
					FormationPattern = FormationPattern.Mixed,
					GFXOffset = FormationGFX.Sprite1,
					Palette1 = 0x1A, // Grey/Purple
					Palette2 = 0x1A,
					ElementalWeakness = SpellElement.Poison,
					MonsterType = MonsterType.MAGE,
					FiendPool = FiendPool.FinalFantasy2,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.FAST, (byte)SpellByte.SLOW, (byte)SpellByte.STUN, (byte)SpellByte.STOP, (byte)SpellByte.FAST, (byte)SpellByte.SLOW, (byte)SpellByte.STUN, (byte)SpellByte.STOP },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Flash, (byte)EnemySkills.Flash, (byte)EnemySkills.Flash, (byte)EnemySkills.Dazzle },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.MUTE, (byte)SpellByte.SLO2, (byte)SpellByte.FAST, (byte)SpellByte.SABR, (byte)SpellByte.STUN, (byte)SpellByte.STOP, (byte)SpellByte.SABR, (byte)SpellByte.BRAK },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Trance, (byte)EnemySkills.Flash, (byte)EnemySkills.Ink, (byte)EnemySkills.Glare },
				},

				new AlternateFiends {
					Name = "GOTUS",
					SpriteSheet = FormationSpriteSheet.KrakenTiamat,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite4,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.Poison,
					MonsterType = MonsterType.GIANT,
					FiendPool = FiendPool.FinalFantasy2,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.SLOW, (byte)SpellByte.DARK, (byte)SpellByte.SLOW, (byte)SpellByte.LIT, (byte)SpellByte.FIRE, (byte)SpellByte.ICE, (byte)SpellByte.DARK, (byte)SpellByte.MUTE },
					SkillChance1 = 0x00,
					Skills1 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.FAST, (byte)SpellByte.FAST, (byte)SpellByte.SABR, (byte)SpellByte.TMPR, (byte)SpellByte.SABR, (byte)SpellByte.ZAP, (byte)SpellByte.XXXX, (byte)SpellByte.QAKE },
					SkillChance2 = 0x00,
					Skills2 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
				},

				new AlternateFiends {
					Name = "IROGIANT",
					SpriteSheet = FormationSpriteSheet.KaryLich,
					FormationPattern = FormationPattern.Fiends,
					GFXOffset = FormationGFX.Sprite1,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.Lightning,
					MonsterType = MonsterType.GIANT,
					FiendPool = FiendPool.FinalFantasy2,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.FOG, (byte)SpellByte.STUN, (byte)SpellByte.BLND, (byte)SpellByte.FIR2, (byte)SpellByte.HOLD, (byte)SpellByte.STUN, (byte)SpellByte.FIRE, (byte)SpellByte.CURE },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Stinger, (byte)EnemySkills.Flash, (byte)EnemySkills.Trance, (byte)EnemySkills.Stinger },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.FIR3, (byte)SpellByte.NUKE, (byte)SpellByte.XFER, (byte)SpellByte.XXXX, (byte)SpellByte.SLO2, (byte)SpellByte.MUTE, (byte)SpellByte.FIR3, (byte)SpellByte.CUR3 },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Poison_Damage, (byte)EnemySkills.Blaze, (byte)EnemySkills.Glare, (byte)EnemySkills.Toxic },
				},

				new AlternateFiends {
					Name = "LAMQUEEN",
					SpriteSheet = FormationSpriteSheet.MummyCoctricWyvernTyro,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite1,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.Time,
					MonsterType = MonsterType.MAGICAL,
					FiendPool = FiendPool.FinalFantasy2,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.FOG, (byte)SpellByte.STUN, (byte)SpellByte.ICE2, (byte)SpellByte.FOG, (byte)SpellByte.SLEP, (byte)SpellByte.SLOW, (byte)SpellByte.ICE2, (byte)SpellByte.LIT2 },
					SkillChance1 = 0x00,
					Skills1 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.INVS, (byte)SpellByte.RUSE, (byte)SpellByte.XXXX, (byte)SpellByte.FOG2, (byte)SpellByte.SLO2, (byte)SpellByte.FIR3, (byte)SpellByte.ICE3, (byte)SpellByte.CUR4 },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Poison_Stone, (byte)EnemySkills.Tornado, (byte)EnemySkills.Ink, (byte)EnemySkills.Poison_Damage },
				},

				new AlternateFiends {
					Name = "MEDUSAE",
					SpriteSheet = FormationSpriteSheet.KaryLich,
					FormationPattern = FormationPattern.Fiends,
					GFXOffset = FormationGFX.Sprite1,
					Palette1 = 0x23, // Green/Grey
					Palette2 = 0x23,
					ElementalWeakness = SpellElement.Poison,
					MonsterType = MonsterType.MAGE,
					FiendPool = FiendPool.FinalFantasy2,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.STUN, (byte)SpellByte.STOP, (byte)SpellByte.STUN, (byte)SpellByte.BRAK, (byte)SpellByte.STUN, (byte)SpellByte.STOP, (byte)SpellByte.STUN, (byte)SpellByte.BRAK },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Gaze, (byte)EnemySkills.Glance, (byte)EnemySkills.Gaze, (byte)EnemySkills.Glare },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.STUN, (byte)SpellByte.STOP, (byte)SpellByte.XXXX, (byte)SpellByte.BRAK, (byte)SpellByte.STUN, (byte)SpellByte.STOP, (byte)SpellByte.XXXX, (byte)SpellByte.BRAK },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Glare, (byte)EnemySkills.Glance, (byte)EnemySkills.Glare, (byte)EnemySkills.Poison_Stone },
				},

				new AlternateFiends {
					Name = "RNDWORM",
					SpriteSheet = FormationSpriteSheet.VampGargoyleEarthDragon1,
					FormationPattern = FormationPattern.Mixed,
					GFXOffset = FormationGFX.Sprite2,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.Fire,
					MonsterType = MonsterType.NONE,
					FiendPool = FiendPool.FinalFantasy2,
					SpellChance1 = 0x00,
					Spells1 = new List<byte> { (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Crack, (byte)EnemySkills.Trance, (byte)EnemySkills.Ink, (byte)EnemySkills.Trance },
					SpellChance2 = 0x00,
					Spells2 = new List<byte> { (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Crack, (byte)EnemySkills.Nuclear, (byte)EnemySkills.Toxic, (byte)EnemySkills.Thunder },
				},

				new AlternateFiends {
					Name = "SERGEANT",
					SpriteSheet = FormationSpriteSheet.AspLobsterBullTroll,
					FormationPattern = FormationPattern.Small9,
					GFXOffset = FormationGFX.Sprite3,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.Lightning,
					MonsterType = MonsterType.GIANT,
					FiendPool = FiendPool.FinalFantasy2,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.CURE, (byte)SpellByte.HEAL, (byte)SpellByte.MUTE, (byte)SpellByte.XFER, (byte)SpellByte.BLND, (byte)SpellByte.ICE, (byte)SpellByte.CURE, (byte)SpellByte.MUTE },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Gaze, (byte)EnemySkills.Glance, (byte)EnemySkills.Stare, (byte)EnemySkills.Dazzle },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.FAST, (byte)SpellByte.TMPR, (byte)SpellByte.BLND, (byte)SpellByte.XFER, (byte)SpellByte.XXXX, (byte)SpellByte.ICE3, (byte)SpellByte.BANE, (byte)SpellByte.FOG },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Blizzard, (byte)EnemySkills.Nuclear, (byte)EnemySkills.Glare, (byte)EnemySkills.Squint },
				},

				new AlternateFiends {
					Name = "TWHD.DRG",
					SpriteSheet = FormationSpriteSheet.KaryLich,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite1,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.Time,
					MonsterType = MonsterType.DRAGON,
					FiendPool = FiendPool.FinalFantasy2,
					SpellChance1 = 0x00,
					Spells1 = new List<byte> { (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Trance, (byte)EnemySkills.Dazzle, (byte)EnemySkills.Flash, (byte)EnemySkills.Stinger },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.TMPR, (byte)SpellByte.FAST, (byte)SpellByte.XFER, (byte)SpellByte.INVS, (byte)SpellByte.TMPR, (byte)SpellByte.SLO2, (byte)SpellByte.CUR3, (byte)SpellByte.MUTE },
					SkillChance2 = 0x00,
					Skills2 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
				},


			};
			var FF3AltFiendslist = new List<AlternateFiends>
			{
				new AlternateFiends {
					Name = "AHRIMAN",
					SpriteSheet = FormationSpriteSheet.ImpWolfIguanaGiant,
					FormationPattern = FormationPattern.Fiends,
					GFXOffset = FormationGFX.Sprite1,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.None,
					MonsterType = MonsterType.MAGICAL,
					FiendPool = FiendPool.FinalFantasy3,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.FIR2, (byte)SpellByte.ICE2, (byte)SpellByte.MUTE, (byte)SpellByte.SLO2, (byte)SpellByte.LIT2, (byte)SpellByte.CUR2, (byte)SpellByte.INVS, (byte)SpellByte.SLP2 },
					SkillChance1 = 0x00,
					Skills1 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.NUKE, (byte)SpellByte.SLO2, (byte)SpellByte.XXXX, (byte)SpellByte.CUR4, (byte)SpellByte.ICE3, (byte)SpellByte.MUTE, (byte)SpellByte.FIR3, (byte)SpellByte.XFER },
					SkillChance2 = 0x00,
					Skills2 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
				},
				new AlternateFiends {
					Name = "AMON",
					SpriteSheet = FormationSpriteSheet.SlimeSpiderManticorAnkylo,
					FormationPattern = FormationPattern.Mixed,
					GFXOffset = FormationGFX.Sprite2,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.Status,
					MonsterType = MonsterType.NONE,
					FiendPool = FiendPool.FinalFantasy3,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.FIR2, (byte)SpellByte.FIR2, (byte)SpellByte.LIT2, (byte)SpellByte.BRAK, (byte)SpellByte.SLOW, (byte)SpellByte.FOG, (byte)SpellByte.STUN, (byte)SpellByte.AICE },
					SkillChance1 = 0x00,
					Skills1 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.FIR3, (byte)SpellByte.NUKE, (byte)SpellByte.LIT3, (byte)SpellByte.CUR4, (byte)SpellByte.XXXX, (byte)SpellByte.BANE, (byte)SpellByte.QAKE, (byte)SpellByte.SLO2 },
					SkillChance2 = 0x00,
					Skills2 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
				},
				new AlternateFiends{
					Name = "BIGRAT",
					SpriteSheet = FormationSpriteSheet.MummyCoctricWyvernTyro,
					FormationPattern = FormationPattern.Small9,
					GFXOffset = FormationGFX.Sprite4,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.None,
					MonsterType = MonsterType.WERE,
					FiendPool = FiendPool.FinalFantasy3,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.FIRE, (byte)SpellByte.ICE, (byte)SpellByte.MUTE, (byte)SpellByte.STUN, (byte)SpellByte.ICE, (byte)SpellByte.FIRE, (byte)SpellByte.LIT, (byte)SpellByte.DARK },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Ink, (byte)EnemySkills.Stinger, (byte)EnemySkills.Snorting, (byte)EnemySkills.Dazzle },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.FIR3, (byte)SpellByte.ICE3, (byte)SpellByte.XXXX, (byte)SpellByte.LIT3, (byte)SpellByte.RUSE, (byte)SpellByte.ICE3, (byte)SpellByte.MUTE, (byte)SpellByte.RUB },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Inferno, (byte)EnemySkills.Blizzard, (byte)EnemySkills.Thunder, (byte)EnemySkills.Swirl },
				},
				new AlternateFiends {
					Name = "CARBUNCL",
					SpriteSheet = FormationSpriteSheet.SentryWaterNagaChimera,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite4,
					Palette1 = 0x2D, // Blue/Grey
					Palette2 = 0x2D,
					ElementalWeakness = SpellElement.None,
					MonsterType = MonsterType.MAGICAL,
					FiendPool = FiendPool.FinalFantasy3,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.CURE, (byte)SpellByte.FAST, (byte)SpellByte.CURE, (byte)SpellByte.SLOW, (byte)SpellByte.CURE, (byte)SpellByte.FAST, (byte)SpellByte.CURE, (byte)SpellByte.SLOW },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Stinger, (byte)EnemySkills.Dazzle, (byte)EnemySkills.Gaze, (byte)EnemySkills.Dazzle },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.FAST, (byte)SpellByte.CUR2, (byte)SpellByte.SLO2, (byte)SpellByte.WALL, (byte)SpellByte.CUR2, (byte)SpellByte.XFER, (byte)SpellByte.SABR, (byte)SpellByte.CUR3 },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Stinger, (byte)EnemySkills.Gaze, (byte)EnemySkills.Glance, (byte)EnemySkills.Dazzle },
				},
				new AlternateFiends {
					Name = "DJINN",
					SpriteSheet = FormationSpriteSheet.SentryWaterNagaChimera,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite3,
					Palette1 = 0x23, // Green/White
					Palette2 = 0x23,
					ElementalWeakness = SpellElement.Ice,
					MonsterType = MonsterType.MAGICAL,
					FiendPool = FiendPool.FinalFantasy3,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.FIRE, (byte)SpellByte.FIRE, (byte)SpellByte.FIRE, (byte)SpellByte.FAST, (byte)SpellByte.FIRE, (byte)SpellByte.FIRE, (byte)SpellByte.FIRE, (byte)SpellByte.FAST },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Scorch, (byte)EnemySkills.Heat, (byte)EnemySkills.Scorch, (byte)EnemySkills.Gaze },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.FIR2, (byte)SpellByte.FIR2, (byte)SpellByte.FAST, (byte)SpellByte.FIR3, (byte)SpellByte.FIR2, (byte)SpellByte.SLO2, (byte)SpellByte.FIR2, (byte)SpellByte.NUKE },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Blaze, (byte)EnemySkills.Scorch, (byte)EnemySkills.Scorch, (byte)EnemySkills.Inferno },
				},
				new AlternateFiends
				{
					Name = "DOGA",
					SpriteSheet = FormationSpriteSheet.MedusaCatmanPedeTiger,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite2,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.None,
					MonsterType = MonsterType.MAGE,
					FiendPool = FiendPool.FinalFantasy3,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.MUTE, (byte)SpellByte.BRAK, (byte)SpellByte.SLEP, (byte)SpellByte.STUN, (byte)SpellByte.QAKE, (byte)SpellByte.SLOW, (byte)SpellByte.MUTE, (byte)SpellByte.BLND },
					SkillChance1 = 0x00,
					Skills1 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.BRAK, (byte)SpellByte.BRAK, (byte)SpellByte.QAKE, (byte)SpellByte.QAKE, (byte)SpellByte.NUKE, (byte)SpellByte.SLO2, (byte)SpellByte.RUB, (byte)SpellByte.XXXX },
					SkillChance2 = 0x00,
					Skills2 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
				},
				new AlternateFiends {
					Name = "ECHIDNA",
					SpriteSheet = FormationSpriteSheet.KaryLich,
					FormationPattern = FormationPattern.Fiends,
					GFXOffset = FormationGFX.Sprite1,
					Palette1 = 0x25, // Red/White
					Palette2 = 0x2F,
					ElementalWeakness = SpellElement.Fire,
					MonsterType = MonsterType.MAGE,
					FiendPool = FiendPool.FinalFantasy3,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.STUN, (byte)SpellByte.STOP, (byte)SpellByte.STUN, (byte)SpellByte.SLOW, (byte)SpellByte.STUN, (byte)SpellByte.STOP, (byte)SpellByte.STUN, (byte)SpellByte.SLOW },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Dazzle, (byte)EnemySkills.Ink, (byte)EnemySkills.Ink, (byte)EnemySkills.Crack },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.STUN, (byte)SpellByte.STOP, (byte)SpellByte.ZAP, (byte)SpellByte.STOP, (byte)SpellByte.WALL, (byte)SpellByte.XFER, (byte)SpellByte.STUN, (byte)SpellByte.XXXX },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Crack, (byte)EnemySkills.Trance, (byte)EnemySkills.Crack, (byte)EnemySkills.Gaze },
				},
				new AlternateFiends
				{
					Name = "GARUDA",
					SpriteSheet = FormationSpriteSheet.KrakenTiamat,
					FormationPattern = FormationPattern.Fiends,
					GFXOffset = FormationGFX.Sprite2,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.Earth,
					MonsterType = MonsterType.NONE,
					FiendPool = FiendPool.FinalFantasy3,
					SpellChance1 = 0x00,
					Spells1 = new List<byte> { (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Dazzle, (byte)EnemySkills.Flash, (byte)EnemySkills.Ink, (byte)EnemySkills.Gaze },
					SpellChance2 = 0x00,
					Spells2 = new List<byte> { (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Thunder, (byte)EnemySkills.Nuclear, (byte)EnemySkills.Toxic, (byte)EnemySkills.Poison_Damage },
				},
				new AlternateFiends
				{
					Name = "GENERAL",
					SpriteSheet = FormationSpriteSheet.BoneCreepHyenaOgre,
					FormationPattern = FormationPattern.Mixed,
					GFXOffset = FormationGFX.Sprite3,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.None,
					MonsterType = MonsterType.NONE,
					FiendPool = FiendPool.FinalFantasy3,
					SpellChance1 = 0x00,
					Spells1 = new List<byte> { (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Flash, (byte)EnemySkills.Stare, (byte)EnemySkills.Stare, (byte)EnemySkills.Trance },
					SpellChance2 = 0x00,
					Spells2 = new List<byte> { (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Trance, (byte)EnemySkills.Squint, (byte)EnemySkills.Toxic, (byte)EnemySkills.Crack },
				},
				new AlternateFiends {
					Name = "GOLDOR",
					SpriteSheet = FormationSpriteSheet.MedusaCatmanPedeTiger,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite1,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.None,
					MonsterType = MonsterType.MAGICAL,
					FiendPool = FiendPool.FinalFantasy3,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.FIR2, (byte)SpellByte.LIT2, (byte)SpellByte.ICE2, (byte)SpellByte.MUTE, (byte)SpellByte.AFIR, (byte)SpellByte.AICE, (byte)SpellByte.ALIT, (byte)SpellByte.SLOW },
					SkillChance1 = 0x00,
					Skills1 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.FIR3, (byte)SpellByte.NUKE, (byte)SpellByte.LIT3, (byte)SpellByte.ICE3, (byte)SpellByte.WALL, (byte)SpellByte.MUTE, (byte)SpellByte.SLO2, (byte)SpellByte.SLO2 },
					SkillChance2 = 0x00,
					Skills2 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
				},
				new AlternateFiends {
					Name = "GUARDIN",
					SpriteSheet = FormationSpriteSheet.SahagPirateSharkBigEye,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite1,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.None,
					MonsterType = MonsterType.GIANT,
					FiendPool = FiendPool.FinalFantasy3,
					SpellChance1 = 0x00,
					Spells1 = new List<byte> { (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Crack, (byte)EnemySkills.Stinger, (byte)EnemySkills.Trance, (byte)EnemySkills.Gaze },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.WALL, (byte)SpellByte.CUR4, (byte)SpellByte.SLO2, (byte)SpellByte.FAST, (byte)SpellByte.RUSE, (byte)SpellByte.SLP2, (byte)SpellByte.QAKE, (byte)SpellByte.QAKE },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Crack, (byte)EnemySkills.Stare, (byte)EnemySkills.Dazzle, (byte)EnemySkills.Tornado },
				},
				new AlternateFiends {
					Name = "GUTSCO",
					SpriteSheet = FormationSpriteSheet.BoneCreepHyenaOgre,
					FormationPattern = FormationPattern.Mixed,
					GFXOffset = FormationGFX.Sprite3,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.Ice,
					MonsterType = MonsterType.GIANT,
					FiendPool = FiendPool.FinalFantasy3,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.FIRE, (byte)SpellByte.FIR2, (byte)SpellByte.SLOW, (byte)SpellByte.FIRE, (byte)SpellByte.FIR2, (byte)SpellByte.STUN, (byte)SpellByte.BLND, (byte)SpellByte.FIRE },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Cremate, (byte)EnemySkills.Heat, (byte)EnemySkills.Stinger, (byte)EnemySkills.Trance },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.FIR3, (byte)SpellByte.FIR3, (byte)SpellByte.FAST, (byte)SpellByte.FOG, (byte)SpellByte.SLO2, (byte)SpellByte.SLP2, (byte)SpellByte.FIR3, (byte)SpellByte.LOK2 },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Blaze, (byte)EnemySkills.Nuclear, (byte)EnemySkills.Cremate, (byte)EnemySkills.Squint },
				},
				new AlternateFiends {
					Name = "HECATON",
					SpriteSheet = FormationSpriteSheet.KrakenTiamat,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite3,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.Earth,
					MonsterType = MonsterType.GIANT,
					FiendPool = FiendPool.FinalFantasy3,
					SpellChance1 = 0x00,
					Spells1 = new List<byte> { (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Stare, (byte)EnemySkills.Gaze, (byte)EnemySkills.Squint, (byte)EnemySkills.Trance },
					SpellChance2 = 0x00,
					Spells2 = new List<byte> { (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Crack, (byte)EnemySkills.Squint, (byte)EnemySkills.Toxic, (byte)EnemySkills.Glare },
				},
				new AlternateFiends {
					Name = "KUNOICHI",
					SpriteSheet = FormationSpriteSheet.CaribeGatorOchoHydra,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite4,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.None,
					MonsterType = MonsterType.NONE,
					FiendPool = FiendPool.FinalFantasy3,
					SpellChance1 = 0x00,
					Spells1 = new List<byte> { (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Dazzle, (byte)EnemySkills.Gaze, (byte)EnemySkills.Trance, (byte)EnemySkills.Trance },
					SpellChance2 = 0x00,
					Spells2 = new List<byte> { (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Tornado, (byte)EnemySkills.Trance, (byte)EnemySkills.Poison_Damage, (byte)EnemySkills.Glare },
				},
				new AlternateFiends {
					Name = "LEVIATHN",
					SpriteSheet = FormationSpriteSheet.ImageGeistWormEye,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite3,
					Palette1 = 0x01, // Blue/White
					Palette2 = 0x01,
					ElementalWeakness = SpellElement.Lightning,
					MonsterType = MonsterType.GIANT,
					FiendPool = FiendPool.FinalFantasy3,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.ICE, (byte)SpellByte.ICE2, (byte)SpellByte.ICE, (byte)SpellByte.STOP, (byte)SpellByte.ICE, (byte)SpellByte.ICE2, (byte)SpellByte.ICE, (byte)SpellByte.STOP },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Frost, (byte)EnemySkills.Dazzle, (byte)EnemySkills.Stinger, (byte)EnemySkills.Flash },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.ICE2, (byte)SpellByte.ICE2, (byte)SpellByte.ICE3, (byte)SpellByte.ICE3, (byte)SpellByte.ICE2, (byte)SpellByte.ICE2, (byte)SpellByte.XFER, (byte)SpellByte.ICE3 },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Frost, (byte)EnemySkills.Swirl, (byte)EnemySkills.Blizzard, (byte)EnemySkills.Swirl },
				},
				new AlternateFiends {
					Name = "LUCIFER",
					SpriteSheet = FormationSpriteSheet.ImpWolfIguanaGiant,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite2,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.Ice,
					MonsterType = MonsterType.REGENERATIVE,
					FiendPool = FiendPool.FinalFantasy3,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.FIR2, (byte)SpellByte.FIRE, (byte)SpellByte.FIR2, (byte)SpellByte.SLOW, (byte)SpellByte.SLEP, (byte)SpellByte.BLND, (byte)SpellByte.MUTE, (byte)SpellByte.FIRE },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Heat, (byte)EnemySkills.Scorch, (byte)EnemySkills.Trance, (byte)EnemySkills.Glance },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.NUKE, (byte)SpellByte.FIR3, (byte)SpellByte.XFER, (byte)SpellByte.FIR3, (byte)SpellByte.XXXX, (byte)SpellByte.FAST, (byte)SpellByte.FOG2, (byte)SpellByte.TMPR },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Inferno, (byte)EnemySkills.Toxic, (byte)EnemySkills.Poison_Damage, (byte)EnemySkills.Squint },
				},
				new AlternateFiends{
					Name = "NEP.DRGN",
					SpriteSheet = FormationSpriteSheet.KrakenTiamat,
					FormationPattern = FormationPattern.Fiends,
					GFXOffset = FormationGFX.Sprite3,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.None,
					MonsterType = MonsterType.DRAGON,
					FiendPool = FiendPool.FinalFantasy3,
					SpellChance1 = 0x00,
					Spells1 = new List<byte> { (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Stare, (byte)EnemySkills.Heat, (byte)EnemySkills.Cremate, (byte)EnemySkills.Trance },
					SpellChance2 = 0x00,
					Spells2 = new List<byte> { (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Tornado, (byte)EnemySkills.Toxic, (byte)EnemySkills.Inferno, (byte)EnemySkills.Tornado },
				},
				new AlternateFiends{
					Name = "NINJI",
					SpriteSheet = FormationSpriteSheet.MummyCoctricWyvernTyro,
					FormationPattern = FormationPattern.Mixed,
					GFXOffset = FormationGFX.Sprite4,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.Time,
					MonsterType = MonsterType.NONE,
					FiendPool = FiendPool.FinalFantasy3,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.FOG, (byte)SpellByte.INVS, (byte)SpellByte.BLND, (byte)SpellByte.BLND, (byte)SpellByte.STUN, (byte)SpellByte.SLEP, (byte)SpellByte.SLEP, (byte)SpellByte.FOG },
					SkillChance1 = 0x00,
					Skills1 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.FAST, (byte)SpellByte.SABR, (byte)SpellByte.FOG2, (byte)SpellByte.INVS, (byte)SpellByte.SLO2, (byte)SpellByte.SLP2, (byte)SpellByte.BANE, (byte)SpellByte.ZAP },
					SkillChance2 = 0x00,
					Skills2 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
				},
				new AlternateFiends {
					Name = "SALAMAND",
					SpriteSheet = FormationSpriteSheet.WizardGarlandDragon2Golem,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite3,
					Palette1 = 0x27, // Orange/Red
					Palette2 = 0x27,
					ElementalWeakness = SpellElement.Ice,
					MonsterType = MonsterType.DRAGON,
					FiendPool = FiendPool.FinalFantasy3,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.FIRE, (byte)SpellByte.DARK, (byte)SpellByte.FIRE, (byte)SpellByte.FIR2, (byte)SpellByte.FIRE, (byte)SpellByte.DARK, (byte)SpellByte.FIRE, (byte)SpellByte.FIR2 },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Flash, (byte)EnemySkills.Heat, (byte)EnemySkills.Flash, (byte)EnemySkills.Heat },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.FIR2, (byte)SpellByte.FIR3, (byte)SpellByte.FIR3, (byte)SpellByte.NUKE, (byte)SpellByte.FIR2, (byte)SpellByte.FIR2, (byte)SpellByte.FIR3, (byte)SpellByte.DARK },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Scorch, (byte)EnemySkills.Blaze, (byte)EnemySkills.Heat, (byte)EnemySkills.Inferno },
				},

				new AlternateFiends {
					Name = "SCYLLA",
					SpriteSheet = FormationSpriteSheet.KrakenTiamat,
					FormationPattern = FormationPattern.Fiends,
					GFXOffset = FormationGFX.Sprite2,
					Palette1 = 0x1A, // Blue/Green
					Palette2 = 0x24,
					ElementalWeakness = SpellElement.Ice,
					MonsterType = MonsterType.AQUATIC,
					FiendPool = FiendPool.FinalFantasy3,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.LIT, (byte)SpellByte.LIT2, (byte)SpellByte.LIT, (byte)SpellByte.LIT2, (byte)SpellByte.LIT, (byte)SpellByte.LIT2, (byte)SpellByte.LIT, (byte)SpellByte.LIT2 },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Dazzle, (byte)EnemySkills.Flash, (byte)EnemySkills.Glance, (byte)EnemySkills.Flash },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.LIT2, (byte)SpellByte.LIT2, (byte)SpellByte.LIT3, (byte)SpellByte.SLO2, (byte)SpellByte.LIT2, (byte)SpellByte.LIT2, (byte)SpellByte.LIT3, (byte)SpellByte.FAST },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Thunder, (byte)EnemySkills.Dazzle, (byte)EnemySkills.Tornado, (byte)EnemySkills.Flash },
				},

				new AlternateFiends {
					Name = "UNNE",
					SpriteSheet = FormationSpriteSheet.BadmanAstosMadponyWarmech,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite3,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.Status,
					MonsterType = MonsterType.MAGE,
					FiendPool = FiendPool.FinalFantasy3,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.ICE, (byte)SpellByte.ICE, (byte)SpellByte.SLOW, (byte)SpellByte.ICE, (byte)SpellByte.FOG, (byte)SpellByte.MUTE, (byte)SpellByte.SLOW, (byte)SpellByte.MUTE },
					SkillChance1 = 0x00,
					Skills1 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.ICE3, (byte)SpellByte.SLO2, (byte)SpellByte.XFER, (byte)SpellByte.ICE3, (byte)SpellByte.BANE, (byte)SpellByte.MUTE, (byte)SpellByte.ICE2, (byte)SpellByte.ICE2 },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Blizzard, (byte)EnemySkills.Tornado, (byte)EnemySkills.Frost, (byte)EnemySkills.Glare },
				},

				new AlternateFiends {
					Name = "ZANDE",
					SpriteSheet = FormationSpriteSheet.KaryLich,
					FormationPattern = FormationPattern.Mixed,
					GFXOffset = FormationGFX.Sprite4,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.None,
					MonsterType = MonsterType.MAGE,
					FiendPool = FiendPool.FinalFantasy3,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.FIRE, (byte)SpellByte.LIT2, (byte)SpellByte.FIR2, (byte)SpellByte.CUR2, (byte)SpellByte.HOLD, (byte)SpellByte.LIT, (byte)SpellByte.HOLD, (byte)SpellByte.BLND },
					SkillChance1 = 0x00,
					Skills1 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.NUKE, (byte)SpellByte.LIT3, (byte)SpellByte.FIR3, (byte)SpellByte.QAKE, (byte)SpellByte.FIR3, (byte)SpellByte.XXXX, (byte)SpellByte.SLP2, (byte)SpellByte.RUB },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Crack, (byte)EnemySkills.Nuclear, (byte)EnemySkills.Blaze, (byte)EnemySkills.Toxic },
				},
			};
			var FF4AltFiendsList = new List<AlternateFiends> {

					new AlternateFiends {
					Name = "ANTLION",
					SpriteSheet = FormationSpriteSheet.AspLobsterBullTroll,
					FormationPattern = FormationPattern.Mixed,
					GFXOffset = FormationGFX.Sprite3,
					Palette1 = 0x3A,
					Palette2 = 0x3A,
					ElementalWeakness = SpellElement.Ice,
					MonsterType = MonsterType.MAGICAL,
					FiendPool = FiendPool.FinalFantasy4,
					SpellChance1 = 0x00,
					Spells1 = new List<byte> { (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Stinger, (byte)EnemySkills.Crack, (byte)EnemySkills.Trance, (byte)EnemySkills.Cremate },
					SpellChance2 = 0x00,
					Spells2 = new List<byte> { (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Toxic, (byte)EnemySkills.Poison_Damage, (byte)EnemySkills.Blaze, (byte)EnemySkills.Crack },
				},

				new AlternateFiends {
					Name = "ASURA",
					SpriteSheet = FormationSpriteSheet.BoneCreepHyenaOgre,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite4,
					Palette1 = 0x3A,
					Palette2 = 0x3A,
					ElementalWeakness = SpellElement.None,
					MonsterType = MonsterType.REGENERATIVE,
					FiendPool = FiendPool.FinalFantasy4,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.CUR2, (byte)SpellByte.CUR3, (byte)SpellByte.CUR3, (byte)SpellByte.FAST, (byte)SpellByte.CUR2, (byte)SpellByte.CUR3, (byte)SpellByte.CUR3, (byte)SpellByte.FAST },
					SkillChance1 = 0x00,
					Skills1 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.CUR2, (byte)SpellByte.CUR3, (byte)SpellByte.CUR2, (byte)SpellByte.FAST, (byte)SpellByte.CUR3, (byte)SpellByte.CUR2, (byte)SpellByte.CUR3, (byte)SpellByte.CUR4 },
					SkillChance2 = 0x00,
					Skills2 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
				},

				new AlternateFiends {
					Name = "BAIGAN",
					SpriteSheet = FormationSpriteSheet.SlimeSpiderManticorAnkylo,
					FormationPattern = FormationPattern.Mixed,
					GFXOffset = FormationGFX.Sprite1,
					Palette1 = 0x3A,
					Palette2 = 0x3A,
					ElementalWeakness = SpellElement.Status,
					MonsterType = MonsterType.MAGICAL,
					FiendPool = FiendPool.FinalFantasy4,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.SLOW, (byte)SpellByte.LIT2, (byte)SpellByte.ICE2, (byte)SpellByte.WALL, (byte)SpellByte.FIR2, (byte)SpellByte.STOP, (byte)SpellByte.TMPR, (byte)SpellByte.FIR2 },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Stinger, (byte)EnemySkills.Dazzle, (byte)EnemySkills.Cremate, (byte)EnemySkills.Frost },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.FIR3, (byte)SpellByte.WALL, (byte)SpellByte.FAST, (byte)SpellByte.ICE3, (byte)SpellByte.NUKE, (byte)SpellByte.SLO2, (byte)SpellByte.FOG, (byte)SpellByte.LIT3 },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Poison_Stone, (byte)EnemySkills.Crack, (byte)EnemySkills.Stare, (byte)EnemySkills.Stinger },
				},

				new AlternateFiends {
					Name = "BALNAB",
					SpriteSheet = FormationSpriteSheet.ImpWolfIguanaGiant,
					FormationPattern = FormationPattern.Small9,
					GFXOffset = FormationGFX.Sprite4,
					Palette1 = 0x3A,
					Palette2 = 0x3A,
					ElementalWeakness = SpellElement.Lightning,
					MonsterType = MonsterType.GIANT,
					FiendPool = FiendPool.FinalFantasy4,
					SpellChance1 = 0x00,
					Spells1 = new List<byte> { (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Cremate, (byte)EnemySkills.Toxic, (byte)EnemySkills.Cremate, (byte)EnemySkills.Stare },
					SpellChance2 = 0x00,
					Spells2 = new List<byte> { (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Poison_Damage, (byte)EnemySkills.Thunder, (byte)EnemySkills.Nuclear, (byte)EnemySkills.Toxic },
				},

				new AlternateFiends {
					Name = "BARBRICA",
					SpriteSheet = FormationSpriteSheet.SentryWaterNagaChimera,
					FormationPattern = FormationPattern.Mixed,
					GFXOffset = FormationGFX.Sprite2,
					Palette1 = 0x36,
					Palette2 = 0x36,
					ElementalWeakness = SpellElement.Earth,
					MonsterType = MonsterType.MAGICAL,
					FiendPool = FiendPool.FinalFantasy4,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.LIT, (byte)SpellByte.DARK, (byte)SpellByte.SLOW, (byte)SpellByte.LIT2, (byte)SpellByte.LIT, (byte)SpellByte.DARK, (byte)SpellByte.SLOW, (byte)SpellByte.LIT2 },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Heat, (byte)EnemySkills.Flash, (byte)EnemySkills.Gaze, (byte)EnemySkills.Heat },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.LIT3, (byte)SpellByte.LIT2, (byte)SpellByte.SLOW, (byte)SpellByte.LIT3, (byte)SpellByte.LIT2, (byte)SpellByte.SLO2, (byte)SpellByte.DARK, (byte)SpellByte.DARK },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Flash, (byte)EnemySkills.Thunder, (byte)EnemySkills.Glare, (byte)EnemySkills.Thunder },
				},
				new AlternateFiends {
					Name = "CAGNAZZO",
					SpriteSheet = FormationSpriteSheet.MummyCoctricWyvernTyro,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite4,
					Palette1 = 0x14, // Blue/Purple
					Palette2 = 0x14,
					ElementalWeakness = SpellElement.Lightning,
					MonsterType = MonsterType.AQUATIC,
					FiendPool = FiendPool.FinalFantasy4,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.ICE, (byte)SpellByte.STUN, (byte)SpellByte.ICE, (byte)SpellByte.ICE2, (byte)SpellByte.ICE, (byte)SpellByte.STUN, (byte)SpellByte.ICE, (byte)SpellByte.ICE2 },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Frost, (byte)EnemySkills.Flash, (byte)EnemySkills.Frost, (byte)EnemySkills.Flash },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.ICE2, (byte)SpellByte.ICE2, (byte)SpellByte.ICE3, (byte)SpellByte.CUR3, (byte)SpellByte.ICE2, (byte)SpellByte.ICE3, (byte)SpellByte.ICE3, (byte)SpellByte.CUR4 },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Frost, (byte)EnemySkills.Dazzle, (byte)EnemySkills.Frost, (byte)EnemySkills.Blizzard },
				},

				new AlternateFiends {
					Name = "CALCABRN",
					SpriteSheet = FormationSpriteSheet.KrakenTiamat,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite1,
					Palette1 = 0x14, // Blue/Purple
					Palette2 = 0x14,
					ElementalWeakness = SpellElement.Fire,
					MonsterType = MonsterType.GIANT,
					FiendPool = FiendPool.FinalFantasy4,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.FAST, (byte)SpellByte.LIT, (byte)SpellByte.LIT2, (byte)SpellByte.SLOW, (byte)SpellByte.FOG, (byte)SpellByte.BLND, (byte)SpellByte.BRAK, (byte)SpellByte.ICE2 },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Trance, (byte)EnemySkills.Frost, (byte)EnemySkills.Gaze, (byte)EnemySkills.Stare },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.SABR, (byte)SpellByte.ICE3, (byte)SpellByte.SLO2, (byte)SpellByte.RUSE, (byte)SpellByte.LIT3, (byte)SpellByte.XXXX, (byte)SpellByte.MUTE, (byte)SpellByte.CUR4 },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Blizzard, (byte)EnemySkills.Crack, (byte)EnemySkills.Poison_Damage, (byte)EnemySkills.Squint },
				},

				new AlternateFiends {
					Name = "D.MIST",
					SpriteSheet = FormationSpriteSheet.SentryWaterNagaChimera,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite4,
					Palette1 = 0x36,
					Palette2 = 0x36,
					ElementalWeakness = SpellElement.Fire,
					MonsterType = MonsterType.DRAGON,
					FiendPool = FiendPool.FinalFantasy4,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.ICE, (byte)SpellByte.ICE2, (byte)SpellByte.SLOW, (byte)SpellByte.FOG, (byte)SpellByte.FOG, (byte)SpellByte.ICE2, (byte)SpellByte.DARK, (byte)SpellByte.CUR2 },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Snorting, (byte)EnemySkills.Frost, (byte)EnemySkills.Frost, (byte)EnemySkills.Gaze },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.ICE3, (byte)SpellByte.SLO2, (byte)SpellByte.ICE3, (byte)SpellByte.FOG, (byte)SpellByte.RUSE, (byte)SpellByte.ICE3, (byte)SpellByte.SLO2, (byte)SpellByte.FOG },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Blizzard, (byte)EnemySkills.Tornado, (byte)EnemySkills.Dazzle, (byte)EnemySkills.Squint },
				},

				new AlternateFiends {
					Name = "D.STORM",
					SpriteSheet = FormationSpriteSheet.SahagPirateSharkBigEye,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite1,
					Palette1 = 0x36,
					Palette2 = 0x36,
					ElementalWeakness = SpellElement.Time,
					MonsterType = MonsterType.DRAGON,
					FiendPool = FiendPool.FinalFantasy4,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.LIT, (byte)SpellByte.FAST, (byte)SpellByte.LIT2, (byte)SpellByte.SLOW, (byte)SpellByte.LIT2, (byte)SpellByte.LOCK, (byte)SpellByte.LIT2, (byte)SpellByte.SLOW },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Glare, (byte)EnemySkills.Dazzle, (byte)EnemySkills.Trance, (byte)EnemySkills.Stare },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.LIT3, (byte)SpellByte.FAST, (byte)SpellByte.LIT3, (byte)SpellByte.SABR, (byte)SpellByte.XXXX, (byte)SpellByte.LIT3, (byte)SpellByte.LOK2, (byte)SpellByte.CUR3 },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Tornado, (byte)EnemySkills.Thunder, (byte)EnemySkills.Glare, (byte)EnemySkills.Poison_Stone },
				},

				new AlternateFiends {
					Name = "DARKELF",
					SpriteSheet = FormationSpriteSheet.ImpWolfIguanaGiant,
					FormationPattern = FormationPattern.Mixed,
					GFXOffset = FormationGFX.Sprite3,
					Palette1 = 0x36,
					Palette2 = 0x36,
					ElementalWeakness = SpellElement.Poison,
					MonsterType = MonsterType.GIANT,
					FiendPool = FiendPool.FinalFantasy4,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.FIR2, (byte)SpellByte.ICE2, (byte)SpellByte.LIT2, (byte)SpellByte.MUTE, (byte)SpellByte.STUN, (byte)SpellByte.FIR2, (byte)SpellByte.LIT2, (byte)SpellByte.ICE2 },
					SkillChance1 = 0x00,
					Skills1 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.LIT3, (byte)SpellByte.ICE3, (byte)SpellByte.FIR3, (byte)SpellByte.RUSE, (byte)SpellByte.XXXX, (byte)SpellByte.NUKE, (byte)SpellByte.CUR3, (byte)SpellByte.SLO2 },
					SkillChance2 = 0x00,
					Skills2 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
				},

				new AlternateFiends {
					Name = "DETHMACH",
					SpriteSheet = FormationSpriteSheet.KrakenTiamat,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite4,
					Palette1 = 0x36,
					Palette2 = 0x36,
					ElementalWeakness = SpellElement.Earth,
					MonsterType = MonsterType.MAGICAL,
					FiendPool = FiendPool.FinalFantasy4,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.BANE, (byte)SpellByte.FOG, (byte)SpellByte.BRAK, (byte)SpellByte.FAST, (byte)SpellByte.STUN, (byte)SpellByte.HOLD, (byte)SpellByte.QAKE, (byte)SpellByte.ZAP },
					SkillChance1 = 0x00,
					Skills1 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.XXXX, (byte)SpellByte.XFER, (byte)SpellByte.ZAP, (byte)SpellByte.XFER, (byte)SpellByte.XXXX, (byte)SpellByte.QAKE, (byte)SpellByte.BANE, (byte)SpellByte.BRAK },
					SkillChance2 = 0x00,
					Skills2 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
				},

				new AlternateFiends {
					Name = "EVILWALL",
					SpriteSheet = FormationSpriteSheet.KrakenTiamat,
					FormationPattern = FormationPattern.Fiends,
					GFXOffset = FormationGFX.Sprite1,
					Palette1 = 0x36,
					Palette2 = 0x36,
					ElementalWeakness = SpellElement.Earth,
					MonsterType = MonsterType.NONE,
					FiendPool = FiendPool.FinalFantasy4,
					SpellChance1 = 0x00,
					Spells1 = new List<byte> { (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Gaze, (byte)EnemySkills.Glance, (byte)EnemySkills.Dazzle, (byte)EnemySkills.Stare },
					SpellChance2 = 0x00,
					Spells2 = new List<byte> { (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Poison_Damage, (byte)EnemySkills.Toxic, (byte)EnemySkills.Squint, (byte)EnemySkills.Nuclear },
				},

				new AlternateFiends {
					Name = "FLANMAST",
					SpriteSheet = FormationSpriteSheet.SahagPirateSharkBigEye,
					FormationPattern = FormationPattern.Small9,
					GFXOffset = FormationGFX.Sprite3,
					Palette1 = 0x36,
					Palette2 = 0x36,
					ElementalWeakness = SpellElement.Status,
					MonsterType = MonsterType.MAGE,
					FiendPool = FiendPool.FinalFantasy4,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.FIR2, (byte)SpellByte.INVS, (byte)SpellByte.FIR2, (byte)SpellByte.MUTE, (byte)SpellByte.RUB, (byte)SpellByte.SLOW, (byte)SpellByte.FIR2, (byte)SpellByte.LIT2 },
					SkillChance1 = 0x00,
					Skills1 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.NUKE, (byte)SpellByte.XXXX, (byte)SpellByte.FIR3, (byte)SpellByte.SLO2, (byte)SpellByte.BRAK, (byte)SpellByte.WALL, (byte)SpellByte.FIR3, (byte)SpellByte.RUSE },
					SkillChance2 = 0x00,
					Skills2 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
				},

				new AlternateFiends {
					Name = "GIGAWORM",
					SpriteSheet = FormationSpriteSheet.ImageGeistWormEye,
					FormationPattern = FormationPattern.Mixed,
					GFXOffset = FormationGFX.Sprite4,
					Palette1 = 0x36,
					Palette2 = 0x36,
					ElementalWeakness = SpellElement.Ice,
					MonsterType = MonsterType.NONE,
					FiendPool = FiendPool.FinalFantasy4,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.LIT2, (byte)SpellByte.FIR2, (byte)SpellByte.QAKE, (byte)SpellByte.STUN, (byte)SpellByte.MUTE, (byte)SpellByte.LIT2, (byte)SpellByte.FIR2, (byte)SpellByte.RUB },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Crack, (byte)EnemySkills.Cremate, (byte)EnemySkills.Dazzle, (byte)EnemySkills.Trance },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.QAKE, (byte)SpellByte.FAST, (byte)SpellByte.FIR3, (byte)SpellByte.SLP2, (byte)SpellByte.XXXX, (byte)SpellByte.RUSE, (byte)SpellByte.FIR3, (byte)SpellByte.SLO2 },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Nuclear, (byte)EnemySkills.Poison_Stone, (byte)EnemySkills.Blaze, (byte)EnemySkills.Dazzle },
				},

				new AlternateFiends {
					Name = "GILGAMSH",
					SpriteSheet = FormationSpriteSheet.WizardGarlandDragon2Golem,
					FormationPattern = FormationPattern.Mixed,
					GFXOffset = FormationGFX.Sprite2,
					Palette1 = 0x36, // Yellow/Purple
					Palette2 = 0x36,
					ElementalWeakness = SpellElement.Time,
					MonsterType = MonsterType.NONE,
					FiendPool = FiendPool.FinalFantasy4, //I know it is FF5 but we need more fiends before FF5 will function
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.FAST, (byte)SpellByte.XFER, (byte)SpellByte.SLOW, (byte)SpellByte.WALL, (byte)SpellByte.FAST, (byte)SpellByte.XFER, (byte)SpellByte.SLOW, (byte)SpellByte.WALL },
					SkillChance1 = 0x00,
					Skills1 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.FAST, (byte)SpellByte.XFER, (byte)SpellByte.SLO2, (byte)SpellByte.SABR, (byte)SpellByte.XXXX, (byte)SpellByte.SABR, (byte)SpellByte.SLO2, (byte)SpellByte.WALL },
					SkillChance2 = 0x00,
					Skills2 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
				},

				new AlternateFiends {
					Name = "GOLBEZ",
					SpriteSheet = FormationSpriteSheet.KrakenTiamat,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite1,
					Palette1 = 0x36,
					Palette2 = 0x36,
					ElementalWeakness = SpellElement.Fire,
					MonsterType = MonsterType.MAGICAL,
					FiendPool = FiendPool.FinalFantasy4,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.QAKE, (byte)SpellByte.ICE2, (byte)SpellByte.RUB, (byte)SpellByte.LIT2, (byte)SpellByte.FIRE, (byte)SpellByte.FIR2, (byte)SpellByte.LIT, (byte)SpellByte.ICE },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Cremate, (byte)EnemySkills.Frost, (byte)EnemySkills.Gaze, (byte)EnemySkills.Stare },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.NUKE, (byte)SpellByte.RUSE, (byte)SpellByte.XXXX, (byte)SpellByte.ICE3, (byte)SpellByte.XFER, (byte)SpellByte.BRAK, (byte)SpellByte.FIR3, (byte)SpellByte.STOP },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Blaze, (byte)EnemySkills.Inferno, (byte)EnemySkills.Swirl, (byte)EnemySkills.Poison_Stone },
				},

				new AlternateFiends {
					Name = "IFRIT",
					SpriteSheet = FormationSpriteSheet.VampGargoyleEarthDragon1,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite3,
					Palette1 = 0x00, // Brown/Red
					Palette2 = 0x00,
					ElementalWeakness = SpellElement.Ice,
					MonsterType = MonsterType.MAGICAL,
					FiendPool = FiendPool.FinalFantasy4, //Will move to FF3 when we get more FF4 fiends
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.FIRE, (byte)SpellByte.STUN, (byte)SpellByte.FIRE, (byte)SpellByte.FIR2, (byte)SpellByte.FIRE, (byte)SpellByte.STUN, (byte)SpellByte.FIRE, (byte)SpellByte.FIR2 },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Heat, (byte)EnemySkills.Scorch, (byte)EnemySkills.Heat, (byte)EnemySkills.Flash },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.FIR2, (byte)SpellByte.FIR3, (byte)SpellByte.XFER, (byte)SpellByte.FIR2, (byte)SpellByte.FIR3, (byte)SpellByte.WALL, (byte)SpellByte.FIR3, (byte)SpellByte.NUKE },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Inferno, (byte)EnemySkills.Flash, (byte)EnemySkills.Blaze, (byte)EnemySkills.Nuclear },
				},

				new AlternateFiends {
					Name = "LUGAE",
					SpriteSheet = FormationSpriteSheet.WizardGarlandDragon2Golem,
					FormationPattern = FormationPattern.Small9,
					GFXOffset = FormationGFX.Sprite3,
					Palette1 = 0x36,
					Palette2 = 0x36,
					ElementalWeakness = SpellElement.Fire,
					MonsterType = MonsterType.UNDEAD,
					FiendPool = FiendPool.FinalFantasy4,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.LIT2, (byte)SpellByte.FIR2, (byte)SpellByte.QAKE, (byte)SpellByte.STUN, (byte)SpellByte.MUTE, (byte)SpellByte.LIT2, (byte)SpellByte.FIR2, (byte)SpellByte.RUB },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Crack, (byte)EnemySkills.Cremate, (byte)EnemySkills.Dazzle, (byte)EnemySkills.Trance },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.QAKE, (byte)SpellByte.FAST, (byte)SpellByte.FIR3, (byte)SpellByte.SLP2, (byte)SpellByte.XXXX, (byte)SpellByte.RUSE, (byte)SpellByte.FIR3, (byte)SpellByte.SLO2 },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Nuclear, (byte)EnemySkills.Poison_Stone, (byte)EnemySkills.Blaze, (byte)EnemySkills.Dazzle },
				},

				new AlternateFiends {
					Name = "MOMBOMB",
					SpriteSheet = FormationSpriteSheet.BoneCreepHyenaOgre,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite1,
					Palette1 = 0x36,
					Palette2 = 0x36,
					ElementalWeakness = SpellElement.Ice,
					MonsterType = MonsterType.NONE,
					FiendPool = FiendPool.FinalFantasy4,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.FIRE, (byte)SpellByte.FIR2, (byte)SpellByte.RUB, (byte)SpellByte.SLOW, (byte)SpellByte.FIR2, (byte)SpellByte.FIR2, (byte)SpellByte.STUN, (byte)SpellByte.BLND },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Heat, (byte)EnemySkills.Cremate, (byte)EnemySkills.Trance, (byte)EnemySkills.Heat },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.FIR3, (byte)SpellByte.NUKE, (byte)SpellByte.MUTE, (byte)SpellByte.RUB, (byte)SpellByte.FIR3, (byte)SpellByte.FAST, (byte)SpellByte.CUR3, (byte)SpellByte.SLOW },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Blaze, (byte)EnemySkills.Cremate, (byte)EnemySkills.Inferno, (byte)EnemySkills.Trance },
				},

				new AlternateFiends {
					Name = "OCTOMAM",
					SpriteSheet = FormationSpriteSheet.BoneCreepHyenaOgre,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite4,
					Palette1 = 0x36,
					Palette2 = 0x36,
					ElementalWeakness = SpellElement.Lightning,
					MonsterType = MonsterType.AQUATIC,
					FiendPool = FiendPool.FinalFantasy4,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.ICE, (byte)SpellByte.CUR2, (byte)SpellByte.ICE2, (byte)SpellByte.FOG, (byte)SpellByte.ICE2, (byte)SpellByte.STUN, (byte)SpellByte.SLEP, (byte)SpellByte.ICE2 },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Ink, (byte)EnemySkills.Stinger, (byte)EnemySkills.Ink, (byte)EnemySkills.Stare },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.ICE3, (byte)SpellByte.ICE3, (byte)SpellByte.FAST, (byte)SpellByte.CUR4, (byte)SpellByte.SLO2, (byte)SpellByte.XXXX, (byte)SpellByte.TMPR, (byte)SpellByte.ICE3 },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Swirl, (byte)EnemySkills.Ink, (byte)EnemySkills.Blizzard, (byte)EnemySkills.Stinger },
				},

				new AlternateFiends {
					Name = "ODIN",
					SpriteSheet = FormationSpriteSheet.ImpWolfIguanaGiant,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite4,
					Palette1 = 0x26, // Yellow/Blue
					Palette2 = 0x26,
					ElementalWeakness = SpellElement.Lightning,
					MonsterType = MonsterType.GIANT,
					FiendPool = FiendPool.FinalFantasy4, //Will move to FF3 when we get more FF4 fiends
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.STUN, (byte)SpellByte.CUR2, (byte)SpellByte.FAST, (byte)SpellByte.SLOW, (byte)SpellByte.STUN, (byte)SpellByte.CUR2, (byte)SpellByte.FAST, (byte)SpellByte.SLOW },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Gaze, (byte)EnemySkills.Flash, (byte)EnemySkills.Flash, (byte)EnemySkills.Crack },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.STUN, (byte)SpellByte.CUR3, (byte)SpellByte.XXXX, (byte)SpellByte.SLO2, (byte)SpellByte.CUR3, (byte)SpellByte.STOP, (byte)SpellByte.SLOW, (byte)SpellByte.NUKE },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Crack, (byte)EnemySkills.Gaze, (byte)EnemySkills.Flash, (byte)EnemySkills.Dazzle },
				},

				new AlternateFiends {
					Name = "OGOPOGO",
					SpriteSheet = FormationSpriteSheet.ImpWolfIguanaGiant,
					FormationPattern = FormationPattern.Fiends,
					GFXOffset = FormationGFX.Sprite3,
					Palette1 = 0x36,
					Palette2 = 0x36,
					ElementalWeakness = SpellElement.Lightning,
					MonsterType = MonsterType.AQUATIC,
					FiendPool = FiendPool.FinalFantasy4,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.ICE2, (byte)SpellByte.ICE, (byte)SpellByte.ICE2, (byte)SpellByte.FOG, (byte)SpellByte.HEL2, (byte)SpellByte.ICE2, (byte)SpellByte.SLOW, (byte)SpellByte.ICE2 },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Ink, (byte)EnemySkills.Frost, (byte)EnemySkills.Ink, (byte)EnemySkills.Frost },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.ICE3, (byte)SpellByte.ICE3, (byte)SpellByte.RUSE, (byte)SpellByte.BLND, (byte)SpellByte.ICE3, (byte)SpellByte.BRAK, (byte)SpellByte.WALL, (byte)SpellByte.ICE3 },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Swirl, (byte)EnemySkills.Ink, (byte)EnemySkills.Blizzard, (byte)EnemySkills.Frost },
				},

				new AlternateFiends {
					Name = "PALEDIM",
					SpriteSheet = FormationSpriteSheet.ImpWolfIguanaGiant,
					FormationPattern = FormationPattern.Mixed,
					GFXOffset = FormationGFX.Sprite2,
					Palette1 = 0x36,
					Palette2 = 0x36,
					ElementalWeakness = SpellElement.None,
					MonsterType = MonsterType.DRAGON,
					FiendPool = FiendPool.FinalFantasy4,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.ICE2, (byte)SpellByte.FIR2, (byte)SpellByte.LIT2, (byte)SpellByte.SLOW, (byte)SpellByte.ICE2, (byte)SpellByte.FIR2, (byte)SpellByte.LIT2, (byte)SpellByte.SLOW },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Crack, (byte)EnemySkills.Frost, (byte)EnemySkills.Cremate, (byte)EnemySkills.Trance },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.ICE3, (byte)SpellByte.FIR3, (byte)SpellByte.LIT3, (byte)SpellByte.SLO2, (byte)SpellByte.ICE3, (byte)SpellByte.LIT3, (byte)SpellByte.FIR3, (byte)SpellByte.SLO2 },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Thunder, (byte)EnemySkills.Inferno, (byte)EnemySkills.Blizzard, (byte)EnemySkills.Crack },
				},

				new AlternateFiends {
					Name = "PLAGUE",
					SpriteSheet = FormationSpriteSheet.ImageGeistWormEye,
					FormationPattern = FormationPattern.Mixed,
					GFXOffset = FormationGFX.Sprite4,
					Palette1 = 0x36,
					Palette2 = 0x36,
					ElementalWeakness = SpellElement.Status,
					MonsterType = MonsterType.MAGE,
					FiendPool = FiendPool.FinalFantasy4,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.BRAK, (byte)SpellByte.SLOW, (byte)SpellByte.QAKE, (byte)SpellByte.SLOW, (byte)SpellByte.INVS, (byte)SpellByte.RUB, (byte)SpellByte.BRAK, (byte)SpellByte.SLOW },
					SkillChance1 = 0x00,
					Skills1 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.XXXX, (byte)SpellByte.BRAK, (byte)SpellByte.QAKE, (byte)SpellByte.SLO2, (byte)SpellByte.RUSE, (byte)SpellByte.RUB, (byte)SpellByte.ZAP, (byte)SpellByte.BANE },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Poison_Stone, (byte)EnemySkills.Nuclear, (byte)EnemySkills.Toxic, (byte)EnemySkills.Crack },
				},

				new AlternateFiends {
					Name = "RAMUH",
					SpriteSheet = FormationSpriteSheet.AspLobsterBullTroll,
					FormationPattern = FormationPattern.Mixed,
					GFXOffset = FormationGFX.Sprite1,
					Palette1 = 0x26,
					Palette2 = 0x26,
					ElementalWeakness = SpellElement.Earth,
					MonsterType = MonsterType.MAGE,
					FiendPool = FiendPool.FinalFantasy4,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.LIT, (byte)SpellByte.LIT2, (byte)SpellByte.CUR2, (byte)SpellByte.LIT2, (byte)SpellByte.LIT, (byte)SpellByte.CUR2, (byte)SpellByte.LIT, (byte)SpellByte.LIT2 },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Stinger, (byte)EnemySkills.Flash, (byte)EnemySkills.Flash, (byte)EnemySkills.Stinger },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.LIT3, (byte)SpellByte.STUN, (byte)SpellByte.LIT3, (byte)SpellByte.SLOW, (byte)SpellByte.CUR3, (byte)SpellByte.LIT3, (byte)SpellByte.STOP, (byte)SpellByte.LIT3 },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Thunder, (byte)EnemySkills.Stinger, (byte)EnemySkills.Flash, (byte)EnemySkills.Tornado },
				},

				new AlternateFiends {
					Name = "RUBICANT",
					SpriteSheet = FormationSpriteSheet.VampGargoyleEarthDragon1,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite3,
					Palette1 = 0x0D, // Red/Red
					Palette2 = 0x0D,
					ElementalWeakness = SpellElement.Ice,
					MonsterType = MonsterType.MAGE,
					FiendPool = FiendPool.FinalFantasy4,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.FIRE, (byte)SpellByte.FIRE, (byte)SpellByte.FIRE, (byte)SpellByte.FIR2, (byte)SpellByte.FIRE, (byte)SpellByte.FIRE, (byte)SpellByte.FIRE, (byte)SpellByte.FIR2 },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Heat, (byte)EnemySkills.Scorch, (byte)EnemySkills.Flash, (byte)EnemySkills.Dazzle },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.FIR2, (byte)SpellByte.FIR2, (byte)SpellByte.FIR3, (byte)SpellByte.NUKE, (byte)SpellByte.FIR2, (byte)SpellByte.FIR3, (byte)SpellByte.FIR3, (byte)SpellByte.NUKE },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Scorch, (byte)EnemySkills.Heat, (byte)EnemySkills.Blaze, (byte)EnemySkills.Nuclear },
				},
				new AlternateFiends {
					Name = "SCARMLIO",
					SpriteSheet = FormationSpriteSheet.BoneCreepHyenaOgre,
					FormationPattern = FormationPattern.Mixed,
					GFXOffset = FormationGFX.Sprite1,
					Palette1 = 0x1B, // Brown/Blue
					Palette2 = 0x1B,
					ElementalWeakness = SpellElement.Fire,
					MonsterType = MonsterType.UNDEAD,
					FiendPool = FiendPool.FinalFantasy4,
					SpellChance1 = 0x00,
					Spells1 = new List<byte> { (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Snorting, (byte)EnemySkills.Gaze, (byte)EnemySkills.Ink, (byte)EnemySkills.Crack },
					SpellChance2 = 0x00,
					Spells2 = new List<byte> { (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Crack, (byte)EnemySkills.Snorting, (byte)EnemySkills.Crack, (byte)EnemySkills.Snorting },
				},

				new AlternateFiends {
					Name = "SHADOW.D",
					SpriteSheet = FormationSpriteSheet.VampGargoyleEarthDragon1,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite2,
					Palette1 = 0x1B,
					Palette2 = 0x1B,
					ElementalWeakness = SpellElement.Earth,
					MonsterType = MonsterType.DRAGON,
					FiendPool = FiendPool.FinalFantasy4,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.STUN, (byte)SpellByte.HOLD, (byte)SpellByte.RUB, (byte)SpellByte.STUN, (byte)SpellByte.HOLD, (byte)SpellByte.RUB, (byte)SpellByte.STUN, (byte)SpellByte.HOLD },
					SkillChance1 = 0x00,
					Skills1 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
					SpellChance2 = 0x00,
					Spells2 = new List<byte> { (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Crack, (byte)EnemySkills.Toxic, (byte)EnemySkills.Nuclear, (byte)EnemySkills.Poison_Stone },
				},

				new AlternateFiends {
					Name = "SHIVA",
					SpriteSheet = FormationSpriteSheet.KaryLich,
					FormationPattern = FormationPattern.Fiends,
					GFXOffset = FormationGFX.Sprite1,
					Palette1 = 0x13, // Blue/Purple
					Palette2 = 0x14,
					ElementalWeakness = SpellElement.Fire,
					MonsterType = MonsterType.MAGE,
					FiendPool = FiendPool.FinalFantasy4, //Will move to FF3 when we get more FF4 fiends
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.ICE, (byte)SpellByte.ICE, (byte)SpellByte.ICE, (byte)SpellByte.ICE2, (byte)SpellByte.ICE, (byte)SpellByte.ICE, (byte)SpellByte.ICE, (byte)SpellByte.ICE2 },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Frost, (byte)EnemySkills.Flash, (byte)EnemySkills.Gaze, (byte)EnemySkills.Snorting },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.ICE2, (byte)SpellByte.ICE3, (byte)SpellByte.ICE2, (byte)SpellByte.ICE2, (byte)SpellByte.ICE3, (byte)SpellByte.ICE3, (byte)SpellByte.ICE2, (byte)SpellByte.BRAK },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Frost, (byte)EnemySkills.Flash, (byte)EnemySkills.Blizzard, (byte)EnemySkills.Gaze },
				},
				new AlternateFiends {
					Name = "TITAN",
					SpriteSheet = FormationSpriteSheet.ImpWolfIguanaGiant,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite4,
					Palette1 = 0x32, // Brown/White
					Palette2 = 0x32,
					ElementalWeakness = SpellElement.Lightning,
					MonsterType = MonsterType.GIANT,
					FiendPool = FiendPool.FinalFantasy4, //Will move to FF3 when we get more FF4 fiends
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.LIT, (byte)SpellByte.LIT, (byte)SpellByte.LIT, (byte)SpellByte.LIT, (byte)SpellByte.LIT, (byte)SpellByte.LIT, (byte)SpellByte.LIT, (byte)SpellByte.LIT },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Dazzle, (byte)EnemySkills.Gaze, (byte)EnemySkills.Dazzle, (byte)EnemySkills.Flash },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.LIT2, (byte)SpellByte.FAST, (byte)SpellByte.LIT3, (byte)SpellByte.SLO2, (byte)SpellByte.STOP, (byte)SpellByte.LIT3, (byte)SpellByte.LIT2, (byte)SpellByte.XFER },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Swirl, (byte)EnemySkills.Scorch, (byte)EnemySkills.Dazzle, (byte)EnemySkills.Tornado },
				},

				new AlternateFiends {
					Name = "WYVERN",
					SpriteSheet = FormationSpriteSheet.CaribeGatorOchoHydra,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite1,
					Palette1 = 0x32,
					Palette2 = 0x32,
					ElementalWeakness = SpellElement.None,
					MonsterType = MonsterType.DRAGON,
					FiendPool = FiendPool.FinalFantasy4,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.FIR2, (byte)SpellByte.SLOW, (byte)SpellByte.FIR2, (byte)SpellByte.INVS, (byte)SpellByte.FIR2, (byte)SpellByte.MUTE, (byte)SpellByte.FIR2, (byte)SpellByte.SLOW },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Heat, (byte)EnemySkills.Cremate, (byte)EnemySkills.Trance, (byte)EnemySkills.Heat },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.NUKE, (byte)SpellByte.RUSE, (byte)SpellByte.FIR3, (byte)SpellByte.FAST, (byte)SpellByte.XXXX, (byte)SpellByte.NUKE, (byte)SpellByte.SLO2, (byte)SpellByte.FIR3 },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Inferno, (byte)EnemySkills.Tornado, (byte)EnemySkills.Glare, (byte)EnemySkills.Tornado },
				},

				new AlternateFiends {
					Name = "ZEMUS",
					SpriteSheet = FormationSpriteSheet.KaryLich,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite4,
					Palette1 = 0x32,
					Palette2 = 0x32,
					ElementalWeakness = SpellElement.None,
					MonsterType = MonsterType.GIANT,
					FiendPool = FiendPool.FinalFantasy4,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.FIR2, (byte)SpellByte.LIT2, (byte)SpellByte.ICE2, (byte)SpellByte.ZAP, (byte)SpellByte.SLOW, (byte)SpellByte.MUTE, (byte)SpellByte.QAKE, (byte)SpellByte.ICE2 },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Trance, (byte)EnemySkills.Cremate, (byte)EnemySkills.Frost, (byte)EnemySkills.Stare },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.FAST, (byte)SpellByte.NUKE, (byte)SpellByte.FIR3, (byte)SpellByte.BANE, (byte)SpellByte.SABR, (byte)SpellByte.SLO2, (byte)SpellByte.NUKE, (byte)SpellByte.CUR4 },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Swirl, (byte)EnemySkills.Poison_Stone, (byte)EnemySkills.Toxic, (byte)EnemySkills.Nuclear },
				},

			};
			var FF5AltFiendsList = new List<AlternateFiends>
			{
					new AlternateFiends {
					Name = "ABDUCTOR",
					SpriteSheet = FormationSpriteSheet.WizardGarlandDragon2Golem,
					FormationPattern = FormationPattern.Fiends,
					GFXOffset = FormationGFX.Sprite1,
					Palette1 = 0x3A,
					Palette2 = 0x3A,
					ElementalWeakness = SpellElement.Status,
					MonsterType = MonsterType.MAGICAL,
					FiendPool = FiendPool.FinalFantasy4,
					SpellChance1 = 0x00,
					Spells1 = new List<byte> { (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Stare, (byte)EnemySkills.Dazzle, (byte)EnemySkills.Trance, (byte)EnemySkills.Cremate },
					SpellChance2 = 0x00,
					Spells2 = new List<byte> { (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Toxic, (byte)EnemySkills.Poison_Damage, (byte)EnemySkills.Blaze, (byte)EnemySkills.Crack },
				},

					new AlternateFiends {
					Name = "ALTAROIT",
					SpriteSheet = FormationSpriteSheet.SahagPirateSharkBigEye,
					FormationPattern = FormationPattern.Mixed,
					GFXOffset = FormationGFX.Sprite4,
					Palette1 = 0x3A,
					Palette2 = 0x3A,
					ElementalWeakness = SpellElement.Time,
					MonsterType = MonsterType.MAGE,
					FiendPool = FiendPool.FinalFantasy4,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.ICE2, (byte)SpellByte.SLOW, (byte)SpellByte.SLEP, (byte)SpellByte.LIT2, (byte)SpellByte.MUTE, (byte)SpellByte.ICE2, (byte)SpellByte.LIT2, (byte)SpellByte.INVS },
					SkillChance1 = 0x00,
					Skills1 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE },
					SkillChance2 = 0x00,
					Skills2 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
				},
			};
			var FF1BonusFiendsList = new List<AlternateFiends>
			{

					new AlternateFiends {
					Name = "BIKKE",
					SpriteSheet = FormationSpriteSheet.AspLobsterBullTroll,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite1,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.Lightning,
					MonsterType = MonsterType.GIANT,
					FiendPool = FiendPool.FinalFantasy2,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.STUN, (byte)SpellByte.HOLD, (byte)SpellByte.CUR2, (byte)SpellByte.SLEP, (byte)SpellByte.HOLD, (byte)SpellByte.CUR2, (byte)SpellByte.BRAK, (byte)SpellByte.STUN },
					SkillChance1 = 0x00,
					Skills1 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.STUN, (byte)SpellByte.BRAK, (byte)SpellByte.CUR4, (byte)SpellByte.QAKE, (byte)SpellByte.STUN, (byte)SpellByte.BRAK, (byte)SpellByte.CUR4, (byte)SpellByte.ZAP },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Frost, (byte)EnemySkills.Blizzard, (byte)EnemySkills.Frost, (byte)EnemySkills.Tornado },
					},

					new AlternateFiends {
					Name = "BUBBLES",
					SpriteSheet = FormationSpriteSheet.MummyCoctricWyvernTyro,
					FormationPattern = FormationPattern.Mixed,
					GFXOffset = FormationGFX.Sprite3,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.Lightning,
					MonsterType = MonsterType.AQUATIC,
					FiendPool = FiendPool.FinalFantasy2,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.ICE, (byte)SpellByte.DARK, (byte)SpellByte.ICE2, (byte)SpellByte.DARK, (byte)SpellByte.ICE, (byte)SpellByte.DARK, (byte)SpellByte.ICE2, (byte)SpellByte.ZAP },
					SkillChance1 = 0x00,
					Skills1 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.ICE3, (byte)SpellByte.XFER, (byte)SpellByte.FADE, (byte)SpellByte.ZAP, (byte)SpellByte.ICE3, (byte)SpellByte.BRAK, (byte)SpellByte.FADE, (byte)SpellByte.ZAP },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Frost, (byte)EnemySkills.Poison_Stone, (byte)EnemySkills.Frost, (byte)EnemySkills.Blizzard },
					},

					new AlternateFiends {
					Name = "DR.UNNE",
					SpriteSheet = FormationSpriteSheet.SlimeSpiderManticorAnkylo,
					FormationPattern = FormationPattern.Mixed,
					GFXOffset = FormationGFX.Sprite4,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.Fire,
					MonsterType = MonsterType.UNDEAD,
					FiendPool = FiendPool.FinalFantasy2,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.ICE2, (byte)SpellByte.DARK, (byte)SpellByte.LIT2, (byte)SpellByte.WALL, (byte)SpellByte.ICE2, (byte)SpellByte.DARK, (byte)SpellByte.LIT2, (byte)SpellByte.RUSE },
					SkillChance1 = 0x00,
					Skills1 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.ICE3, (byte)SpellByte.ZAP, (byte)SpellByte.ICE3, (byte)SpellByte.WALL, (byte)SpellByte.ICE3, (byte)SpellByte.HOLD, (byte)SpellByte.ICE3, (byte)SpellByte.RUSE },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Blizzard, (byte)EnemySkills.Nuclear, (byte)EnemySkills.Tornado, (byte)EnemySkills.Nuclear },
					},

					new AlternateFiends {
					Name = "EVILELF",
					SpriteSheet = FormationSpriteSheet.VampGargoyleEarthDragon1,
					FormationPattern = FormationPattern.Mixed,
					GFXOffset = FormationGFX.Sprite1,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.Poison,
					MonsterType = MonsterType.MAGE,
					FiendPool = FiendPool.FinalFantasy2,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.LIT2, (byte)SpellByte.FIR2, (byte)SpellByte.ICE2, (byte)SpellByte.CUR2, (byte)SpellByte.LIT2, (byte)SpellByte.FIR2, (byte)SpellByte.ICE2, (byte)SpellByte.CUR3 },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Ink, (byte)EnemySkills.Ink, (byte)EnemySkills.Ink, (byte)EnemySkills.Ink },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.LIT3, (byte)SpellByte.NUKE, (byte)SpellByte.ICE3, (byte)SpellByte.CUR4, (byte)SpellByte.LIT3, (byte)SpellByte.NUKE, (byte)SpellByte.ICE3, (byte)SpellByte.CUR4 },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Ink, (byte)EnemySkills.Ink, (byte)EnemySkills.Ink, (byte)EnemySkills.Tornado },
					},

					new AlternateFiends {
					Name = "HAFGUFA",
					SpriteSheet = FormationSpriteSheet.SentryWaterNagaChimera,
					FormationPattern = FormationPattern.Fiends,
					GFXOffset = FormationGFX.Sprite3,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.Ice,
					MonsterType = MonsterType.AQUATIC,
					FiendPool = FiendPool.FinalFantasy2,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.LIT2, (byte)SpellByte.DARK, (byte)SpellByte.LIT2, (byte)SpellByte.INVS, (byte)SpellByte.LIT2, (byte)SpellByte.DARK, (byte)SpellByte.LIT2, (byte)SpellByte.LOCK },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Ink, (byte)EnemySkills.Ink, (byte)EnemySkills.Ink, (byte)EnemySkills.Ink },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.LIT3, (byte)SpellByte.DARK, (byte)SpellByte.RUSE, (byte)SpellByte.NUKE, (byte)SpellByte.LIT3, (byte)SpellByte.XFER, (byte)SpellByte.LOCK, (byte)SpellByte.NUKE },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Ink, (byte)EnemySkills.Ink, (byte)EnemySkills.Ink, (byte)EnemySkills.Thunder },
					},

					new AlternateFiends {
					Name = "HURRAY",
					SpriteSheet = FormationSpriteSheet.AspLobsterBullTroll,
					FormationPattern = FormationPattern.Mixed,
					GFXOffset = FormationGFX.Sprite3,
					Palette1 = 0x3A,
					Palette2 = 0x3A,
					ElementalWeakness = SpellElement.Poison,
					MonsterType = MonsterType.REGENERATIVE,
					FiendPool = FiendPool.FinalFantasy4,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.FIRE, (byte)SpellByte.HOLD, (byte)SpellByte.MUTE, (byte)SpellByte.FIR2, (byte)SpellByte.MUTE, (byte)SpellByte.SLOW, (byte)SpellByte.SLEP, (byte)SpellByte.FIR2 },
					SkillChance1 = 0x00,
					Skills1 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.XXXX, (byte)SpellByte.BANE, (byte)SpellByte.BRAK, (byte)SpellByte.NUKE, (byte)SpellByte.XXXX, (byte)SpellByte.ZAP, (byte)SpellByte.BANE, (byte)SpellByte.SLO2 },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Poison_Stone, (byte)EnemySkills.Glance, (byte)EnemySkills.Crack, (byte)EnemySkills.Squint },
					},

					new AlternateFiends {
					Name = "KOPE",
					SpriteSheet = FormationSpriteSheet.ImageGeistWormEye,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite1,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.Poison,
					MonsterType = MonsterType.MAGICAL,
					FiendPool = FiendPool.FinalFantasy2,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.SABR, (byte)SpellByte.INVS, (byte)SpellByte.LOCK, (byte)SpellByte.DARK, (byte)SpellByte.SABR, (byte)SpellByte.INVS, (byte)SpellByte.LOCK, (byte)SpellByte.QAKE },
					SkillChance1 = 0x00,
					Skills1 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.SABR, (byte)SpellByte.RUSE, (byte)SpellByte.LOK2, (byte)SpellByte.NUKE, (byte)SpellByte.SABR, (byte)SpellByte.RUSE, (byte)SpellByte.LOK2, (byte)SpellByte.CUR4 },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Nuclear, (byte)EnemySkills.Blaze, (byte)EnemySkills.Inferno, (byte)EnemySkills.Blaze },
					},

					new AlternateFiends {
					Name = "LOTAN",
					SpriteSheet = FormationSpriteSheet.KrakenTiamat,
					FormationPattern = FormationPattern.Fiends,
					GFXOffset = FormationGFX.Sprite2,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.Lightning,
					MonsterType = MonsterType.AQUATIC,
					FiendPool = FiendPool.FinalFantasy2,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.FIR2, (byte)SpellByte.BANE, (byte)SpellByte.ICE2, (byte)SpellByte.DARK, (byte)SpellByte.FIR2, (byte)SpellByte.BRAK, (byte)SpellByte.ICE2, (byte)SpellByte.WALL },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Cremate, (byte)EnemySkills.Frost, (byte)EnemySkills.Cremate, (byte)EnemySkills.Thunder },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.FIR3, (byte)SpellByte.WALL, (byte)SpellByte.ICE3, (byte)SpellByte.BANE, (byte)SpellByte.FIR3, (byte)SpellByte.NUKE, (byte)SpellByte.ICE3, (byte)SpellByte.BRAK },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Nuclear, (byte)EnemySkills.Blizzard, (byte)EnemySkills.Nuclear, (byte)EnemySkills.Thunder },
					},

					new AlternateFiends {
					Name = "MASTVAMP",
					SpriteSheet = FormationSpriteSheet.VampGargoyleEarthDragon1,
					FormationPattern = FormationPattern.Small9,
					GFXOffset = FormationGFX.Sprite4,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.Fire,
					MonsterType = MonsterType.UNDEAD,
					FiendPool = FiendPool.FinalFantasy2,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.SLEP, (byte)SpellByte.LIT2, (byte)SpellByte.STUN, (byte)SpellByte.LIT2, (byte)SpellByte.MUTE, (byte)SpellByte.ICE2, (byte)SpellByte.ICE2, (byte)SpellByte.RUSE },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Dazzle, (byte)EnemySkills.Flash, (byte)EnemySkills.Stare, (byte)EnemySkills.Glare },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.WALL, (byte)SpellByte.LIT3, (byte)SpellByte.XXXX, (byte)SpellByte.XFER, (byte)SpellByte.ICE3, (byte)SpellByte.RUSE, (byte)SpellByte.LIT3, (byte)SpellByte.BANE },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Nuclear, (byte)EnemySkills.Toxic, (byte)EnemySkills.Glance, (byte)EnemySkills.Poison_Stone },
					},

					new AlternateFiends {
					Name = "MATOYA",
					SpriteSheet = FormationSpriteSheet.ImpWolfIguanaGiant,
					FormationPattern = FormationPattern.Small9,
					GFXOffset = FormationGFX.Sprite2,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.Status,
					MonsterType = MonsterType.MAGE,
					FiendPool = FiendPool.FinalFantasy2,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.ICE2, (byte)SpellByte.FIR2, (byte)SpellByte.INVS, (byte)SpellByte.LIT2, (byte)SpellByte.MUTE, (byte)SpellByte.STUN, (byte)SpellByte.ICE2, (byte)SpellByte.SLOW },
					SkillChance1 = 0x00,
					Skills1 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.NUKE, (byte)SpellByte.XXXX, (byte)SpellByte.XFER, (byte)SpellByte.ICE3, (byte)SpellByte.CUR4, (byte)SpellByte.ZAP, (byte)SpellByte.RUSE, (byte)SpellByte.BANE },
					SkillChance2 = 0x00,
					Skills2 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
					},

					new AlternateFiends {
					Name = "MOHAWK",
					SpriteSheet = FormationSpriteSheet.SahagPirateSharkBigEye,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite4,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.Time,
					MonsterType = MonsterType.WERE,
					FiendPool = FiendPool.FinalFantasy2,
					SpellChance1 = 0x00,
					Spells1 = new List<byte> { (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE, (byte)SpellByte.NONE },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Trance, (byte)EnemySkills.Glare, (byte)EnemySkills.Gaze, (byte)EnemySkills.Dazzle },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.HOLD, (byte)SpellByte.STOP, (byte)SpellByte.RUSE, (byte)SpellByte.FOG, (byte)SpellByte.NUKE, (byte)SpellByte.STOP, (byte)SpellByte.QAKE, (byte)SpellByte.SLP2 },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Poison_Stone, (byte)EnemySkills.Nuclear, (byte)EnemySkills.Squint, (byte)EnemySkills.Tornado },
					},

					new AlternateFiends {
					Name = "REVENANT",
					SpriteSheet = FormationSpriteSheet.KaryLich,
					FormationPattern = FormationPattern.Fiends,
					GFXOffset = FormationGFX.Sprite1,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.Fire,
					MonsterType = MonsterType.UNDEAD,
					FiendPool = FiendPool.FinalFantasy2,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.BANE, (byte)SpellByte.FOG, (byte)SpellByte.ICE2, (byte)SpellByte.RUSE, (byte)SpellByte.RUB, (byte)SpellByte.SLOW, (byte)SpellByte.LIT2, (byte)SpellByte.MUTE },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Frost, (byte)EnemySkills.Glance, (byte)EnemySkills.Trance, (byte)EnemySkills.Dazzle },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.NUKE, (byte)SpellByte.INVS, (byte)SpellByte.FAST, (byte)SpellByte.ICE3, (byte)SpellByte.SLO2, (byte)SpellByte.FOG, (byte)SpellByte.MUTE, (byte)SpellByte.ZAP },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Thunder, (byte)EnemySkills.Crack, (byte)EnemySkills.Poison_Damage, (byte)EnemySkills.Squint },
					},

					new AlternateFiends {
					Name = "R.MEDUSA",
					SpriteSheet = FormationSpriteSheet.MedusaCatmanPedeTiger,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite2,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.Ice,
					MonsterType = MonsterType.MAGICAL,
					FiendPool = FiendPool.FinalFantasy2,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.FIRE, (byte)SpellByte.STUN, (byte)SpellByte.FIR2, (byte)SpellByte.STUN, (byte)SpellByte.FIRE, (byte)SpellByte.STUN, (byte)SpellByte.FIR2, (byte)SpellByte.STUN },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Trance, (byte)EnemySkills.Blaze, (byte)EnemySkills.Trance, (byte)EnemySkills.Poison_Stone },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.FIR3, (byte)SpellByte.FIR3, (byte)SpellByte.FIR3, (byte)SpellByte.NUKE, (byte)SpellByte.FIR3, (byte)SpellByte.FIR3, (byte)SpellByte.FIR3, (byte)SpellByte.NUKE },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Blaze, (byte)EnemySkills.Poison_Stone, (byte)EnemySkills.Glance, (byte)EnemySkills.Inferno },
					},

					new AlternateFiends {
					Name = "SARDA",
					SpriteSheet = FormationSpriteSheet.SlimeSpiderManticorAnkylo,
					FormationPattern = FormationPattern.Large4,
					GFXOffset = FormationGFX.Sprite4,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.Earth,
					MonsterType = MonsterType.MAGE,
					FiendPool = FiendPool.FinalFantasy2,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.RUSE, (byte)SpellByte.FIR2, (byte)SpellByte.CUR2, (byte)SpellByte.SLOW, (byte)SpellByte.ICE2, (byte)SpellByte.LIT2, (byte)SpellByte.BRAK, (byte)SpellByte.STUN },
					SkillChance1 = 0x00,
					Skills1 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.XXXX, (byte)SpellByte.ICE3, (byte)SpellByte.BANE, (byte)SpellByte.NUKE, (byte)SpellByte.SLO2, (byte)SpellByte.RUSE, (byte)SpellByte.FOG, (byte)SpellByte.QAKE },
					SkillChance2 = 0x00,
					Skills2 = new List<byte> { (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None, (byte)EnemySkills.None },
					},

					new AlternateFiends {
					Name = "VAMAKALI",
					SpriteSheet = FormationSpriteSheet.KrakenTiamat,
					FormationPattern = FormationPattern.Fiends,
					GFXOffset = FormationGFX.Sprite2,
					Palette1 = 0x23,
					Palette2 = 0x25,
					ElementalWeakness = SpellElement.Ice,
					MonsterType = MonsterType.MAGICAL,
					FiendPool = FiendPool.FinalFantasy2,
					SpellChance1 = 0x40,
					Spells1 = new List<byte> { (byte)SpellByte.FIR2, (byte)SpellByte.STUN, (byte)SpellByte.FIR2, (byte)SpellByte.INVS, (byte)SpellByte.SLOW, (byte)SpellByte.FIR2, (byte)SpellByte.MUTE, (byte)SpellByte.RUB },
					SkillChance1 = 0x40,
					Skills1 = new List<byte> { (byte)EnemySkills.Cremate, (byte)EnemySkills.Heat, (byte)EnemySkills.Trance, (byte)EnemySkills.Stinger },
					SpellChance2 = 0x40,
					Spells2 = new List<byte> { (byte)SpellByte.RUSE, (byte)SpellByte.FIR3, (byte)SpellByte.FAST, (byte)SpellByte.SABR, (byte)SpellByte.BRAK, (byte)SpellByte.SLO2, (byte)SpellByte.FIR3, (byte)SpellByte.FIR3 },
					SkillChance2 = 0x40,
					Skills2 = new List<byte> { (byte)EnemySkills.Inferno, (byte)EnemySkills.Poison_Stone, (byte)EnemySkills.Crack, (byte)EnemySkills.Toxic },
					},

			};
			var alternateFiendsList = new List<AlternateFiends>
			{


			};
			if ((bool)flags.FinalFantasy2Fiends)

			{
				alternateFiendsList.AddRange(FF2AltFiendslist);
			}

			if ((bool)flags.FinalFantasy3Fiends)

			{
				alternateFiendsList.AddRange(FF3AltFiendslist);
			}

			if ((bool)flags.FinalFantasy4Fiends)

			{
				alternateFiendsList.AddRange(FF4AltFiendsList);
			}

			if ((bool)flags.FinalFantasy5Fiends)

			{
				alternateFiendsList.AddRange(FF5AltFiendsList);
			}

			if ((bool)flags.FinalFantasy1BonusFiends)
			{
				alternateFiendsList.AddRange(FF1BonusFiendsList);
			}

			if ((bool)!flags.FinalFantasy2Fiends && (bool)!flags.FinalFantasy3Fiends && (bool)!flags.FinalFantasy4Fiends && (bool)!flags.FinalFantasy5Fiends && (bool)!flags.FinalFantasy1BonusFiends)
			{
				alternateFiendsList.AddRange(FF1MasterFiendList);
			}

			var encountersData = new Encounters(this);

			EnemyInfo[] fiends = new EnemyInfo[8];
			EnemyScriptInfo[] fiendsScript = enemyScripts.GetList().Where(s => s.index >= FiendsScriptIndex && s.index <= (FiendsScriptIndex + 7)).ToArray();

			for (int i = 0; i < 8; i++)
			{
				fiends[i] = new EnemyInfo();
				fiends[i].decompressData(Get(EnemyOffset + (FiendsIndex + i) * EnemySize, EnemySize));
			}

			var assembly = System.Reflection.Assembly.GetExecutingAssembly();

			while (true)
			{
				// Shuffle alternate
				alternateFiendsList.Shuffle(rng);

				while (alternateFiendsList.Count >= 4)
				{
					var resourcePath1 = assembly.GetManifestResourceNames().First(str => str.EndsWith(alternateFiendsList[0].Name + ".png"));
					var resourcePath2 = assembly.GetManifestResourceNames().First(str => str.EndsWith(alternateFiendsList[1].Name + ".png"));
					using (Stream stream1 = assembly.GetManifestResourceStream(resourcePath1))
					{
						using (Stream stream2 = assembly.GetManifestResourceStream(resourcePath2))
						{
							//if (await SetLichKaryGraphics(stream1, stream2)) {
							if (SetLichKaryGraphics(stream1, stream2))
							{
								break;
							}
							// The graphics didn't fit, throw out the first element and try the next pair
							alternateFiendsList.RemoveAt(0);
						}
					}
				}
				if (alternateFiendsList.Count < 4)
				{
					// Couldn't find a pair where the graphics fit, reshuffle
					continue;
				}

				while (alternateFiendsList.Count >= 4)
				{
					var resourcePath1 = assembly.GetManifestResourceNames().First(str => str.EndsWith(alternateFiendsList[2].Name + ".png"));
					var resourcePath2 = assembly.GetManifestResourceNames().First(str => str.EndsWith(alternateFiendsList[3].Name + ".png"));
					using (Stream stream1 = assembly.GetManifestResourceStream(resourcePath1))
					{
						using (Stream stream2 = assembly.GetManifestResourceStream(resourcePath2))
						{
							//if (await SetKrakenTiamatGraphics(stream1, stream2)) {
							if (SetKrakenTiamatGraphics(stream1, stream2))
							{
								break;
							}
							alternateFiendsList.RemoveAt(2);
						}
					}
				}
				if (alternateFiendsList.Count < 4)
				{
					continue;
				}
				break;
			}

			// Replace the 4 fiends and their 2nd version at the same time
			for (int i = 0; i < 4; i++)
			{
				var scriptIndex = FiendsScriptIndex + (i * 2);

				fiends[(i * 2)].monster_type = (byte)alternateFiendsList[i].MonsterType;
				fiends[(i * 2) + 1].monster_type = (byte)alternateFiendsList[i].MonsterType;
				fiends[(i * 2)].elem_weakness = (byte)alternateFiendsList[i].ElementalWeakness;
				fiends[(i * 2) + 1].elem_weakness = 0x00;
				fiends[(i * 2)].elem_resist = (byte)(fiends[(i * 2)].elem_resist & ~(byte)alternateFiendsList[i].ElementalWeakness);
				fiends[(i * 2) + 1].elem_resist = (byte)(fiends[(i * 2) + 1].elem_resist & ~(byte)alternateFiendsList[i].ElementalWeakness);

				if (enemyScripts[scriptIndex].skill_chance == 0x00 || alternateFiendsList[i].SkillChance1 == 0x00)
					enemyScripts[scriptIndex].skill_chance = alternateFiendsList[i].SkillChance1;

				if (enemyScripts[scriptIndex + 1].skill_chance == 0x00 || alternateFiendsList[i].SkillChance2 == 0x00)
					enemyScripts[scriptIndex + 1].skill_chance = alternateFiendsList[i].SkillChance2;

				enemyScripts[scriptIndex].skill_list = alternateFiendsList[i].Skills1.ToArray();
				enemyScripts[scriptIndex + 1].skill_list = alternateFiendsList[i].Skills2.ToArray();

				if (enemyScripts[scriptIndex].spell_chance == 0x00 || alternateFiendsList[i].SpellChance1 == 0x00)
					enemyScripts[scriptIndex].spell_chance = alternateFiendsList[i].SpellChance1;

				if (enemyScripts[scriptIndex + 1].spell_chance == 0x00 || alternateFiendsList[i].SpellChance2 == 0x00)
					enemyScripts[scriptIndex + 1].spell_chance = alternateFiendsList[i].SpellChance2;

				enemyScripts.ImportVanillaSpellList(scriptIndex, alternateFiendsList[i].Spells1);
				enemyScripts.ImportVanillaSpellList(scriptIndex + 1, alternateFiendsList[i].Spells2);
			}

			encountersData.Write(this);

			for (int i = 0; i < 8; i++)
			{
				Put(EnemyOffset + (FiendsIndex + i) * EnemySize, fiends[i].compressData());
			}

			//Update fiends names, we stack Fiend1 and Fiend2's names to get more space for names
			var enemyText = ReadText(EnemyTextPointerOffset, EnemyTextPointerBase, EnemyCount);

			for (int i = 0; i < 4; i++)
			{
				enemyText[119 + (i * 2)] = alternateFiendsList[i].Name;
				enemyText[120 + (i * 2)] = "";
			}

			WriteText(enemyText, EnemyTextPointerOffset, EnemyTextPointerBase, EnemyTextOffset);

			// Rewrite point so Fiend2's name is Fiend1 name
			for (int i = 0; i < 4; i++)
			{
				var namepointer = Get(EnemyTextPointerOffset + (119 + (i * 2)) * 2, 2);
				Put(EnemyTextPointerOffset + (120 + (i * 2)) * 2, namepointer);
			}
		}
	}
}
