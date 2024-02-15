using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour
{
    public int value;
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            CoinCounter.instance.IncreaseCoin(value);  
            //Debug.Log(CoinCounter.instance.currentCoins);
        }
    }
}