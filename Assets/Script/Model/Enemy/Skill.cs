using UnityEngine;

namespace Script.Model.Enemy
{
    public class Skill : MonoBehaviour
    {
        public string skill;

        public Skill(string skill) 
        {
            this.skill = skill;
        }
    }
}
