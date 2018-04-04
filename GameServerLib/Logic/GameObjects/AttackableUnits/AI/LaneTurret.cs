﻿using LeagueSandbox.GameServer.Logic.Enet;
using System.Collections.Generic;
using LeagueSandbox.GameServer.Logic.GameObjects.AttackableUnits;
using LeagueSandbox.GameServer.Logic.GameObjects.Stats;

namespace LeagueSandbox.GameServer.Logic.GameObjects
{
    public enum TurretType
    {
        OuterTurret,
        InnerTurret,
        InhibitorTurret,
        NexusTurret,
        FountainTurret
    }

    public class LaneTurret : BaseTurret
    {
        public TurretType Type { get; private set; }
        private bool _turretHPUpdated;

        public LaneTurret(
            string name,
            float x = 0,
            float y = 0,
            TeamId team = TeamId.TEAM_BLUE,
            TurretType type = TurretType.OuterTurret,
            int[] items = null,
            uint netId = 0
        ) : base(name, "", x, y, team, netId)
        {
            Type = type;
            if (items != null)
            {
                foreach (var item in items)
                {
                    var itemTemplate = _itemManager.SafeGetItemType(item);
                    if (itemTemplate == null)
                    {
                        continue;
                    }
                    Inventory.AddItem(itemTemplate);
                }
            }

            BuildTurret(type);
        }

        public int GetEnemyChampionsCount()
        {
            var blueTeam = new List<Champion>();
            var purpTeam = new List<Champion>();
            foreach (var player in _game.ObjectManager.GetAllChampionsFromTeam(TeamId.TEAM_BLUE))
            {
                blueTeam.Add(player);
            }

            foreach (var player in _game.ObjectManager.GetAllChampionsFromTeam(TeamId.TEAM_PURPLE))
            {
                purpTeam.Add(player);
            }
            if (Team == TeamId.TEAM_BLUE)
                return purpTeam.Count;

            return blueTeam.Count;
        }

        public void BuildTurret(TurretType type)
        {
            switch (type)
            {
                case TurretType.InnerTurret:
                    globalGold = 100;

                    HealthPoints = new Health(1300);
                    AttackRange = new Stat(905, 0);
                    AttackSpeed = new AttackSpeed(0);
                    Armor = new Stat(60);
                    MagicResist = new Stat(100);
                    AttackDamage = new Stat(170);
                    IsTargetableToTeam = IsTargetableToTeamFlags.NonTargetableEnemy;
                    IsInvulnerable = true;

                    AutoAttackDelay = 4.95f / 30.0f;
                    AutoAttackProjectileSpeed = 1200.0f;
                    break;
                case TurretType.OuterTurret:
                    globalGold = 125;

                    HealthPoints = new Health(1300);
                    AttackDamage = new Stat(100);
                    AttackRange = new Stat(905, 0);
                    AttackSpeed = new AttackSpeed(-0.205f);
                    Armor = new Stat(60);
                    MagicResist = new Stat(100);
                    AttackDamage = new Stat(152);

                    AutoAttackDelay = 4.95f / 30.0f;
                    AutoAttackProjectileSpeed = 1200.0f;
                    break;
                case TurretType.InhibitorTurret:
                    globalGold = 150;
                    globalExp = 500;

                    HealthPoints = new Health(1300);
                    HealthRegeneration = new Stat(5, 0);
                    ArmorPenetration.PercentBonus = 0.825f;
                    AttackRange = new Stat(905, 0);
                    AttackSpeed = new AttackSpeed(-0.205f);
                    Armor = new Stat(67);
                    MagicResist = new Stat(100);
                    AttackDamage = new Stat(190);
                    IsTargetableToTeam = IsTargetableToTeamFlags.NonTargetableEnemy;
                    IsInvulnerable = true;

                    AutoAttackDelay = 4.95f / 30.0f;
                    AutoAttackProjectileSpeed = 1200.0f;
                    break;
                case TurretType.NexusTurret:
                    globalGold = 50;

                    HealthPoints = new Health(1300);
                    HealthRegeneration = new Stat(5, 0);
                    ArmorPenetration.PercentBonus = 0.825f;
                    AttackRange = new Stat(905, 0);
                    AttackSpeed = new AttackSpeed(-0.205f);
                    Armor = new Stat(65);
                    MagicResist = new Stat(100);
                    AttackDamage = new Stat(180);
                    IsTargetableToTeam = IsTargetableToTeamFlags.NonTargetableEnemy;

                    AutoAttackDelay = 4.95f / 30.0f;
                    AutoAttackProjectileSpeed = 1200.0f;
                    break;
                case TurretType.FountainTurret:
                    AttackSpeed = new AttackSpeed(-0.610f);
                    HealthPoints = new Health(9999);
                    AttackDamage = new Stat(999, 0);
                    AttackRange = new Stat(1250, 0);
                    SetTargetableToTeam(TeamId.TEAM_BLUE, false);
                    SetTargetableToTeam(TeamId.TEAM_PURPLE, false);
                    IsInvulnerable = true;

                    AutoAttackDelay = 1.0f / 30.0f;
                    AutoAttackProjectileSpeed = 2000.0f;
                    break;
                default:
                    HealthPoints = new Health(2000);
                    AttackDamage = new Stat(100, 0);
                    AttackRange = new Stat(905, 0);
                    AttackSpeed = new AttackSpeed(-0.205f);
                    Armor.PercentBonus = 0.5f;
                    MagicResist.PercentBonus = 0.5f;

                    AutoAttackDelay = 4.95f / 30.0f;
                    AutoAttackProjectileSpeed = 1200.0f;

                    break;
            }
        }

