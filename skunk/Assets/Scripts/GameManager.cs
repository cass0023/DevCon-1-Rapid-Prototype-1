using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //[spray timer]//
    public float sprayTimer;
    private float timeRemaining;
    public bool hasSprayed;
    //^changes the time until player can spray again
    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = sprayTimer;
    }

    // Update is called once per frame
    void Update()
    {
        //skunk spray timer
        //will countdown until 0, when spraytimer = 0, allow player to spray again.
        if (hasSprayed){
            if(timeRemaining > 0){
                timeRemaining -= Time.deltaTime;
            }
            if (timeRemaining <= 0){
                timeRemaining = 0;
                hasSprayed = false;
            }
        }
    }
    public void SprayTimer(){
        timeRemaining = sprayTimer;
        hasSprayed = true;
    }

}
