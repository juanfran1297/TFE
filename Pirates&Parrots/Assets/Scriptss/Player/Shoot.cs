using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform salidaDisparo;

    public int maxBalas = 3;
    public int numBalas;

    public bool maxAmmo = false;

    public List<Image> Bullets = new List<Image>();

    public Image balaImage;
    public Transform balasInventory;

    public bool estaRecargando = false;
    public bool estaDisparando = false;

    public int velocidadBala = 14;

    public Animator playerAnim;

    private void Start()
    {
        numBalas = maxBalas;
        InstanciarBalas();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) || numBalas == 0)
        {
            StartCoroutine(Recargar());
        }

        if(Input.GetButtonDown("Fire1") && numBalas > 0 && estaRecargando == false)
        {
            if(Input.GetKey(KeyCode.W))
            {
                playerAnim.SetTrigger("ShootArriba");
            }
            else if(Input.GetKey(KeyCode.S)) 
            {
                playerAnim.SetTrigger("ShootAbajo");
            }
            else
            {
                playerAnim.SetTrigger("Shoot");
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(maxBalas < Bullets.Capacity)
            {
                maxBalas++;
                AddBullet();
            }
            else
            {
                Debug.Log("No se puede tener más balas");
            }
        }

        if (numBalas == maxBalas)
        {
            maxAmmo = true;
        }
        else maxAmmo = false;
    }

    public void Disparo()
    {
        if(estaRecargando == false)
        {
            var bullet = (GameObject)Instantiate(bulletPrefab, salidaDisparo.position, Quaternion.identity);
            if(Input.GetKey(KeyCode.W))
            {
                bullet.GetComponent<Rigidbody>().velocity = transform.up * velocidadBala;
            }
            else if(Input.GetKey(KeyCode.S))
            {
                bullet.GetComponent<Rigidbody>().velocity = -transform.up * velocidadBala;
            }
            else
            {
                bullet.GetComponent<Rigidbody>().velocity = transform.forward * velocidadBala;
            }
            Destroy(bullet, 2.0f);
            numBalas--;
        }

        for (int i = numBalas; i >= numBalas; i--)
        {
            Bullets[i].enabled = false;
        }
    }

    IEnumerator Recargar()
    {
        estaRecargando = true;
        yield return new WaitForSeconds(.5f);
        numBalas = maxBalas;

        yield return new WaitForSeconds(1.0f);
        estaRecargando = false;
        for (int i = 0; i < numBalas; i++)
        {
            Bullets[i].enabled = true;
        }
    }

    public void InstanciarBalas()
    {
        for (int i = 0; i < numBalas; i++)
        {
            Bullets[i] = Instantiate(balaImage, balasInventory, false);
        }
    }

    public void AddBullet()
    {
        if (maxAmmo == true)
        {
            StartCoroutine(Recargar());
            Bullets[maxBalas - 1] = Instantiate(balaImage, balasInventory, false);
        }
        else
        {
            StartCoroutine(AddAndReload());
        }
    }

    IEnumerator AddAndReload()
    {
        StartCoroutine(Recargar());
        yield return new WaitForSeconds(1.1f);
        Bullets[maxBalas - 1] = Instantiate(balaImage, balasInventory, false);

    }
}

