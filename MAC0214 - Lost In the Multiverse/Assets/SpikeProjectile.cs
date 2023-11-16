using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeProjectile : MonoBehaviour
{
	[SerializeField] GameObject flippableObjects;
	[SerializeField] float speed;
	[SerializeField] AudioClip collisionClip;

	private AudioSource audioSource;

	int row = -1;
	float currentDuration = 0.0f;
	float maxDuration = 10.0f;
	int damage;
	Direction diretion;
	bool alreadyCollided = false;
	Queue<EnemyBasics> collidedEnemies = new Queue<EnemyBasics>();

	void Awake()
	{
		audioSource = GameObject.
			FindGameObjectWithTag("ProjectileAudioSource").
			GetComponent<AudioSource>();
	}

	void FixedUpdate()
	{
		ExecuteProjectileBehavior();

		if (collidedEnemies.Count > 0)
		{
			EnemyBasics thatEnemy = collidedEnemies.Dequeue();
			thatEnemy.GetComponent<Health>().TakeDamage(damage);
			audioSource.PlayOneShot(collisionClip);
			ExpireVisualSequence();
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (!col.CompareTag("Enemy")) return;

		EnemyBasics thatEnemy = col.GetComponent<EnemyBasics>();
		if (thatEnemy == null)
		{
			Debug.LogError("Enemy does not have Enemy Script!");
			return;
		}

		if (thatEnemy.GetRow() != row) return;
		Debug.Log("Projectile hit something" + col.gameObject.name + " " + col.gameObject.tag);
		

		collidedEnemies.Enqueue(thatEnemy);
	}

	public virtual void ExpireVisualSequence()
	{
		Destroy(gameObject);
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

	public virtual void SetParameters(int damage, Direction direction, int row)
	{
		this.damage = damage;
		this.row = row;

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
