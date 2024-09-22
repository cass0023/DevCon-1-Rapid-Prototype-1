using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
      public int DamageAmount = 20;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPCS")

        {
            other.GetComponent<NPCSDAMAGE>().TakeDamege(DamageAmount);
        }
    }
}
