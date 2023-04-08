using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesGround: MonoBehaviour {
    public GameObject enemyPrefab;
    public List<Transform> points = new List<Transform>();

    private GameObject currentEnemy;

    void Start() {
        CreateEnemy();
    }

    void Update() {

    }

    void CreateEnemy() {
        int pos = Random.Range(0, points.Count);

        GameObject enemy = Instantiate(enemyPrefab, points[pos].position, points[pos].rotation);
        currentEnemy = enemy;
    }

    public void SpawnEnemy() {
        if(currentEnemy == null) {
            CreateEnemy();
        }
    }
}
