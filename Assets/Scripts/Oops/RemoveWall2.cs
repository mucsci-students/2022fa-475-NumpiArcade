using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveWall2 : MonoBehaviour
{
    public GameObject player;
    public GameObject wall2;
    public GameObject wall3;
    public bool triggered = true;

    void Update()
    {
        if(!player.GetComponent<PlayerMovement>().isAlive)
        {
            if(triggered)
            {
                triggered = false;
                StartCoroutine(ResetWall(5.0f));
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        wall2.SetActive(false);
    }

    IEnumerator ResetWall(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        wall2.SetActive(true);
        wall3.SetActive(false);
        triggered = true;
    }
}
