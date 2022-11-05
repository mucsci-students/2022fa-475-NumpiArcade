using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePipe : MonoBehaviour
{
    public GameObject bario;
    public GameObject ruigi;
    public GameObject spikes;
    public bool triggered = true;

    void Update()
    {
        if(!bario.GetComponent<PlayerMovement>().isAlive || !ruigi.GetComponent<PlayerMovement>().isAlive)
        {
            if(triggered)
            {
                triggered = false;
                StartCoroutine(ResetSpikes(5.0f));
            }
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && triggered)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            spikes.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }
    }

    IEnumerator ResetSpikes(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        triggered = true;
    }
}
