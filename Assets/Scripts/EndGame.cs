using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

    public void OnTrigger(Collider co)
    {
        if (co.gameObject.CompareTag("Player"))
        {
            Application.Quit();
        }
    }
}
