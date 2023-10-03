using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField] GameObject flippableObjects;
	[SerializeField] float speed;

	float currentDuration = 0.0f;
	float maxDuration = 10.0f;
	float damage;
	Direction diretion;

	void FixedUpdate()
	{
		ExecuteProjectileBehavior();
	}

	public virtual void ExecuteProjectileBehavior()
	{
		Vector3 toMove = new Vector3(speed * Time.fixedDeltaTime, 0.0f);
		gameObject.transform.position += toMove;

		currentDuration += Time.fixedDeltaTime;

		if (currentDuration >= maxDuration)
		{
			Destroy(gameObject);
		}
	}

	public virtual void SetParameters(float damage, Direction direction)
	{
		this.damage = damage;

		if (direction == Direction.LEFT)
		{
			speed *= -1;
			flippableObjects.transform.Rotate(new Vector3(0.0f, -180.0f, 0.0f));
			this.diretion = Direction.LEFT;
		}
		else
		{
			this.diretion = Direction.RIGHT;
		}
	}
}
