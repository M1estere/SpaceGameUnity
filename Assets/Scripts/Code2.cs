using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code2 : MonoBehaviour
{
    
    public GameObject asteroid3;
    public GameObject bonus;
    public GameObject bonusLives;


    // public GameObject EnemyShip;
    // public GameObject bonusSpeed;

    public float minDelay, maxDelay, minDelay2, maxDelay2, minDelay3, maxDelay3;
    float nextLaunchTime;
    float nextLaunchTime2;
    float nextLaunchTimeBonus;

    void Update()
    {

        float positionZ = transform.position.z;
        float positionX = Random.Range(-transform.localScale.x/2, transform.localScale.x/2);

        if (Time.time > nextLaunchTime)
        {
            Instantiate(asteroid3, new Vector3(positionX, 0, positionZ), Quaternion.identity);
            nextLaunchTime = Time.time + Random.Range(minDelay, maxDelay);
        }
        if (Time.time > nextLaunchTime2)
        {
            Instantiate(bonus, new Vector3(positionX, 0, positionZ), Quaternion.identity);
            nextLaunchTime2 = Time.time + Random.Range(minDelay2, maxDelay2);            
        }
        if (Time.time > nextLaunchTimeBonus)
        {
            Instantiate(bonusLives, new Vector3(positionX, 0, positionZ), Quaternion.identity);
            nextLaunchTimeBonus = Time.time + Random.Range(minDelay3, maxDelay3);
        }
    }
}
