using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Player" || other.tag != "Trigger")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player" || other.tag != "Trigger")
        {
            Destroy(gameObject);
        }
    }
}
