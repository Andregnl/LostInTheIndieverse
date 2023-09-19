using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDefensiveStructure : DefensiveStructure
{
	[SerializeField] Animator animator;
	[SerializeField] Transform spawnPoint;

    public override void ExecuteDefensiveBehavior()
    {
		currentTime += Time.deltaTime;

		if (currentTime >= attackDelay)
		{
			currentTime = 0.0f;
			animator.SetTrigger("Attack");
		}
	}

	public void SpawnProjectile()
	{
		Instantiate(projectile,
					spawnPoint.position,
					Quaternion.identity,
					gameObject.transform);

		Projectile projectileScript = projectile.GetComponent<Projectile>();

		if (thisDirection == Direction.LEFT)
			projectileScript.SetParameters(damage, Direction.LEFT);
		else
			projectileScript.SetParameters(damage, Direction.RIGHT);
	}
}
