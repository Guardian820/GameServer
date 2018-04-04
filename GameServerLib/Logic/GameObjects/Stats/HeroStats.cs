using System;
using LeagueSandbox.GameServer.Logic.Content;

namespace LeagueSandbox.GameServer.Logic.GameObjects.Stats
{
    public class HeroStats
    {
        private Champion _owner;

        public float Gold { get; set; } // mGold (1-1)
        public float TotalGold { get; set; } // mGoldTotal (1-2)
        public uint SpellEnabledBitFieldLower1 { get; set; } // mReplicatedSpellCanCastBitsLower1 (1-3)
        public uint SpellEnabledBitFieldUpper1 { get; set; } // mReplicatedSpellCanCastBitsUpper1 (1-4)
        public uint SpellEnabledBitFieldLower2 { get; set; } = 0x7C00; // mReplicatedSpellCanCastBitsLower2 (1-5)
        public uint SpellEnabledBitFieldUpper2 { get; set; } // mReplicatedSpellCanCastBitsUpper2 (1-6)
        public uint EvolvePoints { get; set; } // mEvolvePoints (1-7)
        public uint EvolveFlags { get; set; } // mEvolveFlag (1-8)
        public float[] ManaCost { get; set; } = new float[4];
        // ManaCost_0 (1-9)
        // ManaCost_1 (1-10)
        // ManaCost_2 (1-11)
        // ManaCost_3 (1-12)
        public float[] ManaCostEx { get; set; } = new float[16];
        // ManaCostEx_0 (1-13)
        // ManaCostEx_1 (1-14)
        // ManaCostEx_2 (1-15)
        // ManaCostEx_3 (1-16)
        // ManaCostEx_4 (1-17)
        // ManaCostEx_5 (1-18)
        // ManaCostEx_6 (1-19)
        // ManaCostEx_7 (1-20)
        // ManaCostEx_8 (1-21)
        // ManaCostEx_9 (1-22)
        // ManaCostEx_10 (1-23)
        // ManaCostEx_11 (1-24)
        // ManaCostEx_12 (1-25)
        // ManaCostEx_13 (1-26)
        // ManaCostEx_14 (1-27)
        // ManaCostEx_15 (1-28)
        public ActionState ActionState { get; set; } // ActionState (2-1)
        public bool IsMagicImmune => _owner.IsMagicImmune; // MagicImmune (2-2)
        public bool IsInvulnerable => _owner.IsInvulnerable; // IsInvulnerable (2-3)
        public bool IsPhysicalImmune => _owner.IsPhysicalImmune; // IsPhysicalImmune (2-4)
        public bool IsLifestealImmune { get; set; } // IsLifestealImmune (2-5)
        public float BaseAttackDamage  => _owner.AttackDamage.BaseValue; // mBaseAttackDamage (2-6)
        public float BaseAbilityPower => _owner.AbilityPower.BaseValue; // mBaseAbilityDamage (2-7)
        public float TotalDodgeChance => _owner.DodgeChance.Total; // mDodge (2-8)
        public float TotalCriticalChance => _owner.CriticalChance.Total; // mCrit (2-9)
        public float TotalArmor => _owner.Armor.Total; // mArmor (2-10)
        public float SpellBlock => _owner.MagicResist.Total; // mSpellBlock (2-11)
        public float HealthRegenPer5 => _owner.HealthRegeneration.Total; // mHPRegenDate (2-12)
        public float ManaRegenPer5 => _owner.ManaRegeneration.Total; // mPARRegenRate (2-13)
        public float TotalAttackRange => _owner.AttackRange.Total; // mAttackRange (2-14)
        public float FlatAttackDamageMod => _owner.AttackDamage.FlatBonus; // mFlatPhysicalDamageMod (2-15)
        public float PercentAttackDamageMod => _owner.AttackDamage.PercentBonus; // mPercentPhysicalDamageMod (2-16)
        public float FlatMagicalDamageMod => _owner.AbilityPower.FlatBonus; // mFlatMagicDamageMod (2-17)
        public float FlatMagicalReduction => _owner.MagicResist.FlatBonus; // mFlatMagicReduction (2-18)
        public float PercentMagicalReduction => _owner.MagicResist.PercentBonus; // mPercentMagicReduction (2-19)
        public float AttackSpeedMod => _owner.AttackSpeed.PercentBonus; // mAttackSpeedMod (2-20)
        public float FlatAttackRangeMod => _owner.AttackRange.FlatBonus; // mFlatCastRangeMod (2-21)
        public float PercentCdrMod => _owner.CooldownReduction.PercentBonus; // mPercentCooldownMod (2-22)
        public float PassiveCooldownEndTime { get; set; } // mPercentCooldownMod (2-23)
        public float PassiveCooldownTotalTime { get; set; } // mPassiveCooldownTotalTime (2-24)
        public float FlatArmorPenetration => _owner.ArmorPenetration.FlatBonus; // mFlatArmorPenetration (2-25)
        public float PercentArmorPenetration => _owner.ArmorPenetration.PercentBaseBonus; // mPercentArmorPenetration (2-26)
        public float FlatMagicPenetration => _owner.MagicPenetration.FlatBonus; // mFlatMagicPenetration (2-27)
        public float PercentMagicPenetration => _owner.MagicPenetration.PercentBaseBonus; // mPercentMagicPenetration (2-28)
        public float PercentLifeStealMod => _owner.LifeSteal.PercentBonus; // mPercentLifeStealMod (2-29)
        public float PercentSpellVampMod => _owner.SpellVamp.PercentBonus; // mPercentSpellVampMod (2-30)
        public float PercentTenacity => _owner.Tenacity.PercentBonus; // mPercentCCReduction (2-31)
        public float PercentBonusArmorPenetration => _owner.ArmorPenetration.PercentBonus; // mPercentBonusArmorPenetration (4-1)
        public float PercentBonusMagicPenetration => _owner.MagicPenetration.PercentBonus; // mPercentBonusMagicPenetration (4-2)
        public float BaseHealthRegenRate => _owner.HealthRegeneration.BaseValue; // mBaseHPRegenRate (4-3)
        public float BaseManaRegenRate => _owner.ManaRegeneration.BaseValue; // mBasePARRegenRate (4-4)
        public float CurrentHealth => _owner.HealthPoints.Current; // mHP (8-1)
        public float CurrentMana => _owner.ManaPoints.Current; // mMP (8-2)
        public float MaxHealth => _owner.HealthPoints.Total; // mMaxHP (8-3)
        public float MaxMana => _owner.ManaPoints.Total; // mMaxMP (8-4)
        public float Experience { get; set; } // mExp (8-5)
        public float LifeTime { get; set; } // mLifetime (8-6)
        public float MaxLifeTime {get; set; } // mMaxLifetime (8-7)
        public float LifeTimeTicks { get; set; } // mLifetimeTicks (8-8)
        public float FlatVisionRangeMod => _owner.VisionRange.FlatBonus; // mFlatBubbleRadiusMod (8-9)
        public float PercentVisionRangeMod => _owner.VisionRange.PercentBonus; // mPercentBubbleRadiusMod (8-10)
        public float TotalMovementSpeed => _owner.MovementSpeed.Total; // mMoveSpeed (8-11)
        public float TotalSize => _owner.Size.Total; // mCrit (8-12) nice c+p rito :kappa:
        public float PathfindingRadiusMod => _owner.PathfindingRadius.FlatBonus; // mPathfindingRadiusMod (8-13)
        public uint Level { get; set; } // mLevelRef (8-14)
        public uint NumberOfNeutralMinionsKilled { get; set; } // mNumNeutralMinionsKilled (8-15)
        public bool IsTargetable => _owner.IsTargetable; // mIsTargetable (8-16)
        public IsTargetableToTeamFlags IsTargetableToTeamFlags => _owner.IsTargetableToTeam; // mIsTargetableToTeamFlags (8-17)

