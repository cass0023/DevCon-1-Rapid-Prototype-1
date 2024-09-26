using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestNPCS : MonoBehaviour
{
    public Animator anim;
    private NavMeshAgent nav;

    public float range = 10f;
    public float WaitTime = 2;
    public float wait = 0.5f;

    bool waiting;
    private void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        move();
    }

    private void Update()
    {
        if (!waiting&&nav.pathPending && nav.remainingDistance > 0.5f)
        {
            if (Random.value < wait)
            {

            }

            else
            {
                move();
            }
        }

        else
        {
            anim.SetBool("Walk", nav.velocity.sqrMagnitude > 0.1f);
        }
    }

    void move()
    {
        Vector3 randomDirection = Random.insideUnitSphere * range;
        randomDirection += transform.position;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, range, NavMesh.AllAreas))
        {
            nav.SetDestination(hit.position);
            anim.SetBool("Walk", true);
        }
    }

}
