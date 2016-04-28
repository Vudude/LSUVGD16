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
			Debug.Log ("bazooka bullet hit");
            Destroy(other.gameObject);
        }

        else if (other.gameObject.CompareTag("spittingProjectile"))
        {
            Destroy(other.gameObject);
        }

		else if (other.gameObject.CompareTag("merbySniperBullet"))
		{
			Destroy(other.gameObject);
		}

		else if (other.gameObject.CompareTag("merbyPistolBullet"))
		{
			Destroy(other.gameObject);
		}

		else if (other.gameObject.CompareTag("merbySMGBullet"))
		{
			Destroy(other.gameObject);
		}

		else if (other.gameObject.CompareTag("merbyBazookaBullet"))
		{
			Destroy(other.gameObject);
		}
    }
}
