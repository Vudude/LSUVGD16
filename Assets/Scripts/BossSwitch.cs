using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BossSwitch : MonoBehaviour {

	public void OnTriggerEnter(Collider co)
	{
		if (co.gameObject.CompareTag("Player"))
		{
			Debug.Log ("ya hit it");
			SceneManager.LoadScene("Scenes/bosslevel.0");
			//SceneManager.LoadScene("Scenes/EndScreen");
		}
	}
}