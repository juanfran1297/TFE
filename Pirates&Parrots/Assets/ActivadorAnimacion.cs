using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorAnimacion : MonoBehaviour
{
    public GameObject tentaculos;
    public GameObject cabeza;

    Collider thisCollider;
    private void Start()
    {
        tentaculos.SetActive(false);
        cabeza.SetActive(false);
        thisCollider = GetComponent<Collider>();
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            thisCollider.isTrigger = false;
            tentaculos.SetActive(true);
        }
    }

    public void ActivarCabeza()
    {
        cabeza.SetActive(true);
    }
}
