using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveTower : DefensiveStructure
{
	[SerializeField] Animator animator;
	[SerializeField] Transform spawnPoint;

    public void Explode()
    {
		GameObject proj = Instantiate(projectile,
									  spawnPoint.position,
									  Quaternion.identity,
									  gameObject.transform);
		//Destroy(gameObject);
    }
}
