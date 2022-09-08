using System;
using UnityEngine;
using Random = System.Random;

namespace Script.Model.Enemy
{
    public abstract class Enemy : Character
    {
        private Rigidbody2D _rigidbody;
        private Animator _animator;
        private BoxCollider2D _boxCollider2D;
        private bool _inAttackRange = false;
        private bool _isActivate = false;
        private bool _isHit = false;
        private bool _isDead = false;
        private bool _isStopMove = false;
        private GameObject _target = null;
        public float movementSpeed = 1f;
        private static readonly int animState = Animator.StringToHash("AnimState");
        private static readonly int attack = Animator.StringToHash("Attack");

        public void Start()
        {
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _boxCollider2D = GetComponent<BoxCollider2D>();
        }

        public void Update()
        {
            switch (_animator.GetInteger(animState))
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
            }
        }

        private void IdleState()
        {
            if (_isHit)
            {
                Hurt();
            }
            else if (_isActivate)
            {
                StartWalk();
            }
            //_rigidbody.velocity = new Vector2 (transform.localScale.x, 0) * movementSpeed;
        }

        private void DeadState()
        {
            _boxCollider2D.enabled = false;
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        private void HitState()
        {
            health -= 20;
            if (health > 0)
            {
                return;
            }
            _isDead = true;
        }

        private void StopHit()
        {
            _isHit = false;
            if (_isDead)
            {
                Dead();
            }
            else if (_inAttackRange)
            {
                StartAttack();
            }
            else if (_isActivate)
            {
                StartChaseState();
            }
            else
            {
                StartIdle();
            }
        }

        private void ChaseCharacterState()
        {
            if (_isHit)
            {
                Hurt();
            }
            else if (_inAttackRange)
            {
                StartAttack();
            }
            else if(!_isActivate)
            {
                StartIdle();
            }
            else
            {
                WalkToCharacter();
            }
        }

        private void AttackState()
        {
            if (_inAttackRange)
            {
                StartAttack();
            }
            else
            {
                StartChaseState();
            }
        }

        private void StartChaseState()
        {
            _animator.SetInteger(animState, 1);
        }

        private void StartAttack()
        {
            var random = new Random();
            var randomNumber = random.Next(0, 2);
            _animator.SetInteger(attack, randomNumber);
            _animator.SetInteger(animState, 2);
        }

        private void WalkToCharacter()
        {
            if (_isStopMove)
            {
                return;
            }
            if (transform.localPosition.x > _target.transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }else if (transform.localPosition.x < _target.transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            _rigidbody.velocity = new Vector2 (transform.localScale.x, 0) * movementSpeed;
        }
    
        public void StartWalk()
        {
            _animator.SetInteger(animState, 1);
        }

        public void StartIdle()
        {
            _animator.SetInteger(animState, 0);
        }

        public void StopAttack()
        {
            _animator.SetInteger(animState, _isActivate ? 1 : 0);
        }

        public void SetActivate(bool value)
        {
            _isActivate = value;
        }

        public void SetAttack(bool value)
        {
            _inAttackRange = value;
        }

        public override void Dead()
        {
            _animator.SetInteger(animState, 5);
        }

        public override void Hurt()
        {
            _animator.SetInteger(animState , 4);
        }

        public GameObject GetTarget()
        {
            return _target;
        }

        public void SetTarget(GameObject target)
        {
            _target = target;
        }

        public void SetHurt(bool isHit)
        {
            _isHit = isHit;
        }

        public bool GetHurt()
        {
            return _isHit;
        }

        public void StopMove()
        {
            _isStopMove = true;
        }

        public void Move()
        {
            _isStopMove = false;
        }

    }
}
