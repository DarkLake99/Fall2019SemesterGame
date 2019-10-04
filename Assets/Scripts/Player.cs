using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 2;
    public float jump = 3;
    public Rigidbody2D rb;
    public BoxCollider2D checkGround;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizon = Input.GetAxis("Horizontal");
        float variableName = horizon * playerSpeed * Time.deltaTime;
        float jumping = 0;
        if (Input.GetKey("up") || OnTriggerStay(checkGround)) {
            jumping = jump * Time.deltaTime;
        }
        
        transform.position = transform.position + new Vector3(variableName, jumping , 0);

        //Vector2 movement = new Vector2(horizon, 0);

        //rb.AddForce(playerSpeed * movement);
    }

    bool OnTriggerStay(Collider2D collider)
    {
        if(collider.gameObject.tag == "Surface")
        {
            return true;
        }
        return false;
    }
}
