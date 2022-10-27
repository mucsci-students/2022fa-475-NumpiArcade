using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceWall : MonoBehaviour
{
    public GameObject wall;

    void OnTriggerStay2D(Collider2D collider)
    {
        wall.SetActive(true);
    }
}
