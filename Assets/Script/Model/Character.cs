using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public int health;
    public int power;
    public int attackPower;

    public abstract void Walk();

    public abstract void Attack();

    public abstract void Dead();

    public abstract void Hurt();
}
