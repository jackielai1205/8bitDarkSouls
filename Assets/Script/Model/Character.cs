using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public int health;
    public int power;
    public int attackPower;

    public abstract void Dead();

    public abstract void Hurt();
    
}
