using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Model.Enemy
{
    public class EnemyHealthBar : MonoBehaviour
    {
        public Slider slider;
        public Color low;
        public Color high;
        public Vector3 offset;
        public RectTransform fillArea;

        public virtual void SetHealth(int health, int maxHealth)
        {
            slider.gameObject.SetActive(health < maxHealth);
            if (health <= 0)
            {
                fillArea.gameObject.SetActive(false);
            }
            else
            {
                slider.value = health;
            }
            slider.value = (health <= 0) ? 0 : health;
            slider.maxValue = maxHealth;
            slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
        }
        

        // Update is called once per frame
        public virtual void Update()
        {
            slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
        }
    }

}