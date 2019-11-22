using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyControl : MonoBehaviour {

	public float moveSpeed = 4;
	public float maxDisRight;
	public float maxDisLeft;
	public float enemyHealth = 3;

	float intPos;
	Rigidbody2D rb;
	int moveDir;


	void Start () {
		intPos = transform.position.x;

		rb = GetComponent<Rigidbody2D> ();

		moveDir = 1;
	}

	/*private void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.CompareTag("KillBox"))
		{
			Destroy(gameObject);
		}
		
	}*/

	void Update () {
		if (rb.transform.position.x <= intPos - maxDisLeft)							//max left
			moveDir = 1;
		if (rb.transform.position.x >= intPos + maxDisRight)						//max right
			moveDir = -1;
		rb.velocity = new Vector2 (moveDir * moveSpeed, rb.velocity.y);
		if (enemyHealth < 1)
		{
			Destroy(gameObject);
		}
	}

	public void EnemyHit()
	{
		enemyHealth--;
	}
	
}