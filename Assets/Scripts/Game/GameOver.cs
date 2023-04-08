using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver: MonoBehaviour {
    void Start() {
        
    }

    void Update() {
        
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player")) {
            GameController.instance.ShowGameOver();
        }
    }
}
