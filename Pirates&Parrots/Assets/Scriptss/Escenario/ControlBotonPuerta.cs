using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBotonPuerta : MonoBehaviour
{
    public GameObject puerta;
    public Transform puertaAbierta;
    [SerializeField][Range(0, 7)] private float velocidadApertura;

    private bool estaAbierta;

    private void Start()
    {
        estaAbierta = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bala" && estaAbierta == false)
        {
            AbrirPuerta();
            estaAbierta = true;
            Destroy(other.gameObject);
        }
    }

    void AbrirPuerta()
    {
        puerta.transform.position = Vector3.MoveTowards(puerta.transform.position, puertaAbierta.position, velocidadApertura);
    }
}
