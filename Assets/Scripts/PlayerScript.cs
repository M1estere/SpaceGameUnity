using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    public float tilt;
    float speed = 30;
    // float speed2 = 60;
    public float xMin, xMax, zMin, zMax;

    public GameObject lazerShot; // можно положить сам объект (чем стрелять)
    public GameObject torped;

    public Transform lazerGun; // откуда стрелять
    public Transform lazerGun2;
    public Transform lazerGun3;
    public Transform lazerGun4;

    public float shotDelay; // сколько между выстрелами времени

    public GameObject asteroidExplosion; // взрыв астероида

    public GameObject engineTurbo;  // двигатели, включаемые для ускорения
    public GameObject engineTurbo2;
    public GameObject engineHyper;
    public GameObject engineHyper2;

    public GameObject toLeftEngine;
    public GameObject toRightEngine;


    float nextShotTime;

    Rigidbody playerShip;

    private void Awake()  // вызывается раньше всех методов
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        playerShip = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {        

        if(GameControllerScript.instance.lives == 0)
        {
            SceneManager.LoadScene("Restart_Screen");
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        playerShip.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;

        float restrictedX = Mathf.Clamp(playerShip.position.x, xMin, xMax);
        float restrictedZ = Mathf.Clamp(playerShip.position.z, zMin, zMax);

        playerShip.position = new Vector3(restrictedX, 0, restrictedZ);

        playerShip.rotation = Quaternion.Euler(tilt * playerShip.velocity.z, 0,tilt * -playerShip.velocity.x);
       
        if (Time.time > nextShotTime && Input.GetButton("Fire1") && GameControllerScript.instance.charge > 0) // левая кнопка мыши
        {
            Instantiate(lazerShot, lazerGun.position, Quaternion.identity); // можно создать gameObject
            Instantiate(lazerShot, lazerGun2.position, Quaternion.identity);
            nextShotTime = Time.time + shotDelay;
            GameControllerScript.instance.decreaseCharge(25);
        }

        if (GameControllerScript.instance.fuel > 0 && Input.GetKey(KeyCode.LeftShift) && GameControllerScript.instance.score >= 50) // ускорение
        {
            engineTurbo.SetActive(true);
            engineTurbo2.SetActive(true);
            engineHyper.SetActive(true);
            engineHyper2.SetActive(true);
            speed = 60;
            GameControllerScript.instance.fuelDown(1);
        }

        else
        {
            engineTurbo.SetActive(false);
            engineTurbo2.SetActive(false);
            engineHyper.SetActive(false);
            engineHyper2.SetActive(false);
            speed = 30;
        }

        if (Input.GetKeyDown("e") && GameControllerScript.instance.fuel >=10)
        {
            playerShip.position = new Vector3(20, 0, -46);
            GameControllerScript.instance.fuelDown(10);
            toRightEngine.SetActive(true);
        }

        if (Input.GetKeyDown("q") && GameControllerScript.instance.fuel >= 10)
        {
            playerShip.position = new Vector3(-20, 0, -46);
            GameControllerScript.instance.fuelDown(10);
            toLeftEngine.SetActive(true);
        }
        
        toRightEngine.SetActive(false); // отключение боковых двигателей
        toLeftEngine.SetActive(false);

        if(GameControllerScript.instance.score >= 100 /* счёт больше 100*/ && Time.time > nextShotTime && Input.GetButton("Fire2"))
        {
            GameControllerScript.instance.decreaseScore(100);
            Instantiate(torped, lazerGun3.position, Quaternion.identity);
            nextShotTime = Time.time + shotDelay;
        }

        if (GameControllerScript.instance.score == 1000) // выигрыш
        {
            SceneManager.LoadScene("Win");
        }

        if (GameControllerScript.instance.score == -100) // проигрыш
        {
            SceneManager.LoadScene("Restart_Screen");
        }

    }
}
