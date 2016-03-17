﻿using UnityEngine;
using System.Collections;

public class TestProjectile : MonoBehaviour {

    public GameObject prefab;
    private Ray ray;
    private Vector3 lookPos;
    private RaycastHit hit;
    public float aimError = .00001f;
    public float defaultAimDistance = 1000f;
    public float projectileSpeed = 9999;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
            Debug.DrawRay(transform.position, transform.forward);
		if (Input.GetButtonDown("Fire1"))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
                lookPos = hit.point;
            else
            {
                lookPos = Input.mousePosition;
                lookPos.z = defaultAimDistance;
                lookPos = Camera.main.ScreenToWorldPoint(lookPos);
            }

            GameObject projectile = Instantiate(prefab, transform.position + transform.forward, Quaternion.identity) as GameObject;
            projectile.transform.LookAt(lookPos);
            
            projectile.transform.eulerAngles = new Vector3(projectile.transform.eulerAngles.x + Random.Range(-aimError, aimError),
                                                            projectile.transform.eulerAngles.y + Random.Range(-aimError, aimError),
                                                            projectile.transform.eulerAngles.z);

            projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * projectileSpeed);
            //Destroy(projectile, 3.0f);
        }
	}
}