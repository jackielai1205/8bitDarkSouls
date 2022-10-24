using System.Collections;
using System.Collections.Generic;
using Script.Model.Enemy.EnemyType;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Model.Enemy
{
    public class BossHealthBar : EnemyHealthBar
    {
        public Boss boss;
        public Image image;
        public Text bossHealthText;
        public Text bossNameText;

        // Start is called before the first frame update
        void Start()
        {
            image.fillAmount = 1;
            bossNameText.text = boss.bossName;
        }
        
        public override void SetHealth(int health, int maxHealth)
        {
            bossHealthText.text = health + "/" + maxHealth;
            var currentHealthRate = (float)health / (float)maxHealth;
            print(currentHealthRate);
            image.fillAmount = currentHealthRate;
        }

        public override void Update()
        {
            
        }
    }
}



