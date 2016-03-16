using UnityEngine;
using System.Collections;

public class SpitOutEnemy : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		shootTimer = 2;
	}
	
	public Rigidbody projectile;

	public float shootTimer = 0;


	// Update is called once per frame
	void Update () 
	{

		if (shootTimer > 0) 
		{
			shootTimer = shootTimer - Time.deltaTime;
		}

		else 
		{
			Rigidbody clone;
			clone = Instantiate (projectile, new Vector3 (transform.position.x + 0.95f, (transform.position.y + 0.5f), transform.position.z), transform.rotation) as Rigidbody;
			clone.velocity = transform.TransformDirection (Vector3.forward * 10);
			shootTimer = 2;
		}
			

	}
}



