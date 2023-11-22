using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : EnemyBasics
{
	float currentTime = 0.0f;
    [SerializeField] float invisibilityTime = 0.0f;
    float currentInvTime = 0.0f;
    [SerializeField] float invDist = 20.0f;

    void Update(){
        Walk();
        DetectTarget();

        InvisibilityDetection();
        currentInvTime += Time.deltaTime;


		if (currentTarget == null) return;

		currentTime += Time.deltaTime;


		if (currentTime > damageInterval)
		{
			// StrikeCurrentTarget();
			animator.SetTrigger("Attack");
			currentTime = 0.0f;
            currentInvTime = 0.0f;
		}

    }

    void ResetInvTime()
    {
        animator.ResetTrigger("Invisible");
        currentInvTime = 0.0f;
    }

    public void InvisibilityDetection(){
        if (currentInvTime < invisibilityTime) return;

        RaycastHit2D hit = Physics2D.Raycast(transform.position,
                                             Vector3.Normalize(visionObject.transform.position - transform.position),
                                             invDist,
                                             playerAndGroundLayer);
        Debug.DrawRay(transform.position, Vector3.Normalize(visionObject.transform.position - transform.position) * invDist, Color.red);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Tower"))
            {
                            //Debug.Log("Tower");
                if(currentInvTime > invisibilityTime)
                    animator.SetTrigger("Invisible");
            }
        }

    }
}
