using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using Unity.VisualScripting;
using JetBrains.Annotations;

public class StoreManager : MonoBehaviour
{
    public TMP_Text text;
    private int coins;
    int ball1_;
    int ball2_;
    int ball3_;
    int ball4_;
    int ball5_;
    int ball6_;
    public Image ball1GT;
    public Image ball1BT;
    public Image ball1PT;
    public Image ball2GT;
    public Image ball2BT;
    public Image ball2PT;
    public Image ball3GT;
    public Image ball3BT;
    public Image ball3PT;
    public Image ball4GT;
    public Image ball4BT;
    public Image ball4PT;
    public Image ball5GT;
    public Image ball5BT;
    public Image ball5PT;
    public Image ball6GT;
    public Image ball6BT;
    public Image ball6PT;
    private GameObject[] ball;
    private GameObject[] tempBall;
    bool hasRecursed = false;

    int currentSkin;
    private void Awake()
    {
        if(PlayerPrefs.GetInt("CurrentSkin") == 0)
        {
            PlayerPrefs.SetInt("CurrentSkin", 1); 
        }

        UpdateBallStatus(2, ball2GT, ball2BT, ball2PT);
        UpdateBallStatus(3, ball3GT, ball3BT, ball3PT);
        UpdateBallStatus(4, ball4GT, ball4BT, ball4PT);
        UpdateBallStatus(5, ball5GT, ball5BT, ball5PT);
        UpdateBallStatus(6, ball6GT, ball6BT, ball6PT);
        UpdateBallStatus(6, ball6GT, ball6BT, ball6PT);
        text.SetText(PlayerPrefs.GetInt("Coins") + "");
        ball1_ = PlayerPrefs.GetInt("Ball1");
        ball2_ = PlayerPrefs.GetInt("Ball2");
        ball3_ = PlayerPrefs.GetInt("Ball3");
        ball4_ = PlayerPrefs.GetInt("Ball4");
        ball5_ = PlayerPrefs.GetInt("Ball5");
        ball6_ = PlayerPrefs.GetInt("Ball6");
        currentSkin = PlayerPrefs.GetInt("CurrentSkin");
        coins = PlayerPrefs.GetInt("Coins");
    }

    // Start is called before the first frame update
    void Start()
    {

        UpdateBallStatus(1, ball1GT, ball1BT, ball1PT);
        UpdateBallStatus(2, ball2GT, ball2BT, ball2PT);
        UpdateBallStatus(3, ball3GT, ball3BT, ball3PT);
        UpdateBallStatus(4, ball4GT, ball4BT, ball4PT);
        UpdateBallStatus(5, ball5GT, ball5BT, ball5PT);
        UpdateBallStatus(6, ball6GT, ball6BT, ball6PT);
        UpdateBallStatus(6, ball6GT, ball6BT, ball6PT);
        text.SetText(PlayerPrefs.GetInt("Coins") + "");
        ball1_ = PlayerPrefs.GetInt("Ball1");
        ball2_ = PlayerPrefs.GetInt("Ball2");
        ball3_ = PlayerPrefs.GetInt("Ball3");
        ball4_ = PlayerPrefs.GetInt("Ball4");
        ball5_ = PlayerPrefs.GetInt("Ball5");
        ball6_ = PlayerPrefs.GetInt("Ball6");
        currentSkin = PlayerPrefs.GetInt("CurrentSkin");
        coins = PlayerPrefs.GetInt("Coins");
        PlayerPrefs.SetInt("PriceBall2", 25);
        PlayerPrefs.SetInt("PriceBall3", 50);
        PlayerPrefs.SetInt("PriceBall4", 75);
        PlayerPrefs.SetInt("PriceBall5", 75);
        PlayerPrefs.SetInt("PriceBall6", 100);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("CURRENT SKIN : "+PlayerPrefs.GetInt("CurrentSkin"));
        // Debug.Log(currentSkin);
        text.SetText("Coins : " + PlayerPrefs.GetInt("Coins") + "");
        coins = PlayerPrefs.GetInt("Coins");
        if (Input.touchCount > 0)
        {
            updateStatus();
        }
        //  Debug.Log("Current SKIN : "+PlayerPrefs.GetInt("CurrentSkin"));
        //  Debug.Log("Touch COUNT : "+Input.touchCount);

    }
    private void updateStatus()
    {
        UpdateBallStatus(1, ball1GT, ball1BT, ball1PT);
        UpdateBallStatus(2, ball2GT, ball2BT, ball2PT);
        UpdateBallStatus(3, ball3GT, ball3BT, ball3PT);
        UpdateBallStatus(4, ball4GT, ball4BT, ball4PT);
        UpdateBallStatus(5, ball5GT, ball5BT, ball5PT);
        UpdateBallStatus(6, ball6GT, ball6BT, ball6PT);
    }

