using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonusScript : MonoBehaviour
{

    public GameObject bonusExplosion;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody bonus = GetComponent<Rigidbody>();
        
        bonus.velocity = new Vector3(0, 0, -speed);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "bonus" || other.tag == "GameBoundary")
        {
            return;
        }
        if (other.tag == "Asteroid")
        {
            return;
        }
    
        GameObject explosion = Instantiate(bonusExplosion, transform.position, Quaternion.identity);

        Destroy(gameObject);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
