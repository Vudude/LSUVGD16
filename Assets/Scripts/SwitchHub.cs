using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchHub : MonoBehaviour {

    public void OnTriggerEnter(Collider co)
    {
        if (co.gameObject.CompareTag("Player"))
        {
			Debug.Log ("Hub collider");
            SceneManager.LoadScene("Scenes/hub1.0");
        }
    }
}
