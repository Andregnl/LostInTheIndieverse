using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveTowerEvents : MonoBehaviour
{
	[SerializeField] ExplosiveTower defensiveStructure;

	public void Explode()
	{
		defensiveStructure.Explode();
	}

    public void Exclude()
    {
        defensiveStructure.ExpireVisual();
    }
}
