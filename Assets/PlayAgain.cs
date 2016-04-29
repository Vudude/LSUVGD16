using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		playAgain ();
	}

	public void playAgain()
	{ 
		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
			Debug.Break();
		}

		if (Input.GetKey (KeyCode.W)) {
			SceneManager.LoadScene ("Scenes/tutorial2");
		}
	}
}
