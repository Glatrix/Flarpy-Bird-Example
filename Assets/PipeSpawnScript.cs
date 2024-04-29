using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    // The Pipe Prefab (Not an instance)
    public GameObject pipe;

    // Spawn Rate Seconds
    public float spawnRate = 3;
    // Timer Counts up to spawnRate
    private float timer = 0;
    // Offset from middle of where pipe can spawn
    // both +Y and -Y
    public float heightOffset = 8;

    // Start is called before the first frame update
    void Start()
    {
        // We spawn one pipe on start to
        // prevent waitin (spawnRate) seconds
        // before seeing the first one
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        // If timer is less than spawnRate (seconds)
        if(timer < spawnRate) 
        {
            // add the ammount of time that has passed
            // since last call
            timer = timer + Time.deltaTime;
        }
        else 
        {
            // Timer is full so we spawn pipe and reset timer
            SpawnPipe();
            timer = 0;
        }
    }

    // Spawn Pipe at the front of the Screen (Where the Spawner is Located)
    void SpawnPipe()
    {
        // Calculate the Highest and Lowest points a Pipe should spawn
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        // Spawn a Pipe at a Random Y value between lowest and highest point
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
