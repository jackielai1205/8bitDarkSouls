using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth;
	private Animator anim;

	public HealthBar2 healthBar;

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
		anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown("z"))
		{
			TakeDamage(20);
		}
    }

	public void TakeDamage(int _damage)
	{
		currentHealth = Mathf.Clamp(currentHealth - _damage, 0, maxHealth);

        if(currentHealth > 0){
            anim.SetTrigger("Hurt");
			currentHealth -= _damage;
			healthBar.SetHealth(currentHealth);
        } else {
            anim.SetTrigger("Death");
        }
		

	}
}
