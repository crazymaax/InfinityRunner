using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies: MonoBehaviour {
    public List<GameObject> enemiesList = new List<GameObject>();
    public float spawnTime = 3f;

    private float timerCounter;

    void Start() {

    }

    void Update() {
        timerCounter += Time.deltaTime;
        if (timerCounter >= spawnTime) {
            SpawnEnemy();
            timerCounter = 0;
        }
    }

    void SpawnEnemy() {
        Instantiate(enemiesList[Random.Range(0, enemiesList.Count)], transform.position + new Vector3(0, Random.Range(0, 4), 0), transform.rotation);
    }
}
