using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotation : MonoBehaviour
{
    float contador = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        contador = contador + 0.01f;
        RenderSettings.skybox.SetFloat("_Rotation", contador);
    }
}
