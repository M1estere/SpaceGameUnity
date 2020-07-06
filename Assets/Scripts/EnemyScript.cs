using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float speed;

    public GameObject lazerShot; // можно положить сам объект
    public Transform lazerGun; // откуда стрелять
    public float shotDelay; // сколько между выстрелами времени
    public GameObject playerExplosion;

    float nextShotTime;

    Rigidbody Enemy;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
