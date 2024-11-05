using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiomanager : MonoBehaviour
{
   public AudioSource audioSource;

    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("Volume", 0.5f);
        audioSource.volume = savedVolume;
    }
    void Update()
    {
        float savedVolume = PlayerPrefs.GetFloat("Volume", 0.5f);
        audioSource.volume = savedVolume;
    }
}
