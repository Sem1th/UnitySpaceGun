using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{

    Vector3 startPosition;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       float zMovement = Mathf.Repeat( Time.time * speed, 100); // 0...100
        transform.position = startPosition + Vector3.back * zMovement;
    }
}
