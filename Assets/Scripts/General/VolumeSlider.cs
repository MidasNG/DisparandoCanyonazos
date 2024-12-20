using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private Slider slider;
    public AudioMixer mixer;

    private void Start()
    {
        slider = GetComponent<Slider>();
        mixer.SetFloat("MasterVolume", 0);
        mixer.SetFloat("MusicVolume", 0);
        mixer.SetFloat("SFXVolume", 0);
    }

    public void MasterVolumeChange()
    {
        mixer.SetFloat("MasterVolume", -80 + 80 * slider.value);
    }

    public void MusicVolumeChange()
    {
        mixer.SetFloat("MusicVolume", -80 + 80 * slider.value);
    }

    public void SFXVolumeChange()
    {
        mixer.SetFloat("SFXVolume", -80 + 80 * slider.value);
    }
}
