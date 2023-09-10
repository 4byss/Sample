using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FinishGameCollider : MonoBehaviour
{
    private string PLAYER_TAG = "Player";

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag(PLAYER_TAG))
        {
            FindObjectOfType<GameManager>().FinishGame();
        }
        
    }
}
