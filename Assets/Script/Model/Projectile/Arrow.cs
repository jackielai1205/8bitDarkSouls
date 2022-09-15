using System;
using UnityEngine;

namespace Script.Model.Projectile
{
    public class Arrow : MonoBehaviour
    {
        public float arrowSpeed;
        public int power;

        public void Start()
        {
            Destroy(gameObject, 3f);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {

            if (collision.gameObject.GetComponent<Player>() == null)
            {
                return;
            }
            collision.gameObject.GetComponent<Player>().TakeDamage(power);
            Destroy(gameObject);
        }
    }
}