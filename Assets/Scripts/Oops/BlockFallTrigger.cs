using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFallTrigger : MonoBehaviour
{
    public GameObject bario;
    public GameObject ruigi;
    public GameObject block;
    public Vector3 pos;
    public bool triggered = true;

    void Update()
    {
        if(!bario.GetComponent<PlayerMovement>().isAlive || !ruigi.GetComponent<PlayerMovement>().isAlive)
        {
            if(triggered)
            {
                triggered = false;
                StartCoroutine(ResetBlock(5.0f));
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        block.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }

    IEnumerator ResetBlock(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        block.transform.position = pos;
        triggered = true;
    }
}
