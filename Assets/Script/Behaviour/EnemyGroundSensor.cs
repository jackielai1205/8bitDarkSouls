using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Script.Behaviour
{
    public class EnemyGroundSensor : MonoBehaviour
    {
        private bool _onGround;

        //Check if enemy on the ground
        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Ground"))
            {
                _onGround = true;
            }
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            _onGround = false;
        }

        public bool GetOnGround()
        {
            return _onGround;
        }
    }
}
