using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquishRoomba : MonoBehaviour
{
    public GameObject bario;
    public GameObject ruigi;
    public GameObject hitbox1;
    public GameObject hitbox2;
    public GameObject wall;
    public Sprite squishedRoomba;
    public bool triggered = true;
    public Vector3 pos;

    void Update()
    {
        if(!bario.GetComponent<PlayerMovement>().isAlive || !ruigi.GetComponent<PlayerMovement>().isAlive)
        {
            if(triggered)
            {
                triggered = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                StartCoroutine(ResetRoomba(5.0f));
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            hitbox1.GetComponent<BoxCollider2D>().enabled = false;
            hitbox2.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<Animator>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = squishedRoomba;
            hitbox1.GetComponent<RoombaMovement>().moving = false;
            wall.GetComponent<RemoveWall1>().counter += 1;
            gameObject.GetComponent<AudioSource>().Play();
            StartCoroutine(RoombaDisappear(1.0f));
        }
    }

    IEnumerator ResetRoomba(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        hitbox1.GetComponent<BoxCollider2D>().enabled = true;
        hitbox2.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<Animator>().enabled = true;
        hitbox1.GetComponent<RoombaMovement>().moving = true;
        hitbox1.transform.position = pos;
        triggered = true;
    }

    IEnumerator RoombaDisappear(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        gameObject.GetComponent<SpriteRenderer>().sprite = null;
    }
}
