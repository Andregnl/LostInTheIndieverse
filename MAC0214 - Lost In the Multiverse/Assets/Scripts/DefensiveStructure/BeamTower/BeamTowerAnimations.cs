using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamTowerAnimations : MonoBehaviour
{
	[SerializeField] BeamTower defensiveStructure;

	public void SpawnProjectile()
	{
		defensiveStructure.SpawnProjectile();
	}

	public void PlayShootSound()
	{
		defensiveStructure.PlayShootSound();
	}

    public void DeSpawnProjectile()
    {
		defensiveStructure.DeSpawnProjectile();
    }
}