    public void Ball1()
    {

        if (ball1_ != 0)
        {
            currentSkin = 1;
            PlayerPrefs.SetInt("CurrentSkin", 1);
        }
        else if (coins >= 15)
        {
            coins = PlayerPrefs.GetInt("Coins");
            coins -= PlayerPrefs.GetInt("PriceBall"); 
            PlayerPrefs.SetInt("Ball1", 1);
            PlayerPrefs.SetInt("Coins", coins);
            ball1_ = PlayerPrefs.GetInt("Ball1");
            currentSkin = 1;
        }
        if (!hasRecursed)
        {
            hasRecursed = true;
            Ball1();
        }
        UpdateBallStatus(1, ball1GT, ball1BT, ball1PT);
        hasRecursed = false;
    }

    public void Ball2()
    {
        if (ball2_ != 0)
        {
            currentSkin = 2;
            PlayerPrefs.SetInt("CurrentSkin", 2);
        }
        else if (coins >= 15)
        {
            coins = PlayerPrefs.GetInt("Coins");
            coins -= PlayerPrefs.GetInt("PriceBall2");
            PlayerPrefs.SetInt("Ball2", 1);
            PlayerPrefs.SetInt("Coins", coins);
            ball2_ = PlayerPrefs.GetInt("Ball2");
            currentSkin = 2;
        }
        if (!hasRecursed)
        {
            hasRecursed = true;
            Ball2();
        }
        UpdateBallStatus(2, ball2GT, ball2BT, ball2PT);
        hasRecursed = false;
    }

    public void Ball3()
    {
        if (ball3_ != 0)
        {
            currentSkin = 3;
            PlayerPrefs.SetInt("CurrentSkin", 3);
        }
        else if (coins >= 15)
        {
            coins = PlayerPrefs.GetInt("Coins");
            coins -= PlayerPrefs.GetInt("PriceBall3");
            PlayerPrefs.SetInt("Ball3", 1);
            PlayerPrefs.SetInt("Coins", coins);
            ball3_ = PlayerPrefs.GetInt("Ball3");
            currentSkin = 3;
        }
        if (!hasRecursed)
        {
            hasRecursed = true;
            Ball3();
        }     
        UpdateBallStatus(3, ball3GT, ball3BT, ball3PT);
        hasRecursed = false;
    }

    public void Ball4()
    {
        if (ball4_ != 0)
        {
            currentSkin = 4;
            PlayerPrefs.SetInt("CurrentSkin", 4);
        }
        else if (coins >= 15)
        {
            coins = PlayerPrefs.GetInt("Coins");
            coins -= PlayerPrefs.GetInt("PriceBall4");
            PlayerPrefs.SetInt("Ball4", 1);
            PlayerPrefs.SetInt("Coins", coins);
            ball4_ = PlayerPrefs.GetInt("Ball4");
            currentSkin = 4;
        }
        if (!hasRecursed)
        {
            hasRecursed = true;
            Ball4();
        }
        UpdateBallStatus(4, ball4GT, ball4BT, ball4PT);
        hasRecursed = false;
    }

    public void Ball5()
    {
        if (ball5_ != 0)
        {
            currentSkin = 5;
            PlayerPrefs.SetInt("CurrentSkin", 5);
        }
        else if (coins >= 15)
        {
            coins = PlayerPrefs.GetInt("Coins");
            coins -= PlayerPrefs.GetInt("PriceBall5");
            PlayerPrefs.SetInt("Ball5", 1);
            PlayerPrefs.SetInt("Coins", coins);
            ball5_ = PlayerPrefs.GetInt("Ball5");
            currentSkin = 5;
        }
        if (!hasRecursed)
        {
            hasRecursed = true;
            Ball5();
        }
        UpdateBallStatus(5, ball5GT, ball5BT, ball5PT);
        hasRecursed = false;
    }

    public void Ball6()
    {
        if (ball6_ != 0)
        {
            currentSkin = 6;
            PlayerPrefs.SetInt("CurrentSkin", 6);
        }
        else if (coins >= 15)
        {
            coins = PlayerPrefs.GetInt("Coins");
            coins -= PlayerPrefs.GetInt("PriceBall6");
            PlayerPrefs.SetInt("Ball6", 1);
            PlayerPrefs.SetInt("Coins", coins);
            ball6_ = PlayerPrefs.GetInt("Ball6");
            currentSkin = 6;
        }
        if (!hasRecursed)
        {
            hasRecursed = true;
            Ball6();
        }
        UpdateBallStatus(6, ball6GT, ball6BT, ball6PT);
        hasRecursed = false;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main");
    }
    public void Delete()
    {
        PlayerPrefs.DeleteAll();
    }
    //gt-> green tick bt-> black tick pt-> price tag
    private void UpdateBallStatus(int ballNumber, Image gtImage, Image btImage, Image ptImage)
    {
        int ballStatus = PlayerPrefs.GetInt("Ball" + ballNumber);

        if (ballStatus == 1)
        {
            if (currentSkin == ballNumber)
            {
                gtImage.enabled = true;
                btImage.enabled = false;
                ptImage.enabled = false;
            }
            else
            {
                gtImage.enabled = false;
                btImage.enabled = true;
                ptImage.enabled = false;
            }
        }
        else
        {
            gtImage.enabled = false;
            btImage.enabled = false;
            ptImage.enabled = true;
        }
    }

}
