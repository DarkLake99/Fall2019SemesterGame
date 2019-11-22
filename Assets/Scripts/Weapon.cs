using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float fireRate = 0;
    public float Damage = 1;
    public LayerMask notToHit;
    float timeToFire = 0;
    Transform firePoint;

    public AudioSource gunfire;
    public AudioSource woodBreak;
    
    //public GameObject collides;
    private bool hits = false;
    private float objectHealth = 0f;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        firePoint = transform.Find("firePoint");
        if(firePoint == null)
        {
            Debug.LogError("No firePoint. WHAT");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fireRate == 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
                gunfire.Play();
                Shoot();
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Mouse0)&& Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                gunfire.Play();
                Shoot();
            }
        }
    }

    /*private void OnTriggerEnter2D(Collider2D other) redundant code
    {
        if (other.gameObject.tag=="Destructable")
        {
            hits = true;
            objectHealth = 1;
        }
        if (other.gameObject.tag == "Enemy")
        {
            hits = true;
            objectHealth = 2;

        }
        
    }*/

    void Shoot()
    {
       
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, notToHit);
        Debug.DrawLine(firePointPosition , (mousePosition - firePointPosition)*100,Color.white);
        
       
        if (hit.collider!=null)
        {
            EnemyControl enemy = hit.transform.GetComponent<EnemyControl>();
            dWall weakWall = hit.transform.GetComponent<dWall>();
            
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
            Debug.Log("We hit " + hit.collider.name + " and did " + Damage + " damage.");
            if (hit.collider.tag=="Destructable")
            {
                woodBreak.Play();
                weakWall.WallHit();
            }
            else if (hit.collider.tag=="Enemy")
            {
                enemy.EnemyHit();
            }
            
        };
    }
}
