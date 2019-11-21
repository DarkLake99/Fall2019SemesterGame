using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
   //took out start and update since it was obsolete to scene class - Britney 11/21/19

    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
