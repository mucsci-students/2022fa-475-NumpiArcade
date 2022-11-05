using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonMushroom : MonoBehaviour
{
    public GameObject bario;
    public GameObject ruigi;

    void Update()
    {
        if(!bario.GetComponent<PlayerMovement>().isAlive || !ruigi.GetComponent<PlayerMovement>().isAlive)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        gameObject.SetActive(false);
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
