using UnityEngine;
using System.Collections;

public class TestProjectileCollision : MonoBehaviour {

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col);
        /*rb.useGravity = false;
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;*/
        Destroy(gameObject);
    }
}
