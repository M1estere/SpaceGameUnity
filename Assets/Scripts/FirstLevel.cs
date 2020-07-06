using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstLevel : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("First_Level");
    }
    
}
