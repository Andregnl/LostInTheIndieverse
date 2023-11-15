using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {LEFT, RIGHT}

public class DefensiveStructure : Entity
{
	[SerializeField] protected GameObject projectile;
	[SerializeField] protected float attackDelay = 2.0f;
	[SerializeField] protected int damage = 10;
    [SerializeField] AudioSource audioSource;
	[SerializeField] float detectionDistance = 0.0f;
	[SerializeField] LayerMask enemyLayer;
	[SerializeField] GameObject visionObject;
	[SerializeField] GameObject visionVectorOrigin;

	protected float currentTime = 0.0f;

    void Awake(){
        Debug.Log("Criei um Script Structure");
    }
    // Update is called once per frame
    void Update()
    {
        ExecuteDefensiveBehavior();
    }

    public void PlayShootSound()
    {
        if (audioSource == null) return;

        audioSource.Play();
    }

	public bool DetectEnemiesInRow()
	{
		RaycastHit2D hit = Physics2D.Raycast(visionVectorOrigin.transform.position,
                                             Vector3.Normalize(visionObject.transform.position -
															   visionVectorOrigin.transform.position),
                                             detectionDistance,
                                             enemyLayer);
        Debug.DrawRay(visionVectorOrigin.transform.position,
					  Vector3.Normalize(visionObject.transform.position -
										visionVectorOrigin.transform.position) *
					  detectionDistance,
					  Color.green);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                return true;
            }
        }

		return false;
	}

    public virtual void ExecuteDefensiveBehavior()
    {

    }
}
