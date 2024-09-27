using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public GameObject Laser;
  

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))

        {
            Shoot();
        }

        if (Input.GetMouseButtonUp(0)) 
        
        {
            StopShooting();

        }
    }

   

    void Shoot()
    {

        Laser.SetActive(true);
    }

    private void StopShooting()
    {
        Laser.SetActive(false);
    }
}
