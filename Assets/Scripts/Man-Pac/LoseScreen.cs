using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LoseScreen : MonoBehaviour
{
    public GameObject LosingScreen;
    public TMP_Text ScoreEnd;
    public TMP_Text HiScoreEnd;

    public int highscore = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.lives == 0){

            LosingScreen.SetActive(true);
            ScoreEnd.SetText(CoinCollect.score.ToString());
            highscore = PlayerPrefs.GetInt("highscore");
            HiScoreEnd.SetText(highscore.ToString());
            

            if(CoinCollect.score > PlayerPrefs.GetInt("highscore")){
                PlayerPrefs.SetInt("highscore", CoinCollect.score);
                highscore = CoinCollect.score;
                HiScoreEnd.SetText(highscore.ToString());
            }
        }
        
    }
}
