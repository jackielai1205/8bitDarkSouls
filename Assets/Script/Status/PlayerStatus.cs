﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth;
	public int maxStamina = 50;
	public int currentStamina;
	private Animator animState;

	public HealthBar2 healthBar;
	public StaminaBar staminaBar;

    // Start is called before the first frame update
    public void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);

		currentStamina = maxStamina;
		staminaBar.SetMaxStamina(maxStamina);
		this.animState = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown("z"))
		{
			TakeDamage(15);
		}

		if (Input.GetMouseButtonDown(0))
		{
			UseStamina(10);
		}

    }

	public void TakeDamage(int _damage)
	{
        if(currentHealth - _damage > 0){
			currentHealth -= _damage;
            this.animState.SetTrigger("Hurt");
			healthBar.SetHealth(currentHealth);
        } 
		else 
		{
			currentHealth = 0;
			healthBar.SetHealth(currentHealth);
            this.animState.SetTrigger("Death");
			//Time.timescale = 0;
        }
	}

	public void UseStamina(int stamina)
	{
		if(currentStamina - stamina >= 0)
		{
			currentStamina -= stamina;
			staminaBar.SetStamina(currentStamina);
		}
		else
		{
			Debug.Log("Not enough Stamina");
		}

	}
}
