using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPlayer : MonoBehaviour
{
    public bool isPlayer;
    // Speed of paddle
    public float speed;
    // Reference to Rigidbody2D component
    public Rigidbody2D rb;
    // Sets start position of paddles
    public Vector3 start;
    // Movement controls for paddle
    private float movement;

    void Start()
    {
        start = transform.position;
    }

    void Update()
    {
        if (isPlayer)
        {
            movement = Input.GetAxisRaw("Vertical");
        }
        else
        {
            movement = Input.GetAxisRaw("Vertical2");
        }
        // Keeps padddle from moving horizontally
        rb.velocity = new Vector2(rb.velocity.x, movement * speed);
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = start;
    }
}
