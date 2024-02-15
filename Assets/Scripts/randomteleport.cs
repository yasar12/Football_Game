using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using UnityEngine;

public class randomteleport : MonoBehaviour
{
   
   
    
   
    float sindeger;
    private void Awake()
    {
        
      
    }
    void Start()
    {
   
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("sol")) {
           move();
        }
    }
    private void OnParticleTrigger()
    {
        
            if (gameObject.CompareTag("sol"))
            {
            Vector3 portalkoordinat = new Vector3(FindObjectOfType<hareket>().transform.position.x, FindObjectOfType<hareket>().transform.position.y,GameObject.FindWithTag("sag").transform.position.z+2);
          
            teleport(portalkoordinat);

            
            }
            if (gameObject.CompareTag("sag"))
            {
            Vector3 portalkoordinat = new Vector3(FindObjectOfType<hareket>().transform.position.x, FindObjectOfType<hareket>().transform.position.y, GameObject.FindWithTag("sol").transform.position.z - 2);
           
            teleport(portalkoordinat);
            }
        
        
        
    }

    public void teleport(Vector3 portal) 
    {

        FindObjectOfType<hareket>().transform.position = portal;
     
    }

    public void move() { 
          sindeger = Mathf.Sin(Time.time+1)/2;
        
        gameObject.transform.Translate(sindeger*0.05f, 0, 0);
    }
}
