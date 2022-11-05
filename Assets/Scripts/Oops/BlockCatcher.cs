using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCatcher : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "FallingBlock")
        {
            collider.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        }
    }
}
