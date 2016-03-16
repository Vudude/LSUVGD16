using UnityEngine;
using System.Collections;

public class wallScript : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("merbyPistolBullet"))
        {
            Destroy(other.gameObject);
        }

        else if (other.gameObject.CompareTag("merbySniperBullet"))
        {
            Destroy(other.gameObject);
        }

        else if (other.gameObject.CompareTag("merbySmgBullet"))
        {
            Destroy(other.gameObject);
        }

        else if (other.gameObject.CompareTag("merbyBazookaBullet"))
        {
            Destroy(other.gameObject);
        }

        else if (other.gameObject.CompareTag("merbySpittingProjectile"))
        {
            Destroy(other.gameObject);
        }
    }
}
