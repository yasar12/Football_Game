using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class tomrukfallow : MonoBehaviour
{
    public GameObject tomruk;
    [SerializeField] float speed=50000;
    Vector3 velocity;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
         velocity = new Vector3(tomruk.GetComponent<Rigidbody>().velocity.x*1f, tomruk.GetComponent<Rigidbody>().velocity.y, tomruk.GetComponent<Rigidbody>().velocity.z*1f) ;

        back();
        
    }




    public void back()
    {
        Debug.Log(rb.velocity);
        rb.velocity = velocity;
        
    }
}
