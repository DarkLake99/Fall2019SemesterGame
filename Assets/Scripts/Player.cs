using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 8;
    public Vector2 jumpHeight;

    bool isOnGround;
    Rigidbody2D rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //walking
        float horizon = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * horizon, rb.velocity.y);

        //jumping
        if(Input.GetKey(KeyCode.UpArrow) && isOnGround)
        {
            rb.AddForce(jumpHeight, ForceMode2D.Impulse);
        }

        isOnGround = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Surface"))
        {
            isOnGround = true;
            rb.velocity = Vector2.zero;
        }
    }
}
