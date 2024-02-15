using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explodeEnemy : MonoBehaviour
{
  [SerializeField]  Rigidbody rg;
    float explosion_Power = 2000f;
    float yaricap=50;
    float explosion_radius;
    Collision collision;
    void Start()
    {
        
       
        explosion_radius=(yaricap*yaricap)*Mathf.PI*2;
    }

    // Update is called once per frame
    void Update()   
    {
        explode();
    }

    public void explode() {
        if (true) {
            
        }
    }
}
