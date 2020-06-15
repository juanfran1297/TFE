using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuertePlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<PlayerActor>().numVidas = 0;
        }
    }
}
