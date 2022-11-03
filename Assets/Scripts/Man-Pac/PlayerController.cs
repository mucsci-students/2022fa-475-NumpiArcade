using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public GameObject player;
    Vector2 movement;
    private float speed = 5f;
    [SerializeField] private Rigidbody2D rb;

    public Animator animator;

    public int deaths = 0;
    public static int lives = 3;
    public static bool isAlive = true;
    public TMP_Text score;

    public GameObject firstLife;
    public GameObject secondLife;
    public GameObject thirdLife;

    public AudioSource die;
    public AudioSource coingrab;

    public Vector2 init;

    void Update()
    {
        if (isAlive)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
        score.SetText("Score : " + CoinCollect.score.ToString());
        if(lives == 0)
        {
            StartCoroutine(waiter2(1.5f));
        }
    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) 
    { 
        if(other.tag == "coin"){
            coingrab.Play();
        }
        if(other.tag == "enemy" )
        {
            isAlive = false;
            animator.Play("death");
            onDeath();
            if (!isAlive)
            {
                StartCoroutine(waiter(1.5f));
            }
        }
    }
    
    public void onDeath()
    {
        lives -= 1;
        deaths += 1;
        die.Play();


        switch (deaths)
        {
            case 1:
                thirdLife.SetActive(false);
                break;
            case 2:
                secondLife.SetActive(false);
                break;
            case 3:
                firstLife.SetActive(false);
                break;
            default:
                break;
        }
    }

    IEnumerator waiter(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        rb.position = init;
        isAlive = true;
        animator.Play("cons");
    }

    IEnumerator waiter2(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Time.timeScale = 0;
        rb.position = init;
    }
}
