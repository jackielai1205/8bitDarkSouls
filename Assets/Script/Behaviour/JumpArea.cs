using System;
using System.Collections;
using System.Collections.Generic;
using Script.Model.Enemy.EnemyType;
using UnityEngine;

namespace Script.Behaviour
{
    public class JumpArea : MonoBehaviour
    {
        public List<JumpArea> destinations;

        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.GetComponent<GroundEnemy>() != null)
            {
                col.GetComponent<GroundEnemy>().SetJumpArea(this);
            }
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.GetComponent<GroundEnemy>() != null)
            {
                other.GetComponent<GroundEnemy>().SetJumpArea(this);
            }
        }
    }
}
