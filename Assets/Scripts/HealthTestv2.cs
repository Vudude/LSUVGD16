using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HealthTestv2 : MonoBehaviour {


	public GameObject healthBar;

	//the player's starting health upon getting an ablility
	public int abilityHealth = 100;

	//the player's starting health
	public int initialHealth = 0;

	//the player's current health when having an ability
	public int currentHealth; 

	//the color flashed when damaged
	public Color damageColour = new Color(1f, 0f, 0f, 0.1f);

	//boolean that is true when a player aquires a new ability, becomes false immediately after
	//public bool newAbility = false;

	//boolean that is true when merby has an ability
	public bool hasPistolAbility = false;

	//boolean that is true when merby has an ability
	public bool hasSMGAbility = false;

	//boolean that is true when merby has an ability
	public bool hasBazookaAbility = false;

	//boolean that is true when merby has an ability
	public bool hasSniperAbility = false;

	public bool hasAbility = false;
	//boolean that is true when merby takes damage
	//public bool takeDamage = false;

	//boolean that is true when merby takes damage and becomes invincible
	public bool hasInvincibility = false;

	public float invincibleTimer = 2;

	//box for health
	Rect healthLabel = new Rect(60,60,60,60);

	public void barDamage()
	{
		float barHealth = (float)currentHealth / 100f;
		healthBar.transform.localScale = new Vector3 (barHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);

	}
		
	public void initialBarDamage()
	{
		float barHealth =0;
		healthBar.transform.localScale = new Vector3 (barHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);

	}

	//function that calculates merby's new health. Takes an integer that represents the gun's damage
	//if you take damage and your health is zero, you die
	//if you take damage and your health is not zero, subtract the health by damage taken (caps at zero)
	//if damage is greater than your health, health becomes zero
	//resets takeDamage at the end
	//displays updated version of current health
	public void takeDamage(int damage)
	{
		if (hasInvincibility == false) 
		{
			hasInvincibility = true;
			invincibleTimer = 2;

			if (currentHealth == 0) 
			{
				gameObject.SetActive (false);
				SceneManager.LoadScene ("tutorial2");

			}
			else if (damage > currentHealth) 
			{
				currentHealth = 0;
				hasPistolAbility = false;
				hasBazookaAbility = false;
				hasSMGAbility = false;
				hasSniperAbility = false;
				hasAbility = false;
			} 

			else
				currentHealth = currentHealth - damage;

			barDamage ();
		}


	}

	//creates the display for merby's health
	public void OnGUI()
	{
		GUI.contentColor = Color.black;
		GUI.Label (healthLabel, "Health: " + currentHealth, "color");  
	}


	//initilizes merby's health
	void Start () 
	{
		currentHealth = initialHealth;
		OnGUI ();
		barDamage ();
	}

	void Update()
	{
		if (invincibleTimer > 0)
			invincibleTimer = invincibleTimer - Time.deltaTime;
		else
			hasInvincibility = false;
	}

	void OnTriggerEnter(Collider other)
	{	//Debug.Log ("collision happened");


		if (other.gameObject.CompareTag ("pistolBullet")) 
		{
			Destroy(other.gameObject);
			takeDamage (20);
			barDamage ();
			//Debug.Log ("collision happened inside");
		}


		//if merby gets an ability, health becomes 100
		//resets newAbility at the end
		//FIXME change according to multiple abilities
		//if (other.gameObject.CompareTag ("ability")) 
		if (other.gameObject.CompareTag ("pistolEnemy"))
		{
			Destroy(other.gameObject);
			currentHealth = abilityHealth;
			hasPistolAbility = true;
			hasAbility = true;
			barDamage ();
		}
			
		else if (other.gameObject.CompareTag ("smgEnemy"))
		{
			Destroy(other.gameObject);
			currentHealth = abilityHealth;
			hasSMGAbility = true;
			hasAbility = true;
			barDamage ();
		}

		else if (other.gameObject.CompareTag ("sniperEnemy")) 
		{
			Destroy(other.gameObject);
			currentHealth = abilityHealth;
			hasSniperAbility = true;
			hasAbility = true;
			barDamage ();
		}


		else if(other.gameObject.CompareTag ("bazookaEnemy"))
		{
			Destroy(other.gameObject);
			currentHealth = abilityHealth;
			hasBazookaAbility = true;
			hasAbility = true;
			barDamage ();
		}

	
		//calls take damage for each type of bullet collided with
		if (other.gameObject.CompareTag ("pistolBullet")) 
		{
			Destroy(other.gameObject);
			takeDamage (20);
			//Debug.Log ("collision happened inside");
		}

		else if (other.gameObject.CompareTag ("sniperBullet")) 
		{
			Destroy(other.gameObject);
			takeDamage (50);
		}

		else if (other.gameObject.CompareTag ("smgBullet")) 
		{
			Destroy(other.gameObject);
			takeDamage (25);
		}

		else if (other.gameObject.CompareTag ("bazookaBullet")) 
		{
			Destroy(other.gameObject);
			takeDamage (100);
		}
		OnGUI ();

	}
}


/*// Update is called once per frame
	void Update () 
	{
		//if merby gets an ability, health becomes 100
		//resets newAbility at the end
		if (newAbility == true) 
		{
			currentHealth = abilityHealth;
			newAbility = false;
		}

		//if you take damage and your health is zero, you die
		//if you take damage and your health is not zero, subtract the health by damage taken (caps at zero)
		//if damage is greater than your health, health becomes zero
		//resets takeDamage at the end
		//displays updated version of current health
		if (takeDamage == true) 
		{
			if (currentHealth == 0)
				gameObject.SetActive (false);

			else 
				if (damageTaken > currentHealth)
					currentHealth = 0;

				else 
					currentHealth = currentHealth - damageTaken;

			takeDamage = false; 
		}
		OnGUI ();
	}
	*/