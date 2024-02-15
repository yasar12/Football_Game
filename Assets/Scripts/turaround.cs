using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turaround : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround( Vector3.up, 359.99f*Time.deltaTime*0.005f);
    }
}
