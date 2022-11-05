using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public GameObject hallway;
    public string tagCollider;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == tagCollider)
        {
            hallway.GetComponent<ActivateHallway>().awake = false;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.tag == tagCollider)
        {
            hallway.GetComponent<ActivateHallway>().awake = true;
        }
    }
}
