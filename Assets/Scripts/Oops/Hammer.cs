using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(-1.0f, 1.0f, 0.0f) * 150.0f);
        StartCoroutine(DestroyHammer(1.5f));
    }

    IEnumerator DestroyHammer(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Destroy(gameObject);
    }
}
