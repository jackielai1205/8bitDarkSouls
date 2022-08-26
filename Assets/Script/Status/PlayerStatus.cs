using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
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
			TakeDamage(15f);
		}
    }

	public void TakeDamage(float _damage)
	{

        if(currentHealth - _damage > 0f){
			currentHealth -= _damage;
            this.animState.SetTrigger("Hurt");
			healthBar.SetHealth(currentHealth);
        } else {
			currentHealth = 0f;
			healthBar.SetHealth(currentHealth);
            this.animState.SetTrigger("Death");
			//Time.timescale = 0;
        }
		

	}
}
