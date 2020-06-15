using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerActor : Actor
{
    public int numVidas;

    public bool VidaAlMaximo = false;

    public List<Image> Lifes = new List<Image>();

    public Image lifeImagen;
    public Transform vidasInventory;
    public Animator playerAnim;
    public bool estaMuerto;
    public Rigidbody rigibody;

    // Start is called before the first frame update
    void Start()
    {
        maxVida = 3;
        numVidas = maxVida;
        InstanciarVidas();
        playerAnim = GetComponent<Animator>();
        estaMuerto = false;
        rigibody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (numVidas == maxVida)
        {
            VidaAlMaximo = true;
        }
        else VidaAlMaximo = false;

        if (numVidas <= 0)
        {
            playerAnim.SetTrigger("Muerte");
            estaMuerto = true;
        }
    }
    public void InstanciarVidas()
    {
        for (int i = 0; i < numVidas; i++)
        {
            Lifes[i] = Instantiate(lifeImagen, vidasInventory, false);
        }
    }

    public void AddHeart()
    {
        Lifes[maxVida - 1] = Instantiate(lifeImagen, vidasInventory, false);
    }

    public void DeleteHeart()
    {
        numVidas--;
        for (int i = numVidas; i >= numVidas; i--)
        {
            Lifes[i].enabled = false;
        }
    }

    public void ConseguirUnaVida()
    {
        if (numVidas < maxVida)
        {
            numVidas++;
            for (int i = 0; i < numVidas; i++)
            {
                Lifes[i].enabled = true;
            }
        }
        else if(numVidas >= maxVida)
        {
            Debug.Log("No se puede tener más vidas");
        }
    }
}

