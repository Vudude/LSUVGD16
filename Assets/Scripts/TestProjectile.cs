using UnityEngine;
using System.Collections;

public class TestProjectile : MonoBehaviour {

    private GameObject prefab;
    private Ray ray;
    private Vector3 lookPos;
    private RaycastHit hit;
    public float aimError = .00001f;
    public float defaultAimDistance = 1000f;

	// Use this for initialization
	void Start () {
        prefab = Resources.Load("TestProjectile") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
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

            projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * 9999);
            Destroy(projectile, 3.0f);
        }
	}
}