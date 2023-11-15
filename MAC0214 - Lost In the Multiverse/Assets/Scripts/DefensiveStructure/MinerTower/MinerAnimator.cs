using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerAnimator : MonoBehaviour
{
	[SerializeField] MinerTower defensiveStructure;

	public void Animate()
	{
		defensiveStructure.Mine();
	}
}
