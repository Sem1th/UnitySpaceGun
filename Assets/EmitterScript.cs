using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterScript : MonoBehaviour
{

    public GameObject asteroidF;
   // public GameObject asteroidT;
    public float minDelay, maxDelay;
    float nextTimeLaunchStart;


    

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.isStarted == false)
        {
            return;
        }
        if (Time.time > nextTimeLaunchStart)
        {
            float xPosition = Random.Range(-transform.localScale.x/2, transform.localScale.x/2);
            float zPosition = transform.position.z;
            Vector3 asteroidFPosition = new Vector3 (xPosition, 0, zPosition);
          //  Vector3 asteroidTPosition = new Vector3 (xPosition, 0, zPosition);
            Instantiate(asteroidF, asteroidFPosition, Quaternion.identity);
           // Instantiate(asteroidT, asteroidTPosition, Quaternion.identity);


            nextTimeLaunchStart = Time.time + Random.Range(minDelay, maxDelay);
        }
    }
}
