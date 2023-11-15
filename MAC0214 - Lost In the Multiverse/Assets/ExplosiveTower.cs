using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveTower : DefensiveStructure
{
	[SerializeField] Animator animator;
	[SerializeField] Transform spawnPoint;

    public void Explode()
    {
        animator.SetTrigger("attack");
		GameObject proj = Instantiate(projectile, spawnPoint.position, Quaternion.identity);
		proj.transform.SetParent(gameObject.transform.parent);
		//Destroy(gameObject);
    }

	public void ExpireVisual()
	{
		Destroy(gameObject);
	}
}
