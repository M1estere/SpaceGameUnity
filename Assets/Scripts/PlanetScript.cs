using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -speed);
        Rigidbody planet = GetComponent<Rigidbody>();
        planet.angularVelocity = Random.insideUnitSphere * rotationSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
