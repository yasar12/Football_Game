using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class trail_effect : MonoBehaviour
{ 
    private void OnTriggerExit(Collider other)
    {
         if (other.gameObject.CompareTag("floor")) {
            GetComponent<TrailRenderer>().emitting = true;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("floor"))
        {
            GetComponent<TrailRenderer>().emitting = false;
        }
    }
}
