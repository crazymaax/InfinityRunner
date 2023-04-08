using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile: MonoBehaviour {
    public float bulletSpeed = 20f;
    public int damage;

    public GameObject ExplosionPrefab;

    private Rigidbody2D rb;
    
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 1f);
    }

    void FixedUpdate() {
        rb.velocity = Vector2.right * bulletSpeed;
    }

    public void OnHit() {
        GameObject explosion = Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        AudioController.current.PlayAudio(AudioController.current.explosionSFX);
        Destroy(gameObject);
        Destroy(explosion, 1f);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.layer == 3) {
            OnHit();
        }
    }
}
