using UnityEngine;
using System.Collections;

public class TestProjectile : MonoBehaviour {

    GameObject prefab;
	public GameObject merbyPistolBullet;
	public GameObject merbySMGBullet;
	public GameObject merbySniperBullet;
	public GameObject merbyBazookaBullet;
    private Ray ray;
    private Vector3 lookPos;
    private RaycastHit hit;
    public float aimError = .00001f;
    public float defaultAimDistance = 1000f;
    public float projectileSpeed = 9999;
	private AudioSource source;


	public AudioClip pistolSound;
	public AudioClip smgSound;
	public AudioClip bazookaSound;
	public AudioClip sniperSound;
	private AudioClip SSound;

	// Use this for initialization
	void Start () {
	}

	void Awake(){
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
            Debug.DrawRay(transform.position, transform.forward);
		if (Input.GetButtonDown("Fire1") && GetComponent<Ammo>().ammoCount > 0)
        {
			GetComponent<Ammo> ().ammoCount = GetComponent<Ammo>().ammoCount - 1;
			ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0.0f));
            if (Physics.Raycast(ray, out hit))
                lookPos = hit.point;
            else
            {
				lookPos = new Vector3(Screen.width/2,Screen.height/2,0.0f);
                lookPos.z = defaultAimDistance;
                lookPos = Camera.main.ScreenToWorldPoint(lookPos);
            }

			//prefab = merbyPistolBullet;
			if (GetComponent<HealthTestv2> ().hasPistolAbility == true) 
			{
				prefab = merbyPistolBullet;
				SSound = pistolSound;
			} 

			else if (GetComponent<HealthTestv2> ().hasSMGAbility == true) 
			
			{
				prefab = merbySMGBullet;
				SSound = smgSound;
			} 

			else if (GetComponent<HealthTestv2> ().hasSniperAbility == true) 
			{
				prefab = merbySniperBullet;
				SSound = sniperSound;
			}

			else if (GetComponent<HealthTestv2> ().hasBazookaAbility == true) 
			{
				prefab = merbyBazookaBullet;
				SSound = bazookaSound;
			}

            GameObject projectile = Instantiate(prefab, transform.position + transform.forward, Quaternion.identity) as GameObject;

            projectile.transform.LookAt(lookPos);
            
            projectile.transform.eulerAngles = new Vector3(projectile.transform.eulerAngles.x + Random.Range(-aimError, aimError),
                                                            projectile.transform.eulerAngles.y + Random.Range(-aimError, aimError),
                                                            projectile.transform.eulerAngles.z);

			source.PlayOneShot (SSound, 0.5f);

            projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * projectileSpeed);
            Destroy(projectile, 3.0f);
        }
	}
}