using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Reference to rigidbody of ball
    public Rigidbody2D ball;
    // Speed of ball
    public float speed = 200f;

    void Start()
    {
        LaunchBall();
    }

    // Determines the force and direction of the ball
    private void LaunchBall()
    {
        // Determines if ball goes left or right (randomly)
        float x = Random.value < 0.5f ? -1f : 1f;
        // Determines angle of ball (randomly)
        // Uses random range to prevent ball from going horizontal
        float y = Random.value < 0.5f ? Random.Range(-1f, -0.5f) : Random.Range(0.5f, 1f);
        
        // Direction of the ball
        Vector2 ballDirection = new Vector2(x, y);
        
        // Applies force to the ball object
        ball.AddForce(ballDirection * speed);
    }

    public void ResetBall()
    {
        ball.velocity = Vector2.zero;
        ball.position = Vector2.zero;
        LaunchBall();
    }
}
