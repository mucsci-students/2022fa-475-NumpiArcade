using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PitTrap : MonoBehaviour
{
    public GameObject bario;
    public GameObject ruigi;
    public RuleTile tile;
    public Tilemap tilemap;
    public bool triggered = true;

    void Update()
    {
        if(!bario.GetComponent<PlayerMovement>().isAlive || !ruigi.GetComponent<PlayerMovement>().isAlive)
        {
            if(triggered)
            {
                triggered = false;
                StartCoroutine(ResetPit(5.0f));
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        tilemap.SetTile(new Vector3Int(145, 0, 0), null);
        tilemap.SetTile(new Vector3Int(146, 0, 0), null);
        tilemap.SetTile(new Vector3Int(147, 0, 0), null);
        tilemap.SetTile(new Vector3Int(145, -1, 0), null);
        tilemap.SetTile(new Vector3Int(146, -1, 0), null);
        tilemap.SetTile(new Vector3Int(147, -1, 0), null);
        tilemap.SetTile(new Vector3Int(145, -2, 0), null);
        tilemap.SetTile(new Vector3Int(146, -2, 0), null);
        tilemap.SetTile(new Vector3Int(147, -2, 0), null);
        tilemap.SetTile(new Vector3Int(145, -3, 0), null);
        tilemap.SetTile(new Vector3Int(146, -3, 0), null);
        tilemap.SetTile(new Vector3Int(147, -3, 0), null);
        tilemap.SetTile(new Vector3Int(145, -4, 0), null);
        tilemap.SetTile(new Vector3Int(146, -4, 0), null);
        tilemap.SetTile(new Vector3Int(147, -4, 0), null);
    }

    IEnumerator ResetPit(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        tilemap.SetTile(new Vector3Int(145, 0, 0), tile);
        tilemap.SetTile(new Vector3Int(146, 0, 0), tile);
        tilemap.SetTile(new Vector3Int(147, 0, 0), tile);
        tilemap.SetTile(new Vector3Int(145, -1, 0), tile);
        tilemap.SetTile(new Vector3Int(146, -1, 0), tile);
        tilemap.SetTile(new Vector3Int(147, -1, 0), tile);
        tilemap.SetTile(new Vector3Int(145, -2, 0), tile);
        tilemap.SetTile(new Vector3Int(146, -2, 0), tile);
        tilemap.SetTile(new Vector3Int(147, -2, 0), tile);
        tilemap.SetTile(new Vector3Int(145, -3, 0), tile);
        tilemap.SetTile(new Vector3Int(146, -3, 0), tile);
        tilemap.SetTile(new Vector3Int(147, -3, 0), tile);
        tilemap.SetTile(new Vector3Int(145, -4, 0), tile);
        tilemap.SetTile(new Vector3Int(146, -4, 0), tile);
        tilemap.SetTile(new Vector3Int(147, -4, 0), tile);
        triggered = true;
    }
}
