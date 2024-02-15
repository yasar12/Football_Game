using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuCoinManager : MonoBehaviour
{
    public TMP_Text text;
    public TMP_Text tempText;


    void Update()
    {
        text.SetText(PlayerPrefs.GetInt("Coins") + "");

        int y = SceneManager.GetActiveScene().buildIndex;
        if (y == 17)
        {
            GetComponent<MenuCoinManager>().tempText = GameObject.Find("TempCoins").GetComponent<TextMeshProUGUI>();
            tempText.SetText(PlayerPrefs.GetInt("TempCoins").ToString());
        }
        else
        {
            GetComponent<MenuCoinManager>().tempText = GameObject.Find("Coins").GetComponent<TextMeshProUGUI>();
        }
    }
}
