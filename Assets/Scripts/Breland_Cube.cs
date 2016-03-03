using UnityEngine;
using System.Collections;

public class Breland_Cube : MonoBehaviour {

    //private MouseLook m_MouseLook;

    public Texture2D crosshair;

    public float moveSpeed = 5f;
    public float strafeSpeed = 3f;

    public float lookSens = 100f;

    public Ray playerRay;

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
            //transform.Translate(Vector3.left * strafeSpeed * Time.deltaTime);
            transform.Rotate(-Vector3.up * 10f * Time.deltaTime);
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            //transform.Translate(Vector3.right * strafeSpeed * Time.deltaTime);
            transform.Rotate(Vector3.up * 10f * Time.deltaTime);

        playerRay = new Ray(transform.position, transform.forward * 100f);
        Debug.DrawRay(transform.position, transform.forward * 100f);
    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect((Screen.width - crosshair.width) / 2, (Screen.height - crosshair.height) / 2, crosshair.width, crosshair.height), crosshair);
    }
    
}