using UnityEngine;
using System.Collections;

public class BossAI : MonoBehaviour {

	public float gunTimer = 2f;
	public GameObject enemySpawn;
	public Rigidbody projectile;

	private float shootTimer;
	// Use this for initialization
	void Start () {

		shootTimer = gunTimer;
	
	}
	
	// Update is called once per frame
	void Update () {
		shootTimer -= Time.deltaTime;


		ShootCircle();
	
	}

	private void ShootCircle() {
		Shoot(transform.forward);
		Shoot(-transform.forward);
		Shoot(-transform.right);
		Shoot(transform.right);
		Shoot(transform.forward * .25);
		Shoot(-transform.forward * .25);
		Shoot(-transform.right * .25);
		Shoot(transform.right + .25);
            	shootTimer = gunTimer;
	}

	private void Shoot(Vector3 direction) {
		Rigidbody clone;
            	clone = Instantiate(projectile, transform.position + direction + Vector3.up, transform.rotation) as Rigidbody;

            	clone.AddForce(clone.transform.forward * projectileSpeed);
	}

	private void SpawnEnemy(Transform[] spawnPositions) {
		for (int i = 0; i < spawnPositions.length; i++) {
			GameObject enemy;
			enemy = Instantiate(enemySpawn, spawnPositions[i].position, spawnPositions.rotation) as GameObject;
		}
	}
}
