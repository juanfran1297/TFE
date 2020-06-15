using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CargarMenu : MonoBehaviour
{
    Image imagen;
    // Start is called before the first frame update
    void Start()
    {
        imagen = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(imagen.IsActive())
        {
            StartCoroutine(Menu());
        }
    }

    IEnumerator Menu()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Menu");
    }
}
