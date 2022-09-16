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
            var random = new Random();
            var randomNumber = random.Next(0, 2);
            GetAnimator().SetInteger(GetAttackMethod(), randomNumber);
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
            Instantiate(arrow, bow.position,
                    Quaternion.FromToRotation(bow.position, GetTarget().transform.position));
        }
    }
}