using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveWall1 : MonoBehaviour
{
    public GameObject player;
    public bool triggered = true;
    public int counter = 0;

    void Update()
    {
        if(!player.GetComponent<PlayerMovement>().isAlive)
        {
            if(triggered)
            {
                triggered = false;
                counter = 0;
                StartCoroutine(ResetWall(5.0f));
            }
        }
        else
        {
            if(counter >= 2)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

    IEnumerator ResetWall(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        triggered = true;
    }
}
