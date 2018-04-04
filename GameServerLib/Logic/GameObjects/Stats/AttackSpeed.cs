﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueSandbox.GameServer.Logic.GameObjects.Stats
{
    public sealed class AttackSpeed : Stat
    {
        public float AttackDelay { get; private set; }

        public override float Total => BaseValue * PercentBaseBonus * BaseBonus;

        public AttackSpeed(float attackDelay) : base(0.625f, 0.2f, 2.5f)
        {
            AttackDelay = attackDelay;
            BaseValue = 0.625f / (1 + AttackDelay);
            PercentBaseBonus = 1;
            PercentBonus = 1;
        }
    }
}
