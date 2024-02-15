using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationcontroller : MonoBehaviour
{
    enemy_Ai enemyai_script;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
       animator= GetComponent<Animator>();
        enemyai_script=GetComponent<enemy_Ai>();
    }

    // Update is called once per frame
    void Update()
    {
        setrun();
        setkay();
       

    }

    public void setrun()
    { 

     if (enemyai_script.run)
        {    
        animator.SetBool("run",true);
        }
     else
        {
            animator.SetBool("run", false);
        }
    }
    public void setkay()
    {
         if (enemyai_script.kay && !animator.GetBool("take_ball"))
        {
        animator.SetBool("take_ball",true);
        }
       
    }
}
