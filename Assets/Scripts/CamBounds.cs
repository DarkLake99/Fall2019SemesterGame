using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Timers;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class CamBounds : MonoBehaviour
{
    private Vector2 velocity;
    public bool bounds;
    public GameObject player;
    public float smoothTimeX;
    public float smoothTimeY;
    public float speedUp;
    
    public Vector3 minCamPos;
    public Vector3 maxCamPos;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        /*minCamPos =new Vector3(0,0);
        maxCamPos = new Vector3(100,0);*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);
        
        transform.position = new Vector3(posX, posY, transform.position.z);
        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x,minCamPos.x+Time.timeSinceLevelLoad*speedUp, maxCamPos.x),
                    Mathf.Clamp(transform.position.y, minCamPos.y,maxCamPos.y),
                    Mathf.Clamp(transform.position.z,minCamPos.z,maxCamPos.z));
            
        }

        /*if (player.GetComponent<Player>().health==0)
        {
            
            transform.position = new Vector3(Mathf.Clamp(transform.position.x,minCamPos.x, maxCamPos.x),
                Mathf.Clamp(transform.position.y, minCamPos.y,maxCamPos.y),
                Mathf.Clamp(transform.position.z,minCamPos.z,maxCamPos.z));
            
        }*/
    }
    
}
