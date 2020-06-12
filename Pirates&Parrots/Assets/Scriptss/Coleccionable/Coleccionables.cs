using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coleccionables : MonoBehaviour
{

    public int coleccionable;

    public Text coleccionableActual;

    // Update is called once per frame
    void Update()
    {
        coleccionableActual.text = coleccionable.ToString();
    }
}
