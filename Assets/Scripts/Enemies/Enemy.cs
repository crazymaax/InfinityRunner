using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour {
    public int health;
    public int damage;

    private Player player;

    void Start() {

    }

    void Update() {

    }

    public virtual void ReceiveDamage(int damage) {
        health -= damage;

        if(health <= 0) {
            Destroy(gameObject);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Bullet")) {
            int bulletDamage = collider.GetComponent<Projectile>().damage;
            
            collider.GetComponent<Projectile>().OnHit();
            ReceiveDamage(bulletDamage);
        }

        if(collider.CompareTag("Player")) {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            player.OnHit(damage);
        }
    }
}
