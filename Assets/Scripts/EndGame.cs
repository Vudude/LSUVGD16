using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

    public void OnTriggerEnter(Collider co)
    {
        if (co.gameObject.CompareTag("Player"))
        {
			SceneManager.LoadScene("Scenes/level3");
        }
    }
}
