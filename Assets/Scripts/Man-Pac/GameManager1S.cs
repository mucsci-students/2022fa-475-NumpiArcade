using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager1S : MonoBehaviour
{
    public int winCondition = 0;

    public string toLoad = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        win();
    }

    public void win(){
        if(CoinCollect.collected == winCondition){
            keeps.Score = CoinCollect.score;
            CoinCollect.collected = 0;
            SceneManager.LoadScene(toLoad);
        }
    }
}
