using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public GameObject player;
    public bool triggered = true;

    void Update()
    {
        if(!player.GetComponent<PlayerMovement>().isAlive)
        {
            if(triggered)
            {
                triggered = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                StartCoroutine(KillReset(5.0f));
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        player.GetComponent<PlayerMovement>().isAlive = false;
    }

    IEnumerator KillReset(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        triggered = true;
    }
}
