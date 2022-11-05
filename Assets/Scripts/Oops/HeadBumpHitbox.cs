using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBumpHitbox : MonoBehaviour
{
    public GameObject bario;
    public GameObject ruigi;
    public GameObject noBumpHitbox;
    public bool triggered = true;

    void Update()
    {
        if(!bario.GetComponent<PlayerMovement>().isAlive || !ruigi.GetComponent<PlayerMovement>().isAlive)
        {
            if(triggered)
            {
                triggered = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                transform.Find("HeadBumpBlock").gameObject.SetActive(false);
                transform.SetParent(noBumpHitbox.transform);
                StartCoroutine(KillReset(5.0f));
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        noBumpHitbox.GetComponent<NoBumpHitbox>().hit = true;
        transform.parent = null;
        transform.Find("HeadBumpBlock").gameObject.SetActive(true);
    }

    IEnumerator KillReset(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        noBumpHitbox.GetComponent<NoBumpHitbox>().hit = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        triggered = true;
    }
}
