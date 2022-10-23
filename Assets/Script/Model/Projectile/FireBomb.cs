using System;
using Script.Model.Enemy.Skill;
using UnityEngine;

namespace Script.Model.Projectile
{
    public class FireBomb : Skill
    {
        private bool _readyToAttack = false;

        public void Destroy()
        {
            Destroy(gameObject);
        }

        public override void Perform(Transform weapon, Transform target, AudioSource source)
        {
            if (currentCoolDown >= coolDown)
            {
                currentCoolDown = 0;
                var fireBomb = Instantiate(this, new Vector3(target.position.x, target.position.y + 0.1f, target.position.z), target.transform.rotation);
            }
            else
            {
                currentCoolDown++;
            }
            
        }

        public void Damage()
        {
            _readyToAttack = true;
        }
        
        public void OnTriggerStay2D(Collider2D col)
        {
            if (col.gameObject.GetComponent<Player>() == null)
            {
                return;
            }

            if (_readyToAttack)
            {
                col.gameObject.GetComponent<Player>().TakeDamage(power);
                _readyToAttack = false;
            }
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            _readyToAttack = false;
        }
    }
}