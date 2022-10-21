using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBoxHitbox : MonoBehaviour
{
    public int coins = 0;

    void Update()
    {
        if(coins >= 10)
        {
            transform.Find("CoinText").gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        transform.Find("Coin").gameObject.SetActive(true);
        GetComponent<AudioSource>().Play();
        coins = coins + 1;
        StartCoroutine(ToggleCoin(0.2f));
    }

    IEnumerator ToggleCoin(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        transform.Find("Coin").gameObject.SetActive(false);
    }
}