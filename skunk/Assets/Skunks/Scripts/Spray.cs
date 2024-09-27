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

    //Changes the amount of time before the bullet prefab is deleted (in seconds)
    [SerializeField] private float sprayTime;

    void Update()
    {

        // Check if grounded so player can't fly
        // when pressing left click (spraying)
        if (Input.GetKeyDown(KeyCode.Mouse0) && playerMovement.isGrounded && gameManager.hasSprayed == false)
        {
            SpawnSpray();
        }

    }
    public void SpawnSpray(){
        
        playerMovement.animator.SetBool("Other", false);
        playerMovement.animator.Play("spray");
        //Changed to instead just create a "bubble" around the spray spawnpoint
        //For now spray stays in same spot
        var spray = Instantiate(sprayPrefab, spraySpawnPoint.position, spraySpawnPoint.rotation);
        //starts timer in game manager
        gameManager.SprayTimer();
        //This will delete the spray after a set amount of time. 
        //and we can make invisible if needed for visual testing -cass  
        Destroy(spray, sprayTime);
    }
}
