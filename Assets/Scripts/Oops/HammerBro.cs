using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerBro : MonoBehaviour
{
    public GameObject bario;
    public GameObject ruigi;
    public GameObject hammer;
    public bool triggered = false;

    void Update()
    {
        if(!bario.GetComponent<PlayerMovement>().isAlive || !ruigi.GetComponent<PlayerMovement>().isAlive)
        {
            if(triggered)
            {
                triggered = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        triggered = true;
        StartCoroutine(Hammer(0.25f));
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        triggered = false;
    }

    IEnumerator Hammer(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        if(triggered)
        {
            Instantiate(hammer, transform.position, transform.rotation);
            StartCoroutine(Hammer(0.25f));
        }
    }
}
