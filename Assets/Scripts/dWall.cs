using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dWall : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 3;
    public GameObject wall;
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0){
           Destroy(wall);
        }
        
    }

    public void OnTriggerEnter(Collider other)
    {
      /*      if(other.tag == bullet)
            {
                health -= 25;
            }*/
    }

    public void WallHit()
    {
        health--;
    }
    private void dissapear()
    {

    }
}
