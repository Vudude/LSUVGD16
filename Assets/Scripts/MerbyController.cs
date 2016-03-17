﻿using UnityEngine;
using System.Collections;

public class MerbyController : MonoBehaviour {



    public float moveSpeed = 5f;
    public float strafeSpeed = 3f;

    public float lookSens = 100f;
    public float jumpSpeed = 5;


    void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;

    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Break();
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(Vector3.left * strafeSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector3.right * strafeSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * jumpSpeed * Time.deltaTime, Space.World);
        }

        transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y, 0);
    }
    
}