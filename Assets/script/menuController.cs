using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour
{

   public void Choimoi()
   {
        SceneManager.LoadScene(1);
   }
   public void about()
   { 
     SceneManager.LoadScene(2);

   }
   public void Thoat()
   {
        Application.Quit();
   }
}
