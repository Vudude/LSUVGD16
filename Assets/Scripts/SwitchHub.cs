using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchHub : MonoBehaviour {

    public void OnTrigger(Collider co)
    {
        if (co.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("hub1.0");
        }
    }
}
