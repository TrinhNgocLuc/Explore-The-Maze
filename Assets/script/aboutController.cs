using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class aboutController : MonoBehaviour
{
   
   public GameObject pause;

   public void controls()
   {
        SceneManager.LoadScene(3);

   }
   public void Setting()
   {
        SceneManager.LoadScene(4);


   }
   public void back()
   {
     Time.timeScale = 1;
     SceneManager.LoadScene("menu");

   }
   public void Restart()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
     public void Choimoi()
   {
        SceneManager.LoadScene("SampleScene");
   }
   public void about()
   { 
     SceneManager.LoadScene("about");

   }
   public void Thoat()
   {
        Application.Quit();
   }
}
