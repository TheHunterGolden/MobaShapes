using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

    public GameObject enemy;
    public Transform[] spawnPoints;
    public float spawnTimer;
    public int spawnAmount;
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
        startTime = startTime * scalingFactor;
    }

    void SpawnEnemy() {
        for (int i = 0; i < spawnAmount; i++)
        {
            Instantiate(enemy, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        }
    }

    void ResetTimer() {
        spawnTimer = startTime;
    }
}
