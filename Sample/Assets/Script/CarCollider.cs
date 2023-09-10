using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollider : MonoBehaviour
{
    private string CAR_TAG = "Car";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(CAR_TAG))
        {
            Destroy(collision.gameObject);
        }
        
    }
}
