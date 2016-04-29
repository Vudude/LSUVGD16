using UnityEngine;
using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class Ammo : MonoBehaviour 
{

	public int ammoCount = 0;
	//Rect ammoLabel = new Rect(120,160,160,160);
	Rect ammoLabel = new Rect(Screen.width/21, Screen.height/9, Screen.width, Screen.height);
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
		ammoLabel = new Rect(Screen.width/21, Screen.height/9, Screen.width, Screen.height);
		//Debug.Log ("I hate myself" + ammoCount);
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

	public void beserkPistolTrigger()
	{
		//Debug.Log ("made it to beserkPistolTrigger");
		//Debug.Log (ammoCount);
		ammoCount = 1;
		//Debug.Log (ammoCount);
		pistol.gameObject.SetActive (true);
	}

	public void beserkSMGTrigger()
	{
		ammoCount = 1;
		smg.gameObject.SetActive (true);
	}

	public void beserkSniperTrigger()
	{
		ammoCount = 1;
		sniper.gameObject.SetActive (true);
	}

	public void beserkBazookaTrigger()
	{
		ammoCount = 1;
		bazooka.gameObject.SetActive (true);
	}

	public void pistolTrigger()
	{
		ammoCount = 15;
		pistol.gameObject.SetActive (true);
	}

	public void smgTrigger()
	{
		ammoCount = 10;
		smg.gameObject.SetActive (true);
	}

	public void sniperTrigger()
	{
		ammoCount = 5;
		sniper.gameObject.SetActive (true);
	}

	public void bazookaTrigger()
	{
		ammoCount = 5;
		bazooka.gameObject.SetActive (true);
	}
	/*
	void OnTriggerEnter(Collider other)
	{
		//if merby gets an ability, health becomes 100
		//resets newAbility at the end
		if (other.gameObject.CompareTag ("pistolEnemy") && other.GetComponent<EnemyAI> ().is_Berserk == false) //or pistolEnemy
		{
			ammoCount = 15;
			pistol.gameObject.SetActive (true);

		}

		else if (other.gameObject.CompareTag ("smgEnemy") && other.GetComponent<EnemyAI> ().is_Berserk == false) 
		{
			ammoCount = 10;
			smg.gameObject.SetActive (true);
		}

		else if (other.gameObject.CompareTag ("sniperEnemy") && other.GetComponent<EnemyAI> ().is_Berserk == false) 
		{
			ammoCount = 5;
			sniper.gameObject.SetActive (true);
		}

		else if (other.gameObject.CompareTag ("bazookaEnemy") && other.GetComponent<EnemyAI> ().is_Berserk == false) 
		{
			ammoCount = 5;
			bazooka.gameObject.SetActive (true);
		}

	}
	*/


	public void OnGUI()
	{
		var style = new GUIStyle("label");
		style.fontSize = 25;
		GUI.contentColor = Color.magenta;
		GUI.Label (ammoLabel, "Ammo: " + ammoCount, style);  
	}


	public void removeWeapon()
	{
		//Debug.Log ("Did this happen?");
		pistol.gameObject.SetActive (false);
		bazooka.gameObject.SetActive (false);
		sniper.gameObject.SetActive (false);
		smg.gameObject.SetActive (false);
		GetComponent<HealthTestv2> ().currentHealth = 0;
		ammoCount = 0;
		GetComponent<HealthTestv2> ().hasAbility = false;

	}
}
