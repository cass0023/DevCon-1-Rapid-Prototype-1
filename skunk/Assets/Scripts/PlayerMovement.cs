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
    public float jumpHeight;
    public bool isGrounded;
    public Rigidbody rb;

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime *rotationspeed, 0);
        transform.Translate (0,0, y * Time.deltaTime*runspeed);

        animator.SetFloat("VelX",x);
        animator.SetFloat("VelY",y);


        if (Input.GetMouseButtonDown(0))
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
        if (Input.GetKey("space") && isGrounded) 
        { 
            rb.AddForce (Vector3.up*jumpHeight, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    public void OnCollisionStay(Collision col){
        //created invisible cube named ground- when player is colliding with ground, player can jump
        if(col.gameObject.name == "Ground"){
            isGrounded = true;
        }
    }

}
