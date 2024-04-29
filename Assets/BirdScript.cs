using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength = 20;
    public LogicScript logic;
    public bool birdIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // Only Flap if Alive and Space key was pressed
        if (birdIsAlive && Input.GetKeyDown(KeyCode.Space))
        {
            FlapOnce();
        }

        // If we jump/fall out of the map, we die
        if(gameObject.transform.position.y >= 15.0f || gameObject.transform.position.y <= -15.0f)
        {
            logic.GameOver();
        }
    }

    // Just makes us jump into the air once
    public void FlapOnce()
    {
        // Set our birds velocity to Vector.up multiplied by flapStrength
        myRigidbody.velocity = Vector2.up * flapStrength;
    }

    // When we hit a collision. Note: This does not
    // trigger when we hit the invisible collider
    // in between pipes which adds our score.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        birdIsAlive = false;
        logic.GameOver();
    }
}
