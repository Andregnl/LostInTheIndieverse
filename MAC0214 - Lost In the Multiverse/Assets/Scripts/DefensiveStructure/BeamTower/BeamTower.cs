using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamTower : DefensiveStructure
{
	[SerializeField] Animator animator;
	[SerializeField] Transform spawnPoint;
    [SerializeField] LineRenderer beamRay;
    [SerializeField] float distance;
    private BeamRay projectileScript;

	public override void ExecuteDefensiveBehavior()
    {
		if (!DetectEnemiesInRow()) return;

		currentTime += Time.deltaTime;

		if (currentTime >= attackDelay)
		{
			currentTime = 0.0f;
			animator.SetTrigger("attack");
		}
	}

	public void SpawnProjectile()
	{
		GameObject proj = Instantiate(projectile,
									  spawnPoint.position,
									  Quaternion.identity,
									  gameObject.transform);

		projectileScript = proj.GetComponent<BeamRay>();

		if (thisDirection == Direction.LEFT)
			projectileScript.SetParameters(damage, Direction.LEFT, row, distance);
		else
			projectileScript.SetParameters(damage, Direction.RIGHT, row, distance);

	}

    public void DeSpawnProjectile()
    {
        projectileScript.ExpireVisualSequence();
    }
}
