using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax: MonoBehaviour {
    public Transform camera;
    public float parallaxSpeed = 1f;

    private float length;
    private float startPosition;

    void Start() {
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void LateUpdate() {
        float reposition = camera.transform.position.x * (1 - parallaxSpeed);
        float distance = camera.transform.position.x * parallaxSpeed;
        
        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);
        
        if(reposition > startPosition + length) {
            startPosition += length;
        }
    }
}
