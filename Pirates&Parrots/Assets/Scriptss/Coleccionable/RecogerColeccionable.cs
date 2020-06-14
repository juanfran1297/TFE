using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerColeccionable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<PlayerActor>().AddHeart();
            Destroy(this.gameObject);
        }
    }
}
