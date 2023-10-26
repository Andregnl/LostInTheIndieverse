using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasics : Entity
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] protected float damageInterval;
    [SerializeField] Transform visionObject;
    [SerializeField] float detectionDistance = 20.0f;
    [SerializeField] LayerMask playerAndGroundLayer;
    [SerializeField] int hp = 100;
    [SerializeField] protected Animator animator;
    protected GameObject currentTarget;
    
    public virtual void Walk() {
        if (currentTarget != null) { Debug.Log("DEI RETURN"); return; }

		if (thisDirection == Direction.LEFT)
			transform.Translate(new Vector2(1, 0) * speed * Time.deltaTime);
		else
			transform.Translate(new Vector2(-1, 0) * speed * Time.deltaTime);
    }

    public void SetMovementSpeed (float newspeed)
    {
        speed = newspeed;
    }

    public virtual void DetectTarget(){
        RaycastHit2D hit = Physics2D.Raycast(transform.position,
                                             Vector3.Normalize(visionObject.transform.position - transform.position),
                                             detectionDistance,
                                             playerAndGroundLayer);
        Debug.DrawRay(transform.position, Vector3.Normalize(visionObject.transform.position - transform.position) * detectionDistance, Color.green);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Tower"))
            {
                            //Debug.Log("Tower");
                currentTarget = hit.collider.gameObject;
                return;
            }
        }

        currentTarget = null;
    }

    // public void SetTarget(GameObject target)
    // {
    //     if (DetectTarget())
    //     currentTarget = target;
    // }

    public virtual void StrikeCurrentTarget()
    {
        if (!currentTarget) { return; }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.TakeDamage(damage);
        }
    }

}