        public float HealthPerLevel { get; set; }
        public float ManaPerLevel { get; set; }
        public float AttackDamagePerLevel { get; set; }
        public float ArmorPerLevel { get; set; }
        public float MagicResistPerLevel { get; set; }
        public float HealthRegenerationPerLevel { get; set; }
        public float ManaRegenerationPerLevel { get; set; }
        public float AttackSpeedPerLevel { get; set; }

        public float PercentSpellCostReduction { get; set; } = 0;

        public float GetBaseManaCost(byte slot)
        {
            if (slot < 4)
            {
                return ManaCost[slot];
            }

            if (slot > 44 && slot < 61)
            {
                return ManaCostEx[slot - 45];
            }

            return 0;
        }

        public void SetBaseManaCost(byte slot, float val)
        {
            if (slot < 4)
            {
                ManaCost[slot] = val;
            }

            if (slot > 44 && slot < 61)
            {
                ManaCostEx[slot - 45] = val;
            }
        }

        public bool GetActionState(ActionState state)
        {
            return ActionState.HasFlag(state);
        }

        public void SetActionState(ActionState state, bool value)
        {
            if (value)
            {
                ActionState |= state;
            }
            else
            {
                ActionState &= ~state;
            }
        }

        public bool GetSpellEnabled(byte slot)
        {
            return (SpellEnabledBitFieldLower1 & (1 << slot)) != 0;
        }

