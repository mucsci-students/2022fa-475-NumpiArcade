using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleCoinHitbox : MonoBehaviour
{
    public GameObject bario;
    public GameObject ruigi;
    public GameObject coinCounter;
    public bool triggered = false;
    public SpriteRenderer block;
    public Sprite oldBlock;
    public Sprite newBlock;

    void Update()
    {
        if(!bario.GetComponent<PlayerMovement>().isAlive || !ruigi.GetComponent<PlayerMovement>().isAlive)
        {
            transform.Find("CoinText").gameObject.SetActive(false);
            triggered = false;
            block.sprite = oldBlock;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(!triggered)
        {
            block.sprite = newBlock;
            triggered = true;
            transform.Find("Coin").gameObject.SetActive(true);
            transform.Find("CoinText").gameObject.SetActive(true);
            GetComponent<AudioSource>().Play();
            coinCounter.GetComponent<CoinBoxHitbox>().coins += 1;
            StartCoroutine(ToggleCoin(0.2f));
        }
    }

    IEnumerator ToggleCoin(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        transform.Find("Coin").gameObject.SetActive(false);
    }
}
