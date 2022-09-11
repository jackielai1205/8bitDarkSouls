using System;
using UnityEngine;

namespace Script.Model.Enemy.EnemyType
{
    public class LandEnemy : Enemy
    {
        public override void Attack(){}
        
        public override void WalkToCharacter()
        {
            if (GetMove())
            {
                return;
            }
            if (transform.localPosition.x > GetTarget().transform.position.x)
            {
                var localScale = transform.localScale;
                localScale = new Vector3(-Math.Abs(localScale.x), localScale.y, localScale.z);
                transform.localScale = localScale;
            }else if (transform.localPosition.x < GetTarget().transform.position.x)
            {
                var localScale = transform.localScale;
                localScale = new Vector3(Math.Abs(localScale.x), localScale.y, localScale.z);
                transform.localScale = localScale;
            }
            GetRigidbody2D().velocity = new Vector2 (transform.localScale.x, 0) * movementSpeed;
        }
        
        public override void StopMove()
        {
            GetRigidbody2D().constraints = RigidbodyConstraints2D.FreezeAll;
        }

        public override void Move()
        {
            GetRigidbody2D().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        
        public override void DeadState()
        {
            GetBoxCollider2D().enabled = false;
            GetRigidbody2D().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}