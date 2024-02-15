    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

    void Start()
    {

    }
    private void Update()
    {

    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main");
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene("LevelFailMenu");
    }

    public void ProceedScene()
    {
        int sceneIndex = PlayerPrefs.GetInt("LevelCount");
        SceneManager.LoadScene("Level" + sceneIndex);
    }
    public void LoadCurrentScene()
    {
        int sceneIndex = PlayerPrefs.GetInt("LevelCount");
        SceneManager.LoadScene(sceneIndex);
    }

    public void Scene2()
    {
        ChangeScene("Main");
    }
}
