using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy: Enemy {
    public float enemySpeed = 5;

    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3f);
    }

    void Update() {
        rb.velocity = Vector2.left * enemySpeed;
    }
}
