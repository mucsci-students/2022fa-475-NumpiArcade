using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    public Vector3 respawnPos;
    public Vector3 currentPos;
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
    public int pipe;
    public bool active;
    public bool reset = true;
    public bool beatGame = false;

    void Update()
    {
        if(isAlive && !inAnimation && active && !beatGame && !PauseGame.paused)
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
            cameraObj.transform.position = new Vector3(cameraObj.transform.position.x, 0.0f, -10.0f);
            
            Jump();
            Flip();
        }
        else if(!isAlive)
        {
            reset = false;
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
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded && !PauseGame.paused)
        {
            jumped = true;
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            StartCoroutine(Jumped(0.6f));
        }
    }

    private void Flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f && !PauseGame.paused)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1.0f;
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

    public void BackToStart()
    {
        inAnimation = true;
        animator.SetBool("idle", false);
        animator.SetBool("walking", false);
        animator.SetBool("jumping", false);
        animator.SetBool("downPiping", true);
        music.GetComponent<AudioSource>().Stop();
        pipeSound.Play();
        StartCoroutine(DeathPipe(3.0f));
    }

    public void NextArea()
    {
        inAnimation = true;
        animator.SetBool("idle", false);
        animator.SetBool("walking", false);
        animator.SetBool("jumping", false);
        animator.SetBool("downPiping", true);
        music.GetComponent<AudioSource>().Stop();
        pipeSound.Play();
        StartCoroutine(SetCamera(3.0f));
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
            localScale.x *= -1.0f;
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
        animator.SetBool("downPiping", false);
        isAlive = false;
    }

    IEnumerator ResetPosition(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        transform.position = respawnPos;
        transform.Find("Sprite").transform.position = respawnPos;
        inAnimation = false;
        reset = true;
    }

    IEnumerator SetCamera(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        if(!isFacingRight)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1.0f;
            transform.localScale = localScale;
        }

        if(pipe == 1)
        {
            transform.Find("Sprite").transform.position = new Vector3(94.0f, -1.0f, 0.0f);
        }
        else if(pipe == 2)
        {
            transform.Find("Sprite").transform.position = new Vector3(96.0f, -1.0f, 0.0f);
        }
        else
        {
            transform.Find("Sprite").transform.position = new Vector3(98.0f, -1.0f, 0.0f);
        }

        cameraObj.transform.position = new Vector3(113.0f, 0.0f, -10.0f);
        StartCoroutine(EnterNextArea(1.0f));
    }

    IEnumerator EnterNextArea(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        music.GetComponent<AudioSource>().Play();
        animator.SetBool("downPiping", false);
        transform.position = new Vector3(113.0f, 3.5f, 1.0f);
        inAnimation = false;
    }
}