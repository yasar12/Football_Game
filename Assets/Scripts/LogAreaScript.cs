using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogAreaScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LogArea"))
        {
            DestroyObjectsWithTag("Engel");
            Debug.Log("Engel nesneleri silindi.");
        }
    }

    void DestroyObjectsWithTag(string tag)
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject obj in taggedObjects)
        {
            Destroy(obj);
        }
    }
}
