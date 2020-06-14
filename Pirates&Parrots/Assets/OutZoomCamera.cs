using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutZoomCamera : MonoBehaviour
{
    public Camera mainCam;
    float contador = 60;
    int desactivar = 0;
    // Start is called before the first frame update
    void Start()
    {
        contador = mainCam.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        if (desactivar == 1)
        {
            if (mainCam.fieldOfView > 60)
            {
                mainCam.fieldOfView -= 0.2f;
            }

            if (mainCam.fieldOfView <= 60)
            {
                mainCam.fieldOfView = 60;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(mainCam.fieldOfView < 75)
            {
                mainCam.fieldOfView += 0.1f;
            }
            
            if(mainCam.fieldOfView >= 75)
            {
                mainCam.fieldOfView = 75;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            desactivar = 1;
        }
    }
}
