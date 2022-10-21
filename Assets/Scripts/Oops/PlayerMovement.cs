using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Sprite deadSprite;
    public GameObject cameraObj;
    public bool jumped = false;
    public bool isAlive = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start()
    {
        spriteRenderer.sprite = null;
        transform.position = new Vector3(0.0f, -3.0f, -10.0f);
    }

    void Update()
    {
        if(isAlive)
        {
            horizontal = Input.GetAxisRaw("Horizontal");

            if((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
                && !((Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
                    || (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.RightArrow)) || (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.D)))
                && IsGrounded())
            {
                animator.SetBool("idle", false);
                animator.SetBool("walking", true);
                animator.SetBool("jumping", false);
            }
            else if(!IsGrounded() && jumped)
            {
                animator.SetBool("idle", false);
                animator.SetBool("walking", false);
                animator.SetBool("jumping", true);
            }
            else
            {
                animator.SetBool("idle", true);
                animator.SetBool("walking", false);
                animator.SetBool("jumping", false);
            }

            // if(Input.GetKey(KeyCode.W))
            // {
            //     isAlive = false;
            // }

            if(IsGrounded())
            {
                jumped = false;
                if(Input.GetKey(KeyCode.Space))
                {
                    jumped = true;
                    rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                }
            }
            
            cameraObj.transform.position = new Vector3(cameraObj.transform.position.x, 0.0f, cameraObj.transform.position.z);
            Flip();
        }
        else
        {
            animator.SetBool("dead", true);
        }
    }

    private void FixedUpdate()
    {
        if(isAlive)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}