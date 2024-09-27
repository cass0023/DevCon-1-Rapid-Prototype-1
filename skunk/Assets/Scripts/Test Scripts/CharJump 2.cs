using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharJump : MonoBehaviour
{
    //Jump variables
    public float jumpForce = 10f;

    //Multipliers for falling speed, and if the player taps the jump key
    //instead of holding it down, which gives a smaller jump
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    //Component variable for Rigidbody2D
    private Rigidbody _rb;
 
    public bool isGrounded = false;

    //Layermask variable
    public LayerMask groundLayer;

    //Coyote time variables
    public float coyoteTime;
    public float coyoteTimeMax = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize rigidbody component variable
        _rb = GetComponent<Rigidbody>();

        coyoteTime = coyoteTimeMax;     //Set coyote time default value
    }

    // Update is called once per frame
    void Update()
    {
        //Check to make sure the player is on the ground
        //Raycasts are collision lines that look for collisions along their path
        //Required parameters are an origin point and direction
        //Third and fourth parameters here are "size" and "layer mask" to specify the groundLayer
        //Direction Vector2.down is the same as saying (0, -1) as a Vector
        isGrounded = Physics.Raycast(transform.position, Vector2.down, 1.5f, groundLayer);

        //Listen for jump input and confirm coyote time has not elapsed
        if (Input.GetKeyDown(KeyCode.Space) && coyoteTime > 0)
        {
            //Set the rigidbody velocity to x = whatever its x velocity is and y = jumpForce
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
        }

        //Gravity modifications
        if (_rb.velocity.y < 0)
        {
            //Add Vector2 * gravity.y to _rb2D.velocity
            //Multiply by deltaTime to account for framerate weirdness
            _rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        //If the player is moving upward and no longer pressing the spacebar
        else if (_rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            _rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        //Make coyote time work
        if (isGrounded)
        {
            coyoteTime = coyoteTimeMax;
        }
        else
        {
            coyoteTime -= Time.deltaTime;
        }

    }

   
}
