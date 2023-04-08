using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform: MonoBehaviour {
    public List<GameObject> platforms = new List<GameObject>();
    public float offset;

    private List<Transform> currentPlatforms = new List<Transform>();
    private Transform player;
    private Transform currentPlatformPoint;
    private int platformIndex;

    void Start() {

        player = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0; i < platforms.Count; i++) {
            Transform p = Instantiate(platforms[i], new Vector2(i * 30, -3.5f), transform.rotation).transform;
            currentPlatforms.Add(p);
            offset += 30f;
        }

        currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().finalPoint;
    }

    void Update() {
        PlatformMove();
    }
    
    public void Recycle(GameObject platform) {
        platform.transform.position = new Vector2(offset, -3.5f);

        if(platform.GetComponent<Platform>().spawnEnemiesGround != null) {
            platform.GetComponent<Platform>().spawnEnemiesGround.SpawnEnemy();
        }

        offset += 30f;
    }

    void PlatformMove() {
        float distance = player.position.x - currentPlatformPoint.position.x;

        if(distance >= 1) {
            Recycle(currentPlatforms[platformIndex].gameObject);
            platformIndex++;

            if(platformIndex > currentPlatforms.Count -1) {
                platformIndex = 0;
            }

            currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().finalPoint;

        }
    }
}
