using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaMovement : MonoBehaviour
{
    public GameObject bario;
    public GameObject ruigi;
    public float speed = 0.5f;
    public bool moveRight;
    public bool moving = true;
    
    void Update()
    {
        if(moving && (bario.GetComponent<PlayerMovement>().reset && ruigi.GetComponent<PlayerMovement>().reset))
        {
            if(moveRight)
            {
                transform.Translate(2.0f * Time.deltaTime * speed, 0.0f, 0.0f);
                transform.localScale = new Vector2(1.0f, 1.0f);
            }
            else
            {
                transform.Translate(-2.0f * Time.deltaTime * speed, 0.0f, 0.0f);
                transform.localScale = new Vector2(-1.0f, 1.0f);
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
