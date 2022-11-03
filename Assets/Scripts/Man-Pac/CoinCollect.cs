using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public static int collected = 0; 
    public GameObject collidedWith;
    public int winCondition;
    public static int score = 0;
    

        void OnTriggerEnter2D(Collider2D coin) 
        { 
        if(collidedWith.tag == coin.tag){
                collected += 1;
                score += 100;
                Destroy(gameObject);
        }
    }
}
