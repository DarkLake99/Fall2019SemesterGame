using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public GameObject pauseMenu;

    int health;
    GameObject player;
   

    // Start is called before the first frame update
    void Start()
    {
        PauseOff();

        player = GameObject.FindGameObjectWithTag("Player");
        health = player.GetComponent<Player>().health;
    }

    // Update is called once per frame
    void Update()
    {
        health = player.GetComponent<Player>().health;

        if (Input.GetKeyDown(KeyCode.Escape) && health > 1)
        {
            if(Time.timeScale==1)
            {
                PauseON();
            }
            else if(Time.timeScale == 0)
            {
                PauseOff();
            }
        }
    }
    
    public void PauseON()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PauseOff()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
