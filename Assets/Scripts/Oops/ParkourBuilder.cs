using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ParkourBuilder : MonoBehaviour
{
    public GameObject bario;
    public GameObject ruigi;
    public bool triggered = false;
    public bool died = false;
    public SpriteRenderer block;
    public Sprite oldBlock;
    public Sprite newBlock;
    public RuleTile tile;
    public Tilemap tilemap;
    public AudioSource music;

    void Update()
    {
        if((!bario.GetComponent<PlayerMovement>().isAlive || !ruigi.GetComponent<PlayerMovement>().isAlive) && triggered)
        {
            died = true;
            triggered = false;
            GetComponent<AudioSource>().Stop();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(!triggered)
        {
            music.Stop();
            GetComponent<AudioSource>().Play();
            block.sprite = newBlock;
            tilemap.SetTile(new Vector3Int(192, -1, 0), tile);
            tilemap.SetTile(new Vector3Int(195, -1, 0), tile);
            tilemap.SetTile(new Vector3Int(198, -1, 0), tile);
            tilemap.SetTile(new Vector3Int(201, -1, 0), tile);
            tilemap.SetTile(new Vector3Int(204, -1, 0), tile);
            triggered = true;
            StartCoroutine(TimedParkour(5.0f));
        }
    }

    IEnumerator TimedParkour(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        if(!died)
        {
            music.Play();
        }
        block.sprite = oldBlock;
        tilemap.SetTile(new Vector3Int(192, -1, 0), null);
        tilemap.SetTile(new Vector3Int(195, -1, 0), null);
        tilemap.SetTile(new Vector3Int(198, -1, 0), null);
        tilemap.SetTile(new Vector3Int(201, -1, 0), null);
        tilemap.SetTile(new Vector3Int(204, -1, 0), null);
        triggered = false;
        died = false;
    }
}
