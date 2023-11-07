using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : EnemyBasics
{
	float currentTime = 0.0f;

    void Update(){
        Walk();
        DetectTarget();

		if (currentTarget == null) return;

		currentTime += Time.deltaTime;
		if (currentTime > damageInterval)
		{
			// StrikeCurrentTarget();
			animator.SetTrigger("Attack");
			currentTime = 0.0f;
		}
    }

	void OnTriggerEnter2D(Collider2D col)
	{
		if (!col.CompareTag("Base")) return;

		EnemyBasics thatEnemy = col.GetComponent<EnemyBasics>();
		if (thatEnemy == null)
		{
			Debug.LogError("Base does not have base Script!");
			return;
		}

		if (thatEnemy.GetRow() != row) return;
		Debug.Log("Projectile hit something" + col.gameObject.name + " " + col.gameObject.tag);
		

		collidedEnemies.Enqueue(thatEnemy);
	}
}
