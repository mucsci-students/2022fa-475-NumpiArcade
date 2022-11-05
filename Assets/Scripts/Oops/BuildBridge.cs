using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildBridge : MonoBehaviour
{
    public GameObject bario;
    public GameObject ruigi;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject coinCounter;
    public RuleTile tile;
    public Tilemap tilemap;
    public bool triggered = true;
    public bool bridgeBuilt = false;
    
    void Update()
    {
        if(!bario.GetComponent<PlayerMovement>().isAlive || !ruigi.GetComponent<PlayerMovement>().isAlive)
        {
            if(triggered)
            {
                triggered = false;
                StartCoroutine(ResetBridge(5.0f));
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(coinCounter.GetComponent<CoinBoxHitbox>().coins < 30 && !bridgeBuilt)
        {
            text1.SetActive(true);
        }
        else if(coinCounter.GetComponent<CoinBoxHitbox>().coins > 30 && !bridgeBuilt)
        {
            text3.SetActive(true);
        }
        else if(coinCounter.GetComponent<CoinBoxHitbox>().coins == 30 && !bridgeBuilt)
        {
            bridgeBuilt = true;
            coinCounter.GetComponent<CoinBoxHitbox>().coins = 0;
            tilemap.SetTile(new Vector3Int(224, -5, 0), tile);
            tilemap.SetTile(new Vector3Int(225, -5, 0), tile);
            tilemap.SetTile(new Vector3Int(226, -5, 0), tile);
            tilemap.SetTile(new Vector3Int(227, -5, 0), tile);
            tilemap.SetTile(new Vector3Int(228, -5, 0), tile);
            tilemap.SetTile(new Vector3Int(229, -5, 0), tile);
            tilemap.SetTile(new Vector3Int(230, -5, 0), tile);
            tilemap.SetTile(new Vector3Int(231, -5, 0), tile);
            tilemap.SetTile(new Vector3Int(232, -5, 0), tile);
            tilemap.SetTile(new Vector3Int(233, -5, 0), tile);
            tilemap.SetTile(new Vector3Int(234, -5, 0), tile);
            tilemap.SetTile(new Vector3Int(235, -5, 0), tile);
            tilemap.SetTile(new Vector3Int(236, -5, 0), tile);
            tilemap.SetTile(new Vector3Int(237, -5, 0), tile);
            tilemap.SetTile(new Vector3Int(238, -5, 0), tile);
        }
        if(bridgeBuilt)
        {
            text2.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        text1.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);
    }

    IEnumerator ResetBridge(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        tilemap.SetTile(new Vector3Int(224, -5, 0), null);
        tilemap.SetTile(new Vector3Int(225, -5, 0), null);
        tilemap.SetTile(new Vector3Int(226, -5, 0), null);
        tilemap.SetTile(new Vector3Int(227, -5, 0), null);
        tilemap.SetTile(new Vector3Int(228, -5, 0), null);
        tilemap.SetTile(new Vector3Int(229, -5, 0), null);
        tilemap.SetTile(new Vector3Int(230, -5, 0), null);
        tilemap.SetTile(new Vector3Int(231, -5, 0), null);
        tilemap.SetTile(new Vector3Int(232, -5, 0), null);
        tilemap.SetTile(new Vector3Int(233, -5, 0), null);
        tilemap.SetTile(new Vector3Int(234, -5, 0), null);
        tilemap.SetTile(new Vector3Int(235, -5, 0), null);
        tilemap.SetTile(new Vector3Int(236, -5, 0), null);
        tilemap.SetTile(new Vector3Int(237, -5, 0), null);
        tilemap.SetTile(new Vector3Int(238, -5, 0), null);
        bridgeBuilt = false;
        triggered = true;
    }
}
