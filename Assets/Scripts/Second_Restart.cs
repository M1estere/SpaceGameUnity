using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Second_Restart : MonoBehaviour
{
    public void RestartLevel()
    {
        SceneManager.LoadScene("Second_Level");
    }
}
