using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activatriggerr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("tomruk")) {
        GetComponent<BoxCollider>().isTrigger = true;
        }
    }
}
