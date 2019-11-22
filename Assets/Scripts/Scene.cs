using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
   //took out start and update since it was obsolete to scene class - Britney 11/21/1
   
   public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

   public void Reset()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }

   public void Quit()
    {
        Application.Quit();
    }
}
