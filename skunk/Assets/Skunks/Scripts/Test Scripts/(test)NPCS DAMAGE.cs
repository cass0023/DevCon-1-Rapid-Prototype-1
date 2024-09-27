using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSDAMAGE : MonoBehaviour
{
    public int HP = 1000;
    public Animator animator;

    public void TakeDamege(int DamageAmount)

    {
        HP -= DamageAmount;

        if (HP < 0)
        { 
        
        }

        else

        {

            animator.SetTrigger("Run");
        }

    }

}