        public void SetSpellEnabled(byte slot, bool enabled)
        {
            if (enabled)
            {
                SpellEnabledBitFieldLower1 |= (uint)(1 << slot);
            }
            else
            {
                SpellEnabledBitFieldLower1 &= (uint)~(1 << slot);
            }
        }

        public bool GetSummonerSpellEnabled(byte slot)
        {
            return (SpellEnabledBitFieldLower2 & (1 << slot)) != 0;
        }

        public void SetSummonerSpellEnabled(byte slot, bool enabled)
        {
            if (enabled)
            {
                SpellEnabledBitFieldLower2 |= (uint)(16 << slot);
            }
            else
            {
                SpellEnabledBitFieldLower2 &= (uint)~(16 << slot);
            }
        }

        public HeroStats(Champion owner, CharData charData)
        {
            _owner = owner;
            ActionState = ActionState.CanAttack | ActionState.CanCast | ActionState.CanMove;
            _owner.MovementSpeed = new Stat(charData.MoveSpeed, 0);
            _owner.AttackSpeed = new AttackSpeed(charData.AttackDelayOffsetPercent);
            _owner.AttackRange = new Stat(charData.AttackRange, 0);
            _owner.AttackDamage = new Stat(charData.BaseDamage);
            _owner.Armor = new Stat(charData.Armor);
            _owner.MagicResist = new Stat(charData.SpellBlock);
            _owner.HealthRegeneration = new Stat(charData.BaseStaticHPRegen, 0);
            _owner.ManaRegeneration = new Stat(charData.BaseStaticMPRegen); // no min limit as this may not be mana but sth that drains
            HealthPerLevel = charData.HPPerLevel;
            ManaPerLevel = charData.MPPerLevel;
            AttackDamagePerLevel = charData.DamagePerLevel;
            ArmorPerLevel = charData.ArmorPerLevel;
            MagicResistPerLevel = charData.SpellBlockPerLevel;
            HealthRegenerationPerLevel = charData.HPRegenPerLevel;
            ManaRegenerationPerLevel = charData.MPRegenPerLevel;
            AttackSpeedPerLevel = charData.AttackSpeedPerLevel;
        }

