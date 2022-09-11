using Script.Model.Enemy.EnemyType;
using UnityEngine;
using Random = System.Random;

namespace Script.Model.Enemy
{

    public class Skeleton : LandEnemy
    {
        public int currentHealth;

        public override void Attack()
        {
        }

        // public void TakeDamage(int damage){
        //     currentHealth -= damage;
        //     Debug.Log("damage Taken!");
        // }
    }
}
