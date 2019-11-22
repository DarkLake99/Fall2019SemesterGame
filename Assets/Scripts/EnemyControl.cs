using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyControl : MonoBehaviour {

	public float moveSpeed = 4;
	public float maxDisRight;
	public float maxDisLeft;
	public float enemyHealth = 3;
	public GameObject enemy;

	float intPos;
	Rigidbody2D rb;
	int moveDir;


	void Start () {
		intPos = transform.position.x;

		rb = GetComponent<Rigidbody2D> ();

		moveDir = 1;
	}
	void Update () {
		if (rb.transform.position.x <= intPos - maxDisLeft)							//max left
			moveDir = 1;
		if (rb.transform.position.x >= intPos + maxDisRight)						//max right
			moveDir = -1;
		rb.velocity = new Vector2 (moveDir * moveSpeed, rb.velocity.y);
		if (enemyHealth < 1)
		{
			Destroy(enemy);
		}
	}

	public void EnemyHit()
	{
		enemyHealth--;
	}
	
}