using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingGoal : MonoBehaviour
{
    public bool isPlayerGoal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (isPlayerGoal)
            {
                Debug.Log("Player Scored...");
                GameObject.Find("GameManager").GetComponent<GameManager>().PlayerScored();
            }
            else
            {
                Debug.Log("AI Scored...");
                GameObject.Find("GameManager").GetComponent<GameManager>().AIScored();
            }
        }
    }
}
