using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCodeActive : MonoBehaviour
{
    public GameObject bario;
    public GameObject ruigi;
    public GameObject cameraObj;
    public bool triggered = false;

    void Update()
    {
        if(gameObject.GetComponent<CheatCode>().cheater)
        {
            if(!triggered)
            {
                triggered = true;
                ruigi.transform.position = bario.transform.position;
                bario.transform.position = new Vector3(0.0f, -15.0f, 0.0f);
                ruigi.GetComponent<PlayerMovement>().respawnPos = new Vector3(0.0f, -3.0f, 0.0f);
                ruigi.GetComponent<PlayerMovement>().currentPos = bario.GetComponent<PlayerMovement>().currentPos;
                bario.GetComponent<PlayerMovement>().respawnPos = new Vector3(0.0f, -15.0f, 0.0f);
                bario.GetComponent<PlayerMovement>().currentPos = new Vector3(0.0f, -15.0f, 0.0f);
                if(cameraObj.transform.parent != null)
                {
                    cameraObj.transform.SetParent(ruigi.transform);
                    cameraObj.transform.position =  new Vector3(ruigi.transform.position.x, 0.0f, -10.0f);
                }
                bario.GetComponent<PlayerMovement>().active = false;
                ruigi.GetComponent<PlayerMovement>().active = true;
            }
        }
    }
}
