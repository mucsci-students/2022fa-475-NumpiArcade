using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPipe : MonoBehaviour
{
    public GameObject bario;
    public GameObject ruigi;
    public bool triggered = false;

    void OnTriggerStay2D(Collider2D collider)
    {
        if((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && !triggered)
        {
            if(bario.GetComponent<PlayerMovement>().active)
            {
                triggered = true;
                bario.GetComponent<PlayerMovement>().DeathPipe();
            }
            else
            {
                triggered = true;
                ruigi.GetComponent<PlayerMovement>().DeathPipe();
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        triggered = false;
    }
}
