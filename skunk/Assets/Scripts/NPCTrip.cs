using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCTrip : MonoBehaviour
{
    //for some reason my animator window is all messed up rn and wont let me see nodes
    //hypothetically this changes the animations of the npcs when interacting with spray and skunk
    //**need to add breaks in the spline so npc stops moving
    private Rigidbody rb;
    private Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision){
        if(collision.gameObject.CompareTag("Player")){
            Debug.Log("collided with leg " + gameObject.name);

            //plays tripping animation on NPC
            //anim.SetBool("isTripped", true);

        }
        if(collision.gameObject.CompareTag("Spray")){
            Debug.Log(gameObject.name + " has been sprayed");

            //plays kneeling animation after colliding with spray
            //anim.SetBool("isSprayed", true);
        }
    }
}
