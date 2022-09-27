using System;
using UnityEngine;

namespace Script.Model.Enemy.EnemyType
{
    public class FlyEnemy : Enemy
    {
        //Fastest path to player
        public override void WalkToCharacter()
        {
            int flyDirection;
            if (GetStopMove())
            {
                return;
            }
            if (GetTransform().localPosition.x > GetTarget().transform.position.x)
            {
                var localScale = transform.localScale;
                localScale = new Vector3(-Math.Abs(localScale.x), localScale.y, localScale.z);
                transform.localScale = localScale;
            }else if (GetTransform().localPosition.x < GetTarget().transform.position.x)
            {
                var localScale = transform.localScale;
                localScale = new Vector3(Math.Abs(localScale.x), localScale.y, localScale.z);
                transform.localScale = localScale;
            }

            if (GetTransform().localPosition.y > GetTarget().transform.position.y)
            {
                flyDirection = -1;
            }
            else if(GetTarget().transform.position.y > GetTransform().localPosition.y)
            {
                flyDirection = 1;
            }
            else
            {
                flyDirection = 0;
            }
            GetRigidbody2D().velocity = new Vector2 (GetTransform().localScale.x, flyDirection) * movementSpeed;
        }
        
        //Fly enemy will fall down when dead
        public override void DeadState()
        {
            GetRigidbody2D().gravityScale = 1;
            GetCollider2D().enabled = true;
        }

        //Freeze position and rotation when enemy attacking
        public override void StopMove()
        {
            GetRigidbody2D().constraints = RigidbodyConstraints2D.FreezeAll;
        }

        //Release enemy movement except rotation
        public override void Move()
        {
            GetRigidbody2D().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        
        public override void StartAttack() {}
    }
}