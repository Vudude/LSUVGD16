using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour 
{
	public Canvas quitMenu;
	public Button startText;
	public Button exitText;

	// Use this for initialization
	void Start () 
	{
		quitMenu = quitMenu.GetComponent<Canvas>();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartLevel () //this function will be used on our Play button

	{
		SceneManager.LoadScene ("Scenes/tutorial2"); //this will load our first level from our build settings. "1" is the second scene in our game

	}

	public void ExitGame () //This function will be used on our "Exit" button 

	{
		Application.Quit(); //this will quit our game. Note this will only work after building the game

	}
}		