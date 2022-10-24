using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingBall : MonoBehaviour
{
    // Speed of paddle
    public float speed;
    // Reference to Rigidbody2D component
    public Rigidbody2D rb;
    // Sets start position of ball
    public Vector3 start;

    void Start()
    {
        start = transform.position;
        Launch();
    }

    private void Launch()
    {
        // Sets x and y to either -1 or 1
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        // Determines velocity of the ball
        rb.velocity = new Vector2(speed * x, speed * y);
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = start;
        Launch();
    }
}
