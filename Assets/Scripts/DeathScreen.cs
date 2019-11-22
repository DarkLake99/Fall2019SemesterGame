using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    float health;
    GameObject player;

    public GameObject deathScreen;

    // Start is called before the first frame update
    void Start()
    {
        deathScreen.SetActive(false);

        player = GameObject.FindGameObjectWithTag("Player");
        health = player.GetComponent<Player>().health;
    }

    // Update is called once per frame
    void Update()
    {
        health = player.GetComponent<Player>().health;
        if(health < 1)
        {
            deathScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
