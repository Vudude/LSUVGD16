using UnityEngine;
using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour 
{

	int ammoCount = 0;
	Rect ammoLabel = new Rect(60,80,80,80);
	public GameObject projectile;
	public GameObject gun;

	// Use this for initialization
	void Start () 
	{
		gun.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () 
	{

		if (ammoCount == 0) 
		{
			gun.gameObject.SetActive (false);
		}


		if (Input.GetButtonDown("Fire1") && ammoCount > 0)
		{
			ammoCount = ammoCount - 1;
			Rigidbody clone;
			clone = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
			clone.velocity = transform.TransformDirection(Vector3.forward * 10);
			//ammoCount = ammoCount - 1;
		}
		GUI.Label (ammoLabel, "Ammo: " + ammoCount, "color");

	}


	void OnTriggerEnter(Collider other)
	{
		//if merby gets an ability, health becomes 100
		//resets newAbility at the end
		if (other.gameObject.CompareTag ("pistolEnemy")) //or pistolEnemy
		{
			ammoCount = 15;
			gun.gameObject.SetActive (true);

		}

		else if (other.gameObject.CompareTag ("smgEnemy")) 
		{
			ammoCount = 10;
			gun.gameObject.SetActive (true);
		}

		else if (other.gameObject.CompareTag ("sniperEnemy")) 
		{
			ammoCount = 5;
			gun.gameObject.SetActive (true);
		}

		else if (other.gameObject.CompareTag ("bazookaEnemy")) 
		{
			ammoCount = 5;
			gun.gameObject.SetActive (true);
		}

	}


	public void OnGUI()
	{
		GUI.contentColor = Color.black;
		GUI.Label (ammoLabel, "Ammo: " + ammoCount, "color");  
	}
}
