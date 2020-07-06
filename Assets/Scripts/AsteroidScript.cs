using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidScript : MonoBehaviour
{

    public GameObject AsteroidExplosion;
    public GameObject PlayerExplosion;
    public float rotationSpeed;
    public float minSpeed, maxSpeed;
    public float minSize, maxSize;

    float size;
    
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed;
        float speed = Random.Range(minSpeed, maxSpeed);
        asteroid.velocity = new Vector3(0, 0, -speed);

        size = Random.Range(minSize, maxSize);
        asteroid.transform.localScale *= size;
    }

    // при вхождение с другим объектом
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Asteroid" || other.tag == "GameBoundary" || other.tag == "bonus")
        {
            return;
        }

        Destroy(gameObject); // уничтожаем текущий объект

        GameObject explosion = Instantiate(AsteroidExplosion, transform.position, Quaternion.identity);

        explosion.transform.localScale *= size;

        if (other.tag == "Player")
        {
            GameControllerScript.instance.decreaseLives(1);
            GameControllerScript.instance.increaseCount(1);
            GameControllerScript.instance.decreaseScore(10);
        }

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject); // уничтожение второго объекта
            GameControllerScript.instance.increaseScore(10); // увеличениe очков на 10
            GameControllerScript.instance.increaseCount(1);
            GameControllerScript.instance.increaseCharge(5);
        }

        if (other.tag == "Torped")
        {
            GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
            foreach(GameObject asteroid in asteroids)
            {
                Destroy(other.gameObject);
                Destroy(asteroid);
                Instantiate(AsteroidExplosion, asteroid.transform.position, Quaternion.identity);
                GameControllerScript.instance.increaseScore(5);
                GameControllerScript.instance.increaseCount(1);
            }
        }
       
    }
}
