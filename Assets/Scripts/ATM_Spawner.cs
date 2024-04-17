using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATM_Spawner : MonoBehaviour
{
    
    public GameObject[] objectPrefabs; // Array of prefabs to spawn
    public int numberOfObjects = 10; // Number of objects to spawn
    public GameObject spawnCenter;
    public float areaRadius = 20f; // Radius for spawning objects randomly around the spawner
    public float minScale = 1f;    // Minimum scale multiplier
    public float maxScale = 5.0f;

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            // Randomly pick a prefab from the array
            GameObject prefabToSpawn = objectPrefabs[Random.Range(0, objectPrefabs.Length)];

            // Generate a random position within a circle around the spawner
            Vector3 randomPosition = spawnCenter.transform.position + Random.insideUnitSphere * areaRadius;
            randomPosition.y = Random.Range(spawnCenter.transform.position.y-5f, spawnCenter.transform.position.y+5f); // Adjust based on your game's vertical axis requirements

            // Generate a random rotation
            Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);

            // Instantiate the prefab with the random position and rotation
            GameObject spawnedObject = Instantiate(prefabToSpawn, randomPosition, randomRotation);

            // Generate a random scale factor
            float scaleFactor = Random.Range(minScale, maxScale);

            // Set the scale of the spawned object
            spawnedObject.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);


        }
    }


}
