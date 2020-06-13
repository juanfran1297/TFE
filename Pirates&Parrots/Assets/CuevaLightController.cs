using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuevaLightController : MonoBehaviour
{
    public Animator MainLight;

    public Animator SpotLight;
    public Animator SpotLight2;

    float reduccion = 1;
    bool Oscurece = false;
    bool Amanece = false;


    // Start is called before the first frame update
    void Start()
    {
        bool Oscurece = false;
    bool Amanece = false;
        RenderSettings.skybox.SetFloat("_Exposure", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Oscurece == true)
        {
            reduccion = reduccion - 0.015f;
            RenderSettings.skybox.SetFloat("_Exposure", reduccion);
            if (reduccion <= 0.12f)
            {
                reduccion = 0.11f;
                RenderSettings.skybox.SetFloat("_Exposure", reduccion);
                Oscurece = false;
            }
        }
        
        if (Amanece == true)
        {
            reduccion = reduccion + 0.015f;
            RenderSettings.skybox.SetFloat("_Exposure", reduccion);

            if (reduccion >= 0.99)
            {
                reduccion = 1;
                RenderSettings.skybox.SetFloat("_Exposure", reduccion);
                Amanece = false;
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            MainLight.SetBool("Apaga", true);
            SpotLight.SetBool("Apaga", true);
            SpotLight2.SetBool("Apaga", true);


            Oscurece = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            MainLight.SetBool("Apaga", false);
            SpotLight.SetBool("Apaga", false);
            SpotLight2.SetBool("Apaga", false);

            Amanece = true;

        }


    }

    private void OnApplicationQuit()
    {
        RenderSettings.skybox.SetFloat("_Exposure", 1f);

    }
}
