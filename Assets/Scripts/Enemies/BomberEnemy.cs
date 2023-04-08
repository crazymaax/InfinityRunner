using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberEnemy: Enemy {
    public GameObject bombPrefab;
    public Transform firePoint;
    public float throwTimer;

    private float throwCounter;

    void Start() {

    }

    void Update() {
        throwCounter += Time.deltaTime;

        if(throwCounter >= throwTimer) {
            Instantiate(bombPrefab, firePoint.position, firePoint.rotation);
            throwCounter = 0f;
        }        
    }
}
