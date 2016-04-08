using UnityEngine;
using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour 
{

	public int ammoCount = 0;
	Rect ammoLabel = new Rect(60,80,80,80);
	public Rigidbody projectile;
	public GameObject pistol;
	public GameObject sniper;
	public GameObject bazooka;
	public GameObject smg;

	// Use this for initialization
	void Start () 
	{
		pistol.gameObject.SetActive (false);
		bazooka.gameObject.SetActive (false);
		sniper.gameObject.SetActive (false);
		smg.gameObject.SetActive (false);

	}

	// Update is called once per frame
	void Update () 
	{

		if (ammoCount == 0) 
		{
			pistol.gameObject.SetActive (false);
			bazooka.gameObject.SetActive (false);
			sniper.gameObject.SetActive (false);
			smg.gameObject.SetActive (false);
			GetComponent<HealthTestv2> ().currentHealth = 0;
			GetComponent<HealthTestv2> ().hasAbility = false;
		}


		//***Nedded
		/*
		else if (Input.GetButtonDown("Fire1") && ammoCount > 0)
		{
			ammoCount = ammoCount - 1;
			Rigidbody clone;
			//Debug.Log ("SHOOT");
			clone = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
			clone.velocity = transform.TransformDirection(Vector3.forward * 10);
		}
		*/
		GUI.Label (ammoLabel, "Ammo: " + ammoCount, "color");

	}


	void OnTriggerEnter(Collider other)
	{
		//if merby gets an ability, health becomes 100
		//resets newAbility at the end
		if (other.gameObject.CompareTag ("pistolEnemy")) //or pistolEnemy
		{
			ammoCount = 15;
			pistol.gameObject.SetActive (true);

		}

		else if (other.gameObject.CompareTag ("smgEnemy")) 
		{
			ammoCount = 10;
			smg.gameObject.SetActive (true);
		}

		else if (other.gameObject.CompareTag ("sniperEnemy")) 
		{
			ammoCount = 5;
			sniper.gameObject.SetActive (true);
		}

		else if (other.gameObject.CompareTag ("bazookaEnemy")) 
		{
			ammoCount = 5;
			bazooka.gameObject.SetActive (true);
		}

	}


	public void OnGUI()
	{
		GUI.contentColor = Color.black;
		GUI.Label (ammoLabel, "Ammo: " + ammoCount, "color");  
	}


	public void removeWeapon()
	{
		pistol.gameObject.SetActive (false);
		bazooka.gameObject.SetActive (false);
		sniper.gameObject.SetActive (false);
		smg.gameObject.SetActive (false);
		GetComponent<HealthTestv2> ().currentHealth = 0;
	}
}
