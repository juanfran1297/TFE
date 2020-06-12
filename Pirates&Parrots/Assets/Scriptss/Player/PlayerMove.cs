using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    CharacterController characterController;
    #region Public Variables
    public float normalSpeed = 6.0f;
    
    public float crouchSpeed = 3.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    public float speedRotation;

    public Collider col;
    public bool isCrouch = false;
    //Cosas Animator
    public Animator miAnim;    

    public Transform groundCheck;
    public float groundDistance = 0.4f;

    public LayerMask slopeRight;
    public LayerMask slopeLeft;
    #endregion

    #region Private Variables
    [SerializeField] private float speed;
    [SerializeField] private float speedAirController;
    private Vector3 moveDirection = Vector3.zero;
    bool isSlopeRight = false;
    bool isSlopeLeft = false;
    private Quaternion q;
    private Vector3 targetRotation;

    RaycastHit hit;
    #endregion

    #region Private Methods
    void Start()
    {   
        characterController = GetComponent<CharacterController>();
        targetRotation = new Vector3(0, 90, 0);
        q = new Quaternion(0, 1, 0, 1);
        speed = normalSpeed;
    }
    private void Update()
    {
        AnimatorCheckin();
        if (isSlopeLeft || isSlopeRight)
        {
            PegarSuelo();
        }
        Debug.Log(characterController.isGrounded);
    }
    //void Update()
    //{
    //    //AnimatorCheckin();
    //    //if(isSlopeLeft || isSlopeRight)
    //    //{
    //    //    PegarSuelo();
    //    //}
    //    //Debug.Log(characterController.isGrounded);
    //}
    #endregion

    #region Public Methods
    public void AnimatorCheckin()
    {
        miAnim.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        if (miAnim.GetCurrentAnimatorStateInfo(0).IsTag("Locomotion"))
        {
            Locomotion();
        }

        if (isCrouch == true)
        {
            col.transform.localScale = Vector3.Lerp(new Vector3(1, 1, 1), new Vector3(1, .6f, 1), .5f);
            speed = crouchSpeed;
        }
        else
        {
            col.transform.localScale = new Vector3(1, 1, 1);
            speed = normalSpeed;
        }
    }
    #endregion

    #region Function Locomotion

    public void Locomotion()
    {
        
        if (characterController.isGrounded)
        {
            EnSuelo();
        }
        else
        {
            EnSalto();
        }
        
        //Aplicamos Gravedad
        moveDirection.y -= gravity * Time.deltaTime;

        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }
    #endregion

    #region CosasDeRampas
    public void PegarSuelo()
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, .3f, Vector3.down, out hit, 1f))
        {
            transform.position = new Vector3(transform.position.x, hit.point.y + 0.9f, transform.position.z);
        }
    }

    
    public void Rampas()
    {
        isSlopeRight = Physics.CheckSphere(groundCheck.position, groundDistance, slopeRight);
        if (isSlopeRight == true && Input.GetAxis("Horizontal") > 0)
        {
            miAnim.SetBool("SlopeRight", true);
            transform.rotation = new Quaternion(0, 1, 0, 1);
        }
        else
        {
            miAnim.SetBool("SlopeRight", false);
        }

        isSlopeLeft = Physics.CheckSphere(groundCheck.position, groundDistance, slopeLeft);
        if (isSlopeLeft == true && Input.GetAxis("Horizontal") < 0)
        {
            miAnim.SetBool("SlopeLeft", true);
            transform.rotation = new Quaternion(0, -1, 0, 1);
        }
        else
        {
            miAnim.SetBool("SlopeLeft", false);
        }
    }
    #endregion

    #region Suelo
    private void EnSuelo()
    {
        gravity = 9.8f;
        #region Rotación
        if (Input.GetAxis("Horizontal") > 0)
        {
            targetRotation = new Vector3(0, 90, 0);
            q = Quaternion.Euler(targetRotation);
        }
        else if ((Input.GetAxis("Horizontal") < 0))
        {
            targetRotation = new Vector3(0, -90, 0);
            q = Quaternion.Euler(targetRotation);
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, q, speedRotation * Time.deltaTime);
        #endregion

        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        moveDirection *= speed;

        #region Agacharse
        if (Input.GetButton("Crouch"))
        {
            miAnim.SetBool("Agachado", true);
            isCrouch = true;
        }
        else
        {
            miAnim.SetBool("Agachado", false);
            isCrouch = false;
        }
        #endregion

        #region Salto
        if (Input.GetButton("Jump"))
        {
            if(isSlopeRight == true || isSlopeLeft == true)
            {
                return;
            }
            else
            {
                moveDirection.y = jumpSpeed;
            }
        }
        #endregion

        Rampas();
    }
    #endregion

    #region Salto
    public void EnSalto()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            targetRotation = new Vector3(0, 90, 0);
            q = Quaternion.Euler(targetRotation);
        }
        else if ((Input.GetAxis("Horizontal") < 0))
        {
            targetRotation = new Vector3(0, -90, 0);
            q = Quaternion.Euler(targetRotation);
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, q, speedRotation * Time.deltaTime);

        Vector3 tempdirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        moveDirection.x = tempdirection.x * speedAirController;
        gravity = 12.5f;
    }
    #endregion
}
