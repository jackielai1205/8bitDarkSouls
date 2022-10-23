using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public int health;
    private int _maxHealth;
    public int attackPower;

    public abstract void Dead();

    public abstract void Hurt();


    public void SetMaxHealth(int currentHealth)
    {
        _maxHealth = currentHealth;
    }

    public int GetMaxHealth()
    {
        return _maxHealth;
    }
}
