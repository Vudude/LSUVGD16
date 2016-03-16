using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchLevel1 : MonoBehaviour {

    public void OnTrigger(Collider co)
    {
        if (co.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("level1.0");
        }
    }
}
