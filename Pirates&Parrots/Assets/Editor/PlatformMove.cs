using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public GameObject player;

    public Vector3 deltaMovimiento;
    private Vector3 posAnterior;

    private void FixedUpdate()
    {
        deltaMovimiento = transform.position - posAnterior;
        posAnterior = transform.position;
        CharacterController cc = GetComponentInChildren<CharacterController>();

        if (cc != null && deltaMovimiento != Vector3.zero)
        {
            cc.Move(deltaMovimiento);
        }

    }
    private void Start()
    {
        posAnterior = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = null;
        }
    }
}
