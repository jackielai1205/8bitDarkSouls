using System;
using Script.Model.Enemy.EnemyType;
using Unity.VisualScripting;
using UnityEngine;

namespace Script.Behaviour
{
    public class AttackRange : MonoBehaviour
    {
        public Enemy enemy;
        private string _originalTag;

        private void Start()
        {
            _originalTag = gameObject.tag;
        }

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

        public string GetOriginalTag()
        {
            return _originalTag;
        }
    }
}
