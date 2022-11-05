using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{

    public string sceneToLoad = "MainMenu";

    void OnMouseDown(){
        SceneManager.LoadScene(sceneToLoad);
        CoinCollect.score = 0;
        CoinCollect.collected = 0;
        Time.timeScale = 1;
        PlayerController.isAlive = true;
        keeps.lives = 3;
        keeps.deaths = 0;
        

    }
}
