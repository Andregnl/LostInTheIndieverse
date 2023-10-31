using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : EnemyBasics
{
	float currentTime = 0.0f;

	[SerializeField] bool useTimeoutLife = false;
	float timeoutLife = 0.0f;
	float maxTimeoutLife = 3.0f;

    void Update() {

		// Codigo de Debug para inimigo
		if (useTimeoutLife)
		{
			timeoutLife += Time.deltaTime;
			if (timeoutLife >= maxTimeoutLife)
			{
				Destroy(gameObject);
			}
		}

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
}
