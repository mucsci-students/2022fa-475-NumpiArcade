using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PingTimer : MonoBehaviour
{
    public static float timeTaken;
    public bool beatGame = false;
    public TextMeshProUGUI initials;
    public TextMeshProUGUI placementText;
    public GameObject inputScreen;

    void Update()
    {
        if(!beatGame)
        {
            timeTaken += Time.deltaTime;
        }
    }

    public void GameBeaten()
    {
        if(timeTaken < PlayerPrefs.GetFloat("PingHigh1"))
        {
            PlayerPrefs.SetFloat("PingHigh5", PlayerPrefs.GetFloat("PingHigh4"));
            PlayerPrefs.SetFloat("PingHigh4", PlayerPrefs.GetFloat("PingHigh3"));
            PlayerPrefs.SetFloat("PingHigh3", PlayerPrefs.GetFloat("PingHigh2"));
            PlayerPrefs.SetFloat("PingHigh2", PlayerPrefs.GetFloat("PingHigh1"));
            PlayerPrefs.SetFloat("PingHigh1", timeTaken);
            PlayerPrefs.SetString("PingHigh5Name", PlayerPrefs.GetString("PingHigh4Name"));
            PlayerPrefs.SetString("PingHigh4Name", PlayerPrefs.GetString("PingHigh3Name"));
            PlayerPrefs.SetString("PingHigh3Name", PlayerPrefs.GetString("PingHigh2Name"));
            PlayerPrefs.SetString("PingHigh2Name", PlayerPrefs.GetString("PingHigh1Name"));
            PlayerPrefs.SetString("PingHigh1Name", initials.text);
        }
        else if(timeTaken < PlayerPrefs.GetFloat("PingHigh2"))
        {
            PlayerPrefs.SetFloat("PingHigh5", PlayerPrefs.GetFloat("PingHigh4"));
            PlayerPrefs.SetFloat("PingHigh4", PlayerPrefs.GetFloat("PingHigh3"));
            PlayerPrefs.SetFloat("PingHigh3", PlayerPrefs.GetFloat("PingHigh2"));
            PlayerPrefs.SetFloat("PingHigh2", timeTaken);
            PlayerPrefs.SetString("PingHigh5Name", PlayerPrefs.GetString("PingHigh4Name"));
            PlayerPrefs.SetString("PingHigh4Name", PlayerPrefs.GetString("PingHigh3Name"));
            PlayerPrefs.SetString("PingHigh3Name", PlayerPrefs.GetString("PingHigh2Name"));
            PlayerPrefs.SetString("PingHigh2Name", initials.text);
        }
        else if(timeTaken < PlayerPrefs.GetFloat("PingHigh3"))
        {
            PlayerPrefs.SetFloat("PingHigh5", PlayerPrefs.GetFloat("PingHigh4"));
            PlayerPrefs.SetFloat("PingHigh4", PlayerPrefs.GetFloat("PingHigh3"));
            PlayerPrefs.SetFloat("PingHigh3", timeTaken);
            PlayerPrefs.SetString("PingHigh5Name", PlayerPrefs.GetString("PingHigh4Name"));
            PlayerPrefs.SetString("PingHigh4Name", PlayerPrefs.GetString("PingHigh3Name"));
            PlayerPrefs.SetString("PingHigh3Name", initials.text);
        }
        else if(timeTaken < PlayerPrefs.GetFloat("PingHigh4"))
        {
            PlayerPrefs.SetFloat("PingHigh5", PlayerPrefs.GetFloat("PingHigh4"));
            PlayerPrefs.SetFloat("PingHigh4", timeTaken);
            PlayerPrefs.SetString("PingHigh5Name", PlayerPrefs.GetString("PingHigh4Name"));
            PlayerPrefs.SetString("PingHigh4Name", initials.text);
        }
        else if(timeTaken < PlayerPrefs.GetFloat("PingHigh5"))
        {
            PlayerPrefs.SetFloat("PingHigh5", timeTaken);
            PlayerPrefs.SetString("PingHigh5Name", initials.text);
        }
        timeTaken = 0.0f;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }

    public void WinDisplay()
    {
        if(timeTaken < PlayerPrefs.GetFloat("PingHigh1"))
        {
            inputScreen.SetActive(true);
            placementText.SetText("You Placed 1st");
        }
        else if(timeTaken < PlayerPrefs.GetFloat("PingHigh2"))
        {
            inputScreen.SetActive(true);
            placementText.SetText("You Placed 2nd");
        }
        else if(timeTaken < PlayerPrefs.GetFloat("PingHigh3"))
        {
            inputScreen.SetActive(true);
            placementText.SetText("You Placed 3rd");
        }
        else if(timeTaken < PlayerPrefs.GetFloat("PingHigh4"))
        {
            inputScreen.SetActive(true);
            placementText.SetText("You Placed 4th");
        }
        else if(timeTaken < PlayerPrefs.GetFloat("PingHigh5"))
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
}
