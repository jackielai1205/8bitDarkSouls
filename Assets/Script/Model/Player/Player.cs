using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
	public int currentHealth;
	public int stamina = 150;
	public int currentStamina;

	private Animator animState;
	private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
	private Coroutine regen;

	public HealthBar2 healthBar;
	public StaminaBar staminaBar;
    public Inventory inventory;
    private int _currency;

    void Dodge()
    {
        //write code here
    }

    void BlockIdle()
    {
        //write code here
    }

    void Block()
    {
        //write code here
    }

    void Interaction()
    {
        //write code here
    }

    void Jump()
    {
        //write code here
    }

    // Start is called before the first frame update
    void Start()
    {
        //set health
        health = 200;
        currentHealth = health;
		healthBar.SetMaxHealth(health);

        //set stamina
		currentStamina = stamina;
		staminaBar.SetMaxStamina(stamina);
		this.animState = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //need to change these codes
        //these are for testing convenience
        if (Input.GetKeyDown("z"))
		{
			TakeDamage(15);
		}

		if (Input.GetMouseButtonDown(0))
		{
			UseStamina(10);
		}
    }

    public void Walk()
    {
        throw new System.NotImplementedException();
    }

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public override void Dead()
    {
        throw new System.NotImplementedException();
    }

    public override void Hurt()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int damage)
	{
        if(currentHealth - damage > 0){
			currentHealth -= damage;
            this.animState.SetTrigger("Hurt");
			healthBar.SetHealth(currentHealth);
        } 
		else 
		{
			currentHealth = 0;
			healthBar.SetHealth(currentHealth);
            this.animState.SetTrigger("Death");
        }
	}

    public void RecoverHealth(int healthAmount)
    {
        //prevents health from going over current max health
        if(currentHealth + healthAmount <= health)
        {
            currentHealth += 10;
        }
        else
        {
            currentHealth = health;
        }

        Debug.Log(currentHealth);
        healthBar.SetHealth(currentHealth);
    }

    public void RecoverStamina(int staminaAmount)
    {
        //prevents health from going over current max health
        if(currentStamina + staminaAmount <= stamina)
        {
            currentStamina += staminaAmount;
        }
        else
        {
            currentStamina = stamina;
        }

        Debug.Log(currentStamina);
        staminaBar.SetStamina(currentStamina);
    }

    public void UseStamina(int staminaAmount)
	{
		if(currentStamina - staminaAmount >= 0)
		{
			currentStamina -= staminaAmount;
			staminaBar.SetStamina(currentStamina);

			if(regen != null)
			{
				StopCoroutine(regen);
			}

			regen = StartCoroutine(RegenStamina());
		}
		else
		{
			Debug.Log("Not enough Stamina");
            //code to stop player from being able to perform "attack"
		}
	}

    //for regenerating stamina
	private IEnumerator RegenStamina()
	{
		yield return new WaitForSeconds(3);

		while(currentStamina < stamina)
		{
			currentStamina += 1;
			//Debug.Log("stamina increasing by: "+ currentStamina);
			staminaBar.SetStamina(currentStamina);
			yield return regenTick;
		}
		regen = null;
	}
}
