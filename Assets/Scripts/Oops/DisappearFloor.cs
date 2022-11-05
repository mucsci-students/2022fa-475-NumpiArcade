using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearFloor : MonoBehaviour
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
                StartCoroutine(ResetFloor(5.0f));
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    IEnumerator ResetFloor(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        triggered = true;
    }
}
