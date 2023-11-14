using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamRay : MonoBehaviour
{
	[SerializeField] AudioClip collisionClip;

	private AudioSource audioSource;

	int row = -1;
	float currentDuration = 0.0f;
	[SerializeField] float damageInterval;
	[SerializeField] float maxDuration = 10.0f;
	int damage;
	Direction diretion;
    [SerializeField] LineRenderer beamRay;
    [SerializeField] BoxCollider2D collision;
	void Awake()
	{
		audioSource = GameObject.
			FindGameObjectWithTag("ProjectileAudioSource").
			GetComponent<AudioSource>();
	}

	void FixedUpdate()
	{
		ExecuteProjectileBehavior();

	}

	private float currentTime = 100.0f;
	void OnTriggerStay2D(Collider2D col)
	{
		if (!col.CompareTag("Enemy")) return;

		currentTime += Time.deltaTime;

		EnemyBasics thatEnemy = col.GetComponent<EnemyBasics>();
		if (thatEnemy == null)
		{
			Debug.LogError("Enemy does not have Enemy Script!");
			return;
		}

		if (thatEnemy.GetRow() != row) return;
		Debug.Log("Projectile hit something" + col.gameObject.name + " " + col.gameObject.tag);
		
		if(currentTime >= damageInterval)
		{
        	thatEnemy.GetComponent<Health>().TakeDamage(damage);
        	audioSource.PlayOneShot(collisionClip);
			currentTime = 0.0f;
		}
	}

	public virtual void ExpireVisualSequence()
	{
		Destroy(gameObject);
	}

	public virtual void ExecuteProjectileBehavior()
	{

		currentDuration += Time.fixedDeltaTime;

		if (currentDuration >= maxDuration)
		{
			ExpireVisualSequence();
		}
	}

	public virtual void SetParameters(int damage, Direction direction, int row, float distance)
	{
		this.damage = damage;
		this.row = row;

		if (direction == Direction.LEFT)
		{
			this.diretion = Direction.LEFT;
            beamRay.SetPosition(0, transform.position);
            beamRay.SetPosition(1, transform.position - new Vector3(distance, 0.0f));
            collision.offset = new Vector2(-distance/2f, 0); 
		}
		else
		{
			this.diretion = Direction.RIGHT;
            beamRay.SetPosition(0, transform.position);
            beamRay.SetPosition(1, transform.position + new Vector3(distance, 0.0f));             
		    collision.offset = new Vector2(distance/2f, 0); 
        }

        collision.size = new Vector3(distance, 2.0f, 0.0f);
        

	}
}
