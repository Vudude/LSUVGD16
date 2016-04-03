using UnityEngine;
using System.Collections;
namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]

public class EnemyAI : MonoBehaviour 
{

	public NavMeshAgent agent;
	public ThirdPersonCharacter character;
	public Transform player;
	public double fov = 90;
	public double shootDistance = 10;

	private bool is_Shooting = false;
	private bool is_Moving = false;

	private Transform lastSeen;
	private float shootTimer;

	//temporary setters for variables
	public GameObject projectile;
	public float projectileSpeed;
	public float gunTimer;

	// Use this for initialization
	void Start () 
	{
		agent = GetComponentInChildren<NavMeshAgent>();
		character = GetComponent<ThirdPersonCharacter>();

		agent.updateRotation = false;
		agent.updatePosition = false; 
		
		lastSeen = transform;

		//initial setup for timer
		shootTimer = gunTimer;

	}


        private void Update()
        {
		agent.SetDestination(lastSeen.position);

		shootTimer -= Time.deltaTime;

		if (LineOfSight(player)) {
			lastSeen = player;

			if (agent.remainingDistance <= shootDistance) {
				//shooting behavior
				while (shootTimer <= 0) {
					shootTarget(lastSeen);	
				}
			}
			else {
				//move close enough to shoot
			}
			
		}
		else {
			//move to last seen
		}



        }

	private RaycastHit hit;
	private bool LineOfSight (Transform targetView) {
		if (Vector3.Angle(targetView.position - transform.position, transform.forward) <= fov && 
				Physics.Linecast(transform.position, targetView.position, out hit) && hit.collider.transform == targetView) { 
			return true;
		}
		return false;
	}

	private void shootTarget(Transform targetShoot) {
		GameObject clone;
		clone = Instantiate(projectile, transform.position + transform.forward, Quaternion.identity) as GameObject;
		projectile.transform.LookAt(targetShoot);
		projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * projectileSpeed);

		shootTimer = gunTimer;
	}

	private void setWeapon(GameObject weapon) {
		//if for each weapon
	}

}
}
