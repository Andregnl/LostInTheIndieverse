using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDSAnimationEvents : MonoBehaviour
{
	[SerializeField] TestDefensiveStructure defensiveStructure;

	public void SpawnProjectile()
	{
		defensiveStructure.SpawnProjectile();
	}
}
