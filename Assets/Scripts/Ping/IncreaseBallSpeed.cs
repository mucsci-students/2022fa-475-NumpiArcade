using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseBallSpeed : MonoBehaviour
{
    // Controls how hard ball bounces off paddles
    public float bounceSpeed = 1f;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            // Direction of collision pointing away from object
            Vector2 normal = collision.GetContact(0).normal;
            // Increase the force exerted onto ball (making it move faster)
            ball.GetComponent<Rigidbody2D>().AddForce(-normal * bounceSpeed, ForceMode2D.Impulse);
        }
    }
}
