using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerTower : DefensiveStructure
{
	[SerializeField] Animator animator;
	[SerializeField] Transform spawnPoint;
    DragAndDropManager dragDrop;
    [SerializeField] private int currency;

	void Start(){
		dragDrop = FindObjectOfType<DragAndDropManager>();
	}
    public override void ExecuteDefensiveBehavior()
    {
		currentTime += Time.deltaTime;

		if (currentTime >= attackDelay)
		{
			currentTime = 0.0f;
			animator.SetTrigger("Attack");
		}
	}

	public void Mine()
	{
        dragDrop.UpdateCurrency(currency);
	}
}
