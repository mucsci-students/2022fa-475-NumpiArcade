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

    public int lives = 3;
    public bool isAlive = true;
    public TMP_Text score;

    public GameObject firstLife;
    public GameObject secondLife;
    public GameObject thirdLife;
    
    public int deaths = 0;

    void Start()
    {
        if(lives < 3) {thirdLife.SetActive(false);}
        if(lives < 2) {secondLife.SetActive(false);}
        if(lives < 1) {firstLife.SetActive(false);}

        DontDestroyOnLoad(this);
        
    }

    void Update()
    {
            if (isAlive){
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
            }

            score.SetText("Score : " + CoinCollect.score.ToString());


    }


    void FixedUpdate(){
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

        void OnTriggerEnter2D(Collider2D other) 
        { 
        if(other.tag == "enemy" ){
            isAlive = false;
            Debug.Log("diee");
            animator.Play("death");
            onDeath();
            waiter();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
    

    public void onDeath(){
        lives -= 1;
        deaths +=1;

        switch (deaths)
        {
            case 1:
                firstLife.SetActive(false);
                break;
            case 2:
                secondLife.SetActive(false);
                break;
            case 3:
                thirdLife.SetActive(false);
                // Time.timeScale = 0;
                break;
            default:
                break;
        }
        

    }

    IEnumerator waiter()
{
    yield return new WaitForSeconds(3);
    
}

}