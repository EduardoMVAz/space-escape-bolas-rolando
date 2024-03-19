using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBMW : MonoBehaviour
{
    private Rigidbody rb;
    public int orientation;
    public float lowX;
    public float highX;

    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void FixedUpdate()
    {
        if (transform.position.x >= highX && orientation == 0) {
            orientation = 1;
            transform.position = new Vector3(highX, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= lowX && orientation == 1) {
            transform.position = new Vector3(lowX, transform.position.y, transform.position.z);
            orientation = 0;
        }

        if (orientation == 0) {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        } else if (orientation == 1) {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
        }
    }
}
