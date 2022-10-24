using System;
using UnityEngine;

namespace Script.Model.Enemy.EnemyType
{
    public class Wizard : Boss
    {
        public EnemyHealthBar healthBar;
        //Add jump state for ground enemy
        public override void Update()
        {
            switch (GetAnimator().GetInteger(GetAnimState()))
            {
                case 0:
                    IdleState();
                    break;
                case 1:
                    healthBar.gameObject.SetActive(true);
                    PlayBossTheme();
                    ChaseCharacterState();
                    Cast();
                    break;
                case 2:
                    AttackState();
                    Cast();
                    break;
                case 4:
                    HitState();
                    break;
                case 5:
                    DeadState();
                    healthBar.gameObject.SetActive(false);
                    break;
            }
        }
        
        public override void StartAttack()
        {
            GetAnimator().SetInteger(GetAttackMethod(), 0);
            GetAnimator().SetInteger(GetAnimState(), 2);
        }

        public void Cast()
        {
            foreach (Skill.Skill skill in skills)
            {
                skill.Perform(weapon, GetTarget().transform, source);
            }
        }
        
        public override void DeadState()
        {
            // GetRigidbody2D().gravityScale = 1;
            // GetCollider2D().enabled = true;
        }
    }
}