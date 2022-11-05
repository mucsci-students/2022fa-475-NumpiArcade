using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
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
                StartCoroutine(KillReset(5.0f));
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
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

    IEnumerator KillReset(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        triggered = true;
    }
}
