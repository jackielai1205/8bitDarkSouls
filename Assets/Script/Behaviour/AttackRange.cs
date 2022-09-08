using System;
using System.Collections;
using System.Collections.Generic;
using Script.Model.Enemy;
using UnityEngine;

namespace Script.Behaviour
{
    public class AttackRange : MonoBehaviour
    {
        public Enemy enemy;

        private void OnTriggerStay2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                enemy.SetAttack(true);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            enemy.SetAttack(false);
        }
    }
}
