using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    public Vector3 respawnPos = new Vector3(0.0f, -3.0f, -10.0f);
    public Vector3 currentPos = new Vector3(0.0f, -3.0f, -10.0f);
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Sprite deadSprite;
    public GameObject cameraObj;
    public GameObject music;
    public AudioSource deathSound;
    public AudioSource jumpSound;
    public AudioSource pipeSound;
    public bool jumped = false;
    public bool isGrounded = false;
    public bool isAlive = true;
    public bool coroutine = true;
    public bool inAnimation = false;

    void Update()
    {
        if(isAlive && !inAnimation)
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

            if(Input.GetKey(KeyCode.R))
            {
                isAlive = false;
            }

            currentPos = transform.position;
            cameraObj.transform.position = new Vector3(cameraObj.transform.position.x, 0.0f, cameraObj.transform.position.z);
            
            Jump();
            Flip();
        }
        else if(!isAlive)
        {
            transform.position = currentPos;
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
            StartCoroutine(Jumped(0.6f));
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
    
    public void DeathPipe()
    {
        inAnimation = true;
        animator.SetBool("idle", false);
        animator.SetBool("walking", false);
        animator.SetBool("jumping", false);
        animator.SetBool("piping", true);
        music.GetComponent<AudioSource>().Stop();
        pipeSound.Play();
        StartCoroutine(DeathPipe(3.0f));
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
        music.GetComponent<AudioSource>().Play();
        isAlive = true;
        coroutine = true;
        StartCoroutine(ResetPosition(1.0f));
    }

    IEnumerator Jumped(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        jumped = false;
    }

    IEnumerator DeathPipe(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        animator.SetBool("piping", false);
        isAlive = false;
    }

    IEnumerator ResetPosition(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        transform.position = respawnPos;
        transform.Find("Sprite").transform.position = new Vector3(0.0f, -3.0f, 0.0f);
        inAnimation = false;
    }
}