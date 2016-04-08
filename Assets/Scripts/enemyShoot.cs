using UnityEngine;
using System.Collections;

public class enemyShoot : MonoBehaviour {



	public float shootTimer = 0;
	public Rigidbody projectile;
	private bool is_Eaten = false;

	// Use this for initialization
	void Start () 
	{
		shootTimer = 2;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (shootTimer > 0)
			shootTimer = shootTimer - Time.deltaTime;
		else 
		{
			Rigidbody clone;
			clone = Instantiate(projectile, transform.position + transform.forward + Vector3.up, transform.rotation) as Rigidbody;
			clone.velocity = transform.TransformDirection (Vector3.forward * 10);
			shootTimer = 2;
		}
	}

	public void getEaten()
	{
		gameObject.GetComponent<Collider>().isTrigger = true;
		gameObject.GetComponent<Rigidbody>().useGravity = false;
		is_Eaten = true;
	}
}
