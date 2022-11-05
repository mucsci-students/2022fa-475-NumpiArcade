using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempTimer : MonoBehaviour
{
    void Update()
    {
        PingTimer.timeTaken += Time.deltaTime;
    }
}
