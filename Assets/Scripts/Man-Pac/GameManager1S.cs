using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager1S : MonoBehaviour
{
    public int winCondition = 0;
    private int coins;
    public string toLoad ="";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coins = CoinCollect.collected;
        win();
    }

    public void win(){
        if(coins == winCondition){
            Debug.Log("we got a winner");
            SceneManager.LoadScene(toLoad);
        }
    }
}
