using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Ball
    public GameObject ball;

    // Player
    public GameObject playerPaddle;
    public GameObject playerGoal;

    // AI
    public GameObject aiPaddle;
    public GameObject aiGoal;
    
    // Score
    public GameObject playerText;
    public GameObject aiText;

    // Timer
    public GameObject timer;

    private int playerScore;
    private int aiScore;

    public string scene;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            playerScore = 0;
            playerText.GetComponent<TextMeshProUGUI>().text = playerScore.ToString();
            aiScore = 0;
            aiText.GetComponent<TextMeshProUGUI>().text = aiScore.ToString();
            ResetPosition();
        }
        if (playerScore == 3)
        {
            if(scene == "PingLevel2" || scene == "PingLevel3")
            {
                SceneManager.LoadScene(scene);
                aiScore = 0;
                playerScore = 0;
            }
            else
            {
                timer.GetComponent<PingTimer>().beatGame = true;
                timer.GetComponent<PingTimer>().WinDisplay();
                aiScore = 0;
                playerScore = 0;
                Time.timeScale = 0.0f;
            }
        }
        if (aiScore == 3)
        {
            SceneManager.LoadScene("MainMenu");
            aiScore = 0;
            playerScore = 0;
        }
    }

    public void PlayerScored()
    {
        playerScore++;
        playerText.GetComponent<TextMeshProUGUI>().text = playerScore.ToString();
        ResetPosition();
    }

    public void AIScored()
    {
        aiScore++;
        aiText.GetComponent<TextMeshProUGUI>().text = aiScore.ToString();
        ResetPosition();
    }

    public void ResetPosition()
    {
        ball.GetComponent<Ball>().ResetBall();
        playerPaddle.GetComponent<Player>().ResetPaddle();
        aiPaddle.GetComponent<AI>().ResetPaddle();
    }
}
