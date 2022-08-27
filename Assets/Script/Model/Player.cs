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
        health = 200;
        currentHealth = health;
		healthBar.SetMaxHealth(health);

		currentStamina = stamina;
		staminaBar.SetMaxStamina(stamina);
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

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.gameObject.tag == "HealthPotion")
        {
            //this.Heal(10);
            currentHealth += 10;
            Debug.Log(currentHealth);
            healthBar.SetHealth(currentHealth);
        }
    }

    public void UseStamina(int depleted)
	{
		if(currentStamina - depleted >= 0)
		{
			currentStamina -= depleted;
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
            //need to stop player from being able to perform "attack"
		}
	}

	private IEnumerator RegenStamina()
	{
		yield return new WaitForSeconds(2);

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
