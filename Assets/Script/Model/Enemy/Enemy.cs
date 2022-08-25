using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Enemy : Character
{
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
    }

    public void Walk(Transform target)
    {
        if (transform.localPosition.x > target.transform.localPosition.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }else if (transform.localPosition.x < target.transform.localPosition.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2 (transform.localScale.x, 0) * movementSpeed;
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

    public bool IsAttacking()
    {
        return _isAttacking;
    }

    public void SetAttack(bool value)
    {
        _isAttacking = value;
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
