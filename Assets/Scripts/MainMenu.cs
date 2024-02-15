using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public GameObject jungleScene;
    //public GameObject tableScene;
    //public GameObject footballScene;
    int levelCount = PointSystem.levelCount;
    
       void Start()
        {

        PlayerPrefs.SetInt("LevelCount", levelCount);

        if (PlayerPrefs.GetInt("CurrentSkin") == 0)
        {
            PlayerPrefs.SetInt("CurrentSkin", 1);
        }

            //jungleScene.SetActive(false);
            //tableScene.SetActive(false);
            //footballScene.SetActive(false);

            //if (levelCount >= 1 && levelCount <= 5)
            //{
            //    tableScene.SetActive(true);
            //}
            //else if (levelCount > 5 && levelCount <= 10)
            //{
            //    jungleScene.SetActive(true);
            //}
            //else if (levelCount > 10 && levelCount <= 15)
            //{
            //    footballScene.SetActive(true);
            //}
            
        }
    
    public void PlayButton()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("LevelCount"));
        
    }
    public void Store()
    {
        SceneManager.LoadScene("Store");
    }
} 




















/* Ses ve Müzik Kodumuz Olacak -> 
 * 
 * Reklam Kodumuz Olacak -> 
 * 
 * Arayuz eksýklýklerý ->
 * 
 * 
 * 
 * 
 * 
 * 
 * */