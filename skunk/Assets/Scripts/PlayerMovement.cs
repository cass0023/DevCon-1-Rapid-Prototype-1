using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float runspeed = 7;
    public float rotationspeed = 250;

    public Animator animator;

    private float x, y;

    public Rigidbody rb;

    public float JumpHeight = 3;

    public Transform groundCheck;
    public float groundDistance = 0.1f;

    public LayerMask GroundMask;

    bool isGrounded;


    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime *rotationspeed, 0);
        transform.Translate (0,0, y * Time.deltaTime*runspeed);

        animator.SetFloat("VelX",x);
        animator.SetFloat("VelY",y);


        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("Other", false);
            animator.Play("spray");
        }

        if (Input.GetKey("c"))
        {
            animator.SetBool("Other", false);
            animator.Play("attack");
        }

        if (x>0 || x<0 || y>0 || y<0) 
        {
            animator.SetBool("Other", true);
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, GroundMask);

        if (Input.GetKey("space") && isGrounded)
        {
            rb.AddForce(Vector3.up*JumpHeight, ForceMode.Impulse);
        }
    }
}
