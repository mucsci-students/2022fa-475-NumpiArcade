using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinBoxHitbox : MonoBehaviour
{
    public GameObject bario;
    public GameObject ruigi;
    public TextMeshProUGUI coinText;
    public int coins = 0;

    void Update()
    {
        if(coins >= 10)
        {
            transform.Find("CoinText").gameObject.SetActive(true);
        }

        if(!bario.GetComponent<PlayerMovement>().isAlive || !ruigi.GetComponent<PlayerMovement>().isAlive)
        {
            coins = 0;
            transform.Find("CoinText").gameObject.SetActive(false);
        }
        coinText.SetText(coins.ToString());
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        transform.Find("Coin").gameObject.SetActive(true);
        GetComponent<AudioSource>().Play();
        coins += 1;
        StartCoroutine(ToggleCoin(0.2f));
    }

    IEnumerator ToggleCoin(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        transform.Find("Coin").gameObject.SetActive(false);
    }
}