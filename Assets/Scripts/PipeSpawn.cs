using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    // The Pipe Prefab (Not an instance)
    [SerializeField]
    private GameObject _pipePrefab;

    // Spawn Rate Seconds
    [SerializeField]
    private float _spawnRate = 3;

    // Offset from middle of where pipe can spawn
    // both +Y and -Y
    [SerializeField]
    private float _heightOffset = 8;

    // Timer Counts up to spawnRate
    private float _timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        // We spawn one pipe on start to
        // prevent waitin (spawnRate) seconds
        // before seeing the first one
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        // If timer is less than spawnRate (seconds)
        if(_timer < _spawnRate) 
        {
            // add the ammount of time that has passed
            // since last call
            _timer = _timer + Time.deltaTime;
        }
        else 
        {
            // Timer is full so we spawn pipe and reset timer
            spawnPipe();
            _timer = 0;
        }
    }

    // Spawn Pipe at the front of the Screen (Where the Spawner is Located)
    void spawnPipe()
    {
        // Calculate the Highest and Lowest points a Pipe should spawn
        float lowestPoint = transform.position.y - _heightOffset;
        float highestPoint = transform.position.y + _heightOffset;

        // Spawn a Pipe at a Random Y value between lowest and highest point
        Instantiate(_pipePrefab, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
