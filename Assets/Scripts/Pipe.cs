using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    void Start()
    {
        
    }

    void Update()
    {
        if(GameController.start)
        {
            rigidBody.velocity = new Vector2(GameController.pipeVelocity*GameController.scale, 0f);
            if (transform.position.x < -3.5)
            {
                Destroy(gameObject);
            }
        }

        if (GameController.death)
        {
            Stop();
        }
    }

    void Stop()
    {
        rigidBody.velocity = new Vector2(0f, 0f);
    }
}
