using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActor : Actor
{

    public Animator enemyAnim;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(maxVida <= 0)
        {
            Destruir();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bala")
        {
            Damage();
            Destroy(other.gameObject);
        }
    }

    public override void Damage()
    {
        base.Damage();
        enemyAnim.SetTrigger("Damage");
    }
}
