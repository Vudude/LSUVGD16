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
	
	}

	public void playAgain()
	{ 
		SceneManager.LoadScene("Scenes/tutorial2");
	}
}
