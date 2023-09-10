using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarVelocity : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector3(0,0,1 * speed);
    }
}
