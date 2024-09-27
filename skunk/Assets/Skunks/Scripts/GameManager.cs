using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //[UI]//
    [SerializeField]private int npcCount;
    public TextMeshProUGUI sprayedCounter;

    //[spray timer]//
    public float sprayTimer;
    private float timeRemaining;
    public bool hasSprayed;
    //^changes the time until player can spray again
    public int sprayedNPCs;
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
        //checks number of npcs
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPCS");
        npcCount = npcs.Length;
        int counter = npcCount - sprayedNPCs;
        sprayedCounter.text = "" + counter;

    }
    public void SprayTimer(){
        timeRemaining = sprayTimer;
        hasSprayed = true;
    }
}