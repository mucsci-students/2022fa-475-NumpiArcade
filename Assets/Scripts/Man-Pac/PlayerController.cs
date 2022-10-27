using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 movement;
    private float speed = 5f;
    [SerializeField] private Rigidbody2D rb;

    private bool isFacingUp = true;
    private bool isFacingRight = false;
    public Animator animator;
    

    void Start()
    {

    }

    void Update()
    {

            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
    }
    void FixedUpdate(){
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    private void Flipy()
    {
        // if(isFacingUp && vertical < 0f || !isFacingUp && vertical > 0f)
        // {
        //     isFacingUp = !isFacingUp;
        //     Vector3 localScale = transform.localScale;
        //     localScale.y *= -1f;
        //     transform.localScale = localScale;
        // }
        // if(isFacingRight && horizontal < 0f || !isFacingUp && horizontal > 0f)
        // {
        //     isFacingRight = !isFacingRight;
        //     Vector3 localScale = transform.localScale;
        //     localScale.x *= -.1f;
        //     transform.localScale = localScale;
        // }
    }
}