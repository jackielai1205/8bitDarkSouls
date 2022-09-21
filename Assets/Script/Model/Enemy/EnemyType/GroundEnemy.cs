using System;
using System.Collections.Generic;
using Script.Behaviour;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Model.Enemy.EnemyType
{
    public class GroundEnemy : Enemy
    {
        public override void Attack(){}
        public EnemyGroundSensor groundSensor;
        public JumpArea jumpAreas = null;
        private JumpArea _destination = null;

        public override void Update()
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
                    JumpState();
                    break;
            }
        }
        
        public override void WalkToCharacter()
        {
            if (GetStopMove())
            {
                return;
            }
            if (jumpAreas != null)
            {
                foreach (var destination in jumpAreas.destinations)
                {
                    if ((transform.position - GetTarget().transform.position).magnitude > (destination.transform.position - GetTarget().transform.position).magnitude)
                    {
                        StartJump();
                        _destination = destination;
                        return;
                    }
                }
            }

            if (transform.localPosition.x > GetTarget().transform.position.x)
            {
                var localScale = transform.localScale;
                localScale = new Vector3(-Math.Abs(localScale.x), localScale.y, localScale.z);
                transform.localScale = localScale;
            }
            else if (transform.localPosition.x < GetTarget().transform.position.x)
            {
                var localScale = transform.localScale;
                localScale = new Vector3(Math.Abs(localScale.x), localScale.y, localScale.z);
                transform.localScale = localScale;
            }
            GetRigidbody2D().velocity = new Vector2 (transform.localScale.x, GetRigidbody2D().velocity.y) * movementSpeed;
        }
        
        public override void StopMove()
        {
            GetRigidbody2D().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }

        public override void Move()
        {
            GetRigidbody2D().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        
        public void JumpState()
        {
                Vector3 myPosition = transform.position;
                Vector3 p = _destination.transform.position;
                float gravity = Physics.gravity.magnitude;
                float angle = 45 * Mathf.Deg2Rad;
                Vector3 planarTarget = new Vector3(p.x, p.y, p.z);
                Vector3 planarPosition = new Vector3(myPosition.x, myPosition.y, myPosition.z);
                float distance = Vector3.Distance(planarTarget, planarPosition);
                float yOffset = myPosition.y - p.y;
                float initialVelocity = (1 / Mathf.Cos(angle)) * Mathf.Sqrt((0.5f * gravity * Mathf.Pow(distance, 2)) / (distance * Mathf.Tan(angle) + yOffset));
                Vector3 velocity = new Vector3(0, initialVelocity * Mathf.Sin(angle), initialVelocity * Mathf.Cos(angle));
                float angleBetweenObjects = Vector3.Angle(Vector3.forward, planarTarget - planarPosition);
                Vector3 finalVelocity = Quaternion.AngleAxis(angleBetweenObjects, Vector3.up) * velocity;
                GetRigidbody2D().AddForce(finalVelocity * GetRigidbody2D().mass, ForceMode2D.Impulse);
                jumpAreas = null;
                FindNextState();
        }
        
        public override void DeadState()
        {
            GetBoxCollider2D().enabled = false;
            GetRigidbody2D().constraints = RigidbodyConstraints2D.FreezeAll;
        }

        public override void StartAttack(){}

        public void StartJump()
        {
            GetAnimator().SetInteger(GetAnimState(), 6);
        }

        public JumpArea GetJumpArea()
        {
            return jumpAreas;
        }

        public void SetJumpArea(JumpArea jumpArea)
        {
            this.jumpAreas = jumpArea;
        }
        
        float CalculateProjectileMotion(float x, Transform start, Transform target)
        {
            float a = Physics.gravity.y;
            float velocityX = start.position.x - target.position.x;
            float velocityY = Mathf.Sqrt(2 * (a * (start.position.y - target.position.y) ));
 
            float projectileVelocity = Mathf.Sqrt(velocityX  * velocityX  + velocityY  * velocityY );
            float trajectoryAngle = Mathf.Atan(velocityY/velocityX );
 
            return x * Mathf.Tan(trajectoryAngle) - ( (a * x * x) / (2 * (projectileVelocity * projectileVelocity) * (Mathf.Cos(trajectoryAngle) * Mathf.Cos(trajectoryAngle) ) ) );
        }
    }
}