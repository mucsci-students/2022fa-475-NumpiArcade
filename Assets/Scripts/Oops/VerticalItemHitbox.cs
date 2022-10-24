using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalItemHitbox : MonoBehaviour
{
    public GameObject itemBox;

    void OnTriggerEnter2D(Collider2D collider)
    {
        itemBox.transform.position = new Vector3(34.5f, 3.5f, 0.0f);
        StartCoroutine(VerticalItemBox(0.8f));
    }

    IEnumerator VerticalItemBox(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        itemBox.transform.position = new Vector3(34.5f, -0.5f, 0.0f);
    }
}
