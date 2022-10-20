using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetSoundVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;

    void Start()
    {
        if(PlayerPrefs.HasKey("SoundSliderValue"))
        {
            slider.value = PlayerPrefs.GetFloat("SoundSliderValue");
            SetLevel(PlayerPrefs.GetFloat("SoundSliderValue"));
        }
        else
        {
            slider.value = 1.0f;
            SetLevel(1.0f);
        }
    }

    public void SetLevel(float value)
    {
        // Scales slider values logarithmically instead of linearly
        // because that's how audio decibals scale
        mixer.SetFloat("SoundVolume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("SoundSliderValue", value);
    }
}
