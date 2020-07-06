using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript2 : MonoBehaviour
{

    public float tilt;
    public float speed;
    public float xMin, xMax, zMin, zMax;
    
    public GameObject lazerShot; // можно положить сам объект
    public GameObject torped;
    public Transform lazerGun; // откуда стрелять
    public Transform lazerGun2;
    public Transform lazerGun3;
    public Transform lazerGun4;
    public float shotDelay; // сколько между выстрелами времени
    public GameObject asteroidExplosion;

    float nextShotTime;

    Rigidbody playerShip;

    // Start is called before the first frame update
    void Start()
    {
        playerShip = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {        

        float moveHorizontal = Input.GetAxis("Horizontal"); // -1 - left, +1 - right
        float moveVertical = Input.GetAxis("Vertical"); // -1 - down, +1 - up

        playerShip.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;

        float restrictedX = Mathf.Clamp(playerShip.position.x, xMin, xMax);
        float restrictedZ = Mathf.Clamp(playerShip.position.z, zMin, zMax);

        playerShip.position = new Vector3(restrictedX, 0, restrictedZ);

        playerShip.rotation = Quaternion.Euler(tilt * playerShip.velocity.z, 0,tilt * -playerShip.velocity.x);

        // создавать лазерный выстрел
        
        if (Time.time > nextShotTime && Input.GetButton("Fire1")) // левая кнопка мыши
        {
            Instantiate(lazerShot, lazerGun.position, Quaternion.identity); // можно создать gameobject
            Instantiate(lazerShot, lazerGun2.position, Quaternion.identity);
            nextShotTime = Time.time + shotDelay;
        }
        
        if(Time.time > nextShotTime && Input.GetButton("Fire2"))
        {
            Instantiate(torped, lazerGun3.position, Quaternion.identity);
            nextShotTime = Time.time + shotDelay;
        }

        GameController2.instance.finish();
    }
}

