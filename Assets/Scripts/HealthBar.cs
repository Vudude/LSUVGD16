using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/* Brandon Mautz
 * this script controls and displays the health of the main character
 */

public class HealthBar : MonoBehaviour {


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

	public void newBar()
	{
		healthBar.transform.localScale = new Vector3 (1, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
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
				gameObject.SetActive (false);

			else if (damage > currentHealth) 
			{
				currentHealth = 0;
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
		barDamage ();
		OnGUI ();
	}

	void Update()
	{
		if (invincibleTimer > 0)
			invincibleTimer = invincibleTimer - Time.deltaTime;
		else
			hasInvincibility = false;
	}

	void OnTriggerEnter(Collider other)
	{
		//if merby gets an ability, health becomes 100
		//resets newAbility at the end
		//FIXME change according to multiple abilities
		if (other.gameObject.CompareTag ("bazookaEnemny")) 
		{
			Destroy(other.gameObject);
			currentHealth = abilityHealth;
			hasAbility = true;
			barDamage ();
		}

		//calls take damage for each type of bullet collided with
		if (other.gameObject.CompareTag ("pistolBullet")) 
		{
			Destroy(other.gameObject);
			takeDamage (20);
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
