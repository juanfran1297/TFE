using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.WSA.Input;

public class PajaroController : MonoBehaviour
{
    // Adjust the speed for the application.
    public float speed = 1.0f;
    public float attackSpeed = 5.0f;
    // Move our position a step closer to the target.
    float step;
    float attackStep;

    // The target (cylinder) position.
    public Transform[] targets;
    public int destTarget = 0;

    public bool isAttack;

    public GameObject player;

    public LayerMask playerLayer;
    private void Start()
    {
        isAttack = false;
        step = speed * Time.deltaTime; // calculate distance to move
        attackStep = attackSpeed * Time.deltaTime;
    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (targets.Length == 0)
            return;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destTarget = (destTarget + 1) % targets.Length;
    }
    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, 6f);
    }
    void Update()
    {
        
        RaycastHit hit;
        if(Physics.SphereCast(transform.position, 6f, transform.forward, out hit, 6f, playerLayer))
        {
            if(hit.transform.tag == "Player")
            {
                player = hit.transform.gameObject;
                Debug.Log("Se detecta al jugador");
                isAttack = true;
            }
        }
        else
        {
            Debug.Log("NO se detecta al jugador");
            isAttack = false;
        }

        if (isAttack == false)
        {
            // Set the agent to go to the currently selected destination.
            transform.position = Vector3.MoveTowards(transform.position, targets[destTarget].position, step);
            transform.LookAt(targets[destTarget]);

            // Check if the position of the cube and sphere are approximately equal.
            if (Vector3.Distance(transform.position, targets[destTarget].position) < 0.001f)
            {
                GotoNextPoint();
            }
        }
        else if (isAttack == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, attackStep);
            transform.LookAt(player.transform.position);
        }
    }
}
