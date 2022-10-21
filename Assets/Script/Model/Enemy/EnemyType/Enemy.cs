using System;
using UnityEngine;

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
        private CapsuleCollider2D _capsuleCollider2D;
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
            _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
            //Ignore game object with same layer (Enemy layer)
            Physics2D.IgnoreLayerCollision(8, 8, true);
        }

        //Find next state to perform corresponding action
        public virtual void Update()
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

        //When no player enter the activation area, the bot not perform any action
        public void IdleState()
        { 
            if (_isActivate)
            {
                StartWalk();
            }
        }

        //When bot take exceeded damage, the bot die
        public abstract void DeadState();

        //When take damage, bot measure the power and reduce the health.
        public void HitState()
        {
            health -= _takeDamagePower;
            _takeDamagePower = 0;
            if (health <= 0)
            {
                _isDead = true;
            }
        }

        //Perform action if any condition satisfied, otherwise walk to player
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

        //Read the position of player and attack
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
        
        //Notify animator to change animation
        public void StartChaseState()
        {
            _animator.SetInteger(AnimState, 1);
        }
        
        
        //After performed a action, bot will find next state
        public void FindNextState()
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
        
        //Take Damage function for Player attack
        public void TakeDamage(int damage)
        {
            if (_isDead)
            {
                return;
            }
            Hurt();
            _takeDamagePower = damage;
        }

        //Attack function
        public abstract void StartAttack();

        //Actually doing damage by get the player component from game object
        public void DoDamage()
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
            for(int i = 0; i < enemiesToDamage.Length; i++){
                if(enemiesToDamage[i].GetComponent<Player>() != null){
                    enemiesToDamage[i].GetComponent<Player>().TakeDamage(attackPower);
                }
            }
        }
        
        //Destroy this object function
        public void Disappear()
        {
            Destroy(gameObject);
        }

        //Walk function
        public abstract void WalkToCharacter();

        //Notify animator to change animation
        public void StartWalk()
        {
            _animator.SetInteger(AnimState, 1);
        }

        //Notify animator to change animation
        public void StartIdle()
        {
            _animator.SetInteger(AnimState, 0);
        }

        //Notify animator to change animation
        public void SetActivate(bool value)
        {
            _isActivate = value;
        }

        //Set attack range boolean
        public void SetAttack(bool value)
        {
            _inAttackRange = value;
        }

        //Notify animator to change animation
        public override void Dead()
        {
            _animator.SetInteger(AnimState, 5);
        }

        //Notify animator to change animation
        public override void Hurt()
        {
            _animator.SetInteger(AnimState , 4);
        }

        //Getter of target
        public GameObject GetTarget()
        {
            return _target;
        }

        //Getter for isHit
        public bool GetHurt()
        {
            return _isHit;
        }
        
        //Getter for StopMove
        public bool GetStopMove()
        {
            return _isStopMove;
        }

        //Getter for Rigidbody2D
        public Rigidbody2D GetRigidbody2D()
        {
            return _rigidbody;
        }

        //Getter for Transform
        public Transform GetTransform()
        {
            return _transform;
        }

        //Getter for Rigidbody2D
        public CapsuleCollider2D GetCollider2D()
        {
            return _capsuleCollider2D;
        }

        //Getter for animator
        public Animator GetAnimator()
        {
            return _animator;
        }

        //Getter for animstate
        public int GetAnimState()
        {
            return AnimState;
        }

        //Getter for attackMethod
        public int GetAttackMethod()
        {
            return AttackMethod;
        }
        
        //Setter for target
        public void SetTarget(GameObject target)
        {
            _target = target;
        }

        //Setter for isHit
        public void SetHurt(bool isHit)
        {
            _isHit = isHit;
        }
        
        //Setter for RigidBody2D
        public void SetRigidBody(Rigidbody2D rigidbody2D)
        {
            _rigidbody = rigidbody2D;
        }
        
        //Abstract class for different implementation
        public abstract void StopMove();

        //Abstract class for different implementation
        public abstract void Move();
    }
}
