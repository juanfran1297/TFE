using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CangrejoController : MonoBehaviour
{
    // Adjust the speed for the application.
    public float speed;

    // The target (cylinder) position.
    public Transform[] targets;
    public int destTarget = 0;

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (targets.Length == 0)
            return;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destTarget = (destTarget + 1) % targets.Length;
    }

    void Update()
    {
        // Set the agent to go to the currently selected destination.
        transform.position = Vector3.MoveTowards(transform.position, targets[destTarget].position, speed * Time.deltaTime);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, targets[destTarget].position) < 0.001f)
        {
            GotoNextPoint();
        }

        //if(destTarget == 0)
        //{

        //}
        //else if(destTarget == 1)
        //{

        //}
    }
}

    

