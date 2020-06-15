using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PajaroController : MonoBehaviour
{
    // Adjust the speed for the application.
    public float speed = 1.0f;
    public float attackSpeed = 5f;

    // The target (cylinder) position.
    public Transform[] targets;
    public int destTarget = 0;

    public bool isAttack;

    public Vector3 player;
    public Vector3 sitioAtaque;

    public LayerMask playerLayer;
    public float detectionRange;

    public Animator pajaroAnim;
    private void Start()
    {
        isAttack = false;
        pajaroAnim = GetComponent<Animator>();

        speed = 3f;
        attackSpeed = 8f;
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
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRange, playerLayer);
        if (hitColliders.Length > 0)
        {
            player = hitColliders[0].transform.position;
            isAttack = true;
        }
        else
        {
            isAttack = false;
        }

        if (isAttack == false)
        {
            // Set the agent to go to the currently selected destination.
            transform.position = Vector3.MoveTowards(transform.position, targets[destTarget].position, speed * Time.deltaTime);
            transform.LookAt(targets[destTarget]);

            // Check if the position of the cube and sphere are approximately equal.
            if (Vector3.Distance(transform.position, targets[destTarget].position) < 0.001f)
            {
                GotoNextPoint();
            }
            pajaroAnim.SetBool("Ataque", false);
        }

        else if (isAttack == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player, attackSpeed * Time.deltaTime);
            transform.LookAt(player);
            pajaroAnim.SetBool("Ataque", true);
        }
    }
}
