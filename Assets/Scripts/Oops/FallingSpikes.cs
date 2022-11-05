using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpikes : MonoBehaviour
{
    public GameObject bario;
    public GameObject ruigi;
    public GameObject spikePipe;
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

    void OnTriggerEnter2D(Collider2D collider)
    {
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
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
        else
        {
            transform.position = new Vector3(179.0f, 6.0f, 1.0f);
            spikePipe.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    IEnumerator ResetSpikes(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        transform.position = new Vector3(179.0f, 6.0f, 1.0f);
        triggered = true;
    }
}
