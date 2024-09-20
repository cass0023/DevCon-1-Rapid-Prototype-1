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
    public CharJump charJump;

    void Update()
    {
        // Check if grounded so player can't fly
        // when pressing left click (spraying)
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (charJump.isGrounded == true)
            {
                var spray = Instantiate(sprayPrefab, spraySpawnPoint.position, spraySpawnPoint.rotation);
                spray.GetComponent<Rigidbody>().velocity = spraySpawnPoint.forward * spraySpeed;
            }

        }
    }
}
