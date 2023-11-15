using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDefensiveStructure : DefensiveStructure
{
	[SerializeField] Animator animator;
	[SerializeField] Transform spawnPoint;

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

	public void SpawnProjectile()
	{
		GameObject proj = Instantiate(projectile,
									  spawnPoint.position,
									  Quaternion.identity,
									  gameObject.transform);

		Projectile projectileScript = proj.GetComponent<Projectile>();

		if (thisDirection == Direction.LEFT)
			projectileScript.SetParameters(damage, Direction.LEFT, row);
		else
			projectileScript.SetParameters(damage, Direction.RIGHT, row);
	}
}
