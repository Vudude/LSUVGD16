using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.FirstPerson;

public class Enemy : MonoBehaviour {

    private MouseLook mouse;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD:Assets/Scripts/Enemy.cs
	
	}

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
=======


       mouse.LookRotation (transform, transform);

    }

>>>>>>> master:Assets/Scripts/ThirdPersonShooter.cs
}
