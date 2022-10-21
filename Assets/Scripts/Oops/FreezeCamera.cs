using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeCamera : MonoBehaviour
{
    public GameObject player;
    public GameObject cameraObj;

    void OnTriggerEnter2D(Collider2D collider)
    {
        cameraObj.transform.parent = null;
        cameraObj.transform.position = new Vector3(0.0f, 0.0f, -10.0f);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        cameraObj.transform.SetParent(player.transform);
        cameraObj.transform.position = new Vector3(0.0f, 0.0f, -10.0f);
    }
}
