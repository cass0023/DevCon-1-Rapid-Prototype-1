using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCTrip : MonoBehaviour
{
     public GameManager gameManager;
    private Animator anim;

    public float tripTimer;

    private bool tripped;

    void Awake()
    {
        anim = GetComponent<Animator>();
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
        }
    }
    private void OnTriggerEnter(Collider collision){
        if(collision.gameObject.CompareTag("Player")){
            Debug.Log("collided with leg " + gameObject.name);
            //plays tripping animation on NPC
            anim.SetBool("isTripped", true);
        }
        if(collision.gameObject.CompareTag("Spray")){
            Debug.Log(gameObject.name + " has been sprayed");
            //for ui counter
            gameManager.sprayedNPCs += 1;
        }
    }

}
