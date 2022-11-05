using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeCamera : MonoBehaviour
{
    public GameObject bario;
    public GameObject ruigi;
    public GameObject cameraObj;
    public Vector3 pos;

    void OnTriggerEnter2D(Collider2D collider)
    {
        cameraObj.transform.parent = null;
        cameraObj.transform.position = pos;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(bario.GetComponent<PlayerMovement>().active)
        {
            cameraObj.transform.SetParent(bario.transform);
            cameraObj.transform.position = new Vector3(bario.transform.position.x, pos.y, pos.z);
        }
        else
        {
            cameraObj.transform.SetParent(ruigi.transform);
            cameraObj.transform.position = new Vector3(ruigi.transform.position.x, pos.y, pos.z);
        }
    }
}
