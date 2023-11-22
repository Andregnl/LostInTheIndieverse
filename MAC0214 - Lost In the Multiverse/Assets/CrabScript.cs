using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabScript : DefensiveStructure
{
	[SerializeField] Animator animator;
	[SerializeField] Transform spawnPoint;
    [SerializeField] ClawHitbox claw1;
    [SerializeField] ClawHitbox claw2;

    void Start()
    {
		claw1.SetParameters(damage, Direction.LEFT, row);
		claw2.SetParameters(damage, Direction.LEFT, row);    
   
    }
    public override void ExecuteDefensiveBehavior()
    {
		if (!DetectEnemiesInRow()) return;

		currentTime += Time.deltaTime;

		if (currentTime >= attackDelay)
		{
			currentTime = 0.0f;
			animator.SetTrigger("Attack");
		}
	}
}
