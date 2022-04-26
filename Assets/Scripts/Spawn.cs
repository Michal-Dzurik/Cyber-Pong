using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour{
         
    public int minXSpawn = -600;            // The min x position that power ups can spawn
    public int maxXSpawn = 600;           // The max x position that power ups can spawn
    public int minYSpawn = -350;
    public int maxYSpawn = 350;
    public GameObject powerUpPrefab;        // The prefab of the power up to be spawned
    public Canvas canvas;
    public bool isSpawned=true;
    private GameObject powerUp;

    void Start(){
        SpawnPowerUp();
    }

    // Update is called once per frame
    void Update(){
        
        if (!isSpawned){
            StartCoroutine(WaitAndSpawn());
            isSpawned = true;
        }
    }
    private IEnumerator WaitAndSpawn() {
        yield return new WaitForSeconds(5f);
        SpawnPowerUp();

    }
    public void SpawnPowerUp() {
        int randomX = Random.Range(minXSpawn, maxXSpawn);
        int randomY = Random.Range(minYSpawn, maxYSpawn);
        Vector2 spawnPosition = Vector2.zero;       // Create a variable to store the spawn position being generated
        spawnPosition.x = (float)randomX;                  // Assign x to be our random x value
        spawnPosition.y = (float)randomY;                   // Assign y to our desired y position
        
        // Instantiate our powerup at the spawn position with a default rotation
        if(powerUp == null) {
            powerUp = (GameObject)Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity);
            Debug.Log("Spawning new Power UP" + isSpawned);
            powerUp.transform.SetParent(canvas.transform);
            powerUp.transform.localScale = new Vector3(30f, 30f, 30f);
            powerUp.GetComponent<Fade>().fadeIn();
            isSpawned = true;
        }
        
    }
    public void IsDestroyed() {
        this.isSpawned = false;
    }
    public void onRestart() {
        if (powerUp != null){
            Fade fade = powerUp.GetComponent<Fade>();
            fade.Dissapear();
            isSpawned = false;

            powerUp = null;

        }
        else isSpawned = false;

    }

}
