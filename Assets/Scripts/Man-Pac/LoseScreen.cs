using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoseScreen : MonoBehaviour
{
    public GameObject LosingScreen;
    public TMP_Text Score;
    public TMP_Text HiScore;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.lives == 0){
            LosingScreen.SetActive(true);
            Score.SetText("Score : " + CoinCollect.score.ToString());

            // if(CoinCollect.score > HiScore){  convert highscore to int somehow
            //     HiScore.SetText(CoinCollect.score.ToString());
            // }
        }
        
    }
}
