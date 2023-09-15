using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasics : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float damageInterval;
    [SerializeField] private Vector2 direction;
    private GameObject currentTarget;
    public virtual void Walk(){
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void SetMovementSpeed (float newspeed)
    {
        speed = newspeed;
    }

    public void Attack(GameObject target)
    {
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) { return; }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.TakeDamage(damage);
        }
    }

}
