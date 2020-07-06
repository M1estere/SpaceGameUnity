using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusLivesScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody bonusLives = GetComponent<Rigidbody>();
        float speed = 30;
        bonusLives.velocity = new Vector3(0, 0, -speed);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player") // тег игрок и топлива меньше 1200
        {           
            GameControllerScript.instance.increaseLives(1);
            Destroy(gameObject);
        }

        if (other.tag == "GameBoundary" || other.tag == "Asteroid" || other.tag == "bonus" || other.tag == "Torped" || other.tag == "bonusLives")
        {
            return;
        }
        
    }

}
