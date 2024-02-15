using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidingBugFixing : MonoBehaviour
{
    public Rigidbody rb;
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bugged"))
        {
             rb.AddForce(new Vector3(0f,3f,0f));
        }
    }
}
