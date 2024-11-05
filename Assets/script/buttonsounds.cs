using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonSounds : MonoBehaviour
{
    public AudioSource audioSource;
    private Button button;

    void Start()
    {
        
        button = GetComponent<Button>();
    }

    void Update()
    {
        if (button != null)
        {
            button.onClick.AddListener(PlaySound);
        }
    }

    void PlaySound()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }
}
