using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastGun : MonoBehaviour
{
    public Camera playercamera;
    public Transform laserOrigin;
    public float gunRange = 50f;
    public float laserDuration = 0.05f;

    LineRenderer laserLine;

    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            laserLine.SetPosition(0,laserOrigin.position);
            Vector3 rayOrigin = playercamera.ViewportToWorldPoint(new Vector3 (0.5f, 0.5f , 0));
            RaycastHit hit;

            if (Physics.Raycast (rayOrigin, playercamera.transform.forward, out hit, gunRange)) 
            {
            laserLine.SetPosition(1, hit.point);
                Destroy(hit.transform.gameObject);

            }

            else
            {
                laserLine.SetPosition(1, rayOrigin + (playercamera.transform.forward * gunRange));
            }

           
        }
    }

    IEnumerable ShootLaser()
    { 
    laserLine.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        laserLine.enabled = false;
    }
}
