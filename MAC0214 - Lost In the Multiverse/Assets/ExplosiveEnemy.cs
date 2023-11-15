using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveEnemy : EnemyBasics
{
	float currentTime = 0.0f;

    void Update(){
        Walk();
        DetectTarget();

		if (currentTarget == null) return;

		currentTime += Time.deltaTime;
		if (currentTime > damageInterval)
		{
			//StrikeCurrentTarget();
			animator.SetTrigger("Attack");
			currentTime = 0.0f;
		}
    }

    public void ExpireVisual()
    {
        Object.Destroy(gameObject);
    }
}
