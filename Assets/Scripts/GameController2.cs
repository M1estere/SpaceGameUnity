using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController2 : MonoBehaviour
{
    public UnityEngine.UI.Text scoreText;

    public static GameController2 instance;

    int score = 0;

    public void increaseScore(int increment) // для других скриптов
    {
        score += increment;
        scoreText.text = "Score: " + score;
    }
    public void finish()
    {
        if (score == 2000) // сколько очков для завершения уровня
        {
        SceneManager.LoadScene("Win");

        }
    }

    void Start()
    {
        instance = this;
    }
}