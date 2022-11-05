using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public float speed = -2f;
    public float lowerXValue = -17.8f;
    public float upperXValue = 35.6f;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0f, 0f);
        if (transform.position.x <= lowerXValue)
        {
            transform.Translate(upperXValue, 0f, 0f);
        }
    }
}
