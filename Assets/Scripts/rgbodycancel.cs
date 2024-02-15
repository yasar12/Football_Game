using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rgbodycancel : MonoBehaviour
{
   
    CapsuleCollider capsulecollider;
    Animator animator;
    Rigidbody rg;
    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
        rg=GetComponent<Rigidbody>();
        capsulecollider = GetComponent<CapsuleCollider>();
        rg.isKinematic = true;
        capsulecollider.enabled = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (animator.isActiveAndEnabled == true && capsulecollider.enabled == true)
        {
            rg.isKinematic = true;
            capsulecollider.enabled = false;

        }
        else if (animator.isActiveAndEnabled == false)
        {
            rg.isKinematic = false;
            capsulecollider.enabled = true;
        }

    }


}


