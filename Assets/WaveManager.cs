using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

    public GameObject enemy;
    public Transform[] spawnPoints;
    public float spawnTimer;
    public float spawnAmount;
    private float startTime;
    //keep at 1 to not affect anything
    public float scalingFactor;
    void Start () {
        startTime = spawnTimer;
        
	}
	
	
	void Update () {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0) {
            SpawnEnemy();
            ResetTimer();
        }
      
    }

    void SpawnEnemy() {
        for (int i = 0; i < Mathf.Round(spawnAmount); i++)
        {
         GameObject newEnemy = Instantiate(enemy, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            newEnemy.SetActive(true);
        }
    }

    void ResetTimer() {
        float newTimer = (startTime -= scalingFactor);

        spawnTimer = newTimer;
        spawnAmount += 0.05f;

    }
}
