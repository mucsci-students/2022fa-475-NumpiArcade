using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class VerticalItemHitbox : MonoBehaviour
{
    public GameObject itemBox;
    public RuleTile tile;
    public Tilemap tilemap;

    void OnTriggerEnter2D(Collider2D collider)
    {
        tilemap.SetTile(new Vector3Int(34, -1, 0), null);
        itemBox.transform.position = new Vector3(34.5f, 3.5f, 0.0f);
        StartCoroutine(VerticalItemBox(0.8f));
    }

    IEnumerator VerticalItemBox(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        itemBox.transform.position = new Vector3(34.5f, -0.5f, 0.0f);
        tilemap.SetTile(new Vector3Int(34, -1, 0), tile);
    }
}
