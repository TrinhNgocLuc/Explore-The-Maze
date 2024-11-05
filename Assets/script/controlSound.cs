using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class controlSound : MonoBehaviour
{
   public Slider volumeSlider;
    public AudioSource audioSource;

    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("Volume", 0.5f);
        volumeSlider.value = audioSource.volume;
    }
    void Update()
    {
        volumeSlider.onValueChanged.AddListener(delegate { ChangeVolume(); });
    }
    void ChangeVolume()
    {
       float volume = volumeSlider.value;
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
