
using Script.Model.Enemy.EnemyType;
using UnityEngine;
using Random = System.Random;

namespace Script.Model.Enemy
{
    public class Alien : GroundEnemy
    {
        private static readonly int AnimState = Animator.StringToHash("AnimState");
        public override void Attack()
        {
            var random = new Random();
            var randomNumber = random.Next(2, 3);
            GetComponent<Animator>().SetInteger(AnimState, randomNumber);
        }

        public override void StartAttack()
        {
            var random = new Random();
            var randomNumber = random.Next(0, 3);
            GetAnimator().SetInteger(GetAttackMethod(), randomNumber);
            GetAnimator().SetInteger(AnimState, 2);
        }
    }
}

