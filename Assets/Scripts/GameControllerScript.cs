using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    public UnityEngine.UI.Text scoreText;
    public UnityEngine.UI.Text CountText;
    public UnityEngine.UI.Text livesText;
    public UnityEngine.UI.Text fuelText;
    public UnityEngine.UI.Text chargeText;

    public static GameControllerScript instance;

    public int score = 0;
    public int count = 0;
    public int lives = 3;
    public int fuel = 1000;
    public int charge = 1000;

    public void fuelDown(int decrement)
    {
        fuel -= decrement;
        fuelText.text = "Fuel: " + fuel;
    }

    public void fuelUp(int increment)
    {
        fuel += increment;
        fuelText.text = "Fuel: " + fuel;
    }

    public void increaseScore(int increment) // для других скриптов
    {
        score += increment;
        scoreText.text = "Score: " + score;
    }

    public void decreaseScore(int decrement)  
    {
        score -= decrement;
        scoreText.text = "Score " + score;
    }

    public void increaseCount(int plus)
    {
        count += plus;
        CountText.text = "Count: " + count;
    }

    public void decreaseLives(int decrement)
    {
        lives -= decrement;
        livesText.text = "Lives: " + lives;
    }

    public void increaseLives(int increment)
    {
        lives += increment;
        livesText.text = "Lives: "  + lives;
    }

    public void decreaseCharge(int decrement)
    {
        charge -= decrement;
        chargeText.text = "Charge: " + charge;
    }

    public void increaseCharge(int increment)
    {
        charge += increment;
        chargeText.text = "Charge: " + charge;
    }

    void Start()
    {
        instance = this;
    }
}
