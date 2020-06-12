using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public int maxVida;

    // Update is called once per frame
    void Update()
    {
        if(maxVida <= 0)
        {
            Destruir();
        }
    }

    public virtual void Damage()
    {
        maxVida--;
    }

    public virtual void Destruir()
    {
        Destroy(gameObject);
    }
}
