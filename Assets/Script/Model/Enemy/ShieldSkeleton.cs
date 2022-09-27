using System;
using Script.Model.Enemy.EnemyType;

namespace Script.Model.Enemy
{
    public class ShieldSkeleton : GroundEnemy
    {
        //Random available Animation and change the animstate
        public override void StartAttack()
        {
            var random = new Random();
            var randomNumber = random.Next(0, 3);
            GetAnimator().SetInteger(GetAttackMethod(), randomNumber);
            GetAnimator().SetInteger(GetAnimState(), 2);
        }
    }
}