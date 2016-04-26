using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MerbyController : MonoBehaviour {

    Animator anim;
    int jumpHash = Animator.StringToHash("Jump");
    int idleHash = Animator.StringToHash("Idle");
    int walkHash = Animator.StringToHash("Walk");
    int eatHash = Animator.StringToHash("Eat");

    public float moveSpeed = 5f;
    public float strafeSpeed = 3f;

    public float lookSens = 100f;
    public float jumpSpeed = 5;
    private bool isGrounded = true;


    void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;

        anim = GetComponentInChildren<Animator>();

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

        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);


        Vector3 movement = Vector3.zero;

		if (Input.GetKey(KeyCode.M))
		{
			SceneManager.LoadScene ("Scenes/tutorial2");
		}
		if (Input.GetKey(KeyCode.K))
		{
			SceneManager.LoadScene ("Scenes/Level1.0");
		}

		if (Input.GetKey(KeyCode.L))
		{
			SceneManager.LoadScene ("Scenes/level2.1");
		}
		if (Input.GetKey(KeyCode.Slash))
		{
			SceneManager.LoadScene ("Scenes/level3");
		}
		if (Input.GetKey (KeyCode.Semicolon))
		{
			SceneManager.LoadScene ("Scenes/bosslevel.0");
		}

		if (Input.GetKey(KeyCode.F1))
		{
			movement = movement + transform.forward;
		}

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


        if (Input.GetKey(KeyCode.E))
        {
            anim.Play(eatHash);
            anim.SetBool("isEat", true);
        }
        else
            anim.SetBool("isEat", false);

        GetComponent<Rigidbody>().MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);

        CheckGroundStatus();

        if (isGrounded)
            anim.SetBool("isJump", false);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(transform.up * jumpSpeed);
            anim.Play(jumpHash);
            anim.SetBool("isJump", true);
        }

        if (movement == Vector3.zero)
            anim.Play(idleHash);
        else
            anim.Play(walkHash);

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