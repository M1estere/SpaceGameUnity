using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SecondLevel : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Second_Level");
    }

    public void Chapter2()
    {
        SceneManager.LoadScene("Level_Chapter2");
    }

    public void Chapter1()
    {
        SceneManager.LoadScene("Level_Scene");
    }

    public void Level1()
    {
        SceneManager.LoadScene("First_Level");
    }
}
