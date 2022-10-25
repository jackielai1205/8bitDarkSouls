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
                case (int)State.Idle:
                    IdleState();
                    break;
                case (int)State.Chase:
                    ChaseCharacterState();
                    break;
                case (int)State.Attack:
                    AttackState();
                    break;
                case (int)State.Hit:
                    HitState();
                    break;
                case (int)State.Dead:
                    DeadState();
                    break;
                case (int)State.Block:
                    BlockState();
                    break;
            }
        }

        public void StartBlock()
        {
            GetAnimator().SetInteger(GetAnimState(), (int)State.Block);
        }

        public void BlockState()
        {
            FindNextState();
        }
        
        public override void TakeDamage(int damage)
        {
            if (GetAnimator().GetInteger(GetAnimState()) == (int)State.Hit || GetAnimator().GetInteger(GetAnimState()) == (int)State.Chase || _canBlock)
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