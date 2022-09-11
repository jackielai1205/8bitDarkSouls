using UnityEngine;

namespace Script.Model.Enemy.EnemyType
{
    public class FlyEnemy : Enemy
    {
        
        public override void Attack()
        {
            throw new System.NotImplementedException();
        }

        public override void WalkToCharacter()
        {
            int flyDirection;
            if (GetMove())
            {
                return;
            }
            if (GetTransform().localPosition.x > GetTarget().transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }else if (GetTransform().localPosition.x < GetTarget().transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
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
        
        public override void DeadState()
        {
            GetRigidbody2D().gravityScale = 1;
            GetBoxCollider2D().enabled = true;
        }

        public override void StopMove()
        {
            GetRigidbody2D().constraints = RigidbodyConstraints2D.FreezeAll;
        }

        public override void Move()
        {
            GetRigidbody2D().constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        public override void StartAttack() {}
    }
}