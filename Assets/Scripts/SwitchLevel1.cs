using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchLevel1 : MonoBehaviour {

    public void OnTriggerEnter(Collider co)
    {
        if (co.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Scenes/Level1.0");
        }
    }
}
