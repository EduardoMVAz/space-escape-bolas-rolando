using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KW : MonoBehaviour
{
    private Rigidbody rb;
    public int orientation;
    public float lowZ;
    public float highZ;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z >= highZ && orientation == 0) {
            orientation = 1;
            transform.position = new Vector3(transform.position.x, transform.position.y, highZ);
        }
        else if (transform.position.z <= lowZ && orientation == 1) {
            transform.position = new Vector3(transform.position.x, transform.position.y, lowZ);
            orientation = 0;
        }

        if (orientation == 0) {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
        } else if (orientation == 1) {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed);
        }
    }
}
