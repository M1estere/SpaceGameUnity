using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusScript : MonoBehaviour
{

    public GameObject bonusExplosion;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody bonus = GetComponent<Rigidbody>();
        float speed = 30;
        bonus.velocity = new Vector3(0, 0, -speed);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player") // тег игрок и топлива меньше 1200
        {           
            GameControllerScript.instance.fuelUp(50); // сколько топлива за подбор
            GameControllerScript.instance.increaseCharge(25);
            Destroy(gameObject);
        }

        if (other.tag == "GameBoundary" || other.tag == "Asteroid" || other.tag == "bonus" || other.tag == "Torped")
        {
            return;
        }
        
    }
}
