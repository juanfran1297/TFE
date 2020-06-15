using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlesTexto : MonoBehaviour
{
    public GameObject instrucciones;
    // Start is called before the first frame update
    void Start()
    {
        instrucciones.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        instrucciones.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        instrucciones.SetActive(false);
    }
    //public void CerrarTexto()
    //{
    //    instrucciones.SetActive(false);
    //}
}
