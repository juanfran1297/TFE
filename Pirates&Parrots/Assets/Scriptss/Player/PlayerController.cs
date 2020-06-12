using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float speed;
    public float jumpSpeed;

    public Transform groundCheck;
    public float groundDistance = .4f;
    public float slopeDistance = 2f;

    public bool canJump;

    public float speedRotation;
    private Quaternion q;
    private Vector3 targetRotation;

    public LayerMask slopeRight;
    public LayerMask slopeLeft;
    public bool isSlopeRight = false;
    public bool isSlopeLeft = false;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        targetRotation = new Vector3(-180, 90, 0);
        q = Quaternion.Euler(targetRotation);
    }
    private void Update()
    {
        EnSuelo();
    }

    private void FixedUpdate()
    {
        float mH = Input.GetAxis("Horizontal");
        rigidBody.velocity = new Vector2(mH * speed, rigidBody.velocity.y);
    }

    #region EnSuelo
    private void EnSuelo()
    {
        Debug.DrawRay(groundCheck.position, Vector3.down, Color.green);
        RaycastHit hit;
        if (Physics.Raycast(groundCheck.position, Vector3.down, out hit, groundDistance))
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }

        #region Rotación
        if (Input.GetAxis("Horizontal") > 0)
        {
            targetRotation = new Vector3(-180, 90, 0);
            q = Quaternion.Euler(targetRotation);
        }
        else if ((Input.GetAxis("Horizontal") < 0))
        {
            targetRotation = new Vector3(-180, -90, 0);
            q = Quaternion.Euler(targetRotation);
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, q, speedRotation * Time.deltaTime);
        #endregion

        #region Salto
        if (canJump)
        {
            if(isSlopeRight || isSlopeLeft)
            {
                return;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidBody.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
            }
        }
        #endregion

        Rampas();
    }
    #endregion

    #region CosasDeRampas
    public void PegarSuelo()
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, .1f, Vector3.down, out hit, 1f))
        {
            transform.position = new Vector3(transform.position.x, hit.point.y + 0.8f, transform.position.z);
        }
    }

    public void Rampas()
    {
        isSlopeRight = Physics.CheckSphere(groundCheck.position, slopeDistance, slopeRight);
        if (isSlopeRight == true && Input.GetAxis("Horizontal") > 0)
        {
            //miAnim.SetBool("SlopeRight", true);
            targetRotation = new Vector3(-180, 90, 0);
            q = Quaternion.Euler(targetRotation);
        }
        else
        {
            targetRotation = new Vector3(-180, 90, 0);
            q = Quaternion.Euler(targetRotation);
            //miAnim.SetBool("SlopeRight", false);
        }
    }
    #endregion
}
