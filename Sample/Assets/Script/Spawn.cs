using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] objReference;
    private GameObject spawnedCars;
    public Transform L1,L2,L3,L4;

    private int randomIndex;
    private int randomSide;
    // public float speed = 50f;

    void Start() {
        StartCoroutine(SpawnCars());
    }

    void Update() {
        // Vector3 move = new Vector3(0,0,1);
        // transform.Translate(move * speed * Time.deltaTime);
    }

    IEnumerator SpawnCars() {
        while(true) {
            yield return new WaitForSeconds(Random.Range(1f, 2.2f));
            randomIndex = Random.Range(0, objReference.Length);
            randomSide = Random.Range(0, 4);

            spawnedCars = Instantiate(objReference[randomIndex]);

            switch (randomSide) 
            {
                case 0: 
                spawnedCars.transform.position = L1.position;
                spawnedCars.GetComponent<CarVelocity>().speed = Random.Range(150f, 200f);
                break;
                case 1: 
                spawnedCars.transform.position = L2.position;
                spawnedCars.GetComponent<CarVelocity>().speed = Random.Range(150f, 200f);
                break;
                case 2: 
                spawnedCars.transform.position = L3.position;
                spawnedCars.GetComponent<CarVelocity>().speed = Random.Range(150f, 200f);
                break;
                case 3: 
                spawnedCars.transform.position = L4.position;
                spawnedCars.GetComponent<CarVelocity>().speed = Random.Range(150f, 200f);
                break;
                default: Debug.Log("ERROR IN SPAWNING!!!");
                break;
            }
        }
    }

    
}
