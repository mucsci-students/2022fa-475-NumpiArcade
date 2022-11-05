using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public GameObject bario;
    public GameObject ruigi;
    public GameObject randomizer;
    public Vector3 pos;
    public int pipe;
    public bool triggered = false;

    void OnTriggerStay2D(Collider2D collider)
    {
        if((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && !triggered && (bario.GetComponent<PlayerMovement>().reset && ruigi.GetComponent<PlayerMovement>().reset))
        {
            triggered = true;
            if(bario.GetComponent<PlayerMovement>().active)
            {
                bario.GetComponent<PlayerMovement>().rb.velocity = new Vector2(0.0f, 0.0f);
                bario.transform.position = pos;
                bario.GetComponent<PlayerMovement>().currentPos = bario.transform.position;
                if(pipe == 1)
                {
                    if(randomizer.GetComponent<PipeRandomizer>().pipe1 == 1.0f)
                    {
                        bario.GetComponent<PlayerMovement>().NextArea();
                    }
                    else
                    {
                        bario.GetComponent<PlayerMovement>().BackToStart();
                    }
                }
                else if(pipe == 2)
                {
                    if(randomizer.GetComponent<PipeRandomizer>().pipe2 == 1.0f)
                    {
                        bario.GetComponent<PlayerMovement>().NextArea();
                    }
                    else
                    {
                        bario.GetComponent<PlayerMovement>().BackToStart();
                    }
                }
                else
                {
                    if(randomizer.GetComponent<PipeRandomizer>().pipe3 == 1.0f)
                    {
                        bario.GetComponent<PlayerMovement>().NextArea();
                    }
                    else
                    {
                        bario.GetComponent<PlayerMovement>().BackToStart();
                    }
                }
            }
            else
            {
                ruigi.GetComponent<PlayerMovement>().rb.velocity = new Vector2(0.0f, 0.0f);
                ruigi.transform.position = pos;
                ruigi.GetComponent<PlayerMovement>().currentPos = ruigi.transform.position;
                if(pipe == 1)
                {
                    if(randomizer.GetComponent<PipeRandomizer>().pipe1 == 1.0f)
                    {
                        ruigi.GetComponent<PlayerMovement>().NextArea();
                    }
                    else
                    {
                        ruigi.GetComponent<PlayerMovement>().BackToStart();
                    }
                }
                else if(pipe == 2)
                {
                    if(randomizer.GetComponent<PipeRandomizer>().pipe2 == 1.0f)
                    {
                        ruigi.GetComponent<PlayerMovement>().NextArea();
                    }
                    else
                    {
                        ruigi.GetComponent<PlayerMovement>().BackToStart();
                    }
                }
                else
                {
                    if(randomizer.GetComponent<PipeRandomizer>().pipe3 == 1.0f)
                    {
                        ruigi.GetComponent<PlayerMovement>().NextArea();
                    }
                    else
                    {
                        ruigi.GetComponent<PlayerMovement>().BackToStart();
                    }
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        triggered = false;
    }
}
