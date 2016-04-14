using UnityEngine;
using System.Collections;

public class MerbyController : MonoBehaviour {



    public float moveSpeed = 5f;
    public float strafeSpeed = 3f;

    public float lookSens = 100f;
    public float jumpSpeed = 5;
    private bool isGrounded = true;


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

        //if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        //    GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * moveSpeed * Time.deltaTime);
        //if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        //    GetComponent<Rigidbody>().MovePosition(transform.position - transform.forward * moveSpeed * Time.deltaTime);
        //if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        //    GetComponent<Rigidbody>().MovePosition(transform.position - transform.right * moveSpeed * Time.deltaTime);
        //if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        //    GetComponent<Rigidbody>().MovePosition(transform.position + transform.right * moveSpeed * Time.deltaTime);

        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movement = movement + transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement = movement - transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement = movement - transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement = movement + transform.right;
        }

        GetComponent<Rigidbody>().MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);

        CheckGroundStatus();

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(transform.up * jumpSpeed);
            //GetComponent<Rigidbody>().AddExplosionForce(jumpSpeed, transform.position, 5.0f, 3.0f);
        }

        transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y, 0);
    }

    void OnCollisionEnter(Collision collision)
    {

    }

    void CheckGroundStatus()
    {
        //RaycastHit hitInfo;
        Vector3 center = transform.TransformPoint(GetComponent<CapsuleCollider>().center);
        float CCHeightDiv2 = GetComponent<CapsuleCollider>().height / 2;
        // helper to visualise the ground check ray in the scene view
        Debug.DrawLine(center, new Vector3(center.x, center.y - CCHeightDiv2, center.z));
        
        // 0.1f is a small offset to start the ray from inside the character
        // it is also good to note that the transform position in the sample assets is at the base of the character
        if (Physics.Raycast(center, Vector3.down, CCHeightDiv2 +.1f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

}