using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pauseCotroller : MonoBehaviour
{
    public GameObject pausePanel;

    private bool isPaused = false;

    void Start(){
        pausePanel.SetActive(isPaused);
    }
    public void pause()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isPaused = !isPaused;
            if(isPaused == true){
                Time.timeScale= 0;
            pausePanel.SetActive(isPaused);
            }else {
                Time.timeScale = 1;
                pausePanel.SetActive(isPaused);
            }
        }
    }
}
