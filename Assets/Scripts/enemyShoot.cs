using UnityEngine;
using System.Collections;

public class enemyShoot : MonoBehaviour {



	public float shootTimer = 0;
	public GameObject projectile;

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
			GameObject clone;
			clone = Instantiate (projectile, transform.position + transform.forward + Vector3.up, Quaternion.identity) as GameObject;
			clone.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * 100);
			shootTimer = 2;
		}
	}
}
