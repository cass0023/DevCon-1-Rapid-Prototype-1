using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using Unity.VisualScripting;
using UnityEngine;

public class NPCTrip : MonoBehaviour
{
     //**need to add breaks in the spline so npc stops moving
    public GameManager gameManager;
    private Animator anim;
    public SplineFollower splineFollower;
    public float tripTimer;

    private bool tripped;

    void Awake()
    {
        anim = GetComponent<Animator>();
        splineFollower = GetComponent<SplineFollower>();
    }
    void Update()
    {
        //timer to pause npc movement when tripped
        float tempTimer = 0;
        if (tripped){
            tempTimer = tripTimer;
        }
        if(tempTimer > 0){
            tempTimer += Time.deltaTime;
        }
        if (tempTimer >= tripTimer){
            tempTimer = 0;
            tripped = false;
            canMove();
        }
    }
    private void OnTriggerEnter(Collider collision){
        if(collision.gameObject.CompareTag("Player")){
            Debug.Log("collided with leg " + gameObject.name);
            //plays tripping animation on NPC
            anim.SetBool("isTripped", true);
            hasTripped();

        }
        if(collision.gameObject.CompareTag("Spray")){
            Debug.Log(gameObject.name + " has been sprayed");
            //for ui counter
            gameManager.sprayedNPCs += 1;

            
            //plays kneeling animation after colliding with spray
            //anim.Play("isSprayed");
        }
    }
    public void hasTripped(){
        tripped = true;
        splineFollower.enabled = false;
        //pauses npcs movement
    }
    private void canMove(){
        splineFollower.enabled = true;
        //resumes npc movement
    }
}