        public void AddModifier(ChampionStatMod item)
        {
            _owner.HealthPoints.ApplyModifier(item.HealthPoints);
            _owner.ManaPoints.ApplyModifier(item.ManaPoints);
            _owner.MovementSpeed.ApplyModifier(item.MovementSpeed);
            _owner.AttackSpeed.ApplyModifier(item.AttackSpeed);
            _owner.AttackRange.ApplyModifier(item.AttackRange);
            _owner.CriticalChance.ApplyModifier(item.CriticalChance);
            _owner.CriticalDamage.ApplyModifier(item.CriticalDamage);
            _owner.AttackDamage.ApplyModifier(item.AttackDamage);
            _owner.Armor.ApplyModifier(item.Armor);
            _owner.ArmorPenetration.ApplyModifier(item.ArmorPenetration);
            _owner.MagicResist.ApplyModifier(item.ArmorPenetration);
            _owner.MagicPenetration.ApplyModifier(item.MagicPenetration);
            _owner.LifeSteal.ApplyModifier(item.LifeSteal);
            _owner.SpellVamp.ApplyModifier(item.SpellVamp);
            _owner.AbilityPower.ApplyModifier(item.AbilityPower);
            _owner.HealthRegeneration.ApplyModifier(item.HealthRegeneration);
            _owner.ManaRegeneration.ApplyModifier(item.ManaRegeneration);
            _owner.CooldownReduction.ApplyModifier(item.CooldownReduction);
            _owner.Tenacity.ApplyModifier(item.Tenacity);
        }

        public void RemoveModifier(ChampionStatMod item)
        {
            _owner.HealthPoints.RemoveModifier(item.HealthPoints);
            _owner.ManaPoints.RemoveModifier(item.ManaPoints);
            _owner.MovementSpeed.RemoveModifier(item.MovementSpeed);
            _owner.AttackSpeed.RemoveModifier(item.AttackSpeed);
            _owner.AttackRange.RemoveModifier(item.AttackRange);
            _owner.CriticalChance.RemoveModifier(item.CriticalChance);
            _owner.CriticalDamage.RemoveModifier(item.CriticalDamage);
            _owner.AttackDamage.RemoveModifier(item.AttackDamage);
            _owner.Armor.RemoveModifier(item.Armor);
            _owner.ArmorPenetration.RemoveModifier(item.ArmorPenetration);
            _owner.MagicResist.RemoveModifier(item.ArmorPenetration);
            _owner.MagicPenetration.RemoveModifier(item.MagicPenetration);
            _owner.LifeSteal.RemoveModifier(item.LifeSteal);
            _owner.SpellVamp.RemoveModifier(item.SpellVamp);
            _owner.AbilityPower.RemoveModifier(item.AbilityPower);
            _owner.HealthRegeneration.RemoveModifier(item.HealthRegeneration);
            _owner.ManaRegeneration.RemoveModifier(item.ManaRegeneration);
            _owner.CooldownReduction.RemoveModifier(item.CooldownReduction);
            _owner.Tenacity.RemoveModifier(item.Tenacity);
        }
    }

    [Flags]
    public enum ActionState : uint
    {
        CanAttack = 1 << 0,
        CanCast = 1 << 1,
        CanMove = 1 << 2,
        Stealthed = 1 << 3,
        RevealSpecificUnit = 1 << 4,
        Taunted = 1 << 5,
        Feared = 1 << 6,
        Suppressed = 1 << 7,
        Sleeping = 1 << 8,
        NearSighted = 1 << 9,
        Ghosted = 1 << 10,
        GhostProof = 1 << 11,
        Charmed = 1 << 12,
        NoRender = 1 << 13,
        ForceRenderParticles = 1 << 14,
        DodgePiercing = 1 << 15,
        DisableAmbientGold = 1 << 16,
        BrushVisibilityFake = 1 << 17,
        Unknown = 1 << 23 // set to 1 by default
    }

    [Flags]
    public enum IsTargetableToTeamFlags : uint
    {
        NonTargetableAlly = 1 << 23,
        NonTargetableEnemy = 1 << 24,
        TargetableToAll = 1 << 22
    }
}
