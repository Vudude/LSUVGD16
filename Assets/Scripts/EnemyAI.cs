using UnityEngine;
using System.Collections;
namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]

    public class EnemyAI : MonoBehaviour 
    {

	    private NavMeshAgent agent;
	    private ThirdPersonCharacter character;
	    public Transform player;
	    public float fov = 90;
	    public float shootDistance = 10;
        public float RotationSpeed = 5;
        public float moveSpeed = 2;
        public float berserkSpeed = 5;
	    private Transform lastSeen;
	    private float shootTimer;
        private Quaternion _lookRotation;
        private Vector3 _direction;
        private bool is_Berserk = false;
        private bool is_Eaten = false;

        //for animation purposes (not yet used)
	    private bool is_Shooting = false;
	    private bool is_Moving = false;

	    //temporary setters for variables (to be initialized depending on weapon)
	    public Rigidbody projectile;
	    public float projectileSpeed;
	    public float gunTimer;
        public int ammo = 10;

	    // Use this for initialization
	    void Start () 
	    {
		    agent = GetComponentInChildren<NavMeshAgent>();
		    character = GetComponent<ThirdPersonCharacter>();

		    agent.updateRotation = true;
		    agent.updatePosition = true;
            agent.speed = moveSpeed;
		
		    lastSeen = transform;

		    //initial setup for timer (to be initialized depending on weapon)
		    shootTimer = gunTimer;

	    }

        private void Update()
        {
            shootTimer -= Time.deltaTime;

            if (LineOfSight(player))
            {
                lastSeen = player;
                agent.SetDestination(lastSeen.position);

                if (agent.remainingDistance <= shootDistance)
                {
                    if (is_Berserk)
                    {
                        agent.stoppingDistance = 0;
                        agent.speed = berserkSpeed;

                        //some kind of attacking function
                        //gameObject.GetComponent<Collider>().isTrigger = true;
                    }
                    else {
                        agent.stoppingDistance = shootDistance;

                        //rotate to player if in range
                        _direction = (lastSeen.position - transform.position).normalized;
                        _lookRotation = Quaternion.LookRotation(_direction);
                        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);

                        //shoot on timer
                        if (shootTimer <= 0)
                            shoot();
                    }
                }
            }
            else {
                //move to last seen
                agent.stoppingDistance = 1;
            }
        }

        //checks if player is in field of view
        private RaycastHit hit;
	    private bool LineOfSight (Transform targetView) {
		    if (Vector3.Angle(targetView.position - transform.position, transform.forward) <= fov && 
				    Physics.Linecast(transform.position + transform.forward, targetView.position, out hit) && hit.collider.transform == targetView) {
			    return true;
		    }
		    return false;
	    }

	    private void shoot() {
		    Rigidbody clone;
            clone = Instantiate(projectile, transform.position + transform.forward + Vector3.up, transform.rotation) as Rigidbody;
            clone.AddForce(clone.transform.forward * projectileSpeed);
            shootTimer = gunTimer;
            if (ammo-- <= 0) is_Berserk = true;
	    }
    
	    private void setWeapon(GameObject weapon) {
		    //if for each weapon
	    }


        public void getEaten()
        {
            gameObject.GetComponent<Collider>().isTrigger = true;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            is_Eaten = true;
        }
    }
}
