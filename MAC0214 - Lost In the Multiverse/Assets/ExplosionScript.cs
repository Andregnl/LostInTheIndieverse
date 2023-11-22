using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
	[SerializeField] GameObject flippableObjects;
	[SerializeField] AudioClip collisionClip;

	private AudioSource audioSource;
	int damage;

	void Awake()
	{
		audioSource = GameObject.
			FindGameObjectWithTag("ProjectileAudioSource").
			GetComponent<AudioSource>();
				audioSource.PlayOneShot(collisionClip);

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

		Debug.Log("Projectile hit something" + col.gameObject.name + " " + col.gameObject.tag);
		

		thatEnemy.GetComponent<Health>().TakeDamage(999);
	}

	public virtual void ExpireVisualSequence()
	{
		Destroy(gameObject);
	}

    public void SetParameters(int _damage)
    {
        damage = _damage;
    }

}
