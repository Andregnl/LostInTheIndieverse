using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEvent : MonoBehaviour
{
	[SerializeField] ExplosionScript defensiveStructure;

	public void Explode()
	{
		defensiveStructure.ExpireVisualSequence();
	}
}
