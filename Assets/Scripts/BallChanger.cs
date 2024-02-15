using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallChanger : MonoBehaviour
{

    private GameObject[] ball;
    private GameObject[] tempBall;

    void Start()
    {
        ball = new GameObject[6]; // Ball dizisini 5 elemanlý olarak oluþtur
        
        for (int i = 1; i <= 6 ; i++)
        {
            tempBall = GameObject.FindGameObjectsWithTag("Ball" + i);
            if (tempBall.Length > 0)
            {
                ball[i - 1] = tempBall[0]; // Ýlk bulunan nesneyi diziye ekle
            }
        }

        for (int i = 0; i < 6; i++)
        {
            if (i+1 == PlayerPrefs.GetInt("CurrentSkin"))
            {
                ball[i].SetActive(true);
            }
            else
            {
                ball[i].SetActive(false);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
     
    }
}
