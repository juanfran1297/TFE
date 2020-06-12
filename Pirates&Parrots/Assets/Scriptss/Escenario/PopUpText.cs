using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpText : MonoBehaviour
{
    public string TextoQueSale;


    public GameObject cajaTexto;
    public PlayerController playerController;
    public Animator playerAnimator;
    public Shoot playerShoot;
    // Start is called before the first frame update
    void Start()
    {
        GameObject aux = GameObject.Find("Player");

        if(aux != null)
        {
            playerController = aux.GetComponent<PlayerController>();
            playerAnimator = aux.GetComponent<Animator>();
            playerShoot = aux.GetComponent<Shoot>();
        }
        else
        {
            Debug.LogError("No se encuentra al Player");
        }
       
        cajaTexto.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            AbrirTexto(TextoQueSale);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            this.gameObject.GetComponent<Collider>().enabled = false;
        }
    }

    public void AbrirTexto(string texto)
    {
        cajaTexto.GetComponent<Text>().text = texto;
        cajaTexto.SetActive(true);

        Time.timeScale = 0f;

        playerController.enabled = false;
        playerAnimator.enabled = false;
        playerShoot.enabled = false;
    }

    public void CerrarTexto()
    {
        Time.timeScale = 1f;

        playerController.enabled = true;
        playerAnimator.enabled = true;
        playerShoot.enabled = true;


        cajaTexto.SetActive(false);
    }
}
