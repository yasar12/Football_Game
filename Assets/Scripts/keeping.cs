using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keeping : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.rigidbody.AddForce(-Vector3.forward*1);
    }
}
