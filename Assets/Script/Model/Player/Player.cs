using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Script.Model.Enemy.EnemyType;

public class Player : Character
{
	public int currentHealth;
	public int stamina = 150;
	public int currentStamina;

    [SerializeField] float      m_speed = 4.0f;
    [SerializeField] float      m_jumpForce = 7.5f;
    [SerializeField] float      m_rollForce = 6.0f;
    [SerializeField] bool       m_noBlood = false;
    [SerializeField] GameObject m_slideDust;

	private Animator animState;
	private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
	private Coroutine regen;

    // Player Attack Value

    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;

    private float timeBtwAttack;

	public HealthBar2 healthBar;
	public StaminaBar staminaBar;
    public Inventory inventory;
    private int _currency;

    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
    private Sensor_HeroKnight   m_groundSensor;
    private Sensor_HeroKnight   m_wallSensorR1;
    private Sensor_HeroKnight   m_wallSensorR2;
    private Sensor_HeroKnight   m_wallSensorL1;
    private Sensor_HeroKnight   m_wallSensorL2;
    private bool                m_isWallSliding = false;
    private bool                m_grounded = false;
    private bool                m_rolling = false;
    private int                 m_facingDirection = 1;
    private int                 m_currentAttack = 0;
    private float               m_timeSinceAttack = 0.0f;
    private float               m_delayToIdle = 0.0f;
    private float               m_rollDuration = 8.0f / 14.0f;
    private float               m_rollCurrentTime;



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
        m_animator = GetComponent<Animator>();

        m_body2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_HeroKnight>();
        m_wallSensorR1 = transform.Find("WallSensor_R1").GetComponent<Sensor_HeroKnight>();
        m_wallSensorR2 = transform.Find("WallSensor_R2").GetComponent<Sensor_HeroKnight>();
        m_wallSensorL1 = transform.Find("WallSensor_L1").GetComponent<Sensor_HeroKnight>();
        m_wallSensorL2 = transform.Find("WallSensor_L2").GetComponent<Sensor_HeroKnight>();
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

        // Increase timer that controls attack combo
        m_timeSinceAttack += Time.deltaTime;
        
                // Increase timer that checks roll duration
        if(m_rolling)
            m_rollCurrentTime += Time.deltaTime;

        // Disable rolling if timer extends duration
        if(m_rollCurrentTime > m_rollDuration)
            m_rolling = false;
        
        //Check if character just landed on the ground
        if (!m_grounded && m_groundSensor.State())
        {
            m_grounded = true;
            m_animator.SetBool("Grounded", m_grounded);
        }

        //Check if character just started falling
        if (m_grounded && !m_groundSensor.State())
        {
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
        }

        // -- Handle input and movement --
        float inputX = Input.GetAxis("Horizontal");

        // Swap direction of sprite depending on walk direction
        if (inputX > 0)
        {
            // GetComponent<SpriteRenderer>().flipX = false;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            m_facingDirection = 1;
        }
            
        else if (inputX < 0)
        {
            // GetComponent<SpriteRenderer>().flipX = true;
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            m_facingDirection = -1;
        }

        // Move
        if (!m_rolling ){
            m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);
        }
    
        // Set AirSpeed in animator
        m_animator.SetFloat("AirSpeedY", m_body2d.velocity.y);

        // -- Handle Animations --
        // Wall Slide
        m_isWallSliding = (m_wallSensorR1.State() && m_wallSensorR2.State()) || (m_wallSensorL1.State() && m_wallSensorL2.State());
        m_animator.SetBool("WallSlide", m_isWallSliding);
        
        //Attack
        if(timeBtwAttack <= 0 && !m_rolling && Input.GetMouseButtonDown(0)){
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
            for(int i = 0; i < enemiesToDamage.Length; i++){
                if(enemiesToDamage[i].GetComponent<Enemy>() != null){
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
            }
            m_currentAttack++;

            // Loop back to one after third attack
            if (m_currentAttack > 3){
                m_currentAttack = 1;
            }
            // Reset Attack combo if time since last attack is too large
            if (m_timeSinceAttack > 1.0f){
                m_currentAttack = 1;
            }

            // Call one of three attack animations "Attack1", "Attack2", "Attack3"
            m_animator.SetTrigger("Attack" + m_currentAttack);
            m_timeSinceAttack = 0.0f;
            timeBtwAttack = startTimeBtwAttack;
        } else if(timeBtwAttack > 0){
            timeBtwAttack -= Time.deltaTime;
        }

        // Block
        else if (Input.GetMouseButtonDown(1) && !m_rolling)
        {
            m_animator.SetTrigger("Block");
            m_animator.SetBool("IdleBlock", true);
        }

        else if (Input.GetMouseButtonUp(1))
            m_animator.SetBool("IdleBlock", false);

        // Roll
        else if (Input.GetKeyDown("left shift") && !m_rolling && !m_isWallSliding)
        {
            m_rolling = true;
            m_animator.SetTrigger("Roll");
            m_body2d.velocity = new Vector2(m_facingDirection * m_rollForce, m_body2d.velocity.y);
        }
            

        //Jump
        else if (Input.GetKeyDown("space") && m_grounded && !m_rolling)
        {
            m_animator.SetTrigger("Jump");
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
            m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
            m_groundSensor.Disable(0.2f);
        }

        //Run
        else if (Mathf.Abs(inputX) > Mathf.Epsilon)
        {
            // Reset timer
            m_delayToIdle = 0.05f;
            m_animator.SetInteger("AnimState", 1);
        }

        //Idle
        else
        {
            // Prevents flickering transitions to idle
            m_delayToIdle -= Time.deltaTime;
                if(m_delayToIdle < 0)
                    m_animator.SetInteger("AnimState", 0);
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

    // Animation Events
    // Called in slide animation.
    void AE_SlideDust()
    {
        Vector3 spawnPosition;

        if (m_facingDirection == 1)
            spawnPosition = m_wallSensorR2.transform.position;
        else
            spawnPosition = m_wallSensorL2.transform.position;

        if (m_slideDust != null)
        {
            // Set correct arrow spawn position
            GameObject dust = Instantiate(m_slideDust, spawnPosition, gameObject.transform.localRotation) as GameObject;
            // Turn arrow in correct direction
            dust.transform.localScale = new Vector3(m_facingDirection, 1, 1);
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
