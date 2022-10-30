using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 movement;
    private float speed = 5f;
    [SerializeField] private Rigidbody2D rb;

    public Animator animator;

    public int lives = 3;
    public bool isAlive = true;
    

    void Start()
    {
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

        }
    }

}