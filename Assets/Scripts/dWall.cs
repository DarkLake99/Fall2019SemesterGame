using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dWall : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 3;
    public AudioSource woodBreak;
    public AudioSource brokenWood;
 

    // Update is called once per frame
    void Update()
    {
        if (health < 1){
           brokenWood.Play();
            Destroy(gameObject);
        }
        
    }
    
    public void WallHit()
    {
        woodBreak.Play();
        health--;
    }
   
}
