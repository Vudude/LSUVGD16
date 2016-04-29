using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchLevel2 : MonoBehaviour {

	public void OnTriggerEnter(Collider co)
	{
		if (co.gameObject.CompareTag("Player"))
		{
			Debug.Log ("Level 2 switch");
			SceneManager.LoadScene("Scenes/level2.1");
		}
	}
}
