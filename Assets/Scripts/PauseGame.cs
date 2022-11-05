using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public static bool paused = false;
    public GameObject pauseMenu;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        AudioListener.pause = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        paused = false;
    }

    void Pause()
    {
        AudioListener.pause = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        paused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
        paused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
