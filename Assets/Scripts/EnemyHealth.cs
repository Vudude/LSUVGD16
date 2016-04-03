using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

	//the current health of the enemy
	public int currentHealth = 100;

    private bool beingEaten = false;

	// initializes the starting enemy health to be a 100
	void Start () 
	{
	}

	//function that calculates an enemies' new health. Takes an integer that represents merby's damage
	//if the enemy reaches zero health, then it is destroyed
	void OnTriggerEnter(Collider other)
	{
		
        Debug.Log("collision");
		if (other.gameObject.CompareTag ("Player") && beingEaten)
        {
            Destroy(gameObject);
            //other.SendMessage(Grant Weapon Method);
        } 

		//calls take damage for each type of bullet collided with

		else if (other.gameObject.CompareTag ("merbyPistolBullet")) 
		{
            Debug.Log("Pistol Hit");
			Destroy(other.gameObject);
			takeDamage (33);
		}

		else if (other.gameObject.CompareTag ("merbySniperBullet")) 
		{
			Destroy(other.gameObject);
			takeDamage (100);
		}

		else if (other.gameObject.CompareTag ("merbySMGBullet")) 
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

    public void getEaten()
    {
        gameObject.GetComponent<Collider>().isTrigger = true;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        beingEaten = true;
    }
}
