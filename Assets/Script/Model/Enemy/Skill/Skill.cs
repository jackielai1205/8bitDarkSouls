using UnityEngine;

namespace Script.Model.Enemy.Skill
{
    public abstract class Skill : MonoBehaviour
    {
        public int coolDown;
        public int power;
        public int currentCoolDown = 0;
        public abstract void Perform(Transform enemyPos, Transform target);
    }
}
