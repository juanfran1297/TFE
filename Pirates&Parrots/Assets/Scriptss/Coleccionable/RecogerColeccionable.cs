using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerColeccionable : MonoBehaviour
{
    public Coleccionables coleccionables;

    private void Start()
    {
        GameObject aux = GameObject.Find("GameManager");
        if(aux != null)
        {
            coleccionables = aux.GetComponent<Coleccionables>();
        }
        else
        {
            Debug.LogError("No se encuentra el 'Game Manager' o el script 'Coleccionables' dentro de este, asegurate de que está colocado");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            coleccionables.coleccionable++;
            Destroy(this.gameObject);
        }
    }
}
