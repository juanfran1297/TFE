using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatanoController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<PlayerActor>().DeleteHeart();
            Destroy(gameObject);
        }

        if(other.tag == "Bala")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            FindObjectOfType<PlayerActor>().DeleteHeart();
            Destroy(gameObject);
        }

        if (other.transform.tag == "Bala")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
