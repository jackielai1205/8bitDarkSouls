using System;
using Script.Model.Enemy.Skill;
using UnityEngine;

namespace Script.Model.Projectile
{
    public class FireBall : Skill
    {
        public float speed;
        public void Start()
        {
            Destroy(gameObject, 3f);
        }

        public override void Perform(Transform weapon, Transform target)
        {
            if (currentCoolDown >= coolDown)
            {
                currentCoolDown = 0;
                var fireBall = Instantiate(this, weapon.transform.position, weapon.transform.rotation);
                Transform fireBallTransform = fireBall.GetComponent<Transform>();
                Vector3 relativePos = target.position - fireBallTransform.position;
                fireBallTransform.right = relativePos;
                fireBall.GetComponent<Rigidbody2D>().AddForce(relativePos.normalized * speed , ForceMode2D.Impulse);
            }
            else
            {
                currentCoolDown++;
            }
        }

        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.GetComponent<Player>() == null)
            {
                return;
            }
            col.gameObject.GetComponent<Player>().TakeDamage(power);
            Destroy(gameObject);
        }
    }
}