using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasics : Entity
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] protected float damageInterval;
    [SerializeField] protected Transform visionObject;
    [SerializeField] float detectionDistance = 20.0f;
    [SerializeField] protected LayerMask playerAndGroundLayer;
    [SerializeField] protected Animator animator;
	[SerializeField] AudioSource audioSource;
    private bool hitBase = false;
    private bool isKnockback = false;
    protected GameObject currentTarget;
    
    public virtual void Walk() {
        if (currentTarget != null) { return; }

        if(!isKnockback)
        {
            if (thisDirection == Direction.LEFT)
                transform.Translate(new Vector2(1, 0) * speed * Time.deltaTime);
            else
                transform.Translate(new Vector2(-1, 0) * speed * Time.deltaTime);
        }
    }

    public virtual void ApplyKnockback(Direction dir)
    {
        StartCoroutine(Knockback(dir));
    }
    IEnumerator Knockback(Direction dir)
    {
        isKnockback = true;
        if(dir == Direction.LEFT && thisDirection == Direction.LEFT)
            transform.Translate(new Vector2(-1,0) * 30 * 0.1f);
        else if(dir == Direction.RIGHT && thisDirection == Direction.LEFT)
            transform.Translate(new Vector2(1,0) * 30 * 0.1f);
        else if(dir == Direction.LEFT && thisDirection == Direction.RIGHT)
            transform.Translate(new Vector2(1,0) * 30 * 0.1f);
        else if(dir == Direction.RIGHT && thisDirection == Direction.RIGHT)
            transform.Translate(new Vector2(-1,0) * 30 * 0.1f);
        // Wait for a short duration to simulate the knockback effect
        yield return new WaitForSeconds(0.2f);

        isKnockback = false;   
    }

    public void SetMovementSpeed (float newspeed)
    {
        speed = newspeed;
    }

    public void SetDamageInterval(float inteval)
    {
        damageInterval = inteval;
    }
    public void SetDamage(float dg)
    {
        damage = dg;
    }
    public virtual void DetectTarget(){
        RaycastHit2D hit = Physics2D.Raycast(transform.position,
                                             Vector3.Normalize(visionObject.transform.position - transform.position),
                                             detectionDistance,
                                             playerAndGroundLayer);
        //Debug.DrawRay(transform.position, Vector3.Normalize(visionObject.transform.position - transform.position) * detectionDistance, Color.green);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Tower") || hit.collider.CompareTag("Base"))
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
            if (currentTarget.CompareTag("Base")) hitBase = true;
        }
    }

    public virtual void IsBase()
    {
        if(hitBase){
            Debug.Log("Base");
            Object.Destroy(gameObject);
        }
    }
	public void PlayAttackSound()
	{
		audioSource.Play();
	}
}
