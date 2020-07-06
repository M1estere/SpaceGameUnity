using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonLink : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Link()
    {
        Application.OpenURL("https://vk.com/ilya_solov0");
    }

    public void link2()
    {
        Application.OpenURL("https://www.instagram.com/ilya_solov/?hl=ru");        
    }
}
