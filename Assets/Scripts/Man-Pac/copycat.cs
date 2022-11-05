using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copycat : MonoBehaviour
{
    Vector2 movement;
    private float speed = 5f;
    [SerializeField] private Rigidbody2D rb;

    public Vector2 init;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!PlayerController.isAlive){
            rb.position = init;
        }
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            // animator.SetFloat("Horizontal", movement.x);
            // animator.SetFloat("Vertical", movement.y);
            // animator.SetFloat("Speed", movement.sqrMagnitude);
    }
        void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    //  void OnTriggerEnter2D(Collider2D other) 
    // { 
    //     if(other.tag == "Player" )
    //     {
    //         Pl
    //         // Time.timeScale = 0;
    //         // StartCoroutine(deathwait());
    //     }
    // }

    // IEnumerator deathwait(){
    //     yield return new WaitForSeconds(1f);
    //     Time.timeScale = 1;
    //     playerdie = false;
    // }
}
