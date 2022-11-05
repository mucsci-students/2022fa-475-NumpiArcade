using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ActivateHallway : MonoBehaviour
{
    public GameObject bario;
    public GameObject ruigi;
    public GameObject bumper1;
    public GameObject bumper2;
    public GameObject bullet;
    public RuleTile tile;
    public Tilemap tilemap;
    public bool awake = false;
    public bool triggered = true;

    void Update()
    {
        if(!bario.GetComponent<PlayerMovement>().isAlive || !ruigi.GetComponent<PlayerMovement>().isAlive)
        {
            if(triggered)
            {
                triggered = false;
                bumper1.GetComponent<BoxCollider2D>().enabled = false;
                bumper2.GetComponent<BoxCollider2D>().enabled = false;
                bullet.GetComponent<BoxCollider2D>().enabled = false;
                StartCoroutine(ResetHall(5.0f));
            }
        }
        else
        {
            if(awake && (bario.GetComponent<PlayerMovement>().reset && ruigi.GetComponent<PlayerMovement>().reset))
            {
                bullet.transform.Translate(7.0f * Time.deltaTime, 0.0f, 0.0f);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        tilemap.SetTile(new Vector3Int(124, 0, 0), tile);
        tilemap.SetTile(new Vector3Int(125, 0, 0), tile);
        tilemap.SetTile(new Vector3Int(126, 0, 0), tile);
        tilemap.SetTile(new Vector3Int(127, 0, 0), tile);
        tilemap.SetTile(new Vector3Int(128, 0, 0), tile);
        bumper1.GetComponent<BoxCollider2D>().enabled = true;
        bumper2.GetComponent<BoxCollider2D>().enabled = true;
        bullet.GetComponent<BoxCollider2D>().enabled = true;
        bullet.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        awake = true;
    }

    IEnumerator ResetHall(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        awake = false;
        tilemap.SetTile(new Vector3Int(124, 0, 0), null);
        tilemap.SetTile(new Vector3Int(125, 0, 0), null);
        tilemap.SetTile(new Vector3Int(126, 0, 0), null);
        tilemap.SetTile(new Vector3Int(127, 0, 0), null);
        tilemap.SetTile(new Vector3Int(128, 0, 0), null);
        bullet.GetComponent<SpriteRenderer>().enabled = false;
        bullet.transform.position = new Vector3(122.5f, 2.5f, 1.0f);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        triggered = true;
    }
}
