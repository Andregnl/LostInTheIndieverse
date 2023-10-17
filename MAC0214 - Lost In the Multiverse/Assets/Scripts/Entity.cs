using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
	[SerializeField] protected GameObject flippableObjects;
	protected Direction thisDirection;
	protected int row = -1;

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

	public int GetRow()
    {
        return row;
    }
}
