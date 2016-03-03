using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

	//the current health of the enemy
	public int currentHealth;

	// initializes the starting enemy health to be a 100
	void Start () 
	{
		currentHealth = 100;
	}

	//function that calculates an enemies' new health. Takes an integer that represents merby's damage
	//if the enemy reaches zero health, then it is destroyed
	void OnTriggerEnter(Collider other)
	{
		
		//calls take damage for each type of bullet collided with
		if (other.gameObject.CompareTag ("merbyPistolBullet")) 
		{
			Destroy(other.gameObject);
			takeDamage (33);
		}

		else if (other.gameObject.CompareTag ("merbySniperBullet")) 
		{
			Destroy(other.gameObject);
			takeDamage (100);
		}

		else if (other.gameObject.CompareTag ("merbySmgBullet")) 
		{
			Destroy(other.gameObject);
			takeDamage (34);
		}

		else if (other.gameObject.CompareTag ("merbyBazookaBullet")) 
		{
			Destroy(other.gameObject);
			takeDamage (100);
		}

		else if (other.gameObject.CompareTag ("merbySpittingProjectile")) 
		{
			Destroy(other.gameObject);
			takeDamage (100);
		}
	}

	//a function that calculates the enemies new health after taking damage
	public void takeDamage(int damage)
	{
		currentHealth = currentHealth - damage;
			if (currentHealth <= 0)
			gameObject.SetActive (false);
	}

}
