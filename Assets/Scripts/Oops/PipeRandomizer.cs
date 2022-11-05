using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeRandomizer : MonoBehaviour
{
    public GameObject bario;
    public GameObject ruigi;
    public float pipe1;
    public float pipe2;
    public float pipe3;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(pipe1 == -1.0f && pipe2 == -1.0f && pipe3 == -1.0f)
        {
            float randomPipe = Random.Range(0, 3);
            if(randomPipe == 0.0f)
            {
                pipe1 = 1.0f;
                pipe2 = 2.0f;
                pipe3 = 2.0f;
                bario.GetComponent<PlayerMovement>().pipe = 1;
                ruigi.GetComponent<PlayerMovement>().pipe = 1;
            }
            else if(randomPipe == 1.0f)
            {
                pipe1 = 2.0f;
                pipe2 = 1.0f;
                pipe3 = 2.0f;
                bario.GetComponent<PlayerMovement>().pipe = 2;
                ruigi.GetComponent<PlayerMovement>().pipe = 2;
            }
            else
            {
                pipe1 = 2.0f;
                pipe2 = 2.0f;
                pipe3 = 1.0f;
                bario.GetComponent<PlayerMovement>().pipe = 3;
                ruigi.GetComponent<PlayerMovement>().pipe = 3;
            }
        }
    }
}
