using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaKill : MonoBehaviour
{
    public GameObject bario;
    public GameObject ruigi;
    public bool triggered = true;

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
            if(bario.GetComponent<PlayerMovement>().active)
            {
                bario.GetComponent<PlayerMovement>().isAlive = false;
            }
            else
            {
                ruigi.GetComponent<PlayerMovement>().isAlive = false;
            }
        }
    }

    IEnumerator ResetRoomba(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        triggered = true;
    }
}
