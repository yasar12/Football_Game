using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class kalecigeridonus : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
   public  Transform returnpoint;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
       
    }
    
    
    void Update()
    {
        if (animator.GetBool("kalecikalkti"))
        {
           
        }
        if (transform.position == returnpoint.position)
        {
            GetComponent<enemy_Ai>().enabled = false;
            GetComponent<enemyForce>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
            animator.SetBool("enemy2", false);
            GetComponent<kalecimovement>().enabled = true; 
        }
    }
}
