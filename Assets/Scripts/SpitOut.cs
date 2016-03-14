using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class SpitOut: MonoBehaviour {

    public Rigidbody projectile;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if (Input.GetButtonDown("Fire2"))
        {
            Rigidbody clone;
            clone = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            clone.velocity = transform.TransformDirection(Vector3.forward * 10);
        }
	}
}
