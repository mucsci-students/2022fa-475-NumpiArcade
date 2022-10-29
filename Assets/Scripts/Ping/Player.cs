using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Reference to rigidbody of paddle
    public Rigidbody2D paddle;
    // Movement direction of paddle
    public Vector2 movement;
    // Speed of the paddles
    public float speed = 10f;
    
    // Handles movement of the player's paddle
    void Update()
    {
        // Moves paddle up
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            movement = Vector2.up;
        }
        // Moves paddle down
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            movement = Vector2.down;
        }
        // Paddle stays idle otherwise
        else
        {
            movement = Vector2.zero;
        }
    }

    // Handles the physics of the player's paddle
    void FixedUpdate()
    {
        // Check if there is movement
        if (movement.sqrMagnitude != 0)
        {
            paddle.AddForce(movement * speed);
        }
    }

    public void ResetPaddle()
    {
        paddle.velocity = Vector2.zero;
        paddle.position = new Vector2(paddle.position.x, 0f);
    }
}
