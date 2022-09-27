using Script.Model.Enemy.EnemyType;
using UnityEngine;
using Random = System.Random;

namespace Script.Model.Enemy
{
    public class SwordSkeleton : GroundEnemy
    {
        //Random available Animation and change the animstate
        public override void StartAttack()
        {
            var random = new Random();
            var randomNumber = random.Next(0, 2);
            GetAnimator().SetInteger(GetAttackMethod(), randomNumber);
            GetAnimator().SetInteger(GetAnimState(), 2);
        }
    }
}
