using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shepercollidercancel : MonoBehaviour
{
    Animator animator;
    SphereCollider boxcollider;
    Rigidbody rg;
    // Start is called before the first frame update
    private void Awake()
    {
        boxcollider = GetComponent<SphereCollider>();
        animator = GetComponentInParent<Animator>();
        rg = GetComponent<Rigidbody>();
        rg.isKinematic = true;
        boxcollider.enabled = false;
    }
   

    // Update is called once per frame
    void Update()
    {
        if (animator.isActiveAndEnabled == true && boxcollider.enabled == true)
        {
            rg.isKinematic = true;
            boxcollider.enabled = false;

        }
        else if (animator.isActiveAndEnabled == false )
        {
            rg.isKinematic = false;
            boxcollider.enabled = true;
        }
    }
}
