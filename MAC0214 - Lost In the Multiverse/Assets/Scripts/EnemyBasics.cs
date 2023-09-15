using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasics : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    [SerializeField] private float damage;
    [SerializeField] private float damageInterval;

    public virtual void Walk(){}

    public virtual void Attack(){}

    public float GetCurrentHealth(){
        return health;
    }

    public virtual void Heal(float healing){
        float newHealth = health + healing;
        if(newHealth > maxHealth) health = maxHealth;
        else health += healing;
    }

    public virtual void TakeDamage(float damage){
        float newHealth = health - damage;
        if(newHealth <= 0) Die();
        else health -= damage;
    }

    public virtual void Die(){
        Object.Destroy(gameObject);
    }
}
