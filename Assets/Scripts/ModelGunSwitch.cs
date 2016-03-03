using UnityEngine;
using System.Collections;

public class ModelGunSwitch : MonoBehaviour 
{

	public Mesh replacementMesh;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}



	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("ability")) 
		{
			gameObject.GetComponent<MeshFilter> ().mesh = replacementMesh;
		}
	}
}
