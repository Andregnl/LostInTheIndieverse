using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemScript : DefensiveStructure
{
    [SerializeField] GameObject root;
	[SerializeField] Animator animator;
	[SerializeField] Transform spawnPoint;
    [SerializeField] private bool invertShootdir;
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
        Debug.Log("Linha:" + row + " dano" + damage + "Direction" + Direction.RIGHT);
		GameObject proj = Instantiate(projectile,
									  spawnPoint.position,
									  Quaternion.identity);

		SpikeProjectile projectileScript = proj.GetComponent<SpikeProjectile>();

        if (!invertShootdir)
        {
            if (thisDirection == Direction.LEFT)
                projectileScript.SetParameters(damage, Direction.LEFT, row);
            else
                projectileScript.SetParameters(damage, Direction.RIGHT, row);
        }
        else
        {
            if (thisDirection == Direction.LEFT)
                projectileScript.SetParameters(damage, Direction.RIGHT, row);
            else
                projectileScript.SetParameters(damage, Direction.LEFT, row);
        }
	}

    public void Die(int destroyFather){
        if (destroyFather == 1){
            Object.Destroy(root);
        }
        Object.Destroy(gameObject);

    }

}
