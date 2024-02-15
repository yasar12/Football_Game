using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedcontrol : MonoBehaviour
{
    kalecimovement kalecimovementscipt;
    void Start()
    {
        kalecimovementscipt=GetComponentInParent<kalecimovement>();
        
    }

    
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(other.gameObject.GetComponent<Rigidbody>().velocity.z);
            if (other.gameObject.GetComponent<Rigidbody>().velocity.z > 70)
            {
                if (gameObject.CompareTag("sol"))
                {
                    Debug.Log("success");
                kalecimovementscipt.sol = true;
                    Invoke("iptal", 0.4f);
                 
                }
                if (gameObject.CompareTag("sag"))
                {
                    Debug.Log("success");
                    kalecimovementscipt.sag = true;
                    Invoke("iptal2", 0.4f);
                }
            }
         
        
        }
       
       
    }


    public void iptal() {

        kalecimovementscipt.sol = false;
    }
    public void iptal2()
    {

        kalecimovementscipt.sag = false;
    }
}
