using System;
using Script.Model.Enemy;
using Script.Model.Enemy.EnemyType;
using UnityEngine;

namespace Script.Behaviour
{
    public class Vulnerable : MonoBehaviour
    {
        public Enemy enemy;
        public void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Damage"))
            {
                enemy.SetHurt(true);
            }
        }
    }
}