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
        public EnemyGroundSensor groundSensor;
        public JumpArea jumpAreas = null;
        private JumpArea _destination = null;

        //Add jump state for ground enemy
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
        
        //Walk to character horizontally and jump if jump option available 
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
        
        //Freeze position x and rotation z
        public override void StopMove()
        {
            GetRigidbody2D().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }

        //Release position x
        public override void Move()
        {
            GetRigidbody2D().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        
        //Jump and find next state
        public void JumpState()
        {
                GetRigidbody2D().AddForce(CalculateJumpForce() * GetRigidbody2D().mass, ForceMode2D.Impulse);
                jumpAreas = null;
                FindNextState();
        }

        //Calculate jump force
        public Vector3 CalculateJumpForce()
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
            return Quaternion.AngleAxis(angleBetweenObjects, Vector3.up) * velocity;
        }
        
        //Fixed movement and remove collider
        public override void DeadState()
        {
            GetCollider2D().enabled = false;
            GetRigidbody2D().constraints = RigidbodyConstraints2D.FreezeAll;
        }

        //Notify animator to change animstate
        public void StartJump()
        {
            GetAnimator().SetInteger(GetAnimState(), 6);
        }

        //Getter for jump area
        public JumpArea GetJumpArea()
        {
            return jumpAreas;
        }

        
        //Setter for jump area
        public void SetJumpArea(JumpArea jumpArea)
        {
            this.jumpAreas = jumpArea;
        }
        
        public override void StartAttack(){}
    }
}