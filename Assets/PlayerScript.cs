using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody playerShip;
    public GameObject laserShot; //чем стрелять
    public GameObject laserGunF; //откуда стрелять
    public GameObject laserGunT;
    public float shotDelay; //задержка

    float nextShotTime;


    public float speed;
    public float tilt;
    public float xMin, xMax, zMin, zMax;

    // Start is called before the first frame update
    void Start()
    {
       playerShip = GetComponent<Rigidbody>(); 
      
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.isStarted == false)
        {
            return;
        }

        // Touch finger - Input.touches [0];
        // finger.position.x/y
        //Scren.currentResolution
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

         // playerShip.velocity = new Vector3(10, 0, 5);
        playerShip.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;

        float xPosition = Mathf.Clamp(playerShip.position.x, xMin, xMax);
        float zPosition = Mathf.Clamp(playerShip.position.z, zMin, zMax);
        playerShip.position = new Vector3(xPosition, 0, zPosition);

        playerShip.rotation = Quaternion.Euler(playerShip.velocity.z * tilt, 0, - playerShip.velocity.x * tilt);
    
        if(Time.time > nextShotTime && Input.GetButton("Fire1"))
        {
            Instantiate(laserShot, laserGunF.transform.position, Quaternion.identity);
            Instantiate(laserShot, laserGunT.transform.position, Quaternion.identity);
            nextShotTime = Time.time + shotDelay;
        }
       // if (Input.GetButton("Fire2"))
       // {
        //    GameObject[] gameObject = GameObject.FindGameObjectsWithTag("Asteroid");
        //    foreach (GameObject asteroid in gameObject)
        //    {
        //        Destroy(asteroid);
        //    }
        }
    
    
    }

