using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerActor : Actor
{
    [SerializeField]
    private int numVidas;

    public bool VidaAlMaximo = false;

    public List<Image> Lifes = new List<Image>();

    public Image lifeImagen;
    public Transform vidasInventory;

    // Start is called before the first frame update
    void Start()
    {
        maxVida = 3;
        numVidas = maxVida;
        InstanciarVidas();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (maxVida < Lifes.Capacity)
            {
                maxVida++;
                numVidas = maxVida;
                AddHeart();
                for (int i = 0; i < numVidas; i++)
                {
                    Lifes[i].enabled = true;
                }
            }
            else
            {
                Debug.Log("No se puede tener más vidas");
            }
        }

        if (numVidas == maxVida)
        {
            VidaAlMaximo = true;
        }
        else VidaAlMaximo = false;

        if (numVidas <= 0)
        {
            SceneManager.LoadScene("Final");
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            DeleteHeart();
        }
    }
}

