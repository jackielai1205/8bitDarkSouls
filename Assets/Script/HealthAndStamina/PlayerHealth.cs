using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

	public float maxHealth = 100f;
	public float currentHealth;
	private Animator animState;

	public HealthBar2 healthBar;

    // Start is called before the first frame update
    public void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
		this.animState = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown("z"))
		{
			TakeDamage(20f);
		}
    }

	public void TakeDamage(float _damage)
	{
		currentHealth -= _damage;

		if(currentHealth >= 0f)
		{
			healthBar.SetHealth(currentHealth);
		}

        if(currentHealth > 0f){
            this.animState.SetTrigger("Hurt");
        } else {
            this.animState.SetTrigger("Death");
			//Time.timescale = 0;
        }
		

	}
}
