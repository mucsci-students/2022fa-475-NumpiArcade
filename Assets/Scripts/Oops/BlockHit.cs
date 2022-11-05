using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHit : MonoBehaviour
{
    public GameObject bario;
    public GameObject ruigi;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            if(bario.GetComponent<PlayerMovement>().active)
            {
                bario.GetComponent<PlayerMovement>().isAlive = false;
            }
            else
            {
                ruigi.GetComponent<PlayerMovement>().isAlive = false;
            }
        }
    }
}
