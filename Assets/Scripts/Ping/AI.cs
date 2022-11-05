using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    // Reference to rigidbody of paddle
    public Rigidbody2D paddle;
    // Reference to ball for tracking
    public Rigidbody2D ballTracker;
    // Speed of the paddle
    public float speed = 7f;
    // Collision sound
    public AudioSource sound;

    // Tracks ball and moves AI paddle accordingly
    void FixedUpdate()
    {
        // Checks if ball is moving towards paddle
        if (ballTracker.velocity.x < 0f)
        {
            if (ballTracker.position.y > paddle.position.y)
            {
                paddle.AddForce(Vector2.up * speed);
            }
            else
            {
                paddle.AddForce(Vector2.down * speed);
            }
        }
        // Checks if ball is moving away from paddle
        else
        {
            // Move paddle towards center after ball has hit
            if (paddle.position.y < 0f)
            {
                paddle.AddForce(Vector2.up * speed);
            }
            else
            {
                paddle.AddForce(Vector2.down * speed);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            sound.Play();
        }
    }

    public void ResetPaddle()
    {
        paddle.velocity = Vector2.zero;
        paddle.position = new Vector2(paddle.position.x, 0f);
    }
}
