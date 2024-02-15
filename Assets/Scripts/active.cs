using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class active : MonoBehaviour
{
    [SerializeField] GameObject coin;
    public  bool createe;
   [SerializeField] GameObject canvaslocation;
    [SerializeField] GameObject startposition;
    IEnumerator  create()
    {
        Destroy(this.gameObject);
       GameObject gameobj=  Instantiate(coin,startposition.transform.position,Quaternion.identity);
        gameobj.SetActive(true);
        gameobj.transform.SetParent(canvaslocation.transform);
       yield return new  WaitForSeconds(1.5f);
        Destroy(gameobj);
    }
    private void OnTriggerEnter(Collider other)
    {
           StartCoroutine("create");
    }

}
