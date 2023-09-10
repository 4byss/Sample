using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnCollisionEnter (Collision collisionInfo) {
        if(collisionInfo.collider.tag == "Car") {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
