using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class WaveManager : MonoBehaviour {

    public GameObject enemy;
    public Transform[] spawnPoints;
    public float spawnTimer;
    public float spawnAmount;
    private float startTime;
    public int[] waves;
    public int count;
    //keep at 1 to not affect anything
    public float scalingFactor;
    void Start () {
        count = 0;
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
        if (count > waves.Length - 1) {
            count = 0;
        }
        for (int i = 0; i < waves[count]; i++)
        {
            GameObject newEnemy = Instantiate(enemy, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            newEnemy.SetActive(true);
        }
        count++;
    }

    void ResetTimer() {
        float newTimer = (startTime -= scalingFactor);

        spawnTimer = newTimer;
        spawnAmount += 0.05f;

    }
}
