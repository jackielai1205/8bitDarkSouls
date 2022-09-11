using System;
using Script.Model.Enemy;
using Script.Model.Enemy.EnemyType;
using UnityEngine;

namespace Script.Behaviour
{
    public class Vulnerable : MonoBehaviour
    {
        public Enemy enemy;
        public void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Damage"))
            {
                enemy.SetHurt(true);
            }
        }
    }
}