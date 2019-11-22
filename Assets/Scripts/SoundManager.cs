using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] audioHell;

    public static SoundManager bigBoi;
    // Start is called before the first frame update
    void Start()
    {
        bigBoi = this;
    }

    public void PlaySound(int soundIndex)
    {
        AudioSource mus = GetComponent<AudioSource>();
        mus.clip = audioHell[soundIndex];
        mus.Play();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
