using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spray : MonoBehaviour
{
    // Checks if player is spraying
    // Instantiates bullets if true
    public Transform spraySpawnPoint; 
    public GameObject sprayPrefab;
    public float spraySpeed = 10;
    public GameManager gameManager;
    public PlayerMovement playerMovement;
    [SerializeField]private float sprayTime;
    //^changes the amount of time before the bullet prefab is deleted (in seconds)
    void Update()
    {
        
        // Check if grounded so player can't fly
        // when pressing left click (spraying)
        if (Input.GetKeyDown(KeyCode.Mouse0) && playerMovement.isGrounded && gameManager.hasSprayed == false)
        {
            //changed to instead just create a "bubble" around the spray spawnpoint
            var spray = Instantiate(sprayPrefab, spraySpawnPoint.position, spraySpawnPoint.rotation);
            //for now spray stays in same spot
            
            //starts timer in game manager and sets has sprayed to true so player cant spray again
            gameManager.SprayTimer();
           
            //this will delete the spray after a set amount of time. 
            //and we can make invisible if needed for visual testing -cass  
            Destroy(spray, sprayTime);
        }

    }
}
