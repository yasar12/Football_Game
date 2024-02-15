using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxcollidercancel : MonoBehaviour
{
    Animator animator;
    BoxCollider boxcollider;
    Rigidbody rg;
    private void Awake()
    {
        boxcollider = GetComponent<BoxCollider>();
        animator = GetComponentInParent<Animator>();    
        rg = GetComponent<Rigidbody>();
        rg.isKinematic = true;
        boxcollider.enabled = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.isActiveAndEnabled==true&&boxcollider.enabled==true)
        {
            rg.isKinematic = true;
            boxcollider.enabled = false;

        }
        else if (animator.isActiveAndEnabled == false)
        {
            rg.isKinematic=false;
            boxcollider.enabled = true;
        }
    }
}
