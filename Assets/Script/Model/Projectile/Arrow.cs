using System;
using UnityEngine;

namespace Script.Model.Projectile
{
    public class Arrow : MonoBehaviour
    {
        public float arrowSpeed;
        public int power;
        private Transform _target;
        
        //Calculate rotation between target and arrow and add force to navigate arrow to target
        public void Start()
        {
            Transform arrowTransform = GetComponent<Transform>();
            Vector3 relativePos = _target.position - arrowTransform.position;
            arrowTransform.right = relativePos;
            GetComponent<Rigidbody2D>().AddForce(relativePos.normalized * arrowSpeed, ForceMode2D.Impulse);
            Destroy(gameObject, 3f);
        }
        
        //If arrow trigger player component, call player's TakeDamage function and destroy object
        private void OnTriggerEnter2D(Collider2D other)
        {

            if (other.gameObject.GetComponent<Player>() == null)
            {
                return;
            }
            other.gameObject.GetComponent<Player>().TakeDamage(power);
            Destroy(gameObject);
        }

        //Setter for target
        public void SetTarget(Transform target)
        {
            _target = target;
        }
    }
}