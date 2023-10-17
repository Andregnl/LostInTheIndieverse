using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasics : Entity
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float damageInterval;
    [SerializeField] Transform visionObject;
    [SerializeField] float detectionDistance = 20.0f;
    [SerializeField] LayerMask playerAndGroundLayer;
    [SerializeField] int hp = 100;
    private GameObject currentTarget;
    
    public virtual void Walk() {
		if (thisDirection == Direction.LEFT)
			transform.Translate(new Vector2(1, 0) * speed * Time.deltaTime);
		else
			transform.Translate(new Vector2(-1, 0) * speed * Time.deltaTime);
    }

    public void SetMovementSpeed (float newspeed)
    {
        speed = newspeed;
    }

    public virtual bool DetectTarget(){
        RaycastHit2D hit = Physics2D.Raycast(transform.position,
                                             Vector3.Normalize(visionObject.transform.position - transform.position),
                                             detectionDistance,
                                             playerAndGroundLayer);
        Debug.DrawRay(transform.position, Vector3.Normalize(visionObject.transform.position - transform.position) * detectionDistance, Color.green);

        if (hit.collider != null)
        {
            //Debug.Log(hit.collider.gameObject);
            if (hit.collider.CompareTag("Tower"))
            {
                            //Debug.Log("Tower");

                return true;
            }
        }

        return false;
    }

    public void SetTarget(GameObject target)
    {
        if (DetectTarget())
        currentTarget = target;
    }

    public virtual void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) { return; }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.TakeDamage(damage);
        }
    }

}
