using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {LEFT, RIGHT}

public class DefensiveStructure : Entity
{
	[SerializeField] protected GameObject projectile;
	[SerializeField] protected float attackDelay = 2.0f;
	[SerializeField] protected int damage = 10;

	protected float currentTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        ExecuteDefensiveBehavior();
    }

    public virtual void ExecuteDefensiveBehavior()
    {

    }
}
