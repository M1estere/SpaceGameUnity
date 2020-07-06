using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterScript : MonoBehaviour
{

    // public GameObject bonus;
    public GameObject asteroid;


    // public GameObject EnemyShip;
    // public GameObject bonusSpeed
    public float minDelay, maxDelay; // minDelay2, maxDelay2;
    float nextLaunchTime;
    //private float myArray = (asteroid, asteroid2, asteroid3); 
    //private GameObject asteroidSubj = myArray[Random.Range(0, myArray.Length)];
    // Update is called once per frame
    void Update()
    {

        float positionZ = transform.position.z;
        float positionX = Random.Range(-transform.localScale.x/2, transform.localScale.x/2);

        if (Time.time > nextLaunchTime)
        {
            
            Instantiate(asteroid, new Vector3(positionX, 0, positionZ), Quaternion.identity);
            nextLaunchTime = Time.time + Random.Range(minDelay, maxDelay);

        }
    }
}
