using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonMushroom : MonoBehaviour
{
    public GameObject player;

    void OnTriggerEnter2D(Collider2D collider)
    {
        gameObject.SetActive(false);
        player.GetComponent<PlayerMovement>().isAlive = false;
    }
}