using System;
using System.Collections;
using Script.Model.Enemy.Skill;
using UnityEngine;

namespace Script.Model.Enemy.EnemyType
{
    public class Boss : FlyEnemy
    {
        public AudioClip bossTheme;
        public string bossName;
        public Skill.Skill[] skills;
        public Transform weapon;
        private bool themeIsPlaying = false;

        public void PlayBossTheme()
        {
            if (!themeIsPlaying)
            {
                source.clip = bossTheme;
                source.Play();
                themeIsPlaying = true;
            }
        }
        
        public override void FindNextState()
        {
            if (GetIsDead())
            {
                Dead();
            }else if (GetInRange())
            {
                StartAttack();
            }
            else
            {
                StartChaseState();
            }
        }
    }
}
