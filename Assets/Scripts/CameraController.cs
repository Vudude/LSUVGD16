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
        
        transform.position = player.transform.position - player.transform.forward * distance + heightVector;
        transform.rotation = player.transform.rotation * Quaternion.Euler(10f, 0f, 0f);
    }
    
}
