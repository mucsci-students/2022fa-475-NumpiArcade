using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public GameObject bario;
    public GameObject ruigi;
    public float timeValue;
    public bool gameOver = false;
    public bool beatGame = false;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI initials;
    public TextMeshProUGUI placementText;
    public GameObject inputScreen;
    public bool triggered = true;
    public float timeTaken;

    void Update()
    {
        if(!gameOver && !beatGame)
        {
            if(timeValue > 0)
            {
                timeValue -= Time.deltaTime;
            }
            else
            {
                timeValue = 0;
                gameOver = true;
            }

            DisplayTime(timeValue);
        }
        else if(gameOver && triggered)
        {
            triggered = false;
            if(bario.GetComponent<PlayerMovement>().active)
            {
                bario.GetComponent<PlayerMovement>().isAlive = false;
            }
            else
            {
                ruigi.GetComponent<PlayerMovement>().isAlive = false;
            }
            StartCoroutine(EndGame(3.0f));
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        else if(timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.SetText(string.Format("{0:00}:{1:00}", minutes, seconds));
    }

    public void GameBeaten()
    {
        if(timeTaken < PlayerPrefs.GetFloat("OopsHigh1"))
        {
            PlayerPrefs.SetFloat("OopsHigh5", PlayerPrefs.GetFloat("OopsHigh4"));
            PlayerPrefs.SetFloat("OopsHigh4", PlayerPrefs.GetFloat("OopsHigh3"));
            PlayerPrefs.SetFloat("OopsHigh3", PlayerPrefs.GetFloat("OopsHigh2"));
            PlayerPrefs.SetFloat("OopsHigh2", PlayerPrefs.GetFloat("OopsHigh1"));
            PlayerPrefs.SetFloat("OopsHigh1", timeTaken);
            PlayerPrefs.SetString("OopsHigh5Name", PlayerPrefs.GetString("OopsHigh4Name"));
            PlayerPrefs.SetString("OopsHigh4Name", PlayerPrefs.GetString("OopsHigh3Name"));
            PlayerPrefs.SetString("OopsHigh3Name", PlayerPrefs.GetString("OopsHigh2Name"));
            PlayerPrefs.SetString("OopsHigh2Name", PlayerPrefs.GetString("OopsHigh1Name"));
            PlayerPrefs.SetString("OopsHigh1Name", initials.text);
        }
        else if(timeTaken < PlayerPrefs.GetFloat("OopsHigh2"))
        {
            PlayerPrefs.SetFloat("OopsHigh5", PlayerPrefs.GetFloat("OopsHigh4"));
            PlayerPrefs.SetFloat("OopsHigh4", PlayerPrefs.GetFloat("OopsHigh3"));
            PlayerPrefs.SetFloat("OopsHigh3", PlayerPrefs.GetFloat("OopsHigh2"));
            PlayerPrefs.SetFloat("OopsHigh2", timeTaken);
            PlayerPrefs.SetString("OopsHigh5Name", PlayerPrefs.GetString("OopsHigh4Name"));
            PlayerPrefs.SetString("OopsHigh4Name", PlayerPrefs.GetString("OopsHigh3Name"));
            PlayerPrefs.SetString("OopsHigh3Name", PlayerPrefs.GetString("OopsHigh2Name"));
            PlayerPrefs.SetString("OopsHigh2Name", initials.text);
        }
        else if(timeTaken < PlayerPrefs.GetFloat("OopsHigh3"))
        {
            PlayerPrefs.SetFloat("OopsHigh5", PlayerPrefs.GetFloat("OopsHigh4"));
            PlayerPrefs.SetFloat("OopsHigh4", PlayerPrefs.GetFloat("OopsHigh3"));
            PlayerPrefs.SetFloat("OopsHigh3", timeTaken);
            PlayerPrefs.SetString("OopsHigh5Name", PlayerPrefs.GetString("OopsHigh4Name"));
            PlayerPrefs.SetString("OopsHigh4Name", PlayerPrefs.GetString("OopsHigh3Name"));
            PlayerPrefs.SetString("OopsHigh3Name", initials.text);
        }
        else if(timeTaken < PlayerPrefs.GetFloat("OopsHigh4"))
        {
            PlayerPrefs.SetFloat("OopsHigh5", PlayerPrefs.GetFloat("OopsHigh4"));
            PlayerPrefs.SetFloat("OopsHigh4", timeTaken);
            PlayerPrefs.SetString("OopsHigh5Name", PlayerPrefs.GetString("OopsHigh4Name"));
            PlayerPrefs.SetString("OopsHigh4Name", initials.text);
        }
        else if(timeTaken < PlayerPrefs.GetFloat("OopsHigh5"))
        {
            PlayerPrefs.SetFloat("OopsHigh5", timeTaken);
            PlayerPrefs.SetString("OopsHigh5Name", initials.text);
        }
        SceneManager.LoadScene("MainMenu");
    }

    public void WinDisplay()
    {
        timeTaken = 600.0f - timeValue;
        if(timeTaken < PlayerPrefs.GetFloat("OopsHigh1"))
        {
            inputScreen.SetActive(true);
            placementText.SetText("You Placed 1st");
        }
        else if(timeTaken < PlayerPrefs.GetFloat("OopsHigh2"))
        {
            inputScreen.SetActive(true);
            placementText.SetText("You Placed 2nd");
        }
        else if(timeTaken < PlayerPrefs.GetFloat("OopsHigh3"))
        {
            inputScreen.SetActive(true);
            placementText.SetText("You Placed 3rd");
        }
        else if(timeTaken < PlayerPrefs.GetFloat("OopsHigh4"))
        {
            inputScreen.SetActive(true);
            placementText.SetText("You Placed 4th");
        }
        else if(timeTaken < PlayerPrefs.GetFloat("OopsHigh5"))
        {
            inputScreen.SetActive(true);
            placementText.SetText("You Placed 5th");
        }
        else
        {
            timeTaken = 0.0f;
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("MainMenu");
        }
    }

    IEnumerator EndGame(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene("MainMenu");
    }
}
