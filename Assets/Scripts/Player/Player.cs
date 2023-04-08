using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour {
    public float playerSpeed = 5f;
    public float playerJump = 8f;
    public int health = 3;
    
    private Rigidbody2D rb;
    bool isJumping = false;

    public Animator anim;
    public GameObject bulletPrefab;
    public Transform bulletPoint;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            OnJump();
        }
        if(Input.GetKeyDown(KeyCode.LeftControl)) {
            OnShoot();
        }
    }

    public void OnShoot() {
        Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
        AudioController.current.PlayAudio(AudioController.current.projectileSFX);
    }

    public void OnJump() {
        if(!isJumping) {
            anim.SetBool("isJumping", true);
            rb.AddForce(new Vector2(0, playerJump), ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    void FixedUpdate() {
        rb.velocity = new Vector2(playerSpeed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision2D) {
        if(collision2D.gameObject.layer == 3) {
            anim.SetBool("isJumping", false);
            isJumping = false;
        }
    }

    public void OnHit(int damage) {
        health -= damage;
        AudioController.current.PlayAudio(AudioController.current.hitSFX);

        if(health <= 0) {
            GameController.instance.ShowGameOver();
        }
    }
}
