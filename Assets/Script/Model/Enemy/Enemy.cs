using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Enemy : Character
{
    private Vector3 _startPosition;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private bool _isAttacking;
    private bool _isActivate;
    public float movementSpeed = 1f;
    private static readonly int AnimState = Animator.StringToHash("AnimState");

    public void Start()
    {
        _isAttacking = false;
        _isActivate = false;
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;
    }

    public void Update()
    {
        // if (!_isActivate && !_isAttacking)
        // {
        //     StartWalk();
        //     _rigidbody.velocity = new Vector2 (transform.localScale.x, 0) * movementSpeed;
        // }
        
    }

    public void Walk(Vector3 target)
    {
        if (transform.localPosition.x > target.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }else if (transform.localPosition.x < target.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        _rigidbody.velocity = new Vector2 (transform.localScale.x, 0) * movementSpeed;
    }
    
    public void StartWalk()
    {
        _animator.SetInteger(AnimState, 1);
    }

    public void StopWalk()
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

    public bool IsActivate()
    {
        return _isActivate;
    }

    public bool IsAttacking()
    {
        return _isAttacking;
    }

    public void SetAttack(bool value)
    {
        _isAttacking = value;
    }

    public Vector3 GetStartPosition()
    {
        return _startPosition;
    }

    public override void Dead()
    {
        throw new NotImplementedException();
    }

    public override void Hurt()
    {
        throw new NotImplementedException();
    }

    public override void Attack()
    {
        throw new NotImplementedException();
    }
}
