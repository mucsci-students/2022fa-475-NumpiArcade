using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoBumpHitbox : MonoBehaviour
{
    public GameObject headBumpHitbox;
    public bool hit = false;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Transform child = transform.Find("HeadBumpHitbox");
        if(child != null && !hit)
        {
            child.gameObject.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        StartCoroutine(Reappear(0.15f));
    }

    IEnumerator Reappear(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        headBumpHitbox.SetActive(true);
    }
}
