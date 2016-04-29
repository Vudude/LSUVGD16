using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour {

	int health = 100;

	public void OnTriggerEnter(Collider co)
	{
		if (co.gameObject.CompareTag("merbyBazookaBullet"))
		{
			Debug.Log ("hit the tree babeeee");
			Destroy (co.gameObject);
			health = health - 10;
			if (health == 0)
				SceneManager.LoadScene ("Scenes/EndScreen");
		}

	}
}
