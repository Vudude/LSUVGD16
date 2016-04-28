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
		private Transform player;
	    public float fov = 90;
	    public float shootDistance = 10;
        public float RotationSpeed = 5;
        public float moveSpeed = 2;
        public float berserkSpeed = 5;
	    private Transform lastSeen;
	    private float shootTimer;
        private Quaternion _lookRotation;
        private Vector3 _direction;
        public bool is_Berserk = false;
        private bool is_Eaten = false;

        //for animation purposes (not yet used)
	    private bool is_Shooting = false;
	    private bool is_Moving = false;
        
        //Animation Amendment
        Animator anim;
        int idleHash = Animator.StringToHash("Idle");
        int runHash = Animator.StringToHash("Run");
        private Vector3 deltaPosition;

        //temporary setters for variables (to be initialized depending on weapon)
        public Rigidbody projectile;
	    public float projectileSpeed = 999;
	    public float gunTimer = 3f;
        public int ammo = 10;
		public string weapon = "pistol";

		private AudioSource source;

		public AudioClip pistolSound;
		public AudioClip smgSound;
		public AudioClip sniperSound;
		public AudioClip bazookaSound;

		private AudioClip Ssound;

		public void Awake()
		{
			source = GetComponent<AudioSource>();
		}


	    // Use this for initialization
	    void Start () 
	    {
            anim = GetComponentInChildren<Animator>();
            deltaPosition = transform.position;

            agent = GetComponentInChildren<NavMeshAgent>();
		    character = GetComponent<ThirdPersonCharacter>();
		    
		    GameObject playerObject = GameObject.FindWithTag("Player") as GameObject;
		    player = playerObject.transform;

		    agent.updateRotation = true;
		    agent.updatePosition = true;
            agent.speed = moveSpeed;
		
		    lastSeen = transform;

		    //initial setup for timer (to be initialized depending on weapon)
		    shootTimer = gunTimer;
			setWeapon (weapon);

	    }

        public void Update()
        {
            shootTimer -= Time.deltaTime;

            AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
            if (deltaPosition == transform.position)
                anim.Play(idleHash);
            else
                anim.Play(runHash);
            deltaPosition = transform.position;

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

						if (weapon == "pistol") {
							Ssound = pistolSound;
						}
						else if (weapon == "smg") {
							Ssound = smgSound;
						}
						else if (weapon == "sniper") {
							Ssound = sniperSound;
						}
						else if (weapon == "bazooka") {
							Ssound = bazookaSound;
						}
						//Debug.Log (Ssound);

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

	    public void shoot() {
		    Rigidbody clone;
			//Ssound = pistolSound;
			//Debug.Log (Ssound);
			source.PlayOneShot (Ssound, 1.0f);
            clone = Instantiate(projectile, transform.position + transform.forward + Vector3.up, transform.rotation) as Rigidbody;
            clone.AddForce(clone.transform.forward * projectileSpeed);
            shootTimer = gunTimer;
            if (ammo-- <= 0) is_Berserk = true;
	    }
    
		public void setWeapon(string weapon) 
		{
			if (weapon == "pistol") {
				ammo = 10;
				projectileSpeed = 1000;
				gunTimer = 1f;
				shootDistance = 20;
				projectile = GameObject.Find ("pistolBullet").GetComponent<Rigidbody>();
				Ssound = pistolSound;
			}

			else if (weapon == "smg") {
				ammo = 30;
				projectileSpeed = 1500;
				gunTimer = 0.3f;
				shootDistance = 20;
				projectile = GameObject.Find ("smgBullet").GetComponent<Rigidbody>();
				Ssound = smgSound;
			}

			else if (weapon == "sniper") {
				ammo = 10;
				projectileSpeed = 2000;
				gunTimer = 5f;
				shootDistance = 40;
				projectile = GameObject.Find ("sniperBullet").GetComponent<Rigidbody>();
				Ssound = sniperSound;
			}

			else if (weapon == "bazooka") {
				ammo = 5;
				projectileSpeed = 1000;
				gunTimer = 3f;
				shootDistance = 40;
				projectile = GameObject.Find ("bazookaBullet").GetComponent<Rigidbody>();
				Ssound = bazookaSound;
			}

			//Debug.Log (Ssound);

				//projectileSpeed 
				//pstol= 1000;
				//bazooka = 1000
				//smg = 1500
				//sniper = 2000

				//ammo
				//pistol = 10
				//smg = 30
				//bazooka = 5
				//sniper = 10

				//rates
				//pistol = 1
				//smg 0.3
				//bazooka = 3
				//sniper = 5

				//shoot distamnce
				//pistol = 15
				//smg = 10
				//sniper = 40
				//bazooka = 
			
	    }


        public void getEaten()
        {
			is_Berserk = false;
            gameObject.GetComponent<Collider>().isTrigger = true;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            is_Eaten = true;
        }
		/*
		void OnTriggerEnter(Collider other)
		{

			if (other.gameObject.CompareTag ("Player") && is_Berserk == true) 
			{
				other.gameObject.GetComponent<HealthTestv2> ().takeDamage (100);
			} 
		}
		*/

    }
}
