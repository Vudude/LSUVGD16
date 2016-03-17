using UnityEngine;
using System.Collections;

public class wallScript : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pistolBullet"))
        {
            Destroy(other.gameObject);
        }

        else if (other.gameObject.CompareTag("sniperBullet"))
        {
            Destroy(other.gameObject);
        }

        else if (other.gameObject.CompareTag("smgBullet"))
        {
            Destroy(other.gameObject);
        }

        else if (other.gameObject.CompareTag("bazookaBullet"))
        {
            Destroy(other.gameObject);
        }

        else if (other.gameObject.CompareTag("spittingProjectile"))
        {
            Destroy(other.gameObject);
        }
    }
}
