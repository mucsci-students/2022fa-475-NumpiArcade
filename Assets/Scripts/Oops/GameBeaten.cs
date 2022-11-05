using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBeaten : MonoBehaviour
{
    public GameObject bario;
    public GameObject ruigi;
    public GameObject cameraObj;
    public GameObject jowser;
    public GameObject timer;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            if(bario.GetComponent<PlayerMovement>().active)
            {
                bario.GetComponent<PlayerMovement>().beatGame = true;
                bario.GetComponent<PlayerMovement>().rb.velocity = new Vector2(0.0f, 0.0f);
                cameraObj.transform.parent = null;
                cameraObj.transform.position = new Vector3(bario.transform.position.x, 0.0f, -10.0f);
                bario.GetComponent<PlayerMovement>().animator.SetBool("idle", true);
                bario.GetComponent<PlayerMovement>().animator.SetBool("walking", false);
                bario.GetComponent<PlayerMovement>().animator.SetBool("jumping", false);
            }
            else
            {
                ruigi.GetComponent<PlayerMovement>().beatGame = true;
                ruigi.GetComponent<PlayerMovement>().rb.velocity = new Vector2(0.0f, 0.0f);
                cameraObj.transform.parent = null;
                cameraObj.transform.position = new Vector3(ruigi.transform.position.x, 0.0f, -10.0f);
                ruigi.GetComponent<PlayerMovement>().animator.SetBool("idle", true);
                ruigi.GetComponent<PlayerMovement>().animator.SetBool("walking", false);
                ruigi.GetComponent<PlayerMovement>().animator.SetBool("jumping", false);
            }
            jowser.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            jowser.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            gameObject.SetActive(false);
            timer.GetComponent<Timer>().beatGame = true;
        }
    }
}
