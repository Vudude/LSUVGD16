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
		Debug.Log ("State of merby abilty: " + GetComponent<HealthTestv2> ().hasAbility);
		if (Input.GetKey("q") && GetComponent<HealthTestv2>().hasAbility)
        {
            Rigidbody clone;
            clone = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            clone.velocity = transform.TransformDirection(Vector3.forward * 10);
			GetComponent<Ammo> ().removeWeapon ();
        }
	}
}
