using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    private int collected = 0; 
    public GameObject collidedWith;
    public int winCondition;
    public int score = 0;

        void OnTriggerEnter2D(Collider2D coin) 
        { 
        if(collidedWith.tag == coin.tag){
            // Debug.Log("collision");
                collected += 1;
                Destroy(gameObject);
        }
    }
}
