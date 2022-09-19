using Script.Model.Enemy.EnemyType;
using Script.Model.Projectile;
using UnityEngine;
using UnityEngine.UIElements;
using Random = System.Random;

namespace Script.Model.Enemy
{
    public class ArcherSkeleton : GroundEnemy
    {
        public Arrow arrow;
        public Transform bow;
        
        public override void StartAttack()
        {
            var attack = 0;
            if (GetTarget().transform.position.y < transform.position.y)
            {
                attack = 1;
            }
            GetAnimator().SetInteger(GetAttackMethod(), attack);
            GetAnimator().SetInteger(GetAnimState(), 2);
        }

        public void ShotArrow()
        {
            // Quaternion bowRotation = bow.rotation;
            // if (gameObject.transform.localScale.x < 0)
            // {
            //     Instantiate(arrow, bow.transform.position, new Quaternion(bowRotation.x, bowRotation.y, bowRotation.z - 180, bowRotation.w));    
            // }
            // else if(gameObject.transform.localScale.x > 0)
            // {
            //     Instantiate(arrow, bow.transform.position, new Quaternion(bowRotation.x, bowRotation.y, bowRotation.z, bowRotation.w));
            // }
            var arr = Instantiate(arrow, bow.transform.position, arrow.transform.rotation);
            arr.SetTarget(GetTarget().transform);
        }
    }
}