        public override void Update(float diff)
        {
            //Update Stats if it's time
            switch (Type)
            {
                case TurretType.OuterTurret:
                    if (!_turretHPUpdated)
                    {
                        HealthPoints = new Health(1300)
                        {
                            BaseBonus = GetEnemyChampionsCount() * 250
                        };
                    }

                    if (_game.GameTime > 40000 - (GetEnemyChampionsCount() * 2000) &&
                        _game.GameTime < 400000 - (GetEnemyChampionsCount() * 2000))
                    {
                        MagicResist.BaseBonus = (_game.GameTime - 30000) / 60000;
                        AttackDamage.BaseBonus = ((_game.GameTime - 30000) / 60000) * 4;
                    }
                    else if (_game.GameTime >= 30000)
                    {
                        MagicResist.BaseBonus = 7;
                        AttackDamage.BaseBonus = 28;
                    }
                    break;
                case TurretType.InnerTurret:
                    if (!_turretHPUpdated)
                    {
                        HealthPoints = new Health(1300)
                        {
                            BaseBonus = GetEnemyChampionsCount() * 250
                        };
                    }

                    if (_game.GameTime > 480000 && _game.GameTime < 1620000)
                    {
                        Armor.BaseBonus = (_game.GameTime - 480000) / 60000;
                        MagicResist.BaseBonus = (_game.GameTime - 480000) / 60000;
                        AttackDamage.BaseBonus = ((_game.GameTime - 480000) / 60000) * 4;
                    }
                    else if (_game.GameTime >= 480000)
                    {
                        Armor.BaseBonus = 80;
                        MagicResist.BaseBonus = 120;
                        AttackDamage.BaseBonus = 250;
                    }
                    break;
                case TurretType.InhibitorTurret:
                    if (!_turretHPUpdated)
                    {
                        HealthPoints = new Health(1300)
                        {
                            BaseBonus = GetEnemyChampionsCount() * 250
                        };
                    }

                    if (_game.GameTime > 480000 && _game.GameTime < 2220000)
                    {
                        Armor.BaseBonus = (_game.GameTime - 480000) / 60000;
                        MagicResist.BaseBonus = (_game.GameTime - 480000) / 60000;
                        AttackDamage.BaseBonus = ((_game.GameTime - 480000) / 60000) * 4;
                    }
                    else if (_game.GameTime >= 480000)
                    {
                        Armor.BaseBonus = 97;
                        MagicResist.BaseBonus = 130;
                        AttackDamage.BaseBonus = 250;
                    }
                    break;
                case TurretType.NexusTurret:
                    if (!_turretHPUpdated)
                    {
                        HealthPoints = new Health(1300)
                        {
                            BaseBonus = GetEnemyChampionsCount() * 125
                        };
                    }

                    if (_game.GameTime > 480000 && _game.GameTime < 2220000)
                    {
                        Armor.BaseBonus = (_game.GameTime - 480000) / 60000;
                        MagicResist.BaseBonus = (_game.GameTime - 480000) / 60000;
                        AttackDamage.BaseBonus = ((_game.GameTime - 480000) / 60000) * 4;
                    }
                    else if (_game.GameTime >= 480000)
                    {
                        Armor.BaseBonus = 95;
                        MagicResist.BaseBonus = 130;
                        AttackDamage.BaseBonus = 300;
                    }
                    break;
            }
            _turretHPUpdated = true;
            base.Update(diff);
        }

        public override void RefreshWaypoints()
        {
        }

        public override void AutoAttackHit(AttackableUnit target)
        {
            if (Type == TurretType.FountainTurret)
            {
                target.TakeDamage(this, 1000, DamageType.DAMAGE_TYPE_TRUE, DamageSource.DAMAGE_SOURCE_PASSIVE, false);
            }
            else
            {
                base.AutoAttackHit(target);
            }
        }
    }
}
