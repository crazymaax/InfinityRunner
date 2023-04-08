using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb: MonoBehaviour {
    public int damage = 2;

    public float xAxis;
    public float yAxis;

    private Rigidbody2D rb;
    private Player player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(xAxis, yAxis), ForceMode2D.Impulse);

        Destroy(gameObject, 5f);
    }

    void Update() {
        
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player")) {
            player.OnHit(damage);
        }
    }
}
