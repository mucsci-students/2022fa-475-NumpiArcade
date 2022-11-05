using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetMusicVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;

    void Start()
    {
        AudioListener.pause = false;
        if(PlayerPrefs.HasKey("MusicSliderValue"))
        {
            slider.value = PlayerPrefs.GetFloat("MusicSliderValue");
            SetLevel(PlayerPrefs.GetFloat("MusicSliderValue"));
        }
        else
        {
            slider.value = 0.25f;
            SetLevel(0.25f);
        }
    }

    public void SetLevel(float value)
    {
        // Scales slider values logarithmically instead of linearly
        // because that's how audio decibals scale
        mixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("MusicSliderValue", value);
    }
}
