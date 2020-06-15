using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject animatorCamera;

    // Start is called before the first frame update
    void Start()
    {
        animatorCamera.SetActive(true);
        

    }

    // Update is called once per frame
    
    public void cambioCamera()
    {
        
        animatorCamera.SetActive(false);
        
    }
}
