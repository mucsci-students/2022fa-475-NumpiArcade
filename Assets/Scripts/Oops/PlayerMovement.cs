using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    public Vector3 pos = new Vector3(0.0f, -3.0f, -10.0f);

    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Sprite deadSprite;
    public GameObject cameraObj;
    public GameObject music;
    public AudioSource deathSound;
    public AudioSource jumpSound;
    public bool jumped = false;
    public bool isGrounded = false;
    public bool isAlive = true;
    public bool coroutine = true;

    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        spriteRenderer.sprite = null;
        transform.position = pos;
    }

    void Update()
    {
        if(isAlive)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

            if((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
                && !((Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
                    || (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.RightArrow)) || (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.D)))
                && isGrounded)
            {
                animator.SetBool("idle", false);
                animator.SetBool("walking", true);
                animator.SetBool("jumping", false);
            }
            else if(!isGrounded && jumped)
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

            if(Input.GetKey(KeyCode.W))
            {
                isAlive = false;
            }

            pos = transform.position;
            cameraObj.transform.position = new Vector3(cameraObj.transform.position.x, 0.0f, cameraObj.transform.position.z);
            
            Jump();
            Flip();
        }
        else
        {
            transform.position = pos;
            animator.SetBool("dead", true);
            music.GetComponent<AudioSource>().Stop();
            if(coroutine)
            {
                StartCoroutine(Respawn(3.0f));
            }
        }
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumped = true;
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            StartCoroutine(Jumped(0.8f));
        }
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

    IEnumerator Respawn(float delayTime)
    {
        coroutine = false;
        deathSound.Play();

        yield return new WaitForSeconds(delayTime);

        if(!isFacingRight)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
        
        animator.SetBool("dead", false);
        transform.position = new Vector3(0.0f, -3.0f, -10.0f);
        music.GetComponent<AudioSource>().Play();
        isAlive = true;
        coroutine = true;
    }

    IEnumerator Jumped(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        
        jumped = false;
    }
}