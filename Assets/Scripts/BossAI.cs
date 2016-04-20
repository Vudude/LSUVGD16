using UnityEngine;
using System.Collections;

public class BossAI : MonoBehaviour {

	public float gunTimer = 2f;
    public float spawnTimer = 5;
    public GameObject[] spawnPoints;
	public Rigidbody projectile;
    public GameObject enemyPrefab;
    public GameObject player;

    public float rotationSpeed;


    private Quaternion _lookRotation;
    private Vector3 _direction;
    public float shootTimer;
    public float spawnTiming;
    public float projectileSpeed = 500;

	// Use this for initialization
	void Start () {

		shootTimer = gunTimer;
        spawnTiming = spawnTimer;
        spawnPoints = GameObject.FindGameObjectsWithTag("spawnPoint");
	
	}
	
	// Update is called once per frame
	void Update () {
		shootTimer -= Time.deltaTime;
		spawnTiming -= Time.deltaTime;

        if (shootTimer <= 0)
            Shoot();

        //look at player
        _direction = (player.transform.position - transform.position).normalized;
        Debug.Log(player.transform.position);
        _lookRotation = Quaternion.LookRotation(_direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * rotationSpeed);
	
        if (spawnTiming <= 0)
        {
            int random = (int) Random.value * 100 % spawnPoints.Length;
            SpawnEnemy(spawnPoints[random].transform);
        }
        
	}

	private void Shoot() {
		Rigidbody clone;
            	clone = Instantiate(projectile, transform.position + transform.forward + Vector3.up, transform.rotation) as Rigidbody;
            	clone.AddForce(clone.transform.forward * projectileSpeed);
        shootTimer = gunTimer;
	}

	private void SpawnEnemy(Transform spawn) {
		GameObject enemy;
        enemy = Instantiate(enemyPrefab, spawn.position, spawn.rotation) as GameObject;
        spawnTiming = spawnTimer;
	}
}
