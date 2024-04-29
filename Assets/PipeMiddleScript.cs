using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    // Reference to existing Logic Script
    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        // Grab Reference (Pipe Middle Script does not exist in Scene)
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If a Bird passes through this layer
        if(collision.gameObject.layer == 3) // 3 == "Bird"
        {
            // only 1 score for now. Maybe layer
            // random pipes will be gold and be worth 10
            logic.addScore(1);
        }
    }
}
