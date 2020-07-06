using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidSecond : MonoBehaviour
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

        if (other.tag == "Asteroid" || other.tag == "GameBoundary")
        {
            return;
        }


        Destroy(gameObject); // уничтожаем текущий объект
        Destroy(other.gameObject); // уничтожаем второй объект

        GameObject explosion = Instantiate(AsteroidExplosion, transform.position, Quaternion.identity);

        explosion.transform.localScale *= size;

        if (other.tag == "Player")
        {
            Instantiate(PlayerExplosion, other.transform.position, Quaternion.identity);
            SceneManager.LoadScene("Restart_Second");
        }
        if (other.tag == "Laser")
        {
            GameController2.instance.increaseScore(10); // увеличениe очков на 10
        }
        if (other.tag == "Torped")
        {
            GameController2.instance.increaseScore(5);
        }
    }
}
