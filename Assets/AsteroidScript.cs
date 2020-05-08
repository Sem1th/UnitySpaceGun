using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{

    public float rotationSpeed;
    public float minSpeed, maxSpeed;
    public GameObject playerExplosion;

    public GameObject asteroidExplosion;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed;
        

        float zSpeed = Random.Range(minSpeed, maxSpeed);
        asteroid.velocity = new Vector3 (0, 0 , -zSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);


        if (other.tag == "GameBoundary")
        {
            return;
        }

        if (other.tag == "Laser")
        {
        GameController.instance.incrementScore(7);
        }
    
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
            // нужно показать взрыв игрока
        }

        Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
    }

}
