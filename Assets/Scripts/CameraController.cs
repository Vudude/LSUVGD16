using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;

    //public Transform lookAt;

    private Camera cam;

    public float distance = 2.5f;
    public float height = 1.5f;
    private Vector3 heightVector;

    private void Start()
    {
        cam = Camera.main;
        heightVector = new Vector3(0f, height, 0f);
    }

    private void LateUpdate()
    {
        float xRotation = (Input.GetAxis("Mouse X"));
        float yRotation = (Input.GetAxis("Mouse Y"));

        transform.position = player.transform.position - player.transform.forward * distance + heightVector;
        transform.localRotation *= Quaternion.Euler(xRotation, yRotation, 0f);

        
    }
    
}
