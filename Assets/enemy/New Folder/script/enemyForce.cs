using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class enemyForce : MonoBehaviour
{
    

    [Header("Yukselme araligi")]
    public float uppowermin = 300;//topun yükselmek için alabileceği en düşük güç.
    public float uppowermax = 400;//topun yükselmek için alabileceği en yüksek güç.

    float uppower;//yükselme gücünün random bir şekilde belirlendikten sonra atanacağı en son değişken.
    [Header("ileri atilma araligi")]
    public float forwardpowermin=900;//topun ileri gitmek için alabileceği en düşük güç.
    public float forwardpowermax = 1400; //topun ileri gitmek için alabileceği en yüksek güç.
    float forwardpower;//ileri gücünün random bir şekilde belirlendikten sonra atanacağı en son değişken.
    enemy_Ai ai;//enemy_ai script türünde değişken

   
    private void Start()
    {
        
       ai = GetComponent<enemy_Ai>();
    }
    private void OnCollisionEnter(Collision collision)
    {
      
        ball_force(collision);
        
    }



    public void ball_force(Collision collision) { 

      
    
        if (collision.gameObject.CompareTag("Player"))//isim tagı sadece player olan objelerde çalışıcak
        {

         uppower= Random.Range(uppowermin, uppowermax);//verilen min ve max değerlere göre random bir uppower değeri oluşturucak.
        forwardpower = Random.Range(forwardpowermin, forwardpowermax);//verilen min ve max değerlere göre random bir forwardpower değeri oluşturucak.

        Debug.Log("uppower:" + uppower + " " + "forwardpower" + forwardpower);
        
        collision.gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward*forwardpower);//topa yukarı yönde force uygulandı.
        collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * uppower);//topa vuran kişinin ileri yönü doğrultusunda force uygulandı.
       //topa sadece bir kere vurulduktan sonra takip sisteminin tamamen bitmesini istediğimiz için agent sistemi devre dışı bırakıldı.
           
        }
    }
}
