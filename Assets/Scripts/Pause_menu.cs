using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_menu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Continue();
            } 
            
            else
            {
                AudioListener.pause = true;
                Pause();
            }
        }
    }
    public void Continue()
    {
        AudioListener.pause = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void MainMenu()
    {
        AudioListener.pause = false;
        Debug.Log("Load");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main_Scene");
    }

    public void Exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
