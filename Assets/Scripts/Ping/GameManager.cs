using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    private int playerScore;
    private int aiScore;

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
        ball.GetComponent<PingBall>().Reset();
        playerPaddle.GetComponent<PingPlayer>().Reset();
        aiPaddle.GetComponent<PingPlayer>().Reset();
    }
}