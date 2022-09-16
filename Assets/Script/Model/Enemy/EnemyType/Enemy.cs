using System;
using Script.Behaviour;
using UnityEditor.Build;
using UnityEngine;
using Random = System.Random;

namespace Script.Model.Enemy.EnemyType
{
    public abstract class Enemy : Character
    {
        public Transform attackPos;
        public LayerMask whatIsEnemies;
        public float attackRange;
        public float movementSpeed = 1f;
        // public AttackRange attackRange;

        private Transform _transform;
        private Rigidbody2D _rigidbody;
        private Animator _animator;
        private BoxCollider2D _boxCollider2D;
        private bool _inAttackRange = false;
        private bool _isActivate = false;
        private bool _isHit = false;
        private bool _isDead = false;
        private bool _isStopMove = false;
        private GameObject _target = null;
        private static readonly int AnimState = Animator.StringToHash("AnimState");
        private static readonly int AttackMethod = Animator.StringToHash("Attack");
        private int _takeDamagePower = 0;

        public void Start()
        {
            _transform = GetComponent<Transform>();
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _boxCollider2D = GetComponent<BoxCollider2D>();
            Physics2D.IgnoreLayerCollision(8, 8, true);
        }

        public void Update()
        {
            switch (_animator.GetInteger(AnimState))
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
        
        public void IdleState()
        { 
            if (_isActivate)
            {
                StartWalk();
            }
            //_rigidbody.velocity = new Vector2 (transform.localScale.x, 0) * movementSpeed;
        }

        public abstract void DeadState();

        public void HitState()
        {
            health -= _takeDamagePower;
            _takeDamagePower = 0;
            if (health <= 0)
            {
                _isDead = true;
            }
        }

        private void StopHit()
        {
            if (_isDead)
            {
                Dead();
            }else if (_inAttackRange)
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

        public void ChaseCharacterState()
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

        public void AttackState()
        {
            var facingX = gameObject.transform.localScale.x;
            if (_target.transform.position.x < gameObject.transform.position.x)
            {
                facingX = -Math.Abs(facingX);
            }
            GetTransform().localScale = new Vector3(facingX, 
                GetTransform().localScale.y, GetTransform().localScale.z);
            if (_inAttackRange)
            {
                StartAttack();
            }
            else
            {
                StartChaseState();
            }
        }

        public void StartChaseState()
        {
            _animator.SetInteger(AnimState, 1);
        }


        public abstract void StartAttack();

        public void DoDamage()
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
            for(int i = 0; i < enemiesToDamage.Length; i++){
                if(enemiesToDamage[i].GetComponent<Player>() != null){
                    enemiesToDamage[i].GetComponent<Player>().TakeDamage(attackPower);
                }
            }
        }
        //
        // public void StopDoDamage()
        // {
        //     attackRange.gameObject.tag = attackRange.GetOriginalTag();
        // }

        public abstract void WalkToCharacter();

        public void StartWalk()
        {
            _animator.SetInteger(AnimState, 1);
        }

        public void StartIdle()
        {
            _animator.SetInteger(AnimState, 0);
        }

        public void StopAttack()
        {
            _animator.SetInteger(AnimState, _isActivate ? 1 : 0);
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
            _animator.SetInteger(AnimState, 5);
        }

        public override void Hurt()
        {
            _animator.SetInteger(AnimState , 4);
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

        public abstract void StopMove();

        public abstract void Move();

        public bool GetMove()
        {
            return _isStopMove;
        }

        public Rigidbody2D GetRigidbody2D()
        {
            return _rigidbody;
        }

        public Transform GetTransform()
        {
            return _transform;
        }

        public BoxCollider2D GetBoxCollider2D()
        {
            return _boxCollider2D;
        }
        
        public void Disappear()
        {
            Destroy(gameObject);
        }

        public Animator GetAnimator()
        {
            return _animator;
        }

        public int GetAnimState()
        {
            return AnimState;
        }

        public void TakeDamage(int damage)
        {
            Hurt();
            _takeDamagePower = damage;
            Debug.Log("Damage Taken!");
            Debug.Log(health);
        }

        public int GetAttackMethod()
        {
            return AttackMethod;
        }
        
        void OnDrawGizmosSelected(){
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPos.position, attackRange);
        }
        
    }
}
