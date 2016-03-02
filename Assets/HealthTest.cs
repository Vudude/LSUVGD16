using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/* Brandon Mautz
 * this script controls and displays the health of the main character
 */

public class HealthTest : MonoBehaviour {

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


	//box for health
	Rect healthLabel = new Rect(60,60,60,60);

	//function that calculates merby's new health. Takes an integer that represents the gun's damage
	//if you take damage and your health is zero, you die
	//if you take damage and your health is not zero, subtract the health by damage taken (caps at zero)
	//if damage is greater than your health, health becomes zero
	//resets takeDamage at the end
	//displays updated version of current health
	public void takeDamage(int damage)
	{
		if (currentHealth == 0)
			gameObject.SetActive (false);
		else if (damage > currentHealth) 
		{
			currentHealth = 0;
			hasAbility = false;
		}

			else 
				currentHealth = currentHealth - damage;
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
	}

	void OnTriggerEnter(Collider other)
	{
		//if merby gets an ability, health becomes 100
		//resets newAbility at the end
		if (other.gameObject.CompareTag ("ability")) 
		{
			other.gameObject.SetActive (false);
			currentHealth = abilityHealth;
			hasAbility = true;
		}

		//calls take damage for each type of bullet collided with
		if (other.gameObject.CompareTag ("pistolBullet")) 
		{
			other.gameObject.SetActive (false);
			takeDamage (20);
		}

		else if (other.gameObject.CompareTag ("sniperBullet")) 
		{
			other.gameObject.SetActive (false);
			takeDamage (50);
		}

		else if (other.gameObject.CompareTag ("smgBullet")) 
		{
			other.gameObject.SetActive (false);
			takeDamage (25);
		}

		else if (other.gameObject.CompareTag ("bazookaBullet")) 
		{
			other.gameObject.SetActive (false);
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