using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointScript : MonoBehaviour
{
    public ObstacleSpawnerScript obstacleSpawner;
    public Vector3 spawnPosition;
    public Quaternion spawnRotation;
    // Start is called before the first frame update
    void Start()
    {
        // Vector3 spawnPosition = transform.position;
        // Quaternion spawnRotation = transform.rotation;
        obstacleSpawner.SpawnObstacle();//spawnPosition, spawnRotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
