using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public int numberOfPowerUps = 10;       // How many power ups to spawn
    public float minXSpawn = 0.1f;            // The min x position that power ups can spawn
    public float maxXSpawn = 0.3f;           // The max x position that power ups can spawn
    public float minYSpawn = 0.1f;
    public float maxYSpawn = 0.3f;
    public GameObject powerUpPrefab;        // The prefab of the power up to be spawned

    void Start()
    {
            
            float randomX = Random.Range(minXSpawn, maxXSpawn);
            float randomY = Random.Range(minYSpawn, maxYSpawn);
            Vector2 spawnPosition = Vector2.zero;       // Create a variable to store the spawn position being generated
            spawnPosition.x = randomX;                  // Assign x to be our random x value
            spawnPosition.y = randomY;                   // Assign y to our desired y position

            // Instantiate our powerup at the spawn position with a default rotation
            Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
