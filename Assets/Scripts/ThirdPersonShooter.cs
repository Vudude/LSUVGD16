using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.FirstPerson;

public class ThirdPersonShooter : MonoBehaviour {

    private MouseLook mouse;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


       mouse.LookRotation (transform, transform);

    }

}
