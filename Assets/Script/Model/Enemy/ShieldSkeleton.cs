using System;

namespace Script.Model.Enemy
{
    public class ShieldSkeleton : Skeleton
    {
        // public new void Update()
        // {
        //     switch (GetAnimator().GetInteger(GetAnimState()))
        //     {
        //         case 0:
        //             IdleState();
        //             break;
        //         case 1:
        //             ChaseCharacterState();
        //             break;
        //         case 2:
        //             AttackState();
        //             break;
        //         case 4:
        //             HitState();
        //             break;
        //         case 5:
        //             DeadState();
        //             break;
        //     }
        // }
        
        public override void StartAttack()
        {
            var random = new Random();
            var randomNumber = random.Next(0, 3);
            GetAnimator().SetInteger(GetAttackMethod(), randomNumber);
            GetAnimator().SetInteger(GetAnimState(), 2);
        }
    }
}