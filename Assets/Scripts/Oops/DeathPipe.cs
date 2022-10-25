using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPipe : MonoBehaviour
{
    public GameObject player;
    public bool triggered = false;

    void OnTriggerStay2D(Collider2D collider)
    {
        if((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && !triggered)
        {
            triggered = true;
            player.GetComponent<PlayerMovement>().inAnimation = true;
            player.GetComponent<PlayerMovement>().DeathPipe();
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        triggered = false;
    }
}
