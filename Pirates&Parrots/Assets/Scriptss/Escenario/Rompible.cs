using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rompible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bala")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}
