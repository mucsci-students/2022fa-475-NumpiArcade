using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSelected : MonoBehaviour
{
    public AudioSource audioSource;

    void Awake()
    {
        if(PlayerPrefs.GetInt("GameSelected") == 1)
        {
            audioSource.Play();
		    PlayerPrefs.SetInt("GameSelected", 0);
        }
    }
}
