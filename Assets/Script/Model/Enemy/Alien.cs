using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Script.Model.Enemy{
    public class Alien : Enemy
    {
        private static readonly int AnimState = Animator.StringToHash("AnimState");
        public override void Attack()
        {
            var random = new Random();
            var randomNumber = random.Next(2, 3);
            GetComponent<Animator>().SetInteger(AnimState, randomNumber);
        }
    }
}

