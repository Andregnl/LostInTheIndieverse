using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {LEFT, RIGHT}

public class DefensiveStructure : MonoBehaviour
{
	[SerializeField] GameObject flippableObjects;
	[SerializeField] protected GameObject projectile;
	[SerializeField] protected float attackDelay = 2.0f;
	[SerializeField] protected int damage = 10;

	protected float currentTime = 0.0f;
	protected Direction thisDirection;
	protected int row = -1;

    // Update is called once per frame
    void Update()
    {
        ExecuteDefensiveBehavior();
    }

	public void SetDirection(Direction direction)
	{
		thisDirection = direction;

        Quaternion newRot = new Quaternion();

		if (thisDirection == Direction.LEFT)
			newRot.y = -180.0f;
		else
			newRot.y = 0.0f;

        flippableObjects.transform.rotation = newRot;
	}

	public void SetRow(int row)
	{
		this.row = row;
	}

    public virtual void ExecuteDefensiveBehavior()
    {

    }
}
