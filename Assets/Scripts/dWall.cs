using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dWall : MonoBehaviour
{
    // Start is called before the first frame update
    private int health = 100;
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {/*
        if (health == 0){
            dWall.dissapear();
        }
        */
    }

    public void OnTriggerEnter(Collider other)
    {
      /*      if(other.tag == bullet)
            {
                health -= 25;
            }*/
    }

    private void dissapear()
    {

    }
}
