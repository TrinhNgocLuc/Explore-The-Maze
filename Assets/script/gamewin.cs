using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class gameWin : MonoBehaviour

{
    [SerializeField] private GameObject win;
    [SerializeField] private AudioSource audioSourceVictory;
    [SerializeField] private playerHeal playerHeal;

    public void Start(){
        win.SetActive(false);
    }
   private void OnCollisionEnter2D(Collision2D collision)
    {
        {
            if (collision.gameObject.CompareTag("exit"))
            {
                win.SetActive(true);
                audioSourceVictory.Play();
                playerHeal.audioSourceThemne.Stop();
            }
        }
    }
}
