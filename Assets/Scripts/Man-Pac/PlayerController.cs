using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Vector2 movement;
    private float speed = 5f;
    [SerializeField] private Rigidbody2D rb;

    public Animator animator;

    public static bool isAlive = true;
    public TMP_Text score;

    public GameObject firstLife;
    public GameObject secondLife;
    public GameObject thirdLife;

    public AudioSource die;
    public AudioSource coingrab;
    public AudioSource constant;
    
    public Vector2 init;

    public int deaths;
    public int lives;

    


    void Awake(){
        CoinCollect.score = keeps.Score;
        deaths = keeps.deaths;
        lives = keeps.lives;
        Debug.Log(lives + "a");
        Debug.Log(deaths + "a");

        switch(deaths){
            case 1:
                thirdLife.SetActive(false);
                break;
            case 2:
                secondLife.SetActive(false);
                thirdLife.SetActive(false);
                break;
            case 3:
                firstLife.SetActive(false);
                secondLife.SetActive(false);
                thirdLife.SetActive(false);
                break;
            default:
                break;

        }
    }


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
        if(keeps.lives == 0)
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
        if(other.tag == "enemy" && isAlive)
        {
            isAlive = false;
            animator.Play("death");
            onDeath();
            // if (!isAlive)
            // {
            //     StartCoroutine(waiter(.75f));
            // }
        }
    }
    
    public void onDeath()
    {
        keeps.lives -= 1;
        keeps.deaths += 1;
        CoinCollect.collected = 0;
        Debug.Log("current "+keeps.lives);
        Debug.Log("current "+keeps.deaths);
        die.Play();
        StartCoroutine(waiter(1f));
        
    }

    IEnumerator waiter(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        // rb.position = init;
        isAlive = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // animator.Play("cons");
    }

    IEnumerator waiter2(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Time.timeScale = 0;
        rb.position = init;
    }
}
