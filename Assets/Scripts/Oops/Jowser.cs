using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jowser : MonoBehaviour
{
    public GameObject bario;
    public GameObject ruigi;
    public GameObject timer;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            if(bario.GetComponent<PlayerMovement>().active)
            {
                bario.transform.position = new Vector3(5.0f, -15.0f, 1.0f);
            }
            else
            {
                ruigi.transform.position = new Vector3(5.0f, -15.0f, 1.0f);
            }
        }

        if(collider.tag == "Ground")
        {
            gameObject.GetComponent<Animator>().SetBool("laugh", true);
            gameObject.GetComponent<AudioSource>().Play();
            StartCoroutine(BeatGame(1.5f));
        }
    }

    IEnumerator BeatGame(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        gameObject.GetComponent<Animator>().SetBool("laugh", false);
        timer.GetComponent<Timer>().WinDisplay();
    }
}
