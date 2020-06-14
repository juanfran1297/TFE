using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocoController : MonoBehaviour
{
    // Adjust the speed for the application.
    public float speed;
    public float attackSpeed;
    // Move our position a step closer to the target.
    float step;
    float attackStep;

    // The target (cylinder) position.
    public Transform[] targets;
    public int destTarget = 0;

    public bool isAttack;

    public Vector3 player;
    public Vector3 sitioAtaque;

    public LayerMask playerLayer;
    public float detectionRange;

    public Animator cocoAnim;
    public float contador;
    private void Start()
    {
        isAttack = false;
        step = speed * Time.deltaTime; // calculate distance to move
        attackStep = attackSpeed * Time.deltaTime;
        cocoAnim = GetComponent<Animator>();

        speed = 2f;
        attackSpeed = 5f;
        contador = 2f;
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
            transform.position = Vector3.MoveTowards(transform.position, targets[destTarget].position, step);
            transform.LookAt(targets[destTarget]);

            // Check if the position of the cube and sphere are approximately equal.
            if (Vector3.Distance(transform.position, targets[destTarget].position) < 0.001f)
            {
                GotoNextPoint();
            }
            cocoAnim.SetBool("VistaPlayer", false);
        }

        else if (isAttack == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.x, transform.position.y, player.z), attackStep);
            transform.LookAt(player);
            cocoAnim.SetBool("VistaPlayer", true);
        }

        if (Vector3.Distance(player, transform.position) < 3f)
        {
            if (contador >= 2)
            {
                isAttack = true;
                speed = 0f;
                cocoAnim.SetTrigger("Ataque");
                contador = 0;
            }
        }
        else speed = 2f;

        if (contador < 2)
        {
            contador = contador + Time.deltaTime;
            isAttack = false;
        }
    }
}
