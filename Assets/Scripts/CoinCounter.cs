using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;
    public TMP_Text coinText;
    public int currentCoins;
    private int allCoins;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        allCoins = PlayerPrefs.GetInt("Coins");
        coinText.text = currentCoins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("TempCoins", currentCoins);
        if (PointSystem.instance.goalCount == 3)
        {
            allCoins += currentCoins;
            PlayerPrefs.SetInt("Coins", allCoins);
            Debug.Log("999876 : --- " + currentCoins);
            currentCoins = 0;
            PointSystem.nextLevel(PointSystem.instance.goalCount);
        }
        Debug.Log("para miktari :" + currentCoins);
    }

public void IncreaseCoin(int v)
    {
        currentCoins += v;
        coinText.text = "";
        coinText.text += currentCoins.ToString();
    }
    
}