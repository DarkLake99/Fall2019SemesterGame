using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 8;
    public Vector2 jumpHeight;
    public float health = 3;

    bool isOnGround;
    bool inHitStun = false;
    Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!inHitStun)
        {
            //walking
            float horizon = Input.GetAxis("Horizontal");
            if (horizon != 0)
            {
                rb.velocity = new Vector2(speed * horizon, rb.velocity.y);
            }

            //jumping
            if ((Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.W))&& isOnGround)
            {
                rb.AddForce(jumpHeight, ForceMode2D.Impulse);
            }
        }
        isOnGround = false;
    }

    //check if player is on the ground
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Surface"))
        {
            isOnGround = true;
            rb.velocity = Vector2.zero;

            inHitStun = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("KillBox"))
        {
            health = 0f;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health--;
            if (rb.transform.position.x > collision.transform.position.x)
            {
                Knockback(500, 1);
            }
            else if (rb.transform.position.x <= collision.transform.position.x)
            {
                Knockback(500, -1);
            }
        }

        
    }
    
    

    private void Knockback(float knockPwr, int knockDir)
    {
        //rb.AddForce(new Vector2(knockDir.x * 600*Time.deltaTime, knockPwr*0.5f));
        //reset player speed
        rb.velocity = new Vector2(0, 0);
        //y knockback
        rb.AddForce(transform.up * knockPwr);
        //x knockback
        rb.AddForce(transform.right * knockPwr * 25f * knockDir * Time.deltaTime);

        inHitStun = true;
    }
}