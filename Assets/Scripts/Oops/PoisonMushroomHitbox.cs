using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonMushroomHitbox : MonoBehaviour
{
    public GameObject bario;
    public GameObject ruigi;
    public bool triggered = false;
    public SpriteRenderer block;
    public Sprite oldBlock;
    public Sprite newBlock;

    void Update()
    {
        if(!bario.GetComponent<PlayerMovement>().isAlive || !ruigi.GetComponent<PlayerMovement>().isAlive)
        {
            triggered = false;
            block.sprite = oldBlock;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(!triggered)
        {
            transform.Find("PoisonMushroom").gameObject.SetActive(true);
            GetComponent<AudioSource>().Play();
            block.sprite = newBlock;
            triggered = true;
        }
    }
}
