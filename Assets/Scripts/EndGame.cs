using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

    public void OnTriggerEnter(Collider co)
    {
        if (co.gameObject.CompareTag("Player"))
        {
            Application.Quit();
        }
    }
}
