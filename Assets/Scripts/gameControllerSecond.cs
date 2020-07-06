using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameControllerSecond : MonoBehaviour
{
 
    public UnityEngine.UI.Button restartButton;
    public GameObject menu;
    public static gameControllerSecond instance;

    bool die = false;

    public bool Dead()
    {
        return die;
    }

    void Start()
    {
        instance = this;
        AudioSource sound = GetComponent<AudioSource>();
        restartButton.onClick.AddListener(delegate{
            menu.SetActive(false); 
            die = true;
            sound.Play();
            SceneManager.LoadScene("Second_Level");
    });
    }
}