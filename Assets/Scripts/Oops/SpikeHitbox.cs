using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHitbox : MonoBehaviour
{
    public GameObject player;
    public SpriteRenderer Spikes;
    public bool triggered = true;

    void Update()
    {
        if(!player.GetComponent<PlayerMovement>().isAlive)
        {
            if(triggered)
            {
                triggered = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                StartCoroutine(SpikeDisappear(5.0f));
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        player.GetComponent<PlayerMovement>().isAlive = false;
        Spikes.enabled = true;
    }

    IEnumerator SpikeDisappear(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Spikes.enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        triggered = true;
    }
}
