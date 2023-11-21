using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawHitbox : MonoBehaviour
{
	[SerializeField] GameObject flippableObjects;
	[SerializeField] float speed;
	[SerializeField] AudioClip collisionClip;
    [SerializeField] protected Material _flash;
    [SerializeField] protected SpriteRenderer sp;
    private Material originalMaterial;
	private AudioSource audioSource;

	int row = -1;
	int damage;

	void Awake()
	{
		audioSource = GameObject.
			FindGameObjectWithTag("ProjectileAudioSource").
			GetComponent<AudioSource>();
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
		
        thatEnemy.GetComponent<Health>().TakeDamage(damage);
		thatEnemy.GetComponent<EnemyBasics>().ApplyKnockback(Direction.LEFT);
	}


	public virtual void SetParameters(int damage, Direction direction, int row)
	{
		this.damage = damage;
		this.row = row;

		/*if (direction == Direction.LEFT)
		{
			speed *= -1;
			flippableObjects.transform.Rotate(new Vector3(0.0f, -180.0f, 0.0f));
			this.diretion = Direction.LEFT;
		}
		else
		{
			this.diretion = Direction.RIGHT;
		}*/
	}
	
}
