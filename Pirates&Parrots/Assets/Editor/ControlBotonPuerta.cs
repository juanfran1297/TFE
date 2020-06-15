using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBotonPuerta : MonoBehaviour
{
    public Animator botonAnimator;
    public Animator puertaAnimator;

    private bool estaAbierta;

    private void Start()
    {
        botonAnimator = GetComponent<Animator>();
        estaAbierta = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bala" && estaAbierta == false)
        {
            botonAnimator.SetTrigger("Pulsar");
            estaAbierta = true;
            //Destroy(other.gameObject);
        }
    }

    public void AbrirPuerta()
    {
        puertaAnimator.SetTrigger("Abrir");
    }
}
