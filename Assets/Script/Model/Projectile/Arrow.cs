using System;
using UnityEngine;

namespace Script.Model.Projectile
{
    public class Arrow : MonoBehaviour
    {
        public float arrowSpeed;
        public int power;
        private Transform _target;
        
        public void Start()
        {
            Vector3 relativePos = _target.position - transform.position;
            transform.right = relativePos;
            GetComponent<Rigidbody2D>().AddForce(relativePos.normalized * arrowSpeed, ForceMode2D.Impulse);
        }

        public void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D other)
        {

            if (other.gameObject.GetComponent<Player>() == null)
            {
                return;
            }
            other.gameObject.GetComponent<Player>().TakeDamage(power);
            Destroy(gameObject);
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }
    }
}