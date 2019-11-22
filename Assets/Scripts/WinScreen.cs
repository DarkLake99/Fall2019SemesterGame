using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    public GameObject winScreen;
    // Start is called before the first frame update
    void Start()
    {
        winScreen.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            winScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
