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
}
