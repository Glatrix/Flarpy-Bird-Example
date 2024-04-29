using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    // How Fast the Pipes Move Backwards
    public float moveSpeed = 5;
    // Pipe gets deleted of it passes this X value
    public float deadZone = -40f;

    // Update is called once per frame
    void Update()
    {
        // Pipes should keep moving backwards
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        // Delete Pipes once they move way off screen
        if(transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
