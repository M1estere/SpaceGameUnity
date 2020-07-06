using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toControls : MonoBehaviour
{
    // Start is called before the first frame update
    public void Control()
    {
        SceneManager.LoadScene("Controls_Scene");
    }

}
