﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.ThirdPerson;

public class HealthTestv2 : MonoBehaviour {


	public GameObject healthBar;

	public bool abilityHit = false;

	//the player's starting health upon getting an ablility
	public int abilityHealth = 50;

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

	public float invincibleTimer = 1;

	private AudioSource source;

	public AudioClip pickupSound;

	public AudioClip damageSound;



	//box for health
	Rect healthLabel = new Rect(Screen.width/21, Screen.height/15, Screen.width, Screen.height);
	//Rect healthLabel = new Rect(0, 0, 120, 120);


	public void Awake()
	{
		source = GetComponent<AudioSource>();
	}

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

	public void ammoSystem()
	{

	}

	//function that calculates merby's new health. Takes an integer that represents the gun's damage
	//if you take damage and your health is zero, you die
	//if you take damage and your health is not zero, subtract the health by damage taken (caps at zero)
	//if damage is greater than your health, health becomes zero
	//resets takeDamage at the end
	//displays updated version of current health
	public void takeDamage(int damage)
	{
		source.PlayOneShot (damageSound, 0.5f);

		if (hasInvincibility == false) 
		{
			hasInvincibility = true;
			invincibleTimer = 1;

			if (currentHealth == 0) 
			{
				gameObject.SetActive (false);
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);

			}
			else if (damage >= currentHealth) 
			{
				currentHealth = 0;
				hasPistolAbility = false;
				hasBazookaAbility = false;
				hasSMGAbility = false;
				hasSniperAbility = false;
				hasAbility = false;
				GetComponent<Ammo> ().ammoCount = 0;
			} 

			else
				currentHealth = currentHealth - damage;

			barDamage ();
		}


	}

	//creates the display for merby's health
	public void OnGUI()
	{
		var style = new GUIStyle("label");
		style.fontSize = 25;
		GUI.contentColor = Color.magenta;
		GUI.Label (healthLabel, "Health: " + currentHealth, style);  

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

		healthLabel = new Rect(Screen.width/21, Screen.height/15, Screen.width, Screen.height);

		if (invincibleTimer > 0)
			invincibleTimer = invincibleTimer - Time.deltaTime;
		else
			hasInvincibility = false;
	}

	void OnTriggerEnter(Collider other)
	{	
		//Debug.Log ("collision happened");

		//if merby gets an ability, health becomes 100
		//resets newAbility at the end
		//FIXME change according to multiple abilities
		//if (other.gameObject.CompareTag ("ability")) 

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

		if (other.gameObject.GetComponent<EnemyAI> ().is_Berserk == true && other.gameObject.CompareTag ("pistolEnemy") && hasAbility == false && Input.GetKey (KeyCode.E)) 
		{
			//Debug.Log ("made it to Beserk hit you");
			Destroy (other.gameObject);
			currentHealth = 25;
			GetComponent<Ammo> ().beserkPistolTrigger ();
			hasPistolAbility = true;
			hasAbility = true;
			barDamage ();

			abilityHit = true;
			source.PlayOneShot (pickupSound, 0.5f);
		}

		if (other.gameObject.GetComponent<EnemyAI> ().is_Berserk == true && other.gameObject.CompareTag ("smgEnemy") && hasAbility == false && Input.GetKey (KeyCode.E)) 
		{
			Destroy (other.gameObject);
			currentHealth = 25;
			hasSMGAbility = true;
			hasAbility = true;
			barDamage ();

			GetComponent<Ammo> ().beserkSMGTrigger ();
			abilityHit = true;
			source.PlayOneShot (pickupSound, 0.5f);
		}

		else if (other.gameObject.GetComponent<EnemyAI> ().is_Berserk == true && other.gameObject.CompareTag ("sniperEnemy") && hasAbility == false && Input.GetKey (KeyCode.E)) 
		{
			Destroy (other.gameObject);
			currentHealth = 25;
			hasSniperAbility = true;
			hasAbility = true;
			barDamage ();

			GetComponent<Ammo> ().beserkSniperTrigger ();
			abilityHit = true;
			source.PlayOneShot (pickupSound, 0.5f);
		}

		else if (other.gameObject.GetComponent<EnemyAI> ().is_Berserk == true && other.gameObject.CompareTag ("bazookaEnemy") && hasAbility == false && Input.GetKey (KeyCode.E)) 
		{
			Destroy (other.gameObject);
			currentHealth = 25;
			hasBazookaAbility = true;
			hasAbility = true;
			barDamage ();

			GetComponent<Ammo> ().beserkBazookaTrigger ();
			abilityHit = true;
			source.PlayOneShot (pickupSound, 0.5f);
		}


		if (other.gameObject.CompareTag ("pistolEnemy") && hasAbility == false && Input.GetKey (KeyCode.E)) 
		{
			//Debug.Log ("pistol enemy collision happened");
			Destroy (other.gameObject);
			currentHealth = abilityHealth;
			hasPistolAbility = true;
			hasAbility = true;
			barDamage ();

			GetComponent<Ammo> ().pistolTrigger ();
			source.PlayOneShot (pickupSound, 0.5f);

		} 

		else if (other.gameObject.CompareTag ("smgEnemy") && hasAbility == false && Input.GetKey (KeyCode.E)) 
		{
			Destroy (other.gameObject);
			currentHealth = abilityHealth;
			hasSMGAbility = true;
			hasAbility = true;
			barDamage ();

			GetComponent<Ammo> ().smgTrigger ();
			source.PlayOneShot (pickupSound, 0.5f);
		} 

		else if (other.gameObject.CompareTag ("sniperEnemy") && hasAbility == false && Input.GetKey (KeyCode.E)) 
		{
			Destroy (other.gameObject);
			currentHealth = abilityHealth;
			hasSniperAbility = true;
			hasAbility = true;
			barDamage ();

			GetComponent<Ammo> ().sniperTrigger ();
			source.PlayOneShot (pickupSound, 0.5f);
		} 

		else if (other.gameObject.CompareTag ("bazookaEnemy") && hasAbility == false && Input.GetKey (KeyCode.E)) 
		{
			Destroy (other.gameObject);
			currentHealth = abilityHealth;
			hasBazookaAbility = true;
			hasAbility = true;
			barDamage ();

			GetComponent<Ammo> ().bazookaTrigger ();
			source.PlayOneShot (pickupSound, 0.5f);
		} 

		else 
		{
			if (other.GetComponent<EnemyAI> ().is_Berserk == true && (other.gameObject.CompareTag ("pistolEnemy") || other.gameObject.CompareTag ("smgEnemy") || other.gameObject.CompareTag ("sniperEnemy") || other.gameObject.CompareTag ("bazookaEnemy"))) 
			{

				//Debug.Log ("PLS DONT ACTIVATE");
				if (abilityHit == false)
					takeDamage (100);
				else
					abilityHit = false;
				//GetComponent<Ammo> ().ammoCount = 0;
			}
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