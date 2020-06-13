using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuevaLightController : MonoBehaviour
{
    public Animator MainLight;

    public Animator SpotLight;
    public Animator SpotLight2;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            MainLight.SetBool("Apaga", true);
            SpotLight.SetBool("Apaga", true);
            SpotLight2.SetBool("Apaga", true);



        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            MainLight.SetBool("Apaga", false);
            SpotLight.SetBool("Apaga", false);
            SpotLight2.SetBool("Apaga", false);



        }


    }
}
