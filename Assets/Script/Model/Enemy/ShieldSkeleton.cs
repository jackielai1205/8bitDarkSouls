using Script.Model.Enemy.EnemyType;
using UnityEngine;
using Random = System.Random;

namespace Script.Model.Enemy
{
    public class ShieldSkeleton : GroundEnemy
    {
        private bool _canBlock = false;
        //Random available Animation and change the animstate
        public override void StartAttack()
        {
            var random = new Random();
            var randomNumber = random.Next(0, 2);
            GetAnimator().SetInteger(GetAttackMethod(), randomNumber);
            GetAnimator().SetInteger(GetAnimState(), 2);
        }
        
        public virtual void Update()
        {
            switch (GetAnimator().GetInteger(GetAnimState()))
            {
                case 0:
                    IdleState();
                    break;
                case 1:
                    ChaseCharacterState();
                    break;
                case 2:
                    AttackState();
                    break;
                case 4:
                    HitState();
                    break;
                case 5:
                    DeadState();
                    break;
                case 6:
                    BlockState();
                    break;
            }
        }

        public void StartBlock()
        {
            GetAnimator().SetInteger(GetAnimState(), 6);
        }

        public void BlockState()
        {
            FindNextState();
        }
        
        public override void TakeDamage(int damage)
        {
            if (GetAnimator().GetInteger(GetAnimState()) == 0 || GetAnimator().GetInteger(GetAnimState()) == 1 || _canBlock)
            {
                print("Block");
                StartBlock();
                GetRigidbody2D().constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            else
            {
                if (GetIsDead())
                {
                    return;
                }
                Hurt();
                SetTakeDamagePower(damage);
            }
        }

        public void Block()
        {
            _canBlock = true;
        }

        public void CannotBlock()
        {
            _canBlock = false;
        }
    }
}