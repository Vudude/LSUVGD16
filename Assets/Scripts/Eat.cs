﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Eat : MonoBehaviour {
	public float speed = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (Input.GetKey(KeyCode.E) && GetComponent<HealthTestv2>().hasAbility == false)
        {
            RaycastHit hit;
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 backward = transform.TransformDirection(-Vector3.forward);
            
            if (Physics.Raycast(transform.position, forward, out hit))
            {
                //later change this into lerp
				hit.transform.gameObject.GetComponent<Rigidbody>().position = Vector3.MoveTowards(hit.transform.gameObject.GetComponent<Rigidbody>().position, transform.position, speed * Time.deltaTime);

                //also need to disable AI

                hit.transform.gameObject.SendMessage("getEaten");
            }
        }
	}

    
}
