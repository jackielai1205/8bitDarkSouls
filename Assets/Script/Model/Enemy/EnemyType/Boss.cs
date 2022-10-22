using System;
using Script.Model.Enemy.Skill;
using UnityEngine;

namespace Script.Model.Enemy.EnemyType
{
    public class Boss : FlyEnemy
    {
        public string bossName;
        public Skill.Skill[] skills;
        public Transform weapon;
    }
}
