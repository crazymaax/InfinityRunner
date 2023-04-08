using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow: MonoBehaviour {
    Transform player;

    public float CamSpeed = 10f;
    public float offset = 5f;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate() {
        Vector3 newCamPos = new Vector3(player.position.x + offset, 0, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, newCamPos, CamSpeed * Time.deltaTime);
    }
}
