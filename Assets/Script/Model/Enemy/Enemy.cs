using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character
{
    public float movementSpeed = 1f;
    private Rigidbody2D _rigidbody;


    public void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
}
