using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class kalecimovement : MonoBehaviour
{
   Animator animator;
    public bool sol=false;
    public bool sag=false;

    GameObject ball;
    void Start()
    {
        animator = GetComponent<Animator>();
        ball = FindObjectOfType<BallMovement>().gameObject;
    }

    
    void Update()
    {
        if (Vector3.Distance(transform.position, ball.transform.position) < 20&&ball.GetComponent<Rigidbody>().velocity.z<40)
        {
            
        if(!sol&&!sag)
            {

            GetComponent<enemy_Ai>().enabled = true;
            GetComponent<enemyForce>().enabled = true;
            GetComponent<NavMeshAgent>().enabled = true;
         this.enabled = false;
            }
            
            
            

        }
            


        if (sol) { 
        animator.SetBool("sol", true);
         
        }
        else
        {
            animator.SetBool("sol", false);
            
        }
        if (sag)
         { 

         animator.SetBool("sag", true);
         
        }
        else
        {
            animator.SetBool("sag",false);
           
        }


    }


   
}
