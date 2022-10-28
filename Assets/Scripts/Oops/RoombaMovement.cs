using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaMovement : MonoBehaviour
{
    public GameObject player;
    public float speed = 0.5f;
    public bool moveRight;
    public bool moving = true;
    
    void Update()
    {
        if(moving && player.GetComponent<PlayerMovement>().isAlive)
        {
            if(moveRight)
            {
                transform.Translate(2 * Time.deltaTime * speed, 0, 0);
                transform.localScale = new Vector2(1, 1);
            }
            else
            {
                transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
                transform.localScale = new Vector2(-1, 1);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Ground")
        {
            moveRight = !moveRight;
        }
    }
}
