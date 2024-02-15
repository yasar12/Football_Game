using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_Ai : MonoBehaviour
{
    public float distancetotarget = Mathf.Infinity;
    public Transform Target;
    public float Attack_Distance;
    NavMeshAgent agent;

    Animator animator;
    public bool run = false;
    public bool kay = false;
    public bool floor = false;
    public float distancetomovetarget;
    public float movedistance = 20;
    public bool movecancelactive = false;
    public bool tekrarkaydirma = true;
    private void Awake()
    {
        Target = FindObjectOfType<BallMovement>().transform;
animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

    }
   
    // Update is called once per frame
    public void Update()
    {
       
        distancetotarget = Vector3.Distance(Target.position, transform.position);
        distancetomovetarget = Vector3.Distance(Target.position, transform.position);
        distancetomovetarget -= 10;
        if (animator.GetBool("floor") && movecancelactive == false)
        {
            Invoke("movecancel", 0.30f);
            movecancelactive = true;
        }

        if (distancetotarget < Attack_Distance)
        {

            attack();

        }
        if (distancetotarget > Attack_Distance)
        {
            cancelattack();
            movecancel();
        }
    }
    public void attack()
    {
       
        if (animator.GetBool("floor") == false)
        {
            agent.Resume();
            if (movecancelactive)
            {
                movecancelactive = false;
            }

        }


        if (run == false)
            run = true;

        agent.SetDestination(Target.position);
        if (animator.GetBool("floor") == false)
        {
            transform.LookAt(new Vector3(Target.position.x,transform.position.y,Target.transform.position.z));
        }

        if (!tekrarkaydirma&&kay)
        {
            Debug.Log("çalıştı");
            kay = false;
        }
      else  if ( distancetotarget <= 14f && kay == false&&tekrarkaydirma==true)
        {
           
            kay = true;
            tekrarkaydirma= false;
               
                Invoke(nameof(settekrarkaydir), 4f);

            
            GetComponent<NavMeshAgent>().speed = 20;
        }


    }

    public void cancelattack()
    {

        run = false;
        kay = false;
    }

    public void movecancel()
    {

        agent.Stop();
    }
    public void settekrarkaydir() { 
    tekrarkaydirma = true;
    }
    
}